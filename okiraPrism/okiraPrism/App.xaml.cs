using Prism;
using Prism.Ioc;
using okiraPrism.ViewModels;
using okiraPrism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using okiraPrism.ViewModels.Catalog;
using okiraPrism.Views.Catalog;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace okiraPrism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk0MzM1QDMxMzgyZTMyMmUzMFpxdlRGMkx2UXhYZ01HMFF3SzhNUU16dVdKT3B5S0ZDUTY2OUxJQ3Q2K0E9;Mjk0MzM2QDMxMzgyZTMyMmUzMFZSYkJNTE1BL0w4ZFBvbWQ4OVBseUJ2L080UWo1dVRIMDF1NC9YK08vcnM9");

            InitializeComponent();

            AppCenter.Start("android=51e5e8d3-0489-435f-b045-167e1ab34efb;",
                typeof(Analytics), typeof(Crashes));

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ArticleCardPage, ArticleCardViewModel>();
        }

        #region Properties

        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        #endregion
    }
}
