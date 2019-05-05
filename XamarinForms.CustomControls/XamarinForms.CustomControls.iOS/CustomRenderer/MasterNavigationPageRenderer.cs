using Xamarin.Forms;
using XamarinForms.CustomControls.iOS.CustomRenderer;
using XamarinForms.CustomControls.MasterDetailPage;

[assembly: ExportRenderer(typeof(CustomMasterDetailPage), typeof(MasterNavigationPageRenderer))]
namespace XamarinForms.CustomControls.iOS.CustomRenderer
{
    public class MasterNavigationPageRenderer
    {
        public MasterNavigationPageRenderer() : base() { }
    }
}