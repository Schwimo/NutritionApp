using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    /// <summary>
    /// The NutritionViewModel stores the logic for one day of 
    /// the nutriotion diary.
    /// </summary>
    public class NutritionViewModel : BaseViewModel
    {
        #region Fields

        private DateTime _activeDate;
        private double _kcalProgress;

        private IList<NutritionItem> _listOfNutritionItems = new List<NutritionItem>();

        #endregion

        #region Porperties
                
        public DateTime ActiveDate
        {
            get { return _activeDate; }
            set { SetProperty(ref _activeDate, value); }
        }

        public double KcalProgress
        {
            get { return _kcalProgress; }
            set { SetProperty(ref _kcalProgress, value); }
        }

        public IList<NutritionItem> ListOfNutritionItems
        {
            get { return _listOfNutritionItems; }
            set { SetProperty(ref _listOfNutritionItems, value); }
        }

        public ICommand PreviousDayCommand => new Command(OnPreviousDayCommandExecute);
        public ICommand NextDayCommand => new Command(OnNextDayCommandExecute);
        public ICommand AddNutritionItemCommand => new Command(OnAddNutritionItemCommandExecute);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the NutritionViewModel class.
        /// </summary>
        public NutritionViewModel()
        {
            Title = "NUTRITION DIARY";                  
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called from the code behind of the pages.
        /// It is used to load some data when the page is appearing.
        /// </summary>
        public override void OnAppearing()
        {            
            long todayAsBinary = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).ToBinary();

            if (ActiveDate != null && ActiveDate.ToBinary() == todayAsBinary)
            {
                return;
            }

            ActiveDate = new DateTime(todayAsBinary);

            // Load the nutrition items for the date
            Task.Run(async () => await LoadNutritionItemsForDate(ActiveDate));

            // Set the progress bar etc.
            UpdateNutritionDetails();
        }

        private void UpdateNutritionDetails()
        {

        }

        /// <summary>
        /// Load the nutrition items for a specific date.
        /// </summary>
        /// <param name="date"></param>
        private async Task LoadNutritionItemsForDate(DateTime date)
        {
            ListOfNutritionItems = await NutritionDataService.GetItemsAsync(date) as IList<NutritionItem>;
        }

        /// <summary>
        /// Get the data of the prevoious day
        /// </summary>
        private void OnPreviousDayCommandExecute()
        {
            // Calcualtes the prevous day date
            ActiveDate = ActiveDate.AddDays(-1);

            Task.Run(async () => await LoadNutritionItemsForDate(ActiveDate));
            UpdateNutritionDetails();
        }

        /// <summary>
        /// Get the data of the next day
        /// </summary>
        private void OnNextDayCommandExecute()
        {
            // Calcualtes the prevous day date
            ActiveDate = ActiveDate.AddDays(1);

            Task.Run(async () => await LoadNutritionItemsForDate(ActiveDate));
            UpdateNutritionDetails();
        }

        /// <summary>
        /// Adds a new nutrition item to the nutrition diary of the person
        /// </summary>
        private void OnAddNutritionItemCommandExecute()
        {

        }

        #endregion
    }
}
