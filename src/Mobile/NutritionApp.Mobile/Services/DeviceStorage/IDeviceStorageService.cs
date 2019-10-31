using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Core.Models.Person;
using System.Collections.Generic;

namespace NutritionApp.Mobile.Services.DeviceStorage
{
    public interface IDeviceStorageService
    {
        // NUTRITION
        void WriteNutritionItems(IEnumerable<NutritionItem> nutritionItems);
        IEnumerable<NutritionItem> ReadNutritionItems();

        // RECIPES
        void WriteRecipes(IEnumerable<RecipeItem> recipes);
        IEnumerable<RecipeItem> ReadRecipes();

        // CATEGORIES
        void WriteNutritionCategories(IEnumerable<NutritionItemCategorie> categories);
        IEnumerable<NutritionItemCategorie> ReadNutritionCategories();

        // DIARY
        void WriteNutritionDiaryItems(IEnumerable<NutritionDiaryItem> diaryEntries);
        IEnumerable<NutritionDiaryItem> ReadNutritionDiaryItems();

        // PERSON
        void WritePersonData(PersonItem person);
        PersonItem ReadPersonData();
    }
}
