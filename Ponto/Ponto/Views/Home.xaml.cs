using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using Ponto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ponto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {

        HomeViewModel _HomeViewModel;        

        public Home(User usuario)
        {
            InitializeComponent();
            _HomeViewModel = BindingContext as HomeViewModel;
            _HomeViewModel.Nome = usuario.Nome;
            _HomeViewModel.Navigation = Navigation;
            _HomeViewModel.usuario = usuario;
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                _HomeViewModel.CarregaDados();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }

        }

        private void RelatorioSelecionado(object sender, EventArgs e)
        {
            var evento = (TappedEventArgs)e;
            var relatorio = (Relatorio)evento.Parameter;

            Navigation.PushAsync(new DetalhePage(relatorio),false);
        }
    }
}