using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using FreeChat.Models;
using FreeChat.Services;
using ReactiveUI;
using Models;
using System.Threading.Tasks;

namespace FreeChat.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject, IViewModel
    {
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { this.RaiseAndSetIfChanged(ref isBusy, value); }
        }
        protected IDataStore<User> _userDataStore;
        protected IMessageDataStore _messageDataStore;
        protected IConversationsDataStore _conversationDataStore;
        protected IObservable<bool> _notBusyObservable;

        public BaseViewModel(IDataStore<User> userDataStore, 
            IConversationsDataStore convDataStore, IMessageDataStore messageDataStore)
        {
            _conversationDataStore = convDataStore;
            _messageDataStore = messageDataStore;
            _userDataStore = userDataStore;
            _notBusyObservable = this.WhenAnyValue(vm => vm.IsBusy, isBusy => !isBusy);
        }

        public abstract Task Initialize();

        public abstract Task Stop();
    }

    public interface IViewModel
    {
        Task Initialize();
        Task Stop();
    }
}
