using AfricaTransfer.CoreLib.ClientProcessors;
using AfricaTransfer.CoreLib.Models;
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
	public partial class AddPhoneNumber : ContentPage
	{
		public AddPhoneNumber ()
		{
			InitializeComponent ();

            BindingContext = this;
		}

        public string Phone { get; set; }

        public async void AddPhone(object sender, EventArgs e)
        {
            AuthModel.MobilePhoneNumber = Phone;
            ApiServer server = new ApiServer();
            server.AddPhoneNUmber(Phone);
            
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
	}
}
