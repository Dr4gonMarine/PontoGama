using Ponto.Base.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        #region Propriedades       
        
        public INavigation Navigation { get; set; }

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

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value.ToUpper(); OnPropertyChanged("Nome"); }
        }

        #endregion

        #region -> Command <-       

        private Command _CadastrarCommand;
        public Command CadastrarCommand => _CadastrarCommand ?? (_CadastrarCommand = new Command(async () => await Cadastrar()));
        #endregion

        #region -> Métodos <-
        private async Task Cadastrar()
        {
            try
            {
                _usuarioRepository.InsertUser(Nome, Email, Senha);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }        
        }

        #endregion

        public CadastroViewModel()
        {
            _usuarioRepository = new UserRepository();
        }
    }
}
