using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using App1.Models;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace App1.ViewModels
{
    
    public class VRSVerifyViewModel :   BaseViewModel
    {
        private const string context = "dscsaSaleableReturn";
        private const string linkType = "verificationService";

        public VRSVerifyViewModel(VRSRequest v)
        {
            // assign to model var so view can see
            VRSRequest = v;


            string req = "https://mobile.gatewaychecker.com/api/verify";
 
            req += "/gtin/" + v.GTIN;
            req += "/lot/" + v.lot;
            req += "/ser/" + v.ser;
            req += "?exp=" + v.expiry;
            req += "&linkType=" + linkType;
            req += "&context=" + context;

            // send to webservice
            
            string JSONResponse;
            
            JSONResponse = GetVerify(req).Result;

            // assign to model var so view can see
            VRSResponse = JsonConvert.DeserializeObject<VRSResponse>(JSONResponse);

        }

        async Task<string> GetVerify(string s)
        {
            var client = new HttpClient();

            var result = await client.GetAsync(s).ConfigureAwait(false);

            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false); ;

            //result.Content.ToString()
            return content.ToString();

        }
    }
}