using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    public class NutritionViewModel : BaseViewModel
    {
        #region Fields

        private DateTime _activeDate;
        private double _kcalProgress;

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

        public ICommand PreviousDayCommand => new Command(OnPreviousDayCommandExecute);
        public ICommand NextDayCommand => new Command(OnNextDayCommandExecute);

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the NutritionViewModel class.
        /// </summary>
        public NutritionViewModel()
        {
            Title = "NUTRITION DIARY";
            _kcalProgress = 0.3;
            ActiveDate = DateTime.UtcNow;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is called from the code behind of the pages.
        /// It is used to load some data when the page is appearing.
        /// </summary>
        public override void OnAppearing()
        {
                        
        }

        private void OnPreviousDayCommandExecute()
        {

        }

        private void OnNextDayCommandExecute()
        {

        }

        #endregion
    }
}
