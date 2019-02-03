using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ProjectMVVM.iOS.Service;
using UIKit;

namespace ProjectMVVM.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            App appInstance = new App();
            LoadApplication(appInstance);

            appInstance.LocationService = new iOSLocationService();

            return base.FinishedLaunching(app, options);
        }
    }
}
