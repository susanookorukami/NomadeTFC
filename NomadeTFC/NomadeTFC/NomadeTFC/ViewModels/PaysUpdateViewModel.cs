using NomadeTFC.Models;
using NomadeTFC.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NomadeTFC.ViewModels
{
    [QueryProperty(nameof(PaysId), nameof(PaysId))]
    class PaysUpdateViewModel : BaseViewModel
    {
        private Pays _selectedPays;


        public Command CancelCommand { get; }
        public Command SaveCommand { get; }
          




        public PaysUpdateViewModel()
        {
            Title = "Modifier des pays";
           
          
            

          //  UpdatePaysCommand = new Command(OnUpdatePays);



        }


        private async void OnSave()
        {
            Pays newPays = new Pays()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = Nom,

            };

            await DataStorePays.AddItemAsync(newPays);




            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }


        public void OnAppearing()

        {
            IsBusy = true;
           
        }

      


       
        private string lePaysId;
        private string nom;


        public string Id { get; set; }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }



        public string PaysId
        {
            get
            {
                return lePaysId;
            }
            set
            {
                lePaysId = value;
                LoadPaysId(value);
            }
        }

        public async void LoadPaysId(string lePaysId)
        {
            try
            {
                var lePays = await DataStorePays.GetItemAsync(lePaysId);
                Id = lePays.Id;
                Nom = lePays.Nom;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
