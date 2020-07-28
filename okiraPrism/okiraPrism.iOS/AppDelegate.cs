using Syncfusion.XForms.iOS.Cards;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Buttons;
using Foundation;
using Prism;
using Prism.Ioc;
using UIKit;


namespace okiraPrism.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk0MzM1QDMxMzgyZTMyMmUzMFpxdlRGMkx2UXhYZ01HMFF3SzhNUU16dVdKT3B5S0ZDUTY2OUxJQ3Q2K0E9;Mjk0MzM2QDMxMzgyZTMyMmUzMFZSYkJNTE1BL0w4ZFBvbWQ4OVBseUJ2L080UWo1dVRIMDF1NC9YK08vcnM9");

            global::Xamarin.Forms.Forms.Init();
            SfCardViewRenderer.Init();
            SfRatingRenderer.Init();
            SfBorderRenderer.Init();
            Core.Init();
            SfListViewRenderer.Init();
            SfButtonRenderer.Init();
            Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
