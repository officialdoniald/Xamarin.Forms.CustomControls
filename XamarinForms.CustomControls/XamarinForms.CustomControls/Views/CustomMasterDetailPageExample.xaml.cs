using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinForms.CustomControls.MasterDetailPage;
using XamarinForms.CustomControls.NavigationPage;

namespace XamarinForms.CustomControls.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomMasterDetailPageExample : CustomMasterDetailPage
    {
		public CustomMasterDetailPageExample ()
		{
			InitializeComponent ();
            
            listView.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);

                var customPage = new CustomNavigationPage(page)
                {
                    TitleFontAttributes = Enums.FontAttributes.Bold,
                    TitleFontSize = 30,
                    TitleHorizontalAlignment = Enums.HorizontalAlignment.Center,
                    TitleFontFamily = "HelveticaNeueLTStd"
                };

                Detail = customPage;
                listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}