using AfricaTransfer.CoreLib.Models;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageProductsPage : ContentPage
    {
        public ObservableCollection<Product> Items { get; set; }

        public ManageProductsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Product>
            {
                new Product {
                    ID = 1,
                    Price = 123,
                    Name = "Item Name"
                }
            };

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

        async void AddItem(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
