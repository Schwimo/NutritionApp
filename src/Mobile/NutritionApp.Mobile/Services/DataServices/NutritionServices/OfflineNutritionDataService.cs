using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.Services.DataServices.Core;
using NutritionApp.Mobile.Services.DeviceStorage;
using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NutritionApp.Mobile.Services.DataService.Nutrition
{
    /// <summary>
    /// The OfflineNutritionDataService checks if there is a local database file on
    /// your device. If not it loads an db file which is delivered with the app.
    /// </summary>
    public class OfflineNutritionDataService : BaseDataService, INutritionDataService
    {
        #region Fields

        private IList<NutritionItem> _nutritionItems;
        private IList<NutritionItemCategorie> _categorieItems;
        private readonly IDeviceStorageService _deviceStorageService;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor of the OfflineNutritionDataService
        /// </summary>
        public OfflineNutritionDataService()
        {
            _deviceStorageService = ViewModelLocator.Resolve<IDeviceStorageService>();

            // Check for offline database files.
            _nutritionItems = _deviceStorageService.ReadNutritionItems() as IList<NutritionItem>;
            _categorieItems = _deviceStorageService.ReadNutritionCategories() as IList<NutritionItemCategorie>;

            if (_nutritionItems == null || _nutritionItems.Count() <= 0)
            {
                LoadDefaultDatabase();
                _deviceStorageService.WriteNutritionItems(_nutritionItems);
                _deviceStorageService.WriteNutritionCategories(_categorieItems);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// There is a database file which is delivered with the app.
        /// Use this to load the initial state for the database.
        /// </summary>
        private void LoadDefaultDatabase()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(NutritionItem)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("NutritionApp.Core.Database.db.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
                var split = text.Split(';');

                _nutritionItems = JsonConvert.DeserializeObject<List<NutritionItem>>(split[0]);
                _categorieItems = JsonConvert.DeserializeObject<List<NutritionItemCategorie>>(split[1]);
            }
        }

        /// <summary>
        /// If anything changes with item(s) 
        /// the local file has to be updated
        /// </summary>
        private void UpdateLocalFiles()
        {
            _deviceStorageService.WriteNutritionCategories(_categorieItems);
            _deviceStorageService.WriteNutritionItems(_nutritionItems);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add an item to the list and then to the offline file.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> AddItemAsync(NutritionItem item)
        {
            _nutritionItems.Add(item);
            await Task.Run(() => UpdateLocalFiles());
            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update a NutritionItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(NutritionItem item)
        {
            var oldItem = _nutritionItems.Where((NutritionItem arg) => arg.ID == item.ID).FirstOrDefault();
            _nutritionItems.Remove(oldItem);
            _nutritionItems.Add(item);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Delete a NutritionItem
        /// /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _nutritionItems.Where((NutritionItem arg) => arg.ID.Equals(id)).FirstOrDefault();
            _nutritionItems.Remove(oldItem);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Get a NutritionItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<NutritionItem> GetItemAsync(string id)
        {
            return await Task.FromResult(_nutritionItems.FirstOrDefault(s => s.ID.Equals(id)));
        }

        /// <summary>
        /// Get NutritionItems with constraints
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ids"></param>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IList<NutritionItem>> GetItemsAsync(DateTime date, IList<int> ids = null, bool forceRefresh = false)
        {
            if (ids != null)
            {
                var items = _nutritionItems.Where((x) => ids.Contains(x.ID)).ToList();
                return await Task.FromResult(items);
            }
            else
            {
                return await Task.FromResult(_nutritionItems);
            }
        }

        /// <summary>
        /// Get the categories
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IList<NutritionItemCategorie>> GetCategoriesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_categorieItems);
        }

        #endregion
    }
}
