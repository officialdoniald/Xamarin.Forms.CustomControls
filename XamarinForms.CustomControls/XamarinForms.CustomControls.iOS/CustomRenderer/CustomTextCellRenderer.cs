using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinForms.CustomControls.iOS.CustomRenderer;
using XamarinForms.CustomControls.ListView;

[assembly: ExportRenderer(typeof(CustomTextCell), typeof(CustomTextCellRenderer))]
namespace XamarinForms.CustomControls.iOS.CustomRenderer
{
    public class CustomTextCellRenderer : TextCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var view = (CustomTextCell)item;

            var cell = base.GetCell(item, reusableCell, tv);

            //cell.SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Red };
            var TextLabel = cell.TextLabel;
            var DetailTextLabel = cell.DetailTextLabel;

            TextLabel.Font = UIFont.FromName(view.TextFontFamily, (int)view.TextFontSize);
            DetailTextLabel.Font = UIFont.FromName(view.DetailFontFamily, (int)view.DetailFontSize);

            TextLabel.AttributedText = ConvertAttributes(TextLabel.Text, view.TextFontAttributes, (int)view.TextFontSize);
            DetailTextLabel.AttributedText = ConvertAttributes(DetailTextLabel.Text, view.DetailFontAttributes, (int)view.DetailFontSize);

            return cell;
        }

        private NSMutableAttributedString ConvertAttributes(string text, Enums.FontAttributes attr, int size)
        {
            if (attr == Enums.FontAttributes.Bold)
            {
                return new NSMutableAttributedString(
                   str: text,
                   font: UIFont.BoldSystemFontOfSize(size)
                   );
            }
            else if (attr == Enums.FontAttributes.Italic)
            {
                return new NSMutableAttributedString(
                   str: text,
                   font: UIFont.ItalicSystemFontOfSize(size)
                   );
            }
            //else if (attr == Enums.FontAttributes.BoldItalic)
            //{
            //    var textattr = new NSMutableAttributedString(
            //       str: text,
            //       font: UIFont.BoldSystemFontOfSize(size)
            //       );

            //    textattr.Append(new NSMutableAttributedString(
            //       str: text,
            //       font: UIFont.ItalicSystemFontOfSize(size)
            //       ));

            //    return textattr;
            //}
            else
            {
                return new NSMutableAttributedString(
                   str: text,
                   font: UIFont.SystemFontOfSize(size)
                   );
            }
        }
    }
}