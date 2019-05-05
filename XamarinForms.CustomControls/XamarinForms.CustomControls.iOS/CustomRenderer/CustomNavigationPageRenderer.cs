using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinForms.CustomControls.Enums;
using XamarinForms.CustomControls.iOS.CustomRenderer;
using XamarinForms.CustomControls.NavigationPage;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace XamarinForms.CustomControls.iOS.CustomRenderer
{
    public class CustomNavigationPageRenderer: NavigationRenderer
    {

        #region Properties

        private string FontFamily = string.Empty;

        private float TitleFontSize = 0;

        private HorizontalAlignment TitleHorizontalAlignment = HorizontalAlignment.Left;

        private FontAttributes TitleFontAttributes = Enums.FontAttributes.Normal;

        #endregion

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var page = (CustomNavigationPage)e.NewElement;

                FontFamily = page.TitleFontFamily;

                TitleHorizontalAlignment = page.TitleHorizontalAlignment;

                TitleFontAttributes = page.TitleFontAttributes;

                TitleFontSize = page.TitleFontSize;
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            var att = new UITextAttributes
            {
                Font = UIFont.FromName(FontFamily, TitleFontSize)
            };

            UINavigationBar.Appearance.SetTitleTextAttributes(att);

            var label = new UILabel
            {
                Text = NavigationController.NavigationBar.TopItem.Title,
                TextAlignment = ConvertAligntment(TitleHorizontalAlignment),
                Font = UIFont.FromName(FontFamily, TitleFontSize)
            };

            label.SizeToFit();

            NavigationController.NavigationBar.TopItem.Title = "";
            NavigationController.NavigationBar.TopItem.LeftBarButtonItem = new UIBarButtonItem(label);
        }

        private UITextAlignment ConvertAligntment(HorizontalAlignment alignment)
        {
            if (alignment == HorizontalAlignment.Center)
            {
                return UITextAlignment.Center;
            }
            else if (alignment == HorizontalAlignment.Left)
            {
                return UITextAlignment.Left;
            }
            else
            {
                return UITextAlignment.Center;
            }
        }
    }
}