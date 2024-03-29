﻿using NutritionApp.Core.Models.Nutrition;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class MockRecipeDataService : IRecipeDataService
    {
        #region Fields
                        
        #endregion

        #region Constructors

        public MockRecipeDataService()
        {         
        }

        #endregion

        #region Methods

        public Task<bool> AddItemAsync(RecipeItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RecipeItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(RecipeItem item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
