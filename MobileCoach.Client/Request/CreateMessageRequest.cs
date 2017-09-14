using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Request
{
   public class CreateMessageRequest : ApiRequest
    {
        //public int CoachId { get; set; }
        /// <summary>
        /// from - (required) user phone number which sends message
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// body - (required) message body
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
