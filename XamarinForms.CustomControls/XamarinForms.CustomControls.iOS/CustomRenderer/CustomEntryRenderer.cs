using System.ComponentModel;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinForms.CustomControls.Entry;
using XamarinForms.CustomControls.iOS.CustomRenderer;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace XamarinForms.CustomControls.iOS.CustomRenderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        #region Properties

        private UIColor BorderColor = UIColor.Black;

        private int BorderWidth = 1;

        private Thickness TextPadding = new Thickness(0);

        #endregion

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = ((CustomEntry)sender);

            BorderColor = element.BorderColor.ToUIColor();

            BorderWidth = element.BorderWidth;

            TextPadding = element.TextPadding;

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = BorderWidth;
                Control.VerticalAlignment = UIControlContentVerticalAlignment.Center;
                Control.LeftView = new UIView(new CGRect(TextPadding.Left, TextPadding.Top, TextPadding.Right, TextPadding.Bottom));
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.TintColor = UIColor.Black;
                Control.Layer.BorderColor = BorderColor.CGColor;
                //Control.RightView = new UIView(new CGRect(0, 0, 15, 0));
                //Control.RightViewMode = UITextFieldViewMode.Always;
                //// Use tint color to change the cursor's color
                //Control.TintColor = UIColor.White;
            }
        }
    }
}