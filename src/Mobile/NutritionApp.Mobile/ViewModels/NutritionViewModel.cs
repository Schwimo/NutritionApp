using NutritionApp.Core.Models.Nutrition;
using NutritionApp.Mobile.Services.DataService;
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

        private IList<NutritionDiaryItem> _listOfNutritionDiaryItems = new List<NutritionDiaryItem>();

        private INutritionDiaryDataService NutritionDiaryDataService;

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

        public IList<NutritionDiaryItem> ListOfNutritionDiaryItems
        {
            get { return _listOfNutritionDiaryItems; }
            set { SetProperty(ref _listOfNutritionDiaryItems, value); }
        }

        public ICommand PreviousDayCommand => new Command(OnPreviousDayCommandExecute);
        public ICommand NextDayCommand => new Command(OnNextDayCommandExecute);
        public ICommand AddNutritionDiaryItemCommand => new Command(OnAddNutritionDiaryItemCommandExecute);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the NutritionViewModel class.
        /// </summary>
        public NutritionViewModel()
        {
            Title = "NUTRITION DIARY";
            NutritionDiaryDataService = ViewModelLocator.Resolve<INutritionDiaryDataService>();
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
            Task.Run(async () => await LoadNutritionDiaryItemsForDate(ActiveDate));

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
        private async Task LoadNutritionDiaryItemsForDate(DateTime date)
        {
            ListOfNutritionDiaryItems = await NutritionDiaryDataService.GetItemsAsync(date);
        }

        /// <summary>
        /// Get the data of the prevoious day
        /// </summary>
        private void OnPreviousDayCommandExecute()
        {
            // Calcualtes the prevous day date
            ActiveDate = ActiveDate.AddDays(-1);

            Task.Run(async () => await LoadNutritionDiaryItemsForDate(ActiveDate));
            UpdateNutritionDetails();
        }

        /// <summary>
        /// Get the data of the next day
        /// </summary>
        private void OnNextDayCommandExecute()
        {
            // Calcualtes the prevous day date
            ActiveDate = ActiveDate.AddDays(1);

            Task.Run(async () => await LoadNutritionDiaryItemsForDate(ActiveDate));
            UpdateNutritionDetails();
        }

        /// <summary>
        /// Adds a new nutrition item to the nutrition diary of the person
        /// </summary>
        private void OnAddNutritionDiaryItemCommandExecute()
        {

        }

        #endregion
    }
}
