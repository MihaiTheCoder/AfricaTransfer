using AfricaTransfer.CoreLib.Models;
using AfricaTransfer.CoreLib.ServerAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.ClientProcessors
{
    public class TransactionProcessor
    {
        private readonly ApiServer apiServer;

        public TransactionProcessor(ApiServer apiServer)
        {
            this.apiServer = apiServer;
        }

        public void AddBankTransfer(float ammount, string phoneNumber)
        {
            AuthModel authModel = apiServer.GetAuthModel(phoneNumber);
            apiServer.AddBankTransaction(new BankTransaction { Ammount = ammount, DestinationAuthModelID = authModel.ID });
        }
        
        public Product AddProduct(Product product)
        {
            return apiServer.AddProduct(product);
        } 

        public int AddOrder(List<OrderLine> orderLines, string sellerPhoneNumber)
        {
            var seller = apiServer.GetAuthModel(sellerPhoneNumber);
            Order order = new Order();
            order.SellerID = seller.ID;
            order.OrderLines = orderLines;
            return apiServer.AddOrder(order);
        }

        public void AddMobileTransfer(float ammount, string donatorPhoneNumber, string buyerPhoneNumber)
        {
            var donator = apiServer.GetAuthModel(donatorPhoneNumber);
            var buyer = apiServer.GetAuthModel(buyerPhoneNumber);
            var mobileTransaction = new MobileTransaction {
                SourceAuthModelID = donator.ID,
                DestinationAuthModelID = buyer.ID,
                Ammount = ammount
            };
            apiServer.AddMobileTransaction(mobileTransaction);
        }

        public void ConfirmOrder(Order order, string buyerPhoneNumber)
        {
            var buyer = apiServer.GetAuthModel(buyerPhoneNumber);
            order.BuyerID = buyer.ID;

            apiServer.ConfirmOrder(order);
        }

        public Order GetOrder(int id)
        {
            return apiServer.GetOrder(id);
        }
    }
}
