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
        private PontoRepository _PontoRepository;
        private RelatorioRepository _RelatorioRepository;

        public User usuario;

        private DateTime HoraAtual;

        private string _hrAtual;
       
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

                var lastPonto = _PontoRepository.GetLastPonto(usuario.Id);
                var relatorioAtual = _RelatorioRepository.GetRelatorioAtual();

                if(relatorioAtual == null)
                {
                    _RelatorioRepository.InserirIdUsuario(usuario.Id);
                }


                //Validação se ponto de entrada ou saida
                if (lastPonto == null)
                {
                    _PontoRepository.InsertPontoHrInicial(HoraAtual, usuario.Id, relatorioAtual.Id);
                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário inicial registrado", "OK");
                }
                else
                {
                    _PontoRepository.InsertPontoHrFinal(HoraAtual, usuario.Id, lastPonto);
                    await App.Current.MainPage.DisplayAlert("Registrado", "Horário final registrado", "OK");
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
            _PontoRepository = new PontoRepository();
            _RelatorioRepository = new RelatorioRepository();
            HrAtual = DateTime.Now.ToShortTimeString();
        }
    }
}
