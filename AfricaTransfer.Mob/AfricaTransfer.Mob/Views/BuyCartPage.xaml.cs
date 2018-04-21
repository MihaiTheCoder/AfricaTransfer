using AfricaTransfer.CoreLib.ClientProcessors;
using AfricaTransfer.CoreLib.Models;
using AfricaTransfer.CoreLib.ServerAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyCartPage : ContentPage
    {
        public ObservableCollection<OrderLine> Items { get; set; }
        public Order CurrentOrder { get; set; }
        public BuyCartPage (int orderID)
        {
            InitializeComponent ();

            ApiServer server = new ApiServer();
            var tp = new TransactionProcessor(server);

            CurrentOrder = tp.GetOrder(orderID);

            Items = new ObservableCollection<OrderLine>(CurrentOrder.OrderLines);

            MyListView.ItemsSource = Items;
        }

        public async void Buy(object sender, EventArgs e)
        {
            ApiServer server = new ApiServer();
            var tp = new TransactionProcessor(server);
            tp.ConfirmOrder(CurrentOrder, "buyerPhoneNumber");
        }
    }
}
