using FreeChat.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public MessagesViewModel(IDataStore<User> userDataStore, IConversationsDataStore convDataStore, 
            IMessageDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
        {
        }

        public override Task Initialize()
        {
            throw new NotImplementedException();
        }

        public override Task Stop()
        {
            throw new NotImplementedException();
        }
    }
}
