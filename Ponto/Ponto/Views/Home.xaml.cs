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
    }
}