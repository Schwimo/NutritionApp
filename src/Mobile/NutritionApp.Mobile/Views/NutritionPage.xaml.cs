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
    public partial class NutritionPage : ContentPage
    {
        public NutritionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            (this.BindingContext as BaseViewModel).OnAppearing();
            base.OnAppearing();
        }
    }
}