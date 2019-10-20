using NutritionApp.Mobile.Models.Person;
using NutritionApp.Mobile.Services.DataService.Core;
using NutritionApp.Mobile.Services.DataService.Person.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    public class MockPersonDataStore : IWeightDataService, IPersonDataService, IBodyDataService
    {
        #region Fields

        private PersonItem _person;

        #endregion

        #region Constructors

        public MockPersonDataStore()
        {
            _person = new PersonItem();
        }

        #endregion

        #region Methods

        public async Task<bool> AddItemAsync(PersonItem item)
        {
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PersonItem item)
        {
            _person = item;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return await Task.FromResult(true);
        }

        public async Task<PersonItem> GetItemAsync(string id)
        {
            return await Task.FromResult(_person);
        }

        public async Task<IEnumerable<PersonItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Weight item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Weight item)
        {
            throw new NotImplementedException();
        }

        Task<Weight> IDataService<Weight>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Weight>> IDataService<Weight>.GetItemsAsync(DateTime dateConstraint, bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Circumference item)
        {
            throw new NotImplementedException();
        }

        Task<Circumference> IDataService<Circumference>.GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Circumference>> IDataService<Circumference>.GetItemsAsync(DateTime dateConstraint, bool forceRefresh)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
