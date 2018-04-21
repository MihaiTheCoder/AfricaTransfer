using AfricaTransfer.CoreLib.ClientProcessors;
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
            
        }
        public async void TransferFundsBtn_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public async void ViewReportsBtn_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
