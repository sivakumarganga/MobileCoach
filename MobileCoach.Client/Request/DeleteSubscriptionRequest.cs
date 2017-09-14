using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Request
{
  public  class DeleteSubscriptionRequest : ApiRequest
    {
        /// <summary>
        /// user_eq - (required) user EMAIL or PHONE NUMBER in international format (starting with +);
        /// </summary>
        [JsonProperty("user_eq")]
        public string UserEmailOrPhone { get; set; }
    }
}
