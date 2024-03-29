﻿using NutritionApp.Mobile.Services.DataService.Nutrition;
using NutritionApp.Mobile.Services.DeviceStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NutritionApp.Mobile.ViewModels.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Fields

        bool isBusy = false;
        string title = string.Empty;

        private readonly INutritionDataService _nutritionDataService;
        
        #endregion

        #region Properties

        /// <summary>
        /// Get the NutritionDataService
        /// </summary>
        public INutritionDataService NutritionDataService => _nutritionDataService;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        #endregion

        #region Constructors

        public BaseViewModel()
        {
            _nutritionDataService = ViewModelLocator.Resolve<INutritionDataService>();
        }

        #endregion

        #region Methods

        public virtual void OnNavigatingTo(object param)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual bool OnBackButtonPressed()
        {
            return false;
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
