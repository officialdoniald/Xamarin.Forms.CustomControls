using Xamarin.Forms;

namespace XamarinForms.CustomControls.ListView
{
    public class CustomTextCell : TextCell
    {
        public static readonly BindableProperty TextFontSizeProperty =
            BindableProperty.Create("TextFontSize", typeof(double), typeof(CustomTextCell), default(double));

        public static readonly BindableProperty DetailFontSizeProperty =
           BindableProperty.Create("DetailFontSize", typeof(double), typeof(CustomTextCell), default(double));

        public static readonly BindableProperty TextFontAttributesProperty =
           BindableProperty.Create("TextFontAttributes", typeof(Enums.FontAttributes), typeof(CustomTextCell), default(Enums.FontAttributes));

        public static readonly BindableProperty TextFontFamilyProperty =
           BindableProperty.Create("TextFontFamily", typeof(string), typeof(CustomTextCell), default(string));

        public static readonly BindableProperty DetailFontAttributesProperty =
           BindableProperty.Create("DetailFontAttributes", typeof(Enums.FontAttributes), typeof(CustomTextCell), default(Enums.FontAttributes));

        public static readonly BindableProperty DetailFontFamilyProperty =
           BindableProperty.Create("DetailFontFamily", typeof(string), typeof(CustomTextCell), default(string));

        /// <summary>
        /// Set the Text font size.
        /// </summary>
        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        /// <summary>
        /// Set the Detail font size.
        /// </summary>
        public double DetailFontSize
        {
            get { return (double)GetValue(DetailFontSizeProperty); }
            set { SetValue(DetailFontSizeProperty, value); }
        }

        /// <summary>
        /// Set the Font Attributes of the Text.
        /// </summary>
        public Enums.FontAttributes TextFontAttributes
        {
            get { return (Enums.FontAttributes)GetValue(TextFontAttributesProperty); }
            set { SetValue(TextFontAttributesProperty, value); }
        }

        /// <summary>
        /// Set the Font Family of the Text.
        /// </summary>
        public string TextFontFamily
        {
            get { return (string)GetValue(TextFontFamilyProperty); }
            set { SetValue(TextFontFamilyProperty, value); }
        }

        /// <summary>
        /// Set the Font Attributes of the Detail.
        /// </summary>
        public Enums.FontAttributes DetailFontAttributes
        {
            get { return (Enums.FontAttributes)GetValue(DetailFontAttributesProperty); }
            set { SetValue(DetailFontAttributesProperty, value); }
        }

        /// <summary>
        /// Set the Font Family of the Detail.
        /// </summary>
        public string DetailFontFamily
        {
            get { return (string)GetValue(DetailFontFamilyProperty); }
            set { SetValue(DetailFontFamilyProperty, value); }
        }
    }
}