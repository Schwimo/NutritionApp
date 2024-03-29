﻿using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "ABOUT";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}