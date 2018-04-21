using AfricaTransfer.Mob.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManageProductsPage : ContentPage
    {
        public ObservableCollection<Item> Items { get; set; }

        public ManageProductsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Item>
            {
                new Item {
                    Id = "1",
                    Description = "description",
                    Text = "Item Name"
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
    }
}
