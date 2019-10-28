using System;
using System.Collections.Generic;
using System.Text;
using NutritionApp.Mobile.Services.DataService.Core;
using NutritionApp.Core.Models.Nutrition;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public interface INutritionDataService
    {
        Task<bool> AddItemAsync(NutritionItem item);
        Task<bool> UpdateItemAsync(NutritionItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<NutritionItem> GetItemAsync(string id);
        Task<IList<NutritionItem>> GetItemsAsync(DateTime date, IList<int> ids = null, bool forceRefresh = false);
        Task<IList<NutritionItemCategorie>> GetCategoriesAsync(bool forceRefresh = false);
    }
}
