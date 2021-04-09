using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
     

    public class ActiveIngredient
    {
        public string name { get; set; }
        public string strength { get; set; }
    }

    public class Packaging
    {
        public string package_ndc { get; set; }
        public string description { get; set; }
        public string marketing_start_date { get; set; }
        public bool sample { get; set; }
    }

    public class Openfda
    {
        public List<string> manufacturer_name { get; set; }
        public List<string> rxcui { get; set; }
        public List<string> spl_set_id { get; set; }
        public List<bool> is_original_packager { get; set; }
        public List<string> unii { get; set; }
    }

    public class GS1Identifier
    {
        public string GS1 { get; set; }
        public string GTIN { get; set; }
        public string GLN { get; set; }
    }

    public class ProductInfo
    {
        public string product_ndc { get; set; }
        public string generic_name { get; set; }
        public string labeler_name { get; set; }
        public string brand_name { get; set; }
        public List<ActiveIngredient> active_ingredients { get; set; }
        public bool finished { get; set; }
        public Packaging packaging { get; set; }
        public string listing_expiration_date { get; set; }
        public Openfda openfda { get; set; }
        public string marketing_category { get; set; }
        public string dosage_form { get; set; }
        public string spl_id { get; set; }
        public string product_type { get; set; }
        public List<string> route { get; set; }
        public string marketing_start_date { get; set; }
        public string product_id { get; set; }
        public string application_number { get; set; }
        public string brand_name_base { get; set; }
        public List<string> pharm_class { get; set; }
        public GS1Identifier GS1_Identifier { get; set; }
    }
}
