using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Response
{
  public  class GetSubscriptionResponse :ApiResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// coach_id (required) - user’s selected mobile coach keyword or ID
        /// </summary>
        [JsonProperty("keyword")]
        public string[] Keyword { get; set; }

        /// <summary>
        /// phone_number (required) - user’s phone number in international format starting with +
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

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

        [JsonProperty("start_program_at")]
        public DateTime ProgramStartAt { get; set; }

        [JsonProperty("subscription_status")]
        public string Status { get; set; }
        /// <summary>
        /// Custom_field (optional/required) - any custom field present in coach. Custom fields can be individually marked as required for subscription creation
        /// Some client’s mobile coaches contain custom fields. The API can accept custom field values as parameters and create subscriptions with initialized fields.
        /// The parameters should be lower cased. That is, if the custom field's name is AGE, the parameter should be age.
        /// </summary>
        [JsonProperty("Custom_field")]
        public string CustomField { get; set; }
    }
}
