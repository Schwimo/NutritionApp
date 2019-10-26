using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Core.Models.Person;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NutritionApp.Mobile.Services.DataService
{
    public class WebCircumferenceDataService : ICircumferenceDataService
    {
        HttpClient client;
        IEnumerable<NutritionItem> items;

        public WebCircumferenceDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<NutritionItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public Task<bool> AddItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Circumference> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Circumference>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }
    }
}
