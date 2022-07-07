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
    public partial class RegistrarPontoPage : ContentPage
    {
        RegistrarPontoViewModel _RegistrarPontoViewModel;
        public RegistrarPontoPage(User usuario)
        {
            InitializeComponent();
            _RegistrarPontoViewModel = BindingContext as RegistrarPontoViewModel;            
            _RegistrarPontoViewModel.Navigation = Navigation;
            _RegistrarPontoViewModel.usuario = usuario;
        }
    }
}