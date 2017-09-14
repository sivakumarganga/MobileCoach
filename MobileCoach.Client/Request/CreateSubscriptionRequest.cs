using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MobileCoach.Client.Request
{
    public class CreateSubscriptionRequest: ApiRequest
    {
        public CreateSubscriptionRequest()
        {
            this.ONExists = "restart";
            this.Keyword = "qnewibotest";//"qnewibo";
           // this.CustomField = string.Empty;
        }
        /// <summary>
        /// phone_number (required) - user’s phone number in international format starting with +
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// keyword (required) - user’s selected mobile coach keyword or ID. Possible values are qnewibo or qnewibotest
        /// </summary>
        [JsonProperty("keyword")]
        public string Keyword { get; set; }


        /// <summary>
        /// first_name(optional) - user’s first
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///  last_name (optional) - user’s last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// on_exists - (optional) action on exists users subscription. Possible values 'enable' (if disabled) and 'restart' (default: restart)
        /// </summary>
        [JsonProperty("on_exists")]
        public string ONExists { get; set; }

        /// <summary>
        /// Custom_field (optional/required) - any custom field present in coach. Custom fields can be individually marked as required for subscription creation
        /// Some client’s mobile coaches contain custom fields. The API can accept custom field values as parameters and create subscriptions with initialized fields.
        /// The parameters should be lower cased. That is, if the custom field's name is AGE, the parameter should be age.
        /// </summary>
        [JsonProperty("Custom_field")]
        public string CustomField { get; set; }

       

    }
}
