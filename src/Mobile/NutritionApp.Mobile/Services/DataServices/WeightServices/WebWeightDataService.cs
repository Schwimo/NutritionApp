using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Core.Models.Person;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NutritionApp.Mobile.Services.DataService
{
    public class WebWeightDataService : IWeightDataService
    {
        HttpClient client;
        IEnumerable<NutritionItem> items;

        public WebWeightDataService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<NutritionItem>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        #region Methods
        
        public Task<bool> AddItemAsync(Weight item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Weight> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Weight>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Weight item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
