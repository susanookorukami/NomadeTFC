using NomadeTFC.Models;
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
    public partial class UpdatePaysPage : ContentPage
    {

        public Pays lePays { get; set; }
        public UpdatePaysPage()
        {
            InitializeComponent();
            BindingContext = new PaysUpdateViewModel();
        }
       
    }
}