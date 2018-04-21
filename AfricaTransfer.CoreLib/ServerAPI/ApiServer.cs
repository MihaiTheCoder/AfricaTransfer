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
        private readonly string MobileTransactions = "MobileTransactions";
        private readonly string BankTransactions = "BankTransactions";
        private readonly string PhoneCredits = "PhoneCredits";
        private readonly string Products = "Products";
        private readonly string Orders = "Orders";

        public AuthModel GetAuthModel(string phoneNumber)
        {
            string actionUrl = ComposeUrl(AuthModels) + "/" + phoneNumber;
            return HttpGet<AuthModel>(actionUrl).Data;
        }

        public void AddBankTransaction(BankTransaction bankTransaction)
        {
            string actionUrl = ComposeUrl(BankTransactions);
            HttpPost(actionUrl, bankTransaction);
        }

        internal void AddProduct(Product product)
        {
            string actionUrl = ComposeUrl(Products);
            HttpPost(actionUrl, product);
        }

        public int AddOrder(Order order)
        {
            string actionUrl = ComposeUrl(Orders);

            return HttpPost<Order, Order>(actionUrl, order).Data.ID;
        }

        internal Order GetOrder(int id)
        {
            string actionUrl = ComposeUrl(Orders) + "/" + id;
            return HttpGet<Order>(actionUrl).Data;
        }

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

        protected IRestResponse<TResponse> HttpPost<TBody, TResponse>(String Uri, TBody Data)
            where TBody : class
            where TResponse : class, new()
        {
            var client = new RestClient(baseURL);
            var request = new RestRequest(Uri, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(Data);

            var response = client.Execute<TResponse>(request);
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
