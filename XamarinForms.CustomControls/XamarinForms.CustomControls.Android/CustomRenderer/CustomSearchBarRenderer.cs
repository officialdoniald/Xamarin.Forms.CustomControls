using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinForms.CustomControls.Droid.CustomRenderer;
using XamarinForms.CustomControls.SearchBar;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace XamarinForms.CustomControls.Droid.CustomRenderer
{
#pragma warning disable CS0618
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        #region Properties

        private Android.Graphics.Color BorderColor = Android.Graphics.Color.Transparent;

        private int BorderWidth = 1;

        #endregion

        #region Konstruktor

        public CustomSearchBarRenderer() : base() { }

        public CustomSearchBarRenderer(Context context) : base(context) { }

        public CustomSearchBarRenderer(IntPtr a, JniHandleOwnership b) : base() { }

        #endregion

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var newElement = ((CustomSearchBar)sender);

            BorderColor = newElement.BorderColor.ToAndroid();
            
            if (newElement.BorderWidth != 0)
            {
                BorderWidth = newElement.BorderWidth;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (Control != null)
            {
                var searchView = Control;
                searchView.Iconified = true;
                searchView.SetIconifiedByDefault(false);
                int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                var icon = searchView.FindViewById(searchIconId);

                //TODO: image bindolása
                //(icon as ImageView).SetImageResource(Resource.Drawable.searchbaricon);
            }

            LinearLayout linearLayout = this.Control.GetChildAt(0) as LinearLayout;
            linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
            linearLayout = linearLayout.GetChildAt(1) as LinearLayout;

            GradientDrawable gd = new GradientDrawable();
            gd.SetStroke(BorderWidth, BorderColor);

            linearLayout.Background = gd;

            AutoCompleteTextView textView = linearLayout.GetChildAt(0) as AutoCompleteTextView;
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}