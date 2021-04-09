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


namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VRSVerifyPage : ContentPage
    {

        //private string url = "https://mobile.gatewaychecker.com/api/verify/gtin/00860003873595/lot/L210326/ser/AB210010?exp=210131&linkType=verificationService&context=dscsaSaleableReturn?Expiry=210131";
        private string url = "https://mobile.gatewaychecker.com/api/verify";
        private HttpClient _Client = new HttpClient();

        private const string context = "dscsaSaleableReturn";
        private const string linkType = "verificationService";
        private string GTIN;
        private string lot;
        private string ser;
        private string exp;


        public VRSVerifyPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            // load defaults
            GTIN = "00860003873595";
            lot = "L210326";
            ser = "AB210010";
            exp = "210131";

            myLabel1.IsVisible = false;
            myLabel2.IsVisible = false;
            myReturnCode.IsVisible = false;
            lblVRSHeader.IsVisible = false;

            // show current 
            DisplayComponents();

            base.OnAppearing();
        }

        void OnVerifyButtonClicked(object sender, EventArgs args)
    {
        VerifyComponents();
    }
        void DisplayComponents()
        {
            // load UI
            txtGTIN.Text = GTIN;
            txtLot.Text = lot;
            txtSerial.Text = ser;
            txtExpiry.Text = exp;

        }
        async void VerifyComponents()
    {
        GTIN = txtGTIN.Text;
        lot = txtLot.Text;
        ser = txtSerial.Text;
        exp = txtExpiry.Text;

        string req = url;
        req += "/gtin/" + GTIN;
        req += "/lot/" + lot;
        req += "/ser/" + ser;
        req += "?exp=" + exp;
        req += "&linkType=" + linkType;
        req += "&context=" + context;

        //var content = await _Client.GetStringAsync(url);
        var VRSReq = await _Client.GetAsync(req);

        var content = await VRSReq.Content.ReadAsStringAsync();

        string x = req;


        string s = content.ToString();


        var VRSlookup = JsonConvert.DeserializeObject<VRSResponse>(s);
        //_post = new ObservableCollection<VRSResponse>(VRSlookup);

        lblVRSHeader.IsVisible = true;
        myLabel1.IsVisible = true;
        myLabel2.IsVisible = true;
        myReturnCode.IsVisible = true;

        
            myReturnCode.Text = "HTTP : " + VRSReq.StatusCode.ToString();
            myLabel1.Text = VRSlookup.responderGLN;
            myLabel2.Text = "Verified: " + VRSlookup.data.verified.ToString();

            if (VRSlookup.data.verified)
            {
                myLabel3.IsVisible = false;
            }
            else
            {
                myLabel3.IsVisible = true;
                myLabel3.Text = VRSlookup.data.verificationFailureReason + "-" + VRSlookup.data.additionalInfo;

            }

            ;
            myLabel4.Text = VRSlookup.verificationTimestamp;

        }
    }
}