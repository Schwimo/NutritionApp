using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public class OfflineNutritionDataService : INutritionDataService
    {
        private readonly List<NutritionItem> nutritionItems;
        private readonly List<NutritionItemCategorie> categorieItems;

        public OfflineNutritionDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(NutritionItem)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("NutritionApp.Core.Database.db.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
                var split = text.Split(';');

                nutritionItems = JsonConvert.DeserializeObject<List<NutritionItem>>(split[0]);
                categorieItems = JsonConvert.DeserializeObject<List<NutritionItemCategorie>>(split[1]);
            }
        }

        public async Task<bool> AddItemAsync(NutritionItem item)
        {
            nutritionItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(NutritionItem item)
        {
            var oldItem = nutritionItems.Where((NutritionItem arg) => arg.ID == item.ID).FirstOrDefault();
            nutritionItems.Remove(oldItem);
            nutritionItems.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = nutritionItems.Where((NutritionItem arg) => arg.ID.Equals(id)).FirstOrDefault();
            nutritionItems.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<NutritionItem> GetItemAsync(string id)
        {
            return await Task.FromResult(nutritionItems.FirstOrDefault(s => s.ID.Equals(id)));
        }

        public async Task<IList<NutritionItem>> GetItemsAsync(DateTime date, IList<int> ids = null, bool forceRefresh = false)
        {
            if (ids != null)
            {                
                var items = nutritionItems.Where((x) => ids.Contains(x.ID)).ToList();
                return await Task.FromResult(items);
            }
            else
            {
                return await Task.FromResult(nutritionItems);
            }            
        }

        public async Task<IList<NutritionItemCategorie>> GetCategoriesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categorieItems);
        }
    }
}
