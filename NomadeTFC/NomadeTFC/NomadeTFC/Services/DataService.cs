using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NomadeTFC.Services
{
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            
            dynamic data = null;
            var response = await client.GetAsync(queryString);


            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}
