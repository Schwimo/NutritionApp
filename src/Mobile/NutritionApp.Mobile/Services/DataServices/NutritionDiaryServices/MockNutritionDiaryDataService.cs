using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Models.Person;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class MockNutritionDiaryDataService : INutritionDiaryDataService
    {
        #region Fields
                        
        #endregion

        #region Constructors

        public MockNutritionDiaryDataService()
        {
          
        }

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

        #endregion

        #region Methods

        #endregion
    }
}
