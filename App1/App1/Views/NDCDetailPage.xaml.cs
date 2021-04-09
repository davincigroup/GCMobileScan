using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.ViewModels;

namespace App1.Views
{
    
    [QueryProperty("NDC", "ndc")]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDCDetailPage : ContentPage
    {
        private string _NDC;
        public string NDC
        {
            get => _NDC;
            set => lblMyNDC.Text = Uri.UnescapeDataString(value); 
        }
        public NDCDetailPage(string x = "")
        {
            InitializeComponent();
             

            BindingContext = new NDCDetailViewModel(x);

            // lblExpiry.Text = "<strong>Expiration Date</strong><br/>02/28";

            // lblSerial.Text = "<strong>Serial Number</strong><br/>085499874";
             lblMyNDC.Text = x;

        }

         void BtnVerify_Click(object sender, EventArgs e)
        {
            string  x  = "";
        }

    }
}