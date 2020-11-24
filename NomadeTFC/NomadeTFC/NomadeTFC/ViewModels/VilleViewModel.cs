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
   public  class VilleViewModel  : BaseViewModel
    {
        private Ville _selectedVille;

        public ObservableCollection<Ville> Villes { get; }
        public Command LoadVillesCommand { get; }
        public Command AddVilleCommand { get; }
        public Command<Ville> VilleTapped { get; }

        public VilleViewModel()
        {
            Title = "Villes";
            Villes = new ObservableCollection<Ville>();
            LoadVillesCommand = new Command(async () => await ExecuteLoadVillesCommand());

            VilleTapped = new Command<Ville>(OnVilleSelected);

            AddVilleCommand = new Command(OnAddVille);
        }

        async Task ExecuteLoadVillesCommand()
        {
            IsBusy = true;

            try
            {
                Villes.Clear();
                var villes = await DataStoreVille.GetItemsAsync(true);
                foreach (var ville in villes)
                {
                    Villes.Add(ville);
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
            SelectedVille = null;
        }

        public Ville SelectedVille
        {
            get => _selectedVille;
            set
            {
                SetProperty(ref _selectedVille, value);
                OnVilleSelected(value);
            }
        }

        private async void OnAddVille(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVillePage));
        }

        async void OnVilleSelected(Ville ville)
        {
            if (ville == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VilleDetailPage)}?{nameof(VilleDetailViewModel.VilleId)}={ville.Id}");
        }
    }
}
