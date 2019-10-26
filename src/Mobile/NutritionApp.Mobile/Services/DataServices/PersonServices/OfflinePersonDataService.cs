using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutritionApp.Core.Models.Person;

namespace NutritionApp.Mobile.Services.DataService
{
    public class OfflinePersonDataService : IPersonDataService
    {
        public Task<bool> AddItemAsync(PersonItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(PersonItem item)
        {
            throw new NotImplementedException();
        }
    }
}
