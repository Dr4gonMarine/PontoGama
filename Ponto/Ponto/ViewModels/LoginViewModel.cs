using Ponto.Base.Data.Repository;
using Ponto.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private UserRepository _usuarioRepository;


        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; OnPropertyChanged("Senha"); }
        }    


        #region -> Command <-
        private Command _LoginCommand;
        public Command LoginCommand => _LoginCommand ?? (_LoginCommand = new Command(async () => await ValidaLogin()));

        private Command _CadastrarCommand;
        public Command CadastrarCommand => _CadastrarCommand ?? (_CadastrarCommand = new Command(async () => await Cadastrar()));

        #endregion

        #region -> Métodos <-
        private async Task Cadastrar()
        {            
            //await _navigation.PushModalAsync(new Cadastro());
        }
        private async Task ValidaLogin()
        {  
          var usuario = _usuarioRepository.GetByEmail(_email);
          await Task.Delay(200);
          Application.Current.MainPage = new NavigationPage(new Home());
        }
        #endregion

        #region -> Construtor <-
        public LoginViewModel()
        {            
            _usuarioRepository = new UserRepository();
        }       
        #endregion
    }
}
