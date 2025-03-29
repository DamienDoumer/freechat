using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FreeChat.Scenes;

public partial class BaseTabbedPage : ContentPage
{
        #region TabSelectedIndex
        public static readonly BindableProperty TabSelectedIndexProperty = BindableProperty.Create(nameof(TabSelectedIndex), typeof(int), typeof(BaseTabbedPage), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as BaseTabbedPage;
            if (newV != null && !(newV is int)) return;
            var oldTabSelectedIndex = (int)old;
            var newTabSelectedIndex = (int)newV;
            me?.TabSelectedIndexChanged(oldTabSelectedIndex, newTabSelectedIndex);
        });

        private void TabSelectedIndexChanged(int oldTabSelectedIndex, int newTabSelectedIndex)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public int TabSelectedIndex
        {
            get => (int)GetValue(TabSelectedIndexProperty);
            set => SetValue(TabSelectedIndexProperty, value);
        }
        #endregion

        #region SettingsTappedCommand
        public static readonly BindableProperty SettingsTappedCommandProperty = BindableProperty.Create(nameof(SettingsTappedCommand), typeof(ICommand), typeof(BaseTabbedPage), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as BaseTabbedPage;
            if (newV != null && !(newV is Type)) return;
            var oldSettingsTappedCommand = (Type)old;
            var newSettingsTappedCommand = (Type)newV;
            me?.SettingsTappedCommandChanged(oldSettingsTappedCommand, newSettingsTappedCommand);
        });

        private void SettingsTappedCommandChanged(Type oldSettingsTappedCommand, Type newSettingsTappedCommand)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public ICommand SettingsTappedCommand
        {
            get => (ICommand)GetValue(SettingsTappedCommandProperty);
            set => SetValue(SettingsTappedCommandProperty, value);
        }
        #endregion

        #region MessagesTappedCommand
        public static readonly BindableProperty MessagesTappedCommandProperty = BindableProperty.Create(nameof(MessagesTappedCommand), typeof(ICommand), typeof(BaseTabbedPage), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as BaseTabbedPage;
            if (newV != null && !(newV is ICommand)) return;
            var oldMessagesTappedCommand = (ICommand)old;
            var newMessagesTappedCommand = (ICommand)newV;
            me?.MessagesTappedCommandChanged(oldMessagesTappedCommand, newMessagesTappedCommand);
        });

        private void MessagesTappedCommandChanged(ICommand oldMessagesTappedCommand, ICommand newMessagesTappedCommand)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public ICommand MessagesTappedCommand
        {
            get => (ICommand)GetValue(MessagesTappedCommandProperty);
            set => SetValue(MessagesTappedCommandProperty, value);
        }
        #endregion
        
        #region ViewContent
        public static readonly BindableProperty ViewContentProperty = BindableProperty.Create(nameof(ViewContent), typeof(View), typeof(BaseTabbedPage), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as BaseTabbedPage;
            if (newV != null && !(newV is View)) return;
            var oldViewContent = (View)old;
            var newViewContent = (View)newV;
            me?.ViewContentChanged(oldViewContent, newViewContent);
        });

        private void ViewContentChanged(View oldViewContent, View newViewContent)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public View ViewContent
        {
            get => (View)GetValue(ViewContentProperty);
            set => SetValue(ViewContentProperty, value);
        }
        #endregion
        
    public BaseTabbedPage()
    {
        InitializeComponent();
        SettingsTappedCommand = new Command(() => 
            Shell.Current.GoToAsync($"///{Routes.MessagesRoute}"));
        MessagesTappedCommand = new Command(() =>
            Shell.Current.GoToAsync($"///{Routes.ConversationsRoute}"));
    }
}