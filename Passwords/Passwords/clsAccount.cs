using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Passwords
{
    public class clsAccount
    {
        public string name = "";
        public string user = "";
        public string pass = "";

        /// <summary>
        /// Take the values that we have and make them into an XML node
        /// </summary>
        /// <returns></returns>
        public string toXML()
        {
            StringBuilder toReturn = new StringBuilder();
            toReturn.AppendFormat("<{0}>", "account");
            toReturn.AppendFormat("<{0}>{1}</{0}>", "name", name);
            toReturn.AppendFormat("<{0}>{1}</{0}>", "user", Program.Base64Encode(user));
            toReturn.AppendFormat("<{0}>{1}</{0}>", "pass", Program.Base64Encode(pass));
            toReturn.AppendFormat("</{0}>", "account");
            return toReturn.ToString();
        }
    }
}
