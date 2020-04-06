using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessageBubble : PancakeView
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

        public MessageBubble()
        {
            InitializeComponent();
        }
    }
}