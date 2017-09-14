using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Request
{
    public class ApiRequest
    {
        /// <summary>
        /// token (required) - API token given by MC admin
        /// </summary>
        internal string Token { get; set; }
        internal string Secret { get; set; }

        ///// <summary>
        ///// csum (required) - request checksum
        ///// </summary>
        //public string CSUM { get; set; }
    }
}
