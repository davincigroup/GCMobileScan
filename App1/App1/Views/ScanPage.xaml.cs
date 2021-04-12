using Xamarin.Forms;
using System;
using Xamarin.Forms.Xaml;
using ZXing;
using App1.Services;
using System.Threading.Tasks;
using App1.ViewModels;



namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();

            Spinner.IsRunning = false;

        }

        async void OnButtonClickedNDC(object sender, EventArgs args)
        {
            //Navigation.NavigationStack


            //await Navigation.PushAsync(new VRSVerifyPage());
            //await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("//D_FAULT_TabBar8/IMPL_VRSVerifyPage/VRSVerifyPage");
            
            string scanResult = txtValue.Text;

            Spinner.IsRunning = true;

            //ActivityIndicator activityIndicator = new ActivityIndicator { IsRunning = true };

            //await Shell.Current.GoToAsync($"{nameof(NDCDetailPage)}?ndc=" + scanResult);
            //await Navigation.PushAsync(new  NDCDetailPage(scanResult));
            Spinner.IsRunning = true;

            Device.BeginInvokeOnMainThread(async () =>
            {

                await Navigation.PushAsync(new NDCDetailPage(scanResult));

                Spinner.IsRunning = false;
            });
 



        }
        async void OnButtonClickedGTIN(object sender, EventArgs args)
        {
            //Navigation.NavigationStack


            //await Navigation.PushAsync(new VRSVerifyPage());
            //await Navigation.PopToRootAsync();
            //await Shell.Current.GoToAsync("//D_FAULT_TabBar8/IMPL_VRSVerifyPage/VRSVerifyPage");

            string scanResult = txtValue.Text;

            //await Shell.Current.GoToAsync($"{nameof(NDCDetailPage)}?ndc=" + scanResult);
            //await Navigation.PushAsync(new VRSVerifyPage());
            //code={code}
            //await label.RelRotateTo(360, 1000);

            Spinner.IsRunning = true;

            //Device.BeginInvokeOnMainThread(async () =>
            //{

            //    //await Navigation.PushAsync(new VRSVerifyPage(scanResult));

            //    Spinner.IsRunning = false;
            //});

        }
        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            //try
            //{
            string GTIN = "";
            string exp = "";
            string serial = "";
            string lot = "";
            string ErrMsg = "" ;

            var scanner = DependencyService.Get<IQrScanningService>();
            var result = await scanner.ScanAsync();
            if (result != null)

            {
                // NDC or GTIN or not

                txtBarcode.Text = result;
                string barCodeString = result.ToString();

                // verify overall
                scanlib sl = new scanlib();

                VRSRequest v = new VRSRequest();

                if (! sl.ConvertDataMatrix(barCodeString, ref v, ref ErrMsg)) { 
                }
                else
                {
                    switch (pickScanType.SelectedIndex)
                    {
                    // GTIN
                    case 1:
                        Spinner.IsRunning = true;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                        
                            await Navigation.PushAsync(new VRSVerifyPage(v));

                            Spinner.IsRunning = false;
                        });                            
                        break;

                    //  NDC
                    case 0:
                        Spinner.IsRunning = true;
                        Device.BeginInvokeOnMainThread(async () =>
                        {

                            await Navigation.PushAsync(new NDCDetailPage(v.GTIN));

                            Spinner.IsRunning = false;
                        });
                        break;

                        default:
                        {
                            // do some error
                        }

                        break;
                }
                }





            }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }
    }
}