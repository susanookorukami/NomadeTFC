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
    class PaysUpdateViewModel : BaseViewModel
    {
        private Pays _selectedPays;

        public ObservableCollection<Pays> lesPays { get; }
        public Command LoadlesPaysCommand { get; }
        public Command UpdatePaysCommand { get; }



        public Command<Pays> PaysTapped { get; }

        public PaysUpdateViewModel()
        {
            Title = "Liste des pays";
            lesPays = new ObservableCollection<Pays>();
            LoadlesPaysCommand = new Command(async () => await ExecuteLoadlesPaysCommand());

            PaysTapped = new Command<Pays>(OnPaysSelected);

            UpdatePaysCommand = new Command(OnRemovePays);



        }



        async Task ExecuteLoadlesPaysCommand()
        {
            IsBusy = true;

            try
            {
                lesPays.Clear();
                var pays = await DataStorePays.GetItemsAsync(true);
                foreach (var lePays in pays)
                {
                    lesPays.Remove(lePays);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPays = null;
        }

        public Pays SelectedPays
        {
            get => _selectedPays;
            set
            {
                SetProperty(ref _selectedPays, value);
                OnPaysSelected(value);
            }
        }

        private async void OnRemovePays(object obj)
        {
            await Shell.Current.GoToAsync(nameof(UpdatePaysPage));
        }


        async void OnPaysSelected(Pays lePays)
        {
            if (lePays == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PaysDetailPage)}?{nameof(PaysDetailViewModel.PaysId)}={lePays.Id}");
        }
    }
}
