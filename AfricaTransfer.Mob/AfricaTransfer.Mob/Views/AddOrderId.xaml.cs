using AfricaTransfer.CoreLib.ClientProcessors;
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
	public partial class AddOrderId : ContentPage
	{
		public AddOrderId ()
		{
			InitializeComponent ();
		}

        public int OrderId { get; set; }
        public async void AddOrder(object sender, EventArgs e)
        {
            TransactionProcessor processor = new TransactionProcessor();
            var order = processor.GetOrder(OrderId);

            //await Navigation.PushAsync(new )
        }
        
    }
}
