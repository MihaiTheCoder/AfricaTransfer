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
    public partial class BuyerPage : ContentPage
    {
        public BuyerPage()
        {
            InitializeComponent();
        }
        public async void ScanQrCode(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
