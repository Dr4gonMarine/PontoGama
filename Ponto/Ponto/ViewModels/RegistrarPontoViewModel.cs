using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class RegistrarPontoViewModel : BaseViewModel
    {
        #region ->Propriedades<-
        public INavigation Navigation;
        private PontoRepository _pontoRepository;
        private RelatorioRepository _relatorioRepository;

        public User usuario;

        private DateTime HoraAtual;

        private string _hrAtual;
        private TimeSpan? HrJornadaTotal;

        public string HrAtual { get { return _hrAtual; } set { _hrAtual = value; OnPropertyChanged("HrAtual"); } }       

        //private TimeSpan Saldo;

        #endregion

        #region ->Commands<-
        private Command _RegistrarPontoCommand;
        public Command RegistrarPonto => _RegistrarPontoCommand ?? (_RegistrarPontoCommand = new Command(async () => await Registrar()));


        #endregion

        #region ->Métodos<-
        private async Task Registrar()
        {
            try
            {
                HoraAtual = DateTime.Now;

                var lastPonto = _pontoRepository.GetLastPonto(usuario.Id);
                var relatorioAtual = _relatorioRepository.GetRelatorioAtual();

                if(relatorioAtual == null)
                {
                    _relatorioRepository.InserirIdUsuario(usuario.Id);
                }


                //Validação se ponto de entrada ou saida
                if (lastPonto == null)
                {
                    _pontoRepository.InsertPontoHrInicial(HoraAtual, usuario.Id, relatorioAtual.Id); // crashou aqui na primeira vez que registra o ponto
                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário inicial registrado", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    _pontoRepository.InsertPontoHrFinal(HoraAtual, lastPonto);
                    var pontosDoDia = _pontoRepository.GetPontosDoDia(usuario.Id, DateTime.Now.Date);
                    foreach (var item in pontosDoDia)
                    {
                        HrJornadaTotal =+ item.HrJornada;
                    }
                    _relatorioRepository.AtualizaHrJornada(HrJornadaTotal, relatorioAtual.Id);
                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário final registrado", "OK");
                    await Navigation.PopAsync();
                }                               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");                
            }

        }
        #endregion

        public RegistrarPontoViewModel()
        {
            _pontoRepository = new PontoRepository();
            _relatorioRepository = new RelatorioRepository();
            HrAtual = DateTime.Now.ToShortTimeString();
            
        }
    }
}
