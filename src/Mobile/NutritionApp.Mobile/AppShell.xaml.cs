using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NutritionApp.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TODO: Show a message 
        /// "Pressing again will close the app"
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
            //return base.OnBackButtonPressed();
        }
    }
}
