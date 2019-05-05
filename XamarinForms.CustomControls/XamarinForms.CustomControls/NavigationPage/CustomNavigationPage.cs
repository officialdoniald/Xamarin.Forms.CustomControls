using Xamarin.Forms;
using XamarinForms.CustomControls.Enums;

namespace XamarinForms.CustomControls.NavigationPage
{
    public class CustomNavigationPage : Xamarin.Forms.NavigationPage
    {

        public CustomNavigationPage() : base() { }

        public CustomNavigationPage(Xamarin.Forms.Page page) : base(page) { }

        public static readonly BindableProperty TitleFontFamilyProperty =
           BindableProperty.Create("TitleFontFamily", typeof(string), typeof(Xamarin.Forms.NavigationPage), default(string));

        public static readonly BindableProperty TitleFontSizeProperty =
           BindableProperty.Create("TitleFontSize", typeof(float), typeof(Xamarin.Forms.NavigationPage), default(float));

        public static readonly BindableProperty TitleHorizontalAlignmentProperty =
           BindableProperty.Create("TitleHorizontalAlignment", typeof(HorizontalAlignment), typeof(Xamarin.Forms.NavigationPage), default(HorizontalAlignment));

        public static readonly BindableProperty TitleFontAttributesProperty =
           BindableProperty.Create("TitleFontAttributes", typeof(Enums.FontAttributes), typeof(Xamarin.Forms.NavigationPage), default(Enums.FontAttributes));

        /// <summary>
        /// Set the Horizontal Alignment of the Title.
        /// </summary>
        public HorizontalAlignment TitleHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(TitleHorizontalAlignmentProperty); }
            set { SetValue(TitleHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Set the Font Size of the Title.
        /// </summary>
        public float TitleFontSize
        {
            get { return (float)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        /// <summary>
        /// Set the Font Family of the Title.
        /// </summary>
        public string TitleFontFamily
        {
            get { return (string)GetValue(TitleFontFamilyProperty); }
            set { SetValue(TitleFontFamilyProperty, value); }
        }

        /// <summary>
        /// Set the Font Attributes of the Title.
        /// </summary>
        public Enums.FontAttributes TitleFontAttributes
        {
            get { return (Enums.FontAttributes)GetValue(TitleFontAttributesProperty); }
            set { SetValue(TitleFontAttributesProperty, value); }
        }
    }
}