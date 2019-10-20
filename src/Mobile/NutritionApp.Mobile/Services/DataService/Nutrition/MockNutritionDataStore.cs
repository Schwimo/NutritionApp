using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService.Nutrition.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public class MockNutritionDataStore : INutritionDataService
    {
        readonly List<NutritionItem> items;

        public MockNutritionDataStore()
        {
            items = new List<NutritionItem>()
            {
                new NutritionItem("Peach", 100, 20, 10, 5),
                new NutritionItem("Apple", 100, 20, 10, 5),
                new NutritionItem("Banana", 100, 20, 10, 5),
                new NutritionItem("Oats", 100, 20, 10, 5),
                new NutritionItem("Chicken", 100, 20, 10, 5),
                new NutritionItem("Lemon", 100, 20, 10, 5),
                new NutritionItem("Cheddar", 100, 20, 10, 5),
                new NutritionItem("Fish", 100, 20, 10, 5),
            };
        }

        public async Task<bool> AddItemAsync(NutritionItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(NutritionItem item)
        {
            var oldItem = items.Where((NutritionItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((NutritionItem arg) => arg.ID.Equals(id)).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<NutritionItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID.Equals(id)));
        }

        public async Task<IEnumerable<NutritionItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
