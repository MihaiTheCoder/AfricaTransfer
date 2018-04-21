using AfricaTransfer.CoreLib.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartScanPage : ContentPage
    {
        public ObservableCollection<OrderLine> Items { get; set; }

        public CartScanPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<OrderLine>();

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void ScanQr(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Items.Add(new OrderLine { ID = 1, ProductID = 1, ProductPrice = 1, Quantity = 1 });
        }
    }
}
