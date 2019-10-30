using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Core.Models.Person;
using System;
using System.Collections.Generic;
using System.IO;

namespace NutritionApp.Mobile.Services.DeviceStorage
{
    /// <summary>
    /// The device storage service is used to store all necessary items offline
    /// on the device as json elements.
    /// </summary>
    public class DeviceStorageService : IDeviceStorageService
    {
        #region Fields

        /// <summary>
        /// The base file path where all files are stored.
        /// </summary>
        private string _filePath;

        /// <summary>
        /// The nutrition itme file name.
        /// </summary>
        private string _nutritionItemFile = "NutritionItems.txt";

        /// <summary>
        /// The person itme file name.
        /// </summary>
        private string _personItemFile = "PersonItems.txt";

        /// <summary>
        /// The nutrition item categories file name.
        /// </summary>
        private string _categoriesItemFile = "Categories.txt";

        /// <summary>
        /// The nutrition diary file name
        /// </summary>
        private string _nutritionDiaryFile = "NutritionDiary.txt";

        /// <summary>
        /// The recipe file name
        /// </summary>
        private string _recipesFile = "Recipes.txt";

        #endregion

        #region Constructors

        /// <summary>
        /// The constructor for tje device storage service.
        /// </summary>
        public DeviceStorageService()
        {
            _filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Writes a string into a text file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="textToWrite"></param>
        private void WriteFile(string fileName, string textToWrite)
        {
            using (var file = File.CreateText(Path.Combine(_filePath, fileName)))
            {
                file.Write(textToWrite);
            }
        }

        /// <summary>
        /// Reads a string from a text file.
        /// This string can be converted into anything wanted.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string ReadFile(string fileName)
        {
            var path = Path.Combine(_filePath, fileName);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                // TODO: Show alert
                return string.Empty;
            }

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Write the person data to the person text file.
        /// </summary>
        /// <param name="person"></param>
        public void WritePersonData(PersonItem person)
        {
            // Read the last person item in the storage
            // U

            var json = JsonConvert.SerializeObject(person);
            WriteFile(_personItemFile, json);
        }

        /// <summary>
        /// Read the person item file.
        /// </summary>
        /// <returns></returns>
        public PersonItem ReadPersonData()
        {
            var readText = ReadFile(_personItemFile);

            if (String.IsNullOrEmpty(readText))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PersonItem>(readText);
        }

        /// <summary>
        /// Write all nutrition items into a file stored on the device as a json string.
        /// </summary>
        /// <param name="nutritionItems"></param>
        public void WriteNutritionItems(IEnumerable<NutritionItem> nutritionItems)
        {
            var json = JsonConvert.SerializeObject(nutritionItems);
            WriteFile(_nutritionItemFile, json);
        }

        /// <summary>
        /// Get all nutrition items stored on the device inside a text file as a json string.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NutritionItem> ReadNutritionItems()
        {
            var readText = ReadFile(_nutritionItemFile);

            if (String.IsNullOrEmpty(readText))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<NutritionItem>>(readText);
        }

        /// <summary>
        /// Write all recipes into a file stored on the device as a json string.
        /// </summary>
        /// <param name="recipes"></param>
        public void WriteRecipes(IEnumerable<RecipeItem> recipes)
        {
            var json = JsonConvert.SerializeObject(recipes);
            WriteFile(_recipesFile, json);
        }

        /// <summary>
        /// REad all recipes from the recipe file as a jason string.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RecipeItem> ReadRecipes()
        {
            var readText = ReadFile(_recipesFile);

            if (String.IsNullOrEmpty(readText))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<RecipeItem>>(readText);
        }

        /// <summary>
        /// Write all categories to a local file on your device as a json string.
        /// </summary>
        /// <param name="categories"></param>
        public void WriteNutritionCategories(IEnumerable<NutritionItemCategorie> categories)
        {
            var json = JsonConvert.SerializeObject(categories);
            WriteFile(_categoriesItemFile, json);
        }

        /// <summary>
        /// Read all categories from a local file on your device.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NutritionItemCategorie> ReadNutritionCategories()
        {
            var readText = ReadFile(_categoriesItemFile);

            if (String.IsNullOrEmpty(readText))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<NutritionItemCategorie>>(readText);
        }

        /// <summary>
        /// Write all nutrition diary items to a file on your device.
        /// </summary>
        /// <param name="diaryEntries"></param>
        public void WriteNutritionDiaryItems(IEnumerable<NutritionDiaryItem> diaryEntries)
        {
            var json = JsonConvert.SerializeObject(diaryEntries);
            WriteFile(_nutritionDiaryFile, json);
        }

        /// <summary>
        /// Read all nutrition diary items from a local file on your device
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NutritionDiaryItem> ReadNutritionDiaryItems()
        {
            var readText = ReadFile(_nutritionDiaryFile);

            if (String.IsNullOrEmpty(readText))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IEnumerable<NutritionDiaryItem>>(readText);
        }

        #endregion
    }
}
