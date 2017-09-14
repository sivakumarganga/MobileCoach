using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using MobileCoach.Client.Request;
using System.Net;
using MobileCoach.Client.Response;

namespace MobileCoach.Client
{
    public class HttpWebClient
    {
        private HttpClient webClient { get; set; }
        public HttpWebClient()
        {
            this.webClient = new HttpClient();
            this.webClient.DefaultRequestHeaders.ExpectContinue = false;
        }
        public HttpWebClient(string baseUrl) : this()
        {
            this.webClient.BaseAddress = new Uri(baseUrl);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                       SecurityProtocolType.Tls11 |
                                       SecurityProtocolType.Tls12;
        }

        public T Get<T>(string route)
        {
            HttpResponseMessage httpResponse = Task.Run(() => this.webClient.GetAsync(route)).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(httpResponse.Content.ReadAsStringAsync().Result);
            }
            return default(T);
        }
        public async Task<TResponse> Get<TRequest, TResponse>(string route, TRequest request) where TRequest : ApiRequest where TResponse : ApiResponse
        {
            Console.WriteLine($"{Environment.NewLine} ------> {route}   GET <-------");
            Console.WriteLine(JsonConvert.SerializeObject(request));
            var response = new ApiResponse() { IsSuccess = false } as TResponse;
            try
            {
                var url = new Uri(BuildUrlWithChecksum(request, route));
                Console.WriteLine(url);
                HttpResponseMessage httpResponse = await this.webClient.GetAsync(url);
                string responseString = httpResponse.Content.ReadAsStringAsync().Result;
                if (httpResponse.IsSuccessStatusCode)
                {
                    response = JsonConvert.DeserializeObject<TResponse>(responseString);
                }
                response.IsSuccess = httpResponse.IsSuccessStatusCode;
                response.StatusCode = httpResponse.StatusCode.ToString();
                Console.WriteLine(JsonConvert.SerializeObject(PrepareReponse(httpResponse, response)));
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<TResponse> Post<TRequest, TResponse>(string route, TRequest request) where TRequest : ApiRequest where TResponse : ApiResponse
        {
            Console.WriteLine($"{Environment.NewLine} ------> {route} POST <-------");
            Console.WriteLine(JsonConvert.SerializeObject(request));
            var response = new ApiResponse() { IsSuccess = false } as TResponse;
            try
            {
                var url = new Uri(BuildUrlWithChecksum(request, route));
                Console.WriteLine(url);
                StringContent content = new StringContent(url.Query.Trim('?'));
                HttpResponseMessage httpResponse = await this.webClient.PostAsync(url, content);
                string responseString = httpResponse.Content.ReadAsStringAsync().Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    if (typeof(TResponse).FullName != typeof(ApiResponse).FullName)
                    {
                        response = JsonConvert.DeserializeObject<TResponse>(responseString);
                    }
                }
                response.Message = responseString;
                response.IsSuccess = httpResponse.IsSuccessStatusCode;
                response.StatusCode = httpResponse.StatusCode.ToString();
                Console.WriteLine(JsonConvert.SerializeObject(response));
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Data : {e.Data}\nHelpLink : {e.HelpLink}\nHResult : {e.HResult}\nInnerException : {e.InnerException}\nMessage : {e.Message}\nSource : {e.Source}\nStackTrace : {e.StackTrace}");
            }

            return response;
        }
        public string BuildUrlWithChecksum(ApiRequest request, string route)
        {
            string urlToChecksum = ($"{webClient.BaseAddress}{route}?{request.ToQueryString(true)}&token={WebUtility.UrlEncode(request.Token)}&secret={WebUtility.UrlEncode(request.Secret)}");
            string checksum = SHA1Utils.SHA1HashStringForUTF8String(urlToChecksum);
            string url = $"{webClient.BaseAddress}{route}?{request.ToQueryString()}&token={request.Token}&csum={checksum}";
            return url;
        }
        public ApiResponse PrepareReponse(HttpResponseMessage httpResponse, ApiResponse response)
        {
            response = response ?? new ApiResponse();
            response.IsSuccess = httpResponse.IsSuccessStatusCode;
            response.StatusCode = httpResponse.StatusCode.ToString();
            response.Message = httpResponse.Content.ReadAsStringAsync().Result;
            return response;
        }
    }
}
