using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NomadeTFC.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://openweathermap.org/weathermap?basemap=map&cities=true&layer=temperature&lat=30&lon=-20&zoom=5"));
        }

        public ICommand OpenWebCommand { get; }
    }
}