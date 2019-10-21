using NutritionApp.Mobile.Models.Nutrition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class OfflineNutritionDiaryDataService : INutritionDiaryDataService
    {
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
