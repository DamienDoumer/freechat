using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FreeChat.Services;
using FreeChat.Views;

namespace FreeChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            AppLocator.Initialize();
            MainPage = new AppShell();
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
