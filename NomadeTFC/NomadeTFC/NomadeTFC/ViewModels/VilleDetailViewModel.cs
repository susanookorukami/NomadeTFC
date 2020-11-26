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
            get => nom;
            set => SetProperty(ref nom, value);
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

    }
}
