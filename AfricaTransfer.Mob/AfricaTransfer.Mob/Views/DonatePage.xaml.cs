using AfricaTransfer.CoreLib.ClientProcessors;
using AfricaTransfer.CoreLib.Models;
using AfricaTransfer.CoreLib.ServerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonatePage : ContentPage
    {
        public DonatePage()
        {
            InitializeComponent();
        }

        public async void AddFundsBtn_Clicked(object sender, EventArgs e)
        {
            ApiServer server = new ApiServer();
            TransactionProcessor processor = new TransactionProcessor(server);
            processor.AddBankTransfer(100, AuthModel.MobilePhoneNumber);
        }
        public async void TransferFundsBtn_Clicked(object sender, EventArgs e)
        {
            ApiServer server = new ApiServer();
            TransactionProcessor processor = new TransactionProcessor(server);
            processor.AddMobileTransfer(100, AuthModel.MobilePhoneNumber, "buyerNumber");
        }
        public async void ViewReportsBtn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
