using IT_CompanyXamarinAPI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT_CompanyXamarinAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Dashboard());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
