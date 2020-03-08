using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleUserProfileTemplate : ContentView
    {
        public SimpleUserProfileTemplate()
        {
            InitializeComponent();
        }
    }
}