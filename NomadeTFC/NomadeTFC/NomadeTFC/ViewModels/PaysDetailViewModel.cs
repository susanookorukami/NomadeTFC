using NomadeTFC.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace NomadeTFC.ViewModels
{
    [QueryProperty(nameof(PaysId), nameof(PaysId))]
    class PaysDetailViewModel : BaseViewModel
    {
        public Command UpdatePaysCommand { get; }

        public PaysDetailViewModel()
        {
            Title = "edit_pays";

            UpdatePaysCommand = new Command(onEditPays);
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

        private async void onEditPays(object obj)
        {
            await Shell.Current.GoToAsync(nameof(UpdatePaysPage));
        }


    }
}
