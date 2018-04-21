using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AfricaTransfer.Mob.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage ()
        {
            InitializeComponent ();
        }

        public async void BuyerBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuyerPage());
        }

        public async void Seller_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SellerPage());
        }

        public async void DonateBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DonatePage());
        }

    }
}