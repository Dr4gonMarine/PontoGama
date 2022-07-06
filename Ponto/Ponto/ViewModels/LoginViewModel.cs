using Ponto.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class LoginViewModel
    {
        private INavigation _navigation;

        #region -> Command <-
        private Command _LoginCommand;
        public Command LoginCommand => _LoginCommand ?? (_LoginCommand = new Command(async () => await ValidaLogin()));

        private Command _CadastrarCommand;
        public Command CadastrarCommand => _CadastrarCommand ?? (_CadastrarCommand = new Command(async () => await Cadastrar()));

        private async Task Cadastrar()
        {           
           await _navigation.PushModalAsync( new Cadastro());
        }
        #endregion

        #region -> Métodos <-
        private async Task ValidaLogin()
        {            
           Application.Current.MainPage = new NavigationPage(new Home());
        }
        #endregion

        #region -> Construtor <-
        public LoginViewModel()
        {            
            
        }       
        #endregion
    }
}
