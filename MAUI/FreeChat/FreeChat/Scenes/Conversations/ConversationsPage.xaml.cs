using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Scenes.Conversations;

public partial class ConversationsPage : BaseTabbedPage
{
    public ConversationsPage(ConversationsViewModel conversationsViewModel)
    {
        BindingContext = conversationsViewModel;
        InitializeComponent();
    }
}