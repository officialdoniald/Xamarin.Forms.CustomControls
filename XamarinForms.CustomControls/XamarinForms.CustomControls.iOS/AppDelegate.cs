using Foundation;
using UIKit;

namespace XamarinForms.CustomControls.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UITabBar.Appearance.BarTintColor = UIColor.White;
            UITabBar.Appearance.TintColor = UIColor.Black;
            UIProgressView.Appearance.TintColor = UIColor.LightTextColor;
            //var titleAttribute = new UITextAttributes { Font = GetFont(50) };
            //// Updates the ToolbarItem appearance.
            //UIBarButtonItem.Appearance.SetTitleTextAttributes(titleAttribute, UIControlState.Normal);
            //// Sets the NavigationBar title items. Also sets the format for TabbedPage tab items for some reason.
            //UINavigationBar.Appearance.SetTitleTextAttributes(titleAttribute);

            var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = new UIColor(red: 0.81f, green: 0.70f, blue: 0.67f, alpha: 1.0f);
                statusBar.TintColor = UIColor.White;
            }

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}