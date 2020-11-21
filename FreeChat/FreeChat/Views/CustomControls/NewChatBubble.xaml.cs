using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewChatBubble : TemplatedView
    {


        #region Text
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(NewChatBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as NewChatBubble;
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
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NewChatBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as NewChatBubble;
            if (newV != null && !(newV is Color)) return;
            var oldBackgroundColor = (Color)old;
            var newBackgroundColor = (Color)newV;
            me?.TextColorChanged(oldBackgroundColor, newBackgroundColor);
        });

        private void TextColorChanged(Color oldBackgroundColor, Color newBackgroundColor)
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

        #region Content
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(NewChatBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as NewChatBubble;
            if (newV != null && !(newV is View)) return;
            var oldContent = (View)old;
            var newContent = (View)newV;
            me?.ContentChanged(oldContent, newContent);
        });

        private void ContentChanged(View oldContent, View newContent)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public View Content
        {
            get => (View)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
        #endregion


        #region ReplyTappedCommand
        public static readonly BindableProperty ReplyTappedCommandProperty = BindableProperty.Create(nameof(ReplyTappedCommand), typeof(ICommand), typeof(NewChatBubble), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as NewChatBubble;
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




        public NewChatBubble()
        {
            InitializeComponent();
        }
    }
}