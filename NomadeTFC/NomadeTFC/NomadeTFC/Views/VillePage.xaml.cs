using NomadeTFC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NomadeTFC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VillesPage : ContentPage
    {
        VilleViewModel _viewModel;
        public VillesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new VilleViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}