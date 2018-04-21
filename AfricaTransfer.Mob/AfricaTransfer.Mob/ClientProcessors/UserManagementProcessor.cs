using AfricaTransfer.CoreLib.ServerAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfricaTransfer.CoreLib.ClientProcessors
{
    public class UserManagementProcessor
    {
        private readonly ApiServer apiServer;

        public UserManagementProcessor(ApiServer apiServer)
        {
            this.apiServer = apiServer;            
        }

        public void RegisterNewUser(string phoneNumber)
        {
            apiServer.AddPhoneNUmber(phoneNumber);
        }
    }
}
