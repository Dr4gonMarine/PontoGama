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
    public class LoginViewModel : BaseViewModel
    {
        #region Propriedades
        public INavigation Navigation { get; set; }

        private readonly UserRepository _usuarioRepository;

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
        #endregion

        #region -> Command <-
        private Command _LoginCommand;
        public Command LoginCommand => _LoginCommand ?? (_LoginCommand = new Command(async () => await ValidaLogin()));

        private Command _CadastrarCommand;
        public Command CadastrarCommand => _CadastrarCommand ?? (_CadastrarCommand = new Command(async () => await Cadastrar()));
        #endregion

        #region -> Métodos <-
        private async Task Cadastrar()
        {
            await Navigation.PushModalAsync(new Cadastro(),false);            
        }
        private async Task ValidaLogin()
        {
            try
            {
                var usuario = _usuarioRepository.GetByEmail(Email);                
                if (usuario != null)
                {
                    if(usuario.Senha == Senha)
                    {
                        Application.Current.MainPage = new NavigationPage(new Home(usuario));
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Ops", "Senha Incorreta", "OK");
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Usuário não encontrado", "OK");
                }
            
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }

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
