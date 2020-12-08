using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NomadeTFC.Models;
using System.Diagnostics;

namespace NomadeTFC.ViewModels
{
    [QueryProperty(nameof(VilleId), nameof(VilleId))]
    public class VilleDetailViewModel : BaseViewModel
    {
        private string villeId;
        private string nom;
        private string description;
        private string cp;

        public string Id { get; set; }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                SetProperty(ref nom, value);
                LoadWeather(value);
            }
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string CP
        {
            get => cp;
            set => SetProperty(ref cp, value);
        }

        public string VilleId
        {
            get
            {
                return villeId;
            }
            set
            {
                villeId = value;
                LoadVilleId(value);
            }
        }

        public async void LoadVilleId(string villeId)
        {
            try
            {
                var ville = await DataStoreVille.GetItemAsync(villeId);
                Id = ville.Id;
                Nom = ville.Nom;
                Description = ville.Description;
                CP = ville.CP;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private string titre;
        private string temperature;
        private string wind;
        private string humidity;
        private string visibility;
        private string sunrise;
        private string sunset;

        public string Titre
        {
            get => titre;
            set => SetProperty(ref titre, value);
        }
        public string Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }
        public string Wind
        {
            get => wind;
            set => SetProperty(ref wind, value);
        }
        public string Humidity
        {
            get => humidity;
            set => SetProperty(ref humidity, value);
        }
        public string Visibility
        {
            get => visibility;
            set => SetProperty(ref visibility, value);
        }
        public string Sunrise
        {
            get => sunrise;
            set => SetProperty(ref sunrise, value);
        }
        public string Sunset
        {
            get => sunset;
            set => SetProperty(ref sunset, value);
        }
        public async void LoadWeather(string Nom)
        {
            try
            {
                var weather = await WeatherCore.GetWeather(Nom);
                Titre = weather.Titre;
                Temperature = weather.Temperature;
                Wind = weather.Wind;
                Humidity = weather.Humidity;
                Visibility = weather.Visibility;
                Sunrise = weather.Sunrise;
                Sunset = weather.Sunset;
            }
            catch(Exception e)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
