using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace AfricaTransfer.Mob.ViewModels
{
    public class AboutViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }
        public string Title { get; private set; }
        public ICommand OpenWebCommand { get; }
    }
}
