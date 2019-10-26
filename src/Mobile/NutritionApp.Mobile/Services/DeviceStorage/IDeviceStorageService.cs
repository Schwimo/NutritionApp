using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Core.Models.Person;
using System.Collections.Generic;

namespace NutritionApp.Mobile.Services.DeviceStorage
{
    public interface IDeviceStorageService
    {
        void WriteNutritionItems(IEnumerable<NutritionItem> nutritionItems);
        IEnumerable<NutritionItem> ReadNutritionItems();

        void WritePersonData(PersonItem person);
        PersonItem ReadPersonData();
    }
}
