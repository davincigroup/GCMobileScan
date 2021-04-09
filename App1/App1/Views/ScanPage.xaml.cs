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

        async void OnButtonClickedNDC(object sender, EventArgs args)
        {
            //Navigation.NavigationStack


            //await Navigation.PushAsync(new VRSVerifyPage());
            //await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("//D_FAULT_TabBar8/IMPL_VRSVerifyPage/VRSVerifyPage");

            string scanResult = txtValue.Text;

            //await Shell.Current.GoToAsync($"{nameof(NDCDetailPage)}?ndc=" + scanResult);
            await Navigation.PushAsync(new  NDCDetailPage(scanResult));
            //code={code}
            //await label.RelRotateTo(360, 1000);
        }
        async void OnButtonClickedGTIN(object sender, EventArgs args)
        {
            //Navigation.NavigationStack


            //await Navigation.PushAsync(new VRSVerifyPage());
            //await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("//D_FAULT_TabBar8/IMPL_VRSVerifyPage/VRSVerifyPage");

            string scanResult = txtValue.Text;

            //await Shell.Current.GoToAsync($"{nameof(NDCDetailPage)}?ndc=" + scanResult);
            await Navigation.PushAsync(new VRSVerifyPage());
            //code={code}
            //await label.RelRotateTo(360, 1000);
        }

    }
}