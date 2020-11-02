using System.ComponentModel;
using Xamarin.Forms;
using NomadeTFC.ViewModels;

namespace NomadeTFC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}