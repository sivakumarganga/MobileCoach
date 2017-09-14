using MobileCoach.Client.Request;
using MobileCoach.Client.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client
{
    public class MobileCoachClient : IMobileCoachClient
    {
        private readonly MobileCoachConfig _config;
        private readonly HttpWebClient _webClient;
        public MobileCoachClient(MobileCoachConfig config)
        {
            this._config = config;
            this._webClient = new HttpWebClient(this._config.GetBaseUrl());
        }
        //private T EnsureAuthorizationToken<T>(ApiRequest request)
        //{
        //    request.Token = this._config.Token;
        //    request.Secret = this._config.Secret;
        //   // return Task.Run<T>(()=>action(request)).Result;
        //}
        private void EnsureAuthorizationToken(ApiRequest request)
        {
            request.Token = this._config.Token;
            request.Secret = this._config.Secret;
        }
        public ApiResponse CreateSubscription(CreateSubscriptionRequest request)
        {
             EnsureAuthorizationToken(request);
             return Task.Run<ApiResponse>(()=>this._webClient.Post<CreateSubscriptionRequest,ApiResponse>("/subscriptions", request)).Result;
        }
        public ApiResponse GetSubscriptions(GetSubscriptionsRequest request)
        {
            EnsureAuthorizationToken(request);
            return Task.Run<GetSubscriptionsResponse>(() => this._webClient.Get<GetSubscriptionsRequest, GetSubscriptionsResponse>("/subscriptions", request)).Result;
        }
        public ApiResponse DeleteSubscription(DeleteSubscriptionRequest request)
        {
            EnsureAuthorizationToken(request);
            return Task.Run<ApiResponse>(() => this._webClient.Post<DeleteSubscriptionRequest, ApiResponse>("/subscriptions", request)).Result;
        }

        public ApiResponse CreateMessage(CreateMessageRequest request)
        {
            EnsureAuthorizationToken(request);
            return Task.Run<ApiResponse>(() => this._webClient.Post<CreateMessageRequest, ApiResponse>("/messages", request)).Result;
        }
        public GetMessagesResponse GetMessages(GetMessagesRequest request)
        {
            EnsureAuthorizationToken(request);
            return Task.Run<GetMessagesResponse>(() => this._webClient.Get<GetMessagesRequest, GetMessagesResponse>("/messages", request)).Result;
        }
        public ApiResponse Callback(CallbackRequest request)
        {
            return null;
        }

    }
}
