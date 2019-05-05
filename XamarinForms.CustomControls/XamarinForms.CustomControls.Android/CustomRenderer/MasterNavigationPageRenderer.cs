using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Widget;
using Plugin.CurrentActivity;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using XamarinForms.CustomControls.Droid.CustomRenderer;
using XamarinForms.CustomControls.MasterDetailPage;

[assembly: ExportRenderer(typeof(CustomMasterDetailPage), typeof(MasterNavigationPageRenderer))]
namespace XamarinForms.CustomControls.Droid.CustomRenderer
{
#pragma warning disable CS0618
    public class MasterNavigationPageRenderer : MasterDetailPageRenderer
    {
        private static Android.Support.V7.Widget.Toolbar GetToolbar() => (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

        private Android.Support.V7.Widget.Toolbar toolbar;

        public MasterNavigationPageRenderer() : base() { }

        public MasterNavigationPageRenderer(Context context) : base(context) { }

        public MasterNavigationPageRenderer(IntPtr a, JniHandleOwnership b) : base() { }

        //protected override void OnLayout(bool changed, int l, int t, int r, int b)
        //{
        //    base.OnLayout(changed, l, t, r, b);
        //    toolbar = GetToolbar();

        //    if (toolbar != null)
        //    {
        //        //if (GlobalSetting.Instance.NavigationStackCount == 1)
        //        //{
        //        //    SetNavigationButton(Resource.Drawable.menu);
        //        //}
        //        //else
        //        //{
        //        //    SetNavigationButton(Resource.Drawable.back);
        //        //}
        //    }
        //}

        //private void SetNavigationButton(int resourceID)
        //{
        //    var icon = Forms.Context.GetDrawable(resourceID);
        //    using (var drawable = ((BitmapDrawable)icon).Bitmap)
        //    using (var bitmap = Bitmap.CreateScaledBitmap(drawable, 80, 80, false))
        //    using (var newDrawable = new BitmapDrawable(Resources, bitmap))
        //    {
        //        toolbar.NavigationIcon = newDrawable;
        //    }
        //}
    }
#pragma warning restore CS0618
}