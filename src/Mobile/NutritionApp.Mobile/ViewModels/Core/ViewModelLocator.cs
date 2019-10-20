using Autofac;
using NutritionApp.Mobile.Models.Nutrition;
using NutritionApp.Mobile.Services;
using NutritionApp.Mobile.Services.DataService;
using NutritionApp.Mobile.Services.DataService.Core;
using NutritionApp.Mobile.Services.DataService.Nutrition;
using NutritionApp.Mobile.Services.DataService.Nutrition.Core;
using NutritionApp.Mobile.Services.DataService.Person.Core;
using NutritionApp.Mobile.Services.DeviceStorage;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace NutritionApp.Mobile.ViewModels.Core
{
    public class ViewModelLocator
    {
        #region Fields

        private static IContainer _container;
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        #endregion
        
        #region Properties
        public static bool UseMockService { get; set; }

        #endregion

        #region Constructors

        public ViewModelLocator()
        {
            UseMockService = true;
            RegisterDependencies(UseMockService);
        }

        #endregion

        #region Methods

        public static void RegisterDependencies(bool useMockServices)
        {
            var builder = new ContainerBuilder();

            // View models
            builder.RegisterType<MainViewModel>();            
            builder.RegisterType<AboutViewModel>();
            builder.RegisterType<NutritionViewModel>();
            builder.RegisterType<BodyViewModel>();

            // Services                        
            
            if (useMockServices)
            {
                // Register mock services for testing
                UseMockService = true;
                builder.RegisterType<MockNutritionDataStore>().As<INutritionDataService>().SingleInstance();
                builder.RegisterType<MockPersonDataStore>().As<IBodyDataService>().SingleInstance();
                builder.RegisterType<MockPersonDataStore>().As<IPersonDataService>().SingleInstance();
                builder.RegisterType<MockPersonDataStore>().As<IWeightDataService>().SingleInstance();

                //builder.RegisterType<NutritionServiceMock>().As<INutritionService>().SingleInstance();
                //builder.RegisterType<PersonServiceMock>().As<IPersonService>().SingleInstance();
            }
            else
            {
                // Register real services
                UseMockService = false;

                //builder.RegisterType<NutritionService>().As<INutritionService>().SingleInstance();
                //builder.RegisterType<PersonService>().As<IPersonService>().SingleInstance();
            }

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.").Replace("Page", "");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}ViewModel, {1}", viewName, viewAssemblyName);

            Type viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        #endregion        
    }
}

