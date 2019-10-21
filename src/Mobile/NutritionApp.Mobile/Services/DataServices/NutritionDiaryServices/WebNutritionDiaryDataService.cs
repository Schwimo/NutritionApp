using Newtonsoft.Json;
using NutritionApp.Mobile.Models.Nutrition;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NutritionApp.Mobile.Services.DataService
{
    public class WebNutritionDiaryDataService : INutritionDiaryDataService
    {
        HttpClient client;
        IEnumerable<NutritionItem> items;

        public WebNutritionDiaryDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<NutritionItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public Task<bool> AddItemAsync(NutritionDiaryItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NutritionDiaryItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NutritionDiaryItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(NutritionDiaryItem item)
        {
            throw new NotImplementedException();
        }
    }
}
