using NomadeTFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadeTFC.Services
{
   public  class VilleMockDataStore : IDataStore<Ville>
    {
        readonly List<Ville> villes;

        public VilleMockDataStore()
        {
            villes = new List<Ville>()
            {
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "First item", Description="This is an item description.", CP=00000 },
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Second item", Description="This is an item description.", CP=00001 },
                new Ville { Id = Guid.NewGuid().ToString(), Nom = "Third item", Description="This is an item description.", CP=00002 },
            }; 
        }

        public async Task<bool> AddItemAsync(Ville ville)
        {
            villes.Add(ville);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Ville ville)
        {
            var oldItem = villes.Where((Ville arg) => arg.Id == ville.Id).FirstOrDefault();
            villes.Remove(oldItem);
            villes.Add(ville);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = villes.Where((Ville arg) => arg.Id == id).FirstOrDefault();
            villes.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Ville> GetItemAsync(string id)
        {
            return await Task.FromResult(villes.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Ville>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(villes);
        }
    }
}
