using NomadeTFC.Models;
using NomadeTFC.Services;
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
   
       
        public PaysUpdateViewModel()
        {

            Title = "Modifier des pays";
            UpdateCommand = new Command(OnUpdate, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => UpdateCommand.ChangeCanExecute();
        }
        public Command CancelCommand { get; }
        public Command UpdateCommand { get; }


        private async void OnUpdate()
        {
            var id = PaysId;
            Pays UpdatePays = new Pays()
            {
                Id=id,
                //Id = Guid.NewGuid().ToString(),
                Nom = nom,
            };

            await DataStorePays.UpdateItemAsync(UpdatePays);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Nom);
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

