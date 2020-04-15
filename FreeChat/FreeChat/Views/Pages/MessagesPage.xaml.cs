using FreeChat.Helpers;
using FreeChat.Helpers.MyEventArgs;
using FreeChat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagesPage : BasePage
    {
        #region BackCommand
        public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(MessagesPage), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as MessagesPage;
            if (newV != null && !(newV is ICommand)) return;
            var oldBackCommand = (ICommand)old;
            var newBackCommand = (ICommand)newV;
            me?.BackCommandChanged(oldBackCommand, newBackCommand);
        });

        private void BackCommandChanged(ICommand oldBackCommand, ICommand newBackCommand)
        {

        }

        /// <summary>
        /// When back button is pressed, this command is fired
        /// </summary>
        public ICommand BackCommand
        {
            get => (ICommand)GetValue(BackCommandProperty);
            set => SetValue(BackCommandProperty, value);
        }
        #endregion


        void IsFocusOnKeyBoardChanged(bool newIsFocusOnKeyBoard)
        {
            if (newIsFocusOnKeyBoard)
                TextInput.Focus();
            else
                TextInput.Unfocus();
        }

        public MessagesPage()
        {
            InitializeComponent();
            BackCommand = new Command(async _ => 
                await AppShell.Current.Navigation.PopModalAsync());
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<IViewModel, MyFocusEventArgs>(this, Constants.ShowKeyboard, (s, args) =>
                IsFocusOnKeyBoardChanged(args.IsFocused));
            MessagingCenter.Subscribe<IViewModel, ScrollToItemEventArgs>(this, Constants.ScrollToItem, (s, eargs) =>
            {
                MessagesCollectionView.ScrollTo(eargs.Item);
            });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<IViewModel, MyFocusEventArgs>(this, Constants.ShowKeyboard);
            MessagingCenter.Unsubscribe<IViewModel, ScrollToItemEventArgs>(this, Constants.ScrollToItem);
           base.OnDisappearing();
        }
    }
}