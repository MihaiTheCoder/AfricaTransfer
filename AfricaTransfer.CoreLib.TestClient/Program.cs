using AfricaTransfer.CoreLib.ClientProcessors;
using AfricaTransfer.CoreLib.Models;
using AfricaTransfer.CoreLib.ServerAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AfricaTransfer.CoreLib.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //E2E();
        }

        private static void E2E()
        {
            string sellerPhoneNumber = "07434";
            string buyerPhoneNumber = "34075";
            string donatorPhoneNumber = "1234";
            ApiServer apiServer = new ApiServer("http://africatransferapi.azurewebsites.net/api/");
            apiServer.AddPhoneNUmber(sellerPhoneNumber);
            apiServer.AddPhoneNUmber(buyerPhoneNumber);
            apiServer.AddPhoneNUmber(donatorPhoneNumber);
            var x = apiServer.GetAuthModels();

            TransactionProcessor processor = new TransactionProcessor(apiServer);
            processor.AddBankTransfer(44, donatorPhoneNumber);

            processor.AddMobileTransfer(23, donatorPhoneNumber, buyerPhoneNumber);

            var product = processor.AddProduct(new Product { Name = "Capriciosa", Price = 22 });

            var orderId = processor.AddOrder(new List<OrderLine>() { new OrderLine {
                ProductID = product.ID,
                Quantity = 2 } }, sellerPhoneNumber);

            var order = processor.GetOrder(orderId);
            var orderTotal = order.OrderLines.Sum(o => o.ProductPrice);

            processor.ConfirmOrder(order, buyerPhoneNumber);
        }
    }
}
