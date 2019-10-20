using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Models.Person;
using System;
using System.Collections.Generic;
using System.Text;

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
