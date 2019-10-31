using NutritionApp.Core.Models.Nutrition;
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
    public class NutritionItemDetailsViewModel : BaseViewModel
    {
        #region Fields

        public NutritionItem _item;

        #endregion

        #region Porperties

        /// <summary>
        /// The NutritionItem to display.
        /// </summary>
        public NutritionItem Item
        {
            get { return _item; }
            set
            {
                SetProperty(ref _item, value);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the NutritionViewModel class.
        /// </summary>
        public NutritionItemDetailsViewModel()
        {            
        }

        #endregion

        #region Methods

        public override void OnNavigatingTo(object param)
        {
            var item = param as NutritionItem;

            if (item == null)
            {
                return;
            }

            Item = item;
            Title = Item.Name;
        }

        /// <summary>
        /// This method is called from the code behind of the pages.
        /// It is used to load some data when the page is appearing.
        /// </summary>
        public override void OnAppearing()
        {   
        }

        #endregion
    }
}
