using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Data
    {
        public bool verified { get; set; }
        public string verificationFailureReason { get; set; }
        public string additionalInfo { get; set; }
    }

    public class VRSResponse
    {
        public string responderGLN { get; set; }
        public string corrUUID { get; set; }
        public string verificationTimestamp { get; set; }
        public Data data { get; set; }
    }
    public class VRSRequest
    {
        public string GTIN { get; set; }
        public string ser { get; set; }
        public string expiry { get; set; }
        public string lot { get; set; }
    }



}
