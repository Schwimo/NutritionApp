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
    public class MockNutritionDataService : INutritionDataService
    {
        private readonly List<NutritionItem> items;

        public MockNutritionDataService()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MockNutritionDataService)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("NutritionApp.Mobile.db.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<NutritionItem>>(text);
            }            
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

