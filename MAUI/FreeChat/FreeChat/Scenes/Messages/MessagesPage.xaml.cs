using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using FreeChat.Scenes.Messages.Helpers;
using FreeChat.Scenes.Shared;

namespace FreeChat.Scenes.Messages;

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
        
        public MessagesPage(MessagesViewModel ViewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel;
            BackCommand = new AsyncRelayCommand(_ => 
                AppShell.Current.Navigation.PopModalAsync());
        }

        private void TextInput_Focused(object sender, FocusEventArgs e)
        {
            if (!e.IsFocused)
                VisualStateManager.GoToState(TextInput, "Unfocused");
        }
        
        protected override void OnAppearing()
        {
            TextInput.Focused += TextInput_Focused;
            WeakReferenceMessenger.Default.Register<MyFocusEventArgs>(this, (s, args) =>
                IsFocusOnKeyBoardChanged(args.IsFocused));

            WeakReferenceMessenger.Default.Register<ScrollToItemEventArgs>(this, (s, eargs) =>
            {
                MessagesCollectionView.ScrollTo(eargs.Item);
            });
            
            WeakReferenceMessenger.Default.Register<KeyboardAppearEventArgs>(this, (sender, eargs) =>
            {
                if (MessagesGrid.TranslationY == 0)
                {
                    MessagesGrid.TranslationY -= eargs.KeyboardSize;
                }
            });
            WeakReferenceMessenger.Default.Register<string>(this, (sender, eargs) =>
            {
                MessagesGrid.TranslationY = 0;
            });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TextInput.Focused -= TextInput_Focused;
            WeakReferenceMessenger.Default.UnregisterAll(this);
        }
}