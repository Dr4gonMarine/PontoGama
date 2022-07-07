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
    public partial class Cadastro : ContentPage
    {
        CadastroViewModel _CadastroViewmodel;
        public Cadastro()
        {
            InitializeComponent();
            _CadastroViewmodel = BindingContext as CadastroViewModel;
            _CadastroViewmodel.Navigation = Navigation;
        }
    }
}