using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using Ponto.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region ->Propriedades<-
        public List<Relatorio> _listaGeral = new List<Relatorio>();

        public INavigation Navigation { get; set; }
        private RelatorioRepository _relatorioRepository;

        public User usuario { get; set; }

        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; OnPropertyChanged("Nome"); }
        }                
        private ObservableCollection<Relatorio> _relatorioList;
        public ObservableCollection<Relatorio> RelatorioList { get { return _relatorioList; } set { _relatorioList = value; OnPropertyChanged("RelatorioList"); } }

        #endregion

        #region -> Command <-       

        private Command _RegistrarPontoCommand;
        public Command RegistrarPonto => _RegistrarPontoCommand ?? (_RegistrarPontoCommand = new Command(async () => await Registrar()));        
        #endregion

        #region -> Métodos <-
        private async Task Registrar()
        {
            await Navigation.PushAsync(new RegistrarPontoPage(usuario) { BackgroundColor = Color.Aquamarine});
        }
        public void CarregaDados()
        {
            try
            {
                _listaGeral = _relatorioRepository.GetAllRelatorios(usuario.Id);

                RelatorioList = new ObservableCollection<Relatorio>(_listaGeral);

            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }
        }

        #endregion

        public HomeViewModel()
        {
            _relatorioRepository = new RelatorioRepository();
        }
    }
}
