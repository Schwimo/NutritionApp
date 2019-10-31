using NutritionApp.Mobile.ViewModels;
using NutritionApp.Mobile.ViewModels.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutritionApp.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
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