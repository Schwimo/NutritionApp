using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Models.Person;
using NutritionApp.Mobile.Services.DataService.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService
{
    public class MockPersonDataService : IPersonDataService
    {
        #region Fields

        private PersonItem _person;
        
        #endregion

        #region Constructors

        public MockPersonDataService()
        {
            _person = new PersonItem();

            _person.Weights = new List<Weight>()
            {
                new Weight(78.0, DateTime.UtcNow.AddDays(-6)),
                new Weight(78.5, DateTime.UtcNow.AddDays(-5)),
                new Weight(78.0, DateTime.UtcNow.AddDays(-4)),
                new Weight(77.8, DateTime.UtcNow.AddDays(-3)),
                new Weight(77.7, DateTime.UtcNow.AddDays(-2)),
                new Weight(77.6, DateTime.UtcNow.AddDays(-1)),
                new Weight(77.0, DateTime.UtcNow),
            };

            _person.Circumferences = new List<Circumference>()
            {
                new Circumference(DateTime.UtcNow, 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-1), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-2), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-3), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-4), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-5), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
                new Circumference(DateTime.UtcNow.AddDays(-6), 10.0, 80.0, 38.5, 38.5, 30, 30, 50, 60, 70, 58, 58, 30, 30),
            };

            _person.NutritionDiaryList = new List<NutritionDiaryItem>()
            {
                new NutritionDiaryItem(Guid.NewGuid(), 50, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 30, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 80, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 200, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 100, DateTime.UtcNow),
                new NutritionDiaryItem(Guid.NewGuid(), 110, DateTime.UtcNow),

                new NutritionDiaryItem(Guid.NewGuid(), 50, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 30, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 80, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 200, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 100, DateTime.UtcNow.AddDays(-1)),
                new NutritionDiaryItem(Guid.NewGuid(), 110, DateTime.UtcNow.AddDays(-1)),

                new NutritionDiaryItem(Guid.NewGuid(), 50, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 30, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 80, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 200, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 10, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 100, DateTime.UtcNow.AddDays(-2)),
                new NutritionDiaryItem(Guid.NewGuid(), 110, DateTime.UtcNow.AddDays(-2)),
            };
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

        public Task<IEnumerable<PersonItem>> GetItemsAsync(DateTime dateConstraint, bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
