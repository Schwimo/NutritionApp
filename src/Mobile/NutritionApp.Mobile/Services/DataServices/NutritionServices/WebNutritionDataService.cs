using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public class WebNutritionDataService : INutritionDataService
    {
        HttpClient client;
        IEnumerable<NutritionItem> items;

        public WebNutritionDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<NutritionItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        
        public async Task<NutritionItem> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<NutritionItem>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(NutritionItem item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(NutritionItem item)
        {
            if (item == null || item.ID == null || !IsConnected)
            {
                return false;
            }

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/item/{item.ID}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<NutritionItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<NutritionItem>>(json));
            }

            return items;
        }
    }
}
