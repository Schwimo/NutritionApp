using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public interface INutritionDiaryDataService
    {
        // NUTRITION ITEM
        Task<bool> AddItemAsync(NutritionDiaryItem item);
        Task<bool> UpdateItemAsync(NutritionDiaryItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<NutritionDiaryItem> GetItemAsync(string id);
        Task<IList<NutritionDiaryItem>> GetItemsAsync(DateTime date, bool forceRefresh = false);
    }
}
