using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client
{
    public class MobileCoachConfig
    {
        public string Token { get; set; }
        public string Endpoint { get; set; }
        public int CoachId { get; set; }
        public string Secret { get; set; }
        public string GetBaseUrl()
        {
            return string.Format(this.Endpoint, CoachId);
        }
    }
}
