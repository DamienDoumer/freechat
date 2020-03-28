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
    public partial class ToggleButton : ContentView
    {
        public const string Toggled_State_Name = "Toggled";
        public const string Not_Toggled_State_Name = "NotToggled";

        #region ToggleCommand
        public static readonly BindableProperty ToggleCommandProperty = BindableProperty.Create(nameof(ToggleCommand), typeof(ICommand), typeof(ToggleButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as ToggleButton;
            if (newV != null && !(newV is ICommand)) return;
            var oldToggleCommand = (ICommand)old;
            var newToggleCommand = (ICommand)newV;
            me?.ToggleCommandChanged(oldToggleCommand, newToggleCommand);
        });

        private void ToggleCommandChanged(ICommand oldToggleCommand, ICommand newToggleCommand)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public ICommand ToggleCommand
        {
            get => (ICommand)GetValue(ToggleCommandProperty);
            set => SetValue(ToggleCommandProperty, value);
        }
        #endregion

        #region IsToggled
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(ToggleButton), defaultValue: true, propertyChanged: (obj, old, newV) =>
        {
            var me = obj as ToggleButton;
            if (newV != null && !(newV is bool)) return;
            var oldIsToggled = (bool)old;
            var newIsToggled = (bool)newV;
            me?.IsToggledChanged(oldIsToggled, newIsToggled);
        });

        private void IsToggledChanged(bool oldIsToggled, bool newIsToggled)
        {
            if (newIsToggled)
            {
                VisualStateManager.GoToState(this, Toggled_State_Name);
            }
            else
            {
                VisualStateManager.GoToState(this, Not_Toggled_State_Name);
            }
        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }
        #endregion
        #region ToggleOptionTitle
        public static readonly BindableProperty ToggleOptionTitleProperty = BindableProperty.Create(nameof(ToggleOptionTitle), typeof(string), typeof(ToggleButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as ToggleButton;
            if (newV != null && !(newV is string)) return;
            var oldToggleOptionTitle = (string)old;
            var newToggleOptionTitle = (string)newV;
            me?.ToggleOptionTitleChanged(oldToggleOptionTitle, newToggleOptionTitle);
        });

        private void ToggleOptionTitleChanged(string oldToggleOptionTitle, string newToggleOptionTitle)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public string ToggleOptionTitle
        {
            get => (string)GetValue(ToggleOptionTitleProperty);
            set => SetValue(ToggleOptionTitleProperty, value);
        }
        #endregion
        #region NotToggledOptionTitle
        public static readonly BindableProperty NotToggledOptionTitleProperty = BindableProperty.Create(nameof(NotToggledOptionTitle), typeof(string), typeof(ToggleButton), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as ToggleButton;
            if (newV != null && !(newV is string)) return;
            var oldNotToggledOptionTitle = (string)old;
            var newNotToggledOptionTitle = (string)newV;
            me?.NotToggledOptionTitleChanged(oldNotToggledOptionTitle, newNotToggledOptionTitle);
        });

        private void NotToggledOptionTitleChanged(string oldNotToggledOptionTitle, string newNotToggledOptionTitle)
        {

        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public string NotToggledOptionTitle
        {
            get => (string)GetValue(NotToggledOptionTitleProperty);
            set => SetValue(NotToggledOptionTitleProperty, value);
        }
        #endregion

        public ToggleButton()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if ((bool)ToggleCommand?.CanExecute(IsToggled))
            {
                IsToggled = true;
                ToggleCommand.Execute(IsToggled);
            }
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if ((bool)ToggleCommand?.CanExecute(IsToggled))
            {
                IsToggled = false;
                ToggleCommand.Execute(IsToggled);
            }
        }
    }
}