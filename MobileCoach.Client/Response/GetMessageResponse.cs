using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Response
{
    public class GetMessageResponse : ApiResponse
    {
        public string Sender { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}
