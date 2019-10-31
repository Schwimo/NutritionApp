using NutritionApp.Mobile.Services.DeviceStorage;
using NutritionApp.Mobile.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionApp.Mobile.Services.DataServices.Core
{
    public class BaseDataService
    {
        #region Fields

        #endregion

        #region Properties

        public IDeviceStorageService DeviceStorageService { get; }

        #endregion

        #region Constructor

        public BaseDataService()
        {
            DeviceStorageService = ViewModelLocator.Resolve<IDeviceStorageService>();
        }

        #endregion

    }
}
