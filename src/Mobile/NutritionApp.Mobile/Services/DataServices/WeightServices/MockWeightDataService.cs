using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionApp.Mobile.Models.Person;

namespace NutritionApp.Mobile.Services.DataService
{
    public class MockWeightDataService : IWeightDataService
    {
        #region Fields

        #endregion

        #region Constructors

        public MockWeightDataService()
        {
            
        }

        #endregion

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
