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
            InitializeComponent();
            _RegistrarPontoViewModel = BindingContext as RegistrarPontoViewModel;            
            _RegistrarPontoViewModel.Navigation = Navigation;
            _RegistrarPontoViewModel.usuario = usuario;
            var mapa = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(new Position(_RegistrarPontoViewModel.location.Latitude, _RegistrarPontoViewModel.location.Longitude), Distance.FromKilometers(1)));

            var Gama = new Pin { Position = new Position(_RegistrarPontoViewModel.location.Latitude, _RegistrarPontoViewModel.location.Longitude), Label = "Sua posição", Address = "Rua lá" };

            mapa.Pins.Add(Gama);

            MapContainer.Children.Add(mapa);
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
             
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Atenção", ex.Message, "OK");
            }

        }
    }
}