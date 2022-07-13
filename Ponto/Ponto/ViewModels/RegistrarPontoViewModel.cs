using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Ponto.ViewModels
{
    public class RegistrarPontoViewModel : BaseViewModel
    {
        #region ->Propriedades<-
        public INavigation Navigation;
        private PontoRepository _pontoRepository;
        private RelatorioRepository _relatorioRepository;
        public Xamarin.Forms.Maps.Map mapa;

        public Location location { get; set; }
        public User usuario;

        private DateTime HoraAtual;

        private string _hrAtual;
        private TimeSpan? HrJornadaTotal = new TimeSpan(0, 0, 0);
        private TimeSpan Saldo = new TimeSpan(0, 0, 0);

        public string HrAtual { get { return _hrAtual; } set { _hrAtual = value; OnPropertyChanged("HrAtual"); } }

        #endregion

        #region ->Commands<-
        private Command _RegistrarPontoCommand;
        public Command RegistrarPonto => _RegistrarPontoCommand ?? (_RegistrarPontoCommand = new Command(async () => await Registrar()));

        private Command _BackCommand;
        public Command BackCommand => _BackCommand ?? (_BackCommand = new Command(async () => await Voltar()));



        #endregion

        #region ->Métodos<-
        private async Task Voltar()
        {
            await Navigation.PopAsync();
        }
        private async Task Registrar()
        {
            try
            {
                HoraAtual = DateTime.Now;

                var lastPonto = _pontoRepository.GetLastPonto(usuario.Id);
                var relatorioAtual = _relatorioRepository.GetRelatorioAtual();

                if (relatorioAtual == null)
                {
                    _relatorioRepository.InserirIdUsuario(usuario.Id);
                    relatorioAtual = _relatorioRepository.GetRelatorioAtual();
                }


                //Validação se ponto de entrada ou saida
                if (lastPonto == null)
                {
                    _pontoRepository.InsertPontoHrInicial(HoraAtual, usuario.Id, relatorioAtual.Id);

                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário inicial registrado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    _pontoRepository.InsertPontoHrFinal(HoraAtual, lastPonto); //Inserindo o horario final

                    //Parte do relatório
                    var pontosDoDia = _pontoRepository.GetPontosDoDia(usuario.Id, DateTime.Now.Date);
                    //Atualizando HrJornada
                    foreach (var item in pontosDoDia)
                    {
                        HrJornadaTotal += item.HrJornada;
                    }
                    _relatorioRepository.AtualizaHrJornada(HrJornadaTotal, relatorioAtual.Id);

                    //Atualizando Saldo
                    if (usuario.IsEstagiario == true)
                    {
                        TimeSpan HrEstagio = new TimeSpan(6, 0, 0);
                        Saldo = HrEstagio.Subtract(HrJornadaTotal.Value);
                    }
                    else
                    {
                        TimeSpan HrEfetivado = new TimeSpan(8, 0, 0);
                        Saldo = HrEfetivado.Subtract(HrJornadaTotal.Value);
                    }
                    // Esse saldo pode estar sendo salvo invertido pode ser melhorado
                    if (Saldo.Hours > 0)
                    {
                        _relatorioRepository.AtualizaSaldo(Saldo, relatorioAtual.Id, false);
                    }
                    else
                    {
                        _relatorioRepository.AtualizaSaldo(Saldo, relatorioAtual.Id, true);
                    }

                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário final registrado", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }

        }
        public async Task CarregaDados()
        {
            location = await Geolocation.GetLastKnownLocationAsync();            
        }
        #endregion

        public RegistrarPontoViewModel()
        {
            _pontoRepository = new PontoRepository();
            _relatorioRepository = new RelatorioRepository();
            HrAtual = DateTime.Now.ToShortTimeString();
            CarregaDados();
        }
    }
}
