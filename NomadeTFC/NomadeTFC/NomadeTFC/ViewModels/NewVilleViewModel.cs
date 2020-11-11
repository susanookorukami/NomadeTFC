using NomadeTFC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NomadeTFC.ViewModels
{
    public class NewVilleViewModel : BaseViewModel
    {
        private string nom;
        private string description;
        private int cp;
        public NewVilleViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Nom)
                && !String.IsNullOrWhiteSpace(Description);
                
        }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int CP
        {
            get => cp;
            set => SetProperty(ref cp, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Ville newVille = new Ville()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = Nom,
                Description = Description,
                CP = CP
            };

            await DataStoreVille.AddItemAsync(newVille);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
