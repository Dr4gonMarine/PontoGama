using Ponto.Base.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ponto.Controls.Validations;

namespace Ponto.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        #region ->Propriedades<-       

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

        private string _isEstagiario;

        public string IsEstagiario
        {
            get { return _isEstagiario; }
            set { _isEstagiario = value; OnPropertyChanged("IsEstagiario"); }
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
                if (ValidaEntry.ValidaEntryEmail(Email) && ValidaEntry.ValidaSenha(Senha) && ValidaEntry.ValidaNome(Nome))
                {
                    if (string.IsNullOrEmpty(IsEstagiario))
                    {
                        IsEstagiario = "false";
                    }
                    bool estagiario = Boolean.Parse(IsEstagiario);
                    _usuarioRepository.InsertUser(Nome, Email, Senha, estagiario);
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Cuidado", "Email e Senha não são validos", "OK");
                }
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
        #endregion

        #region ->Métodos<-

        #endregion

        public CadastroViewModel()
        {
            _usuarioRepository = new UserRepository();
        }
    }
}
