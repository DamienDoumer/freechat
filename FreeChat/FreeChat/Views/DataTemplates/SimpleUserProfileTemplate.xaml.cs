using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleUserProfileTemplate : ContentView
    {
        #region IsInTitle
        public static readonly BindableProperty IsInTitleProperty = BindableProperty.Create(nameof(IsInTitle), typeof(bool), typeof(SimpleUserProfileTemplate), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as SimpleUserProfileTemplate;
            if (newV != null && !(newV is bool)) return;
            var oldIsInTitle = (bool)old;
            var newIsInTitle = (bool)newV;
            me?.IsInTitleChanged(oldIsInTitle, newIsInTitle);
        });

        private void IsInTitleChanged(bool oldIsInTitle, bool newIsInTitle)
        {

        }

        /// <summary>
        /// A bindable property which states if the user profile is displayed in the title view
        /// </summary>
        public bool IsInTitle
        {
            get => (bool)GetValue(IsInTitleProperty);
            set => SetValue(IsInTitleProperty, value);
        }
        #endregion


        public SimpleUserProfileTemplate()
        {
            InitializeComponent();
        }
    }
}