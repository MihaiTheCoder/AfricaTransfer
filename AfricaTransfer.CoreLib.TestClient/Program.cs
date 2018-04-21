using AfricaTransfer.CoreLib.ServerAPI;
using System;

namespace AfricaTransfer.CoreLib.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ApiServer apiServer = new ApiServer("http://localhost:59887/api/");
            apiServer.AddPhoneNUmber("0743");
            var x = apiServer.GetAuthModels();
            Console.WriteLine("Hello World!");
        }
    }
}
