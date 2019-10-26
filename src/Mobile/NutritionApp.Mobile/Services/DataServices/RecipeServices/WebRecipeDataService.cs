using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NutritionApp.Mobile.Services.DataService
{
    public class WebRecipeDataService : IRecipeDataService
    {
        HttpClient client;
        IEnumerable<NutritionItem> items;

        public WebRecipeDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<NutritionItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public Task<bool> AddItemAsync(RecipeItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(RecipeItem item)
        {
            throw new NotImplementedException();
        }
    }
}
