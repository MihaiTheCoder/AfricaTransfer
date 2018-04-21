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
    public partial class SellerPage : ContentPage
    {
        public SellerPage()
        {
            InitializeComponent();
        }

        public async void SellProductsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CartScanPage());
        }
        public async void MngProductsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ManageProductsPage());
        }
        public async void CashOutBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CartScanPage());
        }
    }
}
