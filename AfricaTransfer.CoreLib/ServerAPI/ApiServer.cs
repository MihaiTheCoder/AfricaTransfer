using AfricaTransfer.CoreLib.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AfricaTransfer.CoreLib.ServerAPI
{
    public class ApiServer
    {
        private readonly string baseURL;
        private readonly string AuthModels = "AuthModels";

        public ApiServer(string baseURL)
        {
            this.baseURL = baseURL;
        }

        public List<AuthModel> GetAuthModels()
        {
            return HttpGet<List<AuthModel>>(ComposeUrl(AuthModels)).Data;
        }

        public void AddPhoneNUmber(string phoneNumber)
        {
            HttpPost(ComposeUrl(AuthModels), new AuthModel { PhoneNumber = phoneNumber });
        }

        private string ComposeUrl(string controller)
        {
            return String.Format("{0}/{1}", baseURL, controller);
        }

        protected IRestResponse HttpPost<TBody>(String Uri, TBody Data)
    where TBody : class
{
            var client = new RestClient(baseURL);
            var request = new RestRequest(Uri, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(Data);

            var response = client.Execute(request);
            return response;
        }

        protected IRestResponse<TResponse> HttpGet<TResponse>(String uri) where TResponse:class, new()
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest(uri, Method.GET);
            return client.Get<TResponse>(request);
        }
    }
}
