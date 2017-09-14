using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Request
{
    public class CallbackRequest : ApiRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }
        public MessageType Type { get; set; }
        public int CoachId { get; set; }
    }
}
