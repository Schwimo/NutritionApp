using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabasePage : ContentPage
    {
        public DatabasePage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if (this.BindingContext == null ||
                (this.BindingContext as BaseViewModel) == null)
            {
                return base.OnBackButtonPressed();
            }
            
            if ((this.BindingContext as BaseViewModel).OnBackButtonPressed())
            {
                return true;
            }

            return base.OnBackButtonPressed();
        }
    }
}