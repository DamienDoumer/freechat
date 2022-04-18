using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FreeChat.Services.Navigation
{
    public class SimpleNavigationService : INavigationService
    {
        public Task GotoPage(string route)
        {
            try
            {
                return Shell.Current.GoToAsync(route);
                //return Shell.Current.GoToAsync("///freechat/settings");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
