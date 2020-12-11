using NomadeTFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadeTFC.Services
{
   public  class PaysMockDataStore : IDataStore<Pays>
    {
        readonly List<Pays> pays;

        public PaysMockDataStore()
        {
            pays = new List<Pays>()
            {
                new Pays { Id = Guid.NewGuid().ToString(), Nom = "France" },
                new Pays { Id = Guid.NewGuid().ToString(), Nom = "Angleterre" },
                new Pays { Id = Guid.NewGuid().ToString(), Nom = "Espagne"},
            };
        }

        public async Task<bool> AddItemAsync(Pays lePays)
        {
            pays.Add(lePays);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Pays lePays)
        {
            var oldItem = pays.Where((Pays arg) => arg.Id == lePays.Id).FirstOrDefault();
            pays.Remove(oldItem);
            pays.Add(lePays);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = pays.Where((Pays arg) => arg.Id == id).FirstOrDefault();
            pays.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Pays> GetItemAsync(string id)
        {
            return await Task.FromResult(pays.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pays>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(pays);
        }
    }
}

