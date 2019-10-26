using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.ViewModels.Core;
using NutritionApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields

        private int _itemsCount = 0;
        private IList<NutritionItem> _nutritionItemDatabase = new List<NutritionItem>();

        #endregion

        #region Properties

        public ICommand ShowMoreCommand => new Command(async () => await OnShowMoreCommandExecute());
         
        public IList<NutritionItem> NutritionItemDatabase
        {
            get { return _nutritionItemDatabase; }
            set { SetProperty(ref _nutritionItemDatabase, value); }
        }

        public int ItemsCount
        {
            get { return _itemsCount; }
            set { SetProperty(ref _itemsCount, value); }
        }        

        #endregion

        #region Constructors

        public MainViewModel()
        {
            Title = "HOME";
        }

        #endregion

        #region Methods

        public override void OnAppearing()
        {
            Task.Run(LoadDatabaseItems);
            base.OnAppearing();
        }

        private async Task LoadDatabaseItems()
        {
            if (ItemsCount > 0)
            {
                return;
            }
            
            NutritionItemDatabase = await NutritionDataService.GetItemsAsync(DateTime.MinValue) as IList<NutritionItem>;
            ItemsCount = NutritionItemDatabase.Count;
        }

        private async Task OnShowMoreCommandExecute()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
        }

        #endregion
    }
}
