using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FreeChat.Views.DataTemplates
{
    public class BaseTemplate : ContentView
    {

        #region ParentContext
        public static readonly BindableProperty ParentContextProperty = BindableProperty.Create(nameof(ParentContext), typeof(object), typeof(BaseTemplate), propertyChanged: (obj, old, newV) =>
        {
            var me = obj as BaseTemplate;
            if (newV != null && !(newV is object)) return;
            var oldParentContext = (object)old;
            var newParentContext = (object)newV;
            me?.ParentContextChanged(oldParentContext, newParentContext);
        });

        private void ParentContextChanged(object oldParentContext, object newParentContext)
        {
        }

        /// <summary>
        /// A bindable property
        /// </summary>
        public object ParentContext
        {
            get => (object)GetValue(ParentContextProperty);
            set => SetValue(ParentContextProperty, value);
        }
        #endregion


    }
}
