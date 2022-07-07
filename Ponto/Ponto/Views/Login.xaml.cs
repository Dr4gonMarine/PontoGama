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
    public partial class Login : ContentPage
    {
        LoginViewModel _LoginViewModel;
        public Login()
        {
            InitializeComponent();

            _LoginViewModel = BindingContext as LoginViewModel;
            _LoginViewModel.Navigation = Navigation;
        }
    }
}