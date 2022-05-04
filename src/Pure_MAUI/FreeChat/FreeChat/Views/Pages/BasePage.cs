using FreeChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Views.Pages
{
    public class BasePage : ContentPage
    {
        public IViewModel ViewModel => (IViewModel)BindingContext;

        public BasePage()
        {
        }

        protected async override void OnAppearing()
        {
            if (ViewModel != null)
                await ViewModel.Initialize();
            base.OnAppearing();
        }

        protected async override void OnDisappearing()
        {
            if (ViewModel != null)
                await ViewModel?.Stop();
            base.OnDisappearing();
        }
    }
}
