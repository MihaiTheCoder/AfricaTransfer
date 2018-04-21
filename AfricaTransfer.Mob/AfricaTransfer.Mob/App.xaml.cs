using System;

using AfricaTransfer.Mob.Views;
using Xamarin.Forms;

namespace AfricaTransfer.Mob
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();


            MainPage = new NavigationPage( new MainPage());
            //((App.Current as App).MainPage as NavigationPage).PushAsync()
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}
