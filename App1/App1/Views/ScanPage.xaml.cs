using Xamarin.Forms;
using System;
namespace App1.Views
{

    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            //Navigation.NavigationStack
            

            //await Navigation.PushAsync(new VRSVerifyPage());
            //await Navigation.PopToRootAsync();
            await Shell.Current.GoToAsync("//D_FAULT_TabBar8/IMPL_VRSVerifyPage/VRSVerifyPage");

            //await label.RelRotateTo(360, 1000);
        }

    }
}