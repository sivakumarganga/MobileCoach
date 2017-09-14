using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Request
{
    public class GetMessagesRequest : ApiRequest
    {
        /// <summary>
        /// user_eq - (required) user EMAIL or PHONE NUMBER in international format (starting with +);
        /// </summary>
        [JsonProperty("user_eq")]
        public string UserEmailOrPhone { get; set; }

        /// <summary>
        /// date_lt - (optional) message date less than filter in format "YYYY-MM-DD hh:mm:ss"
        /// </summary>
        [JsonProperty("date_lt")]
        public DateTime? LessThanDate { get; set; }
        /// <summary>
        /// date_lteq - (optional) message date less than or equal filter in format "YYYY-MM-DD hh:mm:ss"
        /// </summary>
        [JsonProperty("date_lteq")]
        public DateTime? LessThanOrEquals { get; set; }

        /// <summary>
        /// date_gt - (optional) message date greater than filter in format "YYYY-MM-DD hh:mm:ss UTC"
        /// </summary>
        [JsonProperty("date_gt")]
        public DateTime? GreaterThanDate { get; set; }

        /// <summary>
        /// date_gteq - (optional) message date greater than or equal filter in format "YYYY-MM-DD hh:mm:ss"
        /// </summary>
        [JsonProperty("date_gteq")]
        public DateTime? GreaterThanOrEquals { get; set; }

        /// <summary>
        /// page - (optional) current page of messages result (by default: 1)
        /// </summary>
        [JsonProperty("page")]
        public int? PageIndex { get; set; }

        /// <summary>
        /// per_page - (optional) messages per page (default: 100, maximum: 100)
        /// </summary>
        [JsonProperty("per_page")]
        public int? PageSize { get; set; }

    }
}
