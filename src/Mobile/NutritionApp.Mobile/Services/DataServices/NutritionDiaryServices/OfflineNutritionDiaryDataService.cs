using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.Services.DataServices.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class OfflineNutritionDiaryDataService : BaseDataService, INutritionDiaryDataService
    {
        #region Fields



        #endregion

        #region Constructors

        public OfflineNutritionDiaryDataService()
        {

        }

        #endregion

        #region Methods

        public Task<bool> AddItemAsync(NutritionDiaryItem item)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<NutritionDiaryItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<NutritionDiaryItem>> GetItemsAsync(DateTime date, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(NutritionDiaryItem item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
