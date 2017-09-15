using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileCoach.Client.MobileCoachConfig qaConfig = new Client.MobileCoachConfig() {
                 CoachId=172,
                 Endpoint= "https://qa.mobilecoach.com/api/v1/coaches/{0}",
                 Token= "--token--",
                 Secret= "--secret--"
            };

            MobileCoach.Client.MobileCoachClient qaClient = new Client.MobileCoachClient(qaConfig);

            var msg = qaClient.CreateMessage(new Client.Request.CreateMessageRequest()
            {
                Body = "this is body",
                From = "+18015551234"
            });

            var msgs = qaClient.GetMessages(new Client.Request.GetMessagesRequest()
            {
                UserEmailOrPhone = "+18015551234"
            });

           

            var result = qaClient.GetSubscriptions(new Client.Request.GetSubscriptionsRequest
            {
                //FirstName = "John",
                //LastName = "Doe",
                PhoneNumber = "+18017875106"
            });
            var result1 = qaClient.CreateSubscription(new Client.Request.CreateSubscriptionRequest
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "+18017875106",
                Keyword= "qnewibotest"
            });
            Console.Read();
        }
    }
}
