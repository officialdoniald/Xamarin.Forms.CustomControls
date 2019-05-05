using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.V7.Graphics.Drawable;
using Android.Util;
using Android.Widget;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinForms.CustomControls.Droid.CustomRenderer;
using XamarinForms.CustomControls.Enums;
using XamarinForms.CustomControls.NavigationPage;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustonNavigationPageRenderer))]
namespace XamarinForms.CustomControls.Droid.CustomRenderer
{
#pragma warning disable CS0618
    public class CustonNavigationPageRenderer : Xamarin.Forms.Platform.Android.AppCompat.NavigationPageRenderer
    {
        #region Properties

        private static Android.Support.V7.Widget.Toolbar GetToolbar() => (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

        private Android.Support.V7.Widget.Toolbar toolbar;

        private Page view;

        private string FontFamily = string.Empty;

        private float TitleFontSize = 0;

        private HorizontalAlignment TitleHorizontalAlignment = HorizontalAlignment.Left;

        private Enums.FontAttributes TitleFontAttributes = Enums.FontAttributes.Normal;

        #endregion

        #region Kontruktor

        public CustonNavigationPageRenderer() : base() { }

        public CustonNavigationPageRenderer(Context context) : base(context) { }

        public CustonNavigationPageRenderer(IntPtr a, JniHandleOwnership b) : base() { }

        #endregion

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var page = (CustomNavigationPage)sender;

            FontFamily = page.TitleFontFamily;

            TitleHorizontalAlignment = page.TitleHorizontalAlignment;

            TitleFontAttributes = page.TitleFontAttributes;

            TitleFontSize = page.TitleFontSize;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            SetTitle();
            
            //if (view is LoginPage || view is PasswordResetPage || view is RegisterPage || view is SMSPage)
            //{
            //    SetIcon();
            //}
        }

        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            var retVal = base.OnPushAsync(view, animated);

            //GlobalSetting.Instance.NavigationStackCount = view.Navigation.NavigationStack.Count;

            this.view = view;

            return retVal;
        }

        protected override Task<bool> OnPopToRootAsync(Page page, bool animated)
        {
            var retVal = base.OnPopToRootAsync(page, animated);

            //GlobalSetting.Instance.NavigationStackCount = page.Navigation.NavigationStack.Count - 1;

            view = page;

            return retVal;
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            var retVal = base.OnPopViewAsync(page, animated);

            //GlobalSetting.Instance.NavigationStackCount = page.Navigation.NavigationStack.Count - 1;

            view = page;

            return retVal;
        }

        private void SetTitle()
        {
            toolbar = GetToolbar();

            if (toolbar != null)
            {
                for (var i = 0; i < toolbar.ChildCount; i++)
                {
                    var Title = toolbar.GetChildAt(i);

                    if (Title is TextView)
                    {
                        var title = toolbar.GetChildAt(i) as TextView;

                        if (TitleHorizontalAlignment == HorizontalAlignment.Center)
                        {
                            //Title in center
                            float toolbarCenter = toolbar.Width / 2;
                            float titleCenter = title.Width / 2;
                            title.SetX(toolbarCenter - titleCenter);
                        }

                        //Title Font "HelveticaNeueLTStd"
                        if (!string.IsNullOrEmpty(FontFamily))
                        {
                            var typeface = Typeface.Create(FontFamily, ConvertFontAttributesToTypefaceStyle(TitleFontAttributes));
                            title.Typeface = typeface;
                        }

                        if (TitleFontSize != 0)
                        {
                            title.TextSize = TitleFontSize;
                        }
                    }
                }
            }
        }

        private void SetIcon()
        {
            toolbar = GetToolbar();

            if (toolbar != null)
            {
                //if (GlobalSetting.Instance.NavigationStackCount == 1)
                //{
                //    //SetNavigationButton(Resource.Drawable.menu);
                //}
                //else
                //{
                //    SetNavigationButton(Resource.Drawable.back);
                //}
            }
        }
        
        private void SetNavigationButton(int resourceID)
        {
            var icon = Forms.Context.GetDrawable(resourceID);
            using (var drawable = ((BitmapDrawable)icon).Bitmap)
            using (var bitmap = Bitmap.CreateScaledBitmap(drawable, 80, 80, false))
            using (var newDrawable = new BitmapDrawable(Resources, bitmap))
            {
                toolbar.NavigationIcon = newDrawable;
            }
        }

        private Android.Graphics.TypefaceStyle ConvertFontAttributesToTypefaceStyle(Enums.FontAttributes fontAttributes)
        {
            if (fontAttributes == Enums.FontAttributes.Bold)
            {
                return Android.Graphics.TypefaceStyle.Bold;
            }
            else if (fontAttributes == Enums.FontAttributes.BoldItalic)
            {
                return Android.Graphics.TypefaceStyle.BoldItalic;
            }
            else if (fontAttributes == Enums.FontAttributes.Italic)
            {
                return Android.Graphics.TypefaceStyle.Italic;
            }
            else return Android.Graphics.TypefaceStyle.Normal;
        }
    }
#pragma warning restore CS0618
}