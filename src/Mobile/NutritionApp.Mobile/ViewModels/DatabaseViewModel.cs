using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    public class DatabaseViewModel : BaseViewModel
    {
        #region Fields

        private IList<NutritionItemCategorie> _nutritionItemCategories = new List<NutritionItemCategorie>();
        private IList<NutritionItem> _nutritionItems = new List<NutritionItem>();        
        private bool _isCategorieListViewVisible = true;
        private bool _isItemListViewVisible = false;

        private IList<object> _backBuffer = new List<object>();

        #endregion

        #region Properties

        public ICommand CategoriesClickedCommand => new Command(OnCategoriesClickedCommandExecute);
        public ICommand ItemClickedCommand => new Command(OnItemClickedCommandExecute);

        public bool IsCategorieListViewVisible
        {
            get { return _isCategorieListViewVisible; }
            set { SetProperty(ref _isCategorieListViewVisible, value); }
        }

        public bool IsItemListViewVisible
        {
            get { return _isItemListViewVisible; }
            set { SetProperty(ref _isItemListViewVisible, value); }
        }

        public IList<NutritionItemCategorie> NutritionItemCategories 
        {
            get { return _nutritionItemCategories; }
            set { SetProperty(ref _nutritionItemCategories, value); }
        }

        public IList<NutritionItem> NutritionItems
        {
            get { return _nutritionItems; }
            set { SetProperty(ref _nutritionItems, value); }
        }
               
        #endregion


        #region Constructors

        public DatabaseViewModel()
        {
            Title = "DATABASE";

            Task.Run(() => LoadCategorieData());
        }

        #endregion

        #region Methods

        public override bool OnBackButtonPressed()
        {            
            if (_backBuffer.Count == 1)
            {
                // If there is only one item left, load the highest categories
                _backBuffer.RemoveAt(_backBuffer.Count-1);
                Task.Run(LoadCategorieData);
                IsItemListViewVisible = false;
                IsCategorieListViewVisible = true;
                return true;
            }
            else if (_backBuffer.Count >= 2)
            {
                _backBuffer.RemoveAt(_backBuffer.Count - 1);
                LoadItemList(_backBuffer.Last());                
                return true;               
            }

            return base.OnBackButtonPressed();
        }

        private void OnItemClickedCommandExecute(object param)
        {
            int id = Convert.ToInt32(param);
        }

        private void OnCategoriesClickedCommandExecute(object param)
        {   
            // Put the clicked item in the buffer
            int id = Convert.ToInt32(param);
            NutritionItemCategorie item = _nutritionItemCategories.Where((x) => x.ID == id).FirstOrDefault();
            _backBuffer.Add(item);
            LoadItemList(item);
        }

        private void LoadItemList(object item)
        {
            NutritionItemCategorie categorieItem = item as NutritionItemCategorie;
            NutritionItem nutritionItem = item as NutritionItem;

            if (categorieItem != null)
            {
                if (categorieItem.ListOfSubCategories.Count >= 1)
                {
                    // If there are sub categories in the list, show them                    
                    NutritionItemCategories = categorieItem.ListOfSubCategories;
                    IsItemListViewVisible = false;
                    IsCategorieListViewVisible = true;
                }
                else
                {                    
                    // If there are no more categories, show the nutrition items
                    Task.Run(() => LoadNutritionItems(categorieItem.ListOfNutritionItemIDs));
                    IsItemListViewVisible = true;
                    IsCategorieListViewVisible = false;
                }
            }
            else if (nutritionItem != null)
            {
                // Show detail page of item
                // Add to navigation stack
            }
        }

        private async Task LoadNutritionItems(IList<int> ids)
        {
            NutritionItems = await NutritionDataService.GetItemsAsync(DateTime.MinValue, ids);
        }

        /// <summary>
        /// Load the categories where the id is in.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task LoadCategorieData()
        {
            NutritionItemCategories = await NutritionDataService.GetCategoriesAsync();
        }

        #endregion
    }
}
