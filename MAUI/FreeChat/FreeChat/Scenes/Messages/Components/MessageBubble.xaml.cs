using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Models;

namespace FreeChat.Scenes.Messages.Components;

public partial class MessageBubble : ContentView
{
        #region Text
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MessageBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as MessageBubble;
            if (newV != null && !(newV is string)) return;
            var oldText = (string)old;
            var newText = (string)newV;
            me?.TextChanged(oldText, newText);
        });

        private void TextChanged(string oldText, string newText)
        {
            
        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        #endregion

        #region TextColor
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MessageBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as MessageBubble;
            if (newV != null && !(newV is Color)) return;
            var oldBackgroundColor = (Color)old;
            var newBackgroundColor = (Color)newV;
            me?.BackgroundColorChanged(oldBackgroundColor, newBackgroundColor);
        });

        private void BackgroundColorChanged(Color oldBackgroundColor, Color newBackgroundColor)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }
        #endregion



        #region ReplyTappedCommand
        public static readonly BindableProperty ReplyTappedCommandProperty = BindableProperty.Create(nameof(ReplyTappedCommand), typeof(ICommand), typeof(MessageBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as MessageBubble;
            if (newV != null && !(newV is ICommand)) return;
            var oldReplyTappedCommand = (ICommand)old;
            var newReplyTappedCommand = (ICommand)newV;
            me?.ReplyTappedCommandChanged(oldReplyTappedCommand, newReplyTappedCommand);
        });

        private void ReplyTappedCommandChanged(ICommand oldReplyTappedCommand, ICommand newReplyTappedCommand)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public ICommand ReplyTappedCommand
        {
            get => (ICommand)GetValue(ReplyTappedCommandProperty);
            set => SetValue(ReplyTappedCommandProperty, value);
        }
        #endregion




        #region ReplyBackgroundOpacity
        public static readonly BindableProperty ReplyBackgroundOpacityProperty = BindableProperty.Create(nameof(ReplyBackgroundOpacity),
            typeof(float), typeof(MessageBubble), defaultValue: 1f, propertyChanged: (obj, old, newV) =>
        {
            var me = obj as MessageBubble;
            if (newV != null && !(newV is Type)) return;
            var oldReplyBackgroundOpacity = (Type)old;
            var newReplyBackgroundOpacity = (Type)newV;
            me?.ReplyBackgroundOpacityChanged(oldReplyBackgroundOpacity, newReplyBackgroundOpacity);
        });

        private void ReplyBackgroundOpacityChanged(Type oldReplyBackgroundOpacity, Type newReplyBackgroundOpacity)
        {
        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public Type ReplyBackgroundOpacity
        {
            get => (Type)GetValue(ReplyBackgroundOpacityProperty);
            set => SetValue(ReplyBackgroundOpacityProperty, value);
        }
        #endregion



    public MessageBubble()
    {
        InitializeComponent();
    }

    private async void TapGestureRecognizer_OnTapped(object? sender, TappedEventArgs e)
    {
        var view = sender as View;
        if (view == null) return;
        
        await view.ScaleTo(0.95, 100, Easing.CubicIn);
    
        if (ReplyTappedCommand?.CanExecute(view.BindingContext as Message) ?? false) ReplyTappedCommand?.Execute(view.BindingContext as Message);
        
        // Animate scale back to original
        await view.ScaleTo(1, 100, Easing.CubicOut);
    }
}