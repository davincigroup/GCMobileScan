using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDCDetailPage : ContentPage
    {
        public NDCDetailPage()
        {
            InitializeComponent();

            lblExpiry.Text = "<strong>Expiration Date</strong><br/>02/28";

            lblSerial.Text = "<strong>Serial Number</strong><br/>085499874";
        }

         void BtnVerify_Click(object sender, EventArgs e)
        {
            string  x  = "";
        }

    }
}