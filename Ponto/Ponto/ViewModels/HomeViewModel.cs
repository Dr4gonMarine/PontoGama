using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using Ponto.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region ->Propriedades<-

        public INavigation Navigation { get; set; }

        private UserRepository _usuarioRepository;
        
        public User usuario { get; set; }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged ("Nome"); }
        }

        #endregion

        #region -> Command <-       

        private Command _RegistrarPontoCommand;
        public Command RegistrarPonto => _RegistrarPontoCommand ?? (_RegistrarPontoCommand = new Command(async () => await Registrar()));
        #endregion

        #region -> Métodos <-
        private async Task Registrar()
        {
            await Navigation.PushAsync(new RegistrarPontoPage(usuario)); 
        }

        #endregion

        public HomeViewModel()
        {
            _usuarioRepository = new UserRepository();           
        }
    }
}
