using Ponto.Base.Models;
using Ponto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Ponto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarPontoPage : ContentPage
    {
        RegistrarPontoViewModel _RegistrarPontoViewModel;        
        public RegistrarPontoPage(User usuario)
        {
            try
            {
                InitializeComponent();
                _RegistrarPontoViewModel = BindingContext as RegistrarPontoViewModel;
                _RegistrarPontoViewModel.Navigation = Navigation;
                _RegistrarPontoViewModel.usuario = usuario;
                _RegistrarPontoViewModel.CarregaMapa().GetAwaiter();
                if(_RegistrarPontoViewModel.mapa != null)
                    MapContainer.Children.Add(_RegistrarPontoViewModel.mapa);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("OPS", ex.Message, "OK");
            }
        }       
    }
}