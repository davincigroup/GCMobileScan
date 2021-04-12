using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    class scanlib
    {
        public bool ConvertDataMatrix(string barCodeString, ref VRSRequest v, ref string ErrMsg)
        {

            //string barCodeString = "01050604788800041117111321OGA164500210B123CR890J";

            //ASCII character GS (ASCII value 29)
            // YYMMTT is date format, TT can be 00 as convention to indicate last day of month
            // char FNC1 = (char)29;

            //FNC1 = "\u001d";
            int FNC1ptr = 0;
            string AICode = "";

            try
            {
                FNC1ptr = barCodeString.Substring(1, barCodeString.Length - 1).IndexOf((char)29);

                v.GTIN = barCodeString.Substring(3, 14);

                int ptr = 0;
                AICode = barCodeString.Substring(17, 2);

                // PRE INDICATOR
                switch (AICode)
                {
                    case "21":
                        v.ser = barCodeString.Substring(19, FNC1ptr - 18);
                        break;

                    case "17":
                        v.expiry = barCodeString.Substring(19,6);
                        break;

                    case "10":
                        v.lot = barCodeString.Substring(19, FNC1ptr - 19);
                        break;
                }

                // POST INDICATOR
                AICode = barCodeString.Substring(FNC1ptr + 2, 2);
                switch (AICode)
                {
                    case "17":
                        v.expiry = barCodeString.Substring(FNC1ptr + 4, 6);
                        ptr = FNC1ptr + 9;
                        break;

                    case "21":
                        v.ser = barCodeString.Substring(FNC1ptr + 4, 6);
                        ptr = FNC1ptr + 9;
                        break;

                    case "10":
                        v.lot = barCodeString.Substring(FNC1ptr + 4, FNC1ptr - 19);
                        ptr = FNC1ptr +9;
                        break;
                }

                // FINAL VAR

                AICode = barCodeString.Substring(ptr + 1, 2);
                switch (AICode)
                {
                    case "17":
                        v.ser = barCodeString.Substring(FNC1ptr + 2, 6);
                        break;

                    case "21":
                        v.expiry = barCodeString.Substring(FNC1ptr + 2, 6);
                        break;

                    case "10":
                        v.lot = barCodeString.Substring(ptr + 3, barCodeString.Length - (ptr + 3));
                        break;
                }

                // need check for all components

                //v.expiry = barCodeString.Substring(19, 6);

                //// remember this is variable, from fixed point to X
                //v.ser = barCodeString.Substring(27, FNC1ptr - 26);

                //// remember this is variable, from X to EOS
                //v.lot = barCodeString.Substring(FNC1ptr + 4, barCodeString.Length - FNC1ptr - 4);
            }
            catch (Exception e)
            {
                ErrMsg = e.Message;
                return false;
            }

            ErrMsg = "";

            return true;
        }

    }
}
