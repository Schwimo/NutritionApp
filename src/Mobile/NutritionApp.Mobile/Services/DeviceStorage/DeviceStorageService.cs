using Newtonsoft.Json;
using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Models.Person;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        #endregion
    }
}
