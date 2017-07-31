using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Gratitude.Data;
namespace Gratitude.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Constants.DB_FILE_PATH = Helper.GetLocalFilePath(Constants.DB_FILE_NAME);
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
