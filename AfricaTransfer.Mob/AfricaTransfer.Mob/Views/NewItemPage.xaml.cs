using AfricaTransfer.CoreLib.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Product Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Product
            {
                Name = "Item name",
                Price = 0
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}
