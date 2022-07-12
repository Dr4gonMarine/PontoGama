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
    public partial class DetalhePage : ContentPage
    {
        DetalheViewModel _detalheViewModel;
        public DetalhePage(Relatorio relatorio)
        {
            InitializeComponent();
            _detalheViewModel = BindingContext as DetalheViewModel;            
            _detalheViewModel.Navigation = Navigation;
            _detalheViewModel.relatorio = relatorio;
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                _detalheViewModel.CarregaDados();
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }

        }
    }
}