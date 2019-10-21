using NutritionApp.Mobile.Models.Person;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class MockCircumferenceDataService : ICircumferenceDataService
    {
        #region Fields

        private PersonItem _person;
        
        #endregion

        #region Constructors

        public MockCircumferenceDataService()
        {
            _person = new PersonItem();                        
        }

        public Task<bool> AddItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Circumference> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Circumference>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Methods


        #endregion
    }
}
