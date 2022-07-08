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

                if (lastPonto == null)
                {
                    _PontoRepository.InsertPontoHrInicial(HoraAtual, usuario.Id);
                }
                else
                {
                    _PontoRepository.InsertPontoHrFinal(HoraAtual, usuario.Id);
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
            HrAtual = DateTime.Now.ToShortTimeString();
        }
    }
}
