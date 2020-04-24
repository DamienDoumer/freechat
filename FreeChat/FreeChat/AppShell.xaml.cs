using FreeChat.Services.Navigation;
using FreeChat.Views.Pages;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FreeChat
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            Routing.RegisterRoute(Constants.MessagesPageUrl, typeof(MessagesPage));
        }
    }
}
