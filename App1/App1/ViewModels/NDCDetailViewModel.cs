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
    public class NDCDetailViewModel : BaseViewModel
    {
        public NDCDetailViewModel(string NDCString)
        {

            //NDCString = "00369238115499";  //         NDCString 

            string url = "https://mobile.gatewaychecker.com/api/gtindecode/gtin/";

            // send to webservice
            url += NDCString;

            string JSONResponse;
            //string JSONResponse = "{\r\n  \"product_ndc\" : \"70727-497\",\r\n  \"generic_name\" : \"netarsudil\",\r\n  \"labeler_name\" : \"Aerie Pharmaceuticals, Inc.\",\r\n  \"brand_name\" : \"Rhopressa\",\r\n  \"active_ingredients\" : [ {\r\n    \"name\" : \"NETARSUDIL MESYLATE\",\r\n    \"strength\" : \".2 mg/mL\"\r\n  } ],\r\n  \"finished\" : true,\r\n  \"packaging\" : {\r\n    \"package_ndc\" : \"70727-497-25\",\r\n    \"description\" : \"1 BOTTLE in 1 CARTON (70727-497-25)  > 2.5 mL in 1 BOTTLE\",\r\n    \"marketing_start_date\" : \"20171218\",\r\n    \"sample\" : false\r\n  },\r\n  \"listing_expiration_date\" : \"20211231\",\r\n  \"openfda\" : {\r\n    \"manufacturer_name\" : [ \"Aerie Pharmaceuticals, Inc.\" ],\r\n    \"rxcui\" : [ \"1992868\", \"1992873\" ],\r\n    \"spl_set_id\" : [ \"7d4f0e3a-5b86-4c43-982a-813b22ae7e22\" ],\r\n    \"is_original_packager\" : [ true ],\r\n    \"unii\" : [ \"VL756B1K0U\" ]\r\n  },\r\n  \"marketing_category\" : \"NDA\",\r\n  \"dosage_form\" : \"SOLUTION/ DROPS\",\r\n  \"spl_id\" : \"f2f908c6-8885-49e8-b2d6-b673a81a10f2\",\r\n  \"product_type\" : \"HUMAN PRESCRIPTION DRUG\",\r\n  \"route\" : [ \"OPHTHALMIC\", \"TOPICAL\" ],\r\n  \"marketing_start_date\" : \"20171218\",\r\n  \"product_id\" : \"70727-497_f2f908c6-8885-49e8-b2d6-b673a81a10f2\",\r\n  \"application_number\" : \"NDA208254\",\r\n  \"brand_name_base\" : \"Rhopressa\",\r\n  \"pharm_class\" : [ \"Rho Kinase Inhibitor [EPC]\", \"Rho Kinase Inhibitors [MoA]\" ],\r\n  \"GS1_Identifier\" : {\r\n    \"GS1\" : \"0370727\",\r\n    \"GTIN\" : \"00370727497255\",\r\n    \"GLN\" : \"0370727\"\r\n  }\r\n}\r\n";

            JSONResponse  = GetNDC(url).Result;

            NDC = JsonConvert.DeserializeObject<ProductInfo>(JSONResponse);
            Title = NDCString; // NDC.generic_name;

            //activeIngredients[].strength,  dosage_form, route[]          
            foreach (ActiveIngredient AI in NDC.active_ingredients)
            {
                strengthFormRoute += AI.strength + ", ";
            }
            strengthFormRoute += NDC.dosage_form + ", ";

            // which is manuf
            foreach (string s in NDC.openfda.manufacturer_name)
            {
                manufacturer_name = s;
            }


            foreach (string s in NDC.route)
            {
                strengthFormRoute += s + ", ";
            }
            strengthFormRoute = strengthFormRoute.Substring(0, strengthFormRoute.Length - 2);

            // package desc
            packageDesc = NDC.packaging.description; //+ ", (" + NDC.packaging.package_ndc + ")";

        }
         
        async Task<string> GetNDC(string s) 
        {
            var client = new HttpClient();

            var result = await client.GetAsync(s).ConfigureAwait(false);

            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false); ;

            //result.Content.ToString()
            return content.ToString();

        }
        
    }


}