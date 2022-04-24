using FreeChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationsPage : BaseTabbedPage
    {
        public ConversationsPage(ConversationsViewModel conversationsViewModel)
        {
            InitializeComponent();

            BindingContext = conversationsViewModel;
        }
    }
}