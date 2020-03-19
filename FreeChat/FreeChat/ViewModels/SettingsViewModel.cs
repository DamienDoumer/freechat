using FreeChat.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public SettingsViewModel(IDataStore<User> userDataStore, IConversationsDataStore convDataStore,
            IMessageDataStore messageDataStore) : base(userDataStore, convDataStore, messageDataStore)
        {
        }

        public override Task Initialize()
        {
            return Task.CompletedTask;
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
