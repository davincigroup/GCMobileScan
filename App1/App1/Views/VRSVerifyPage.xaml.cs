using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using App1;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using App1.ViewModels;

namespace App1.Views
{
    [QueryProperty("NDC", "ndc")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VRSVerifyPage : ContentPage
    {

       

        private string _barCodeString;
        public string barCodeString
        {
            get => _barCodeString;
            set => _barCodeString = Uri.UnescapeDataString(value);
        }

        public VRSVerifyPage(VRSRequest v)
        {
            InitializeComponent();
            
            BindingContext = new VRSVerifyViewModel(v);


        }
        protected override void OnAppearing()
        {

            // TODO need struct and pass it
            //scanlib sl = new scanlib();
            //if (sl.ConvertDataMatrix(barCodeString, ref GTIN, ref exp, ref ser, ref lot, ref ErrMsg))
            //{
            //    // already passed
            //}
           
            //base.OnAppearing();
        }

        void OnVerifyButtonClicked(object sender, EventArgs args)
    {
        VerifyComponents();
    }
    
        async void VerifyComponents()
    {
        //GTIN = txtGTIN.Text;
        //lot = txtLot.Text;
        //ser = txtSerial.Text;
        //exp = txtExpiry.Text;

        //string req = url;
        //req += "/gtin/" + GTIN;
        //req += "/lot/" + lot;
        //req += "/ser/" + ser;
        //req += "?exp=" + exp;
        //req += "&linkType=" + linkType;
        //req += "&context=" + context;

        //var content = await _Client.GetStringAsync(url);
        //var VRSReq = await _Client.GetAsync(req);

        //var content = await VRSReq.Content.ReadAsStringAsync();

        //string x = req;


        //string s = content.ToString();


        //var VRSlookup = JsonConvert.DeserializeObject<VRSResponse>(s);
        ////_post = new ObservableCollection<VRSResponse>(VRSlookup);

        //lblVRSHeader.IsVisible = true;
        //myLabel1.IsVisible = true;
        //myLabel2.IsVisible = true;
        //myReturnCode.IsVisible = true;

         

            
        }
    }
}