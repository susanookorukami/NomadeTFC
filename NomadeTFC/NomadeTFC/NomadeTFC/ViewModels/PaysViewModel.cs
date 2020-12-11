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
    public class PaysViewModel : BaseViewModel
    {
        private Pays _selectedPays;

        public ObservableCollection<Pays> lesPays { get; }
        public Command LoadlesPaysCommand { get; }
        public Command AddPaysCommand { get; }
        
        public Command<Pays> PaysTapped { get; }

        public PaysViewModel()
        {
            Title = "Liste des pays";
            lesPays = new ObservableCollection<Pays>();
            LoadlesPaysCommand = new Command(async () => await ExecuteLoadlesPaysCommand());

            PaysTapped = new Command<Pays>(OnPaysSelected);

            AddPaysCommand = new Command(OnAddPays);
       

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
                    lesPays.Add(lePays);
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

        private async void OnAddPays(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPaysPage));
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
