using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Core
{
    public interface IDataService<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false);
    }
}