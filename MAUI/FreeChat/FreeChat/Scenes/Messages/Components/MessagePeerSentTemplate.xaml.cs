using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeChat.Scenes.Shared;

namespace FreeChat.Scenes.Messages.Components;

public partial class MessagePeerSentTemplate : BaseTemplate
{
    public MessagePeerSentTemplate(object parentContext)
    {
        ParentContext = parentContext;
        InitializeComponent();
        //MAUI's XAML has a few bugs, forcing me to do things here (in Xamarin project, 
        //I didn't have these constraints).
        MessageBubble1.ReplyTappedCommand = (ParentContext as MessagesViewModel)!.ReplyMessageSelectedCommand;
    }
}