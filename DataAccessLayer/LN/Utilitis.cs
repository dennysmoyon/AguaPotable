using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.LN
{
    public static class Utilitis
    {
        public static string GeneratedCode(string tipeCode)
        {
            var codGenerated = "";

            DateTime today = DateTime.Now;
            string dateKey = today.ToString("yyMMddHHmmss");

            switch (tipeCode) {
                case "COM":
                    codGenerated = "CM" + dateKey;
                    break;
                case "EQU":
                    codGenerated = "EQ" + dateKey;
                    break;
                case "UTR":
                    codGenerated = "UT" + dateKey;
                    break;
                default:
                    codGenerated = "UNI" + dateKey;
                    break;
            }

            return codGenerated;
        }
    }
}
