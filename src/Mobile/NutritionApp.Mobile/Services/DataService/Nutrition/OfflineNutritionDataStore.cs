using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService.Nutrition.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public class OfflineNutritionDataStore : INutritionDataService
    {
        public Task<bool> AddItemAsync(NutritionItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NutritionItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NutritionItem>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(NutritionItem item)
        {
            throw new NotImplementedException();
        }
    }
}
