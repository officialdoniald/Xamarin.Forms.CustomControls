using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.CustomControls.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinForms.CustomControls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomMasterDetailPageExample();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}