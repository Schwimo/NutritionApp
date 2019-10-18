using NutritionApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public ICommand ShowMoreCommand => new Command(async () => await OnShowMoreCommandExecute());
        
        public MainViewModel()
        {
            Title = "HOME";            
        }

        private async Task OnShowMoreCommandExecute()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
        }
    }
}
