using Android.Graphics;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinForms.CustomControls.Droid.CustomRenderer;
using XamarinForms.CustomControls.ListView;

[assembly: ExportRenderer(typeof(CustomTextCell), typeof(CustomTextCellRenderer))]
namespace XamarinForms.CustomControls.Droid.CustomRenderer
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        private Android.Views.View _cellCore;

        public CustomTextCellRenderer() : base() { }

        public CustomTextCellRenderer(System.IntPtr a, Android.Runtime.JniHandleOwnership b) : base() { }
        
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Android.Content.Context context)
        {
            var view = (CustomTextCell)item;

            if (convertView == null)
            {
                convertView = new BaseCellView(context, item);
            }

            if (convertView is BaseCellView cellView)
            {
                cellView.SetImageVisible(false);

                cellView.MainText = view.Text;
                cellView.DetailText = view.Detail;

                cellView.SetMainTextColor(view.TextColor);
                cellView.SetDetailTextColor(view.DetailColor);

                var control = ((LinearLayout)convertView);
                if (control.GetChildAt(1) is LinearLayout linearLayout)
                {
                    var mainTextView = (TextView)linearLayout.GetChildAt(0);
                    var detailTextView = (TextView)linearLayout.GetChildAt(1);

                    mainTextView.TextSize = (float)view.TextFontSize;
                    detailTextView.TextSize = (float)view.DetailFontSize;
                    var titleTypeface = Typeface.Create(view.TextFontFamily, ConvertFontAttributesToTypefaceStyle(view.TextFontAttributes));
                    var detailTypeface = Typeface.Create(view.DetailFontFamily, ConvertFontAttributesToTypefaceStyle(view.DetailFontAttributes));
                    mainTextView.Typeface = titleTypeface;
                    detailTextView.Typeface = detailTypeface;
                }
            }

            return _cellCore = convertView;
        }

        private TypefaceStyle ConvertFontAttributesToTypefaceStyle(Enums.FontAttributes fontAttributes)
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
}