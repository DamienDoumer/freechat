using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeChat.Views.DataTemplates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesageISentTemplate : BaseTemplate
    {
        public MesageISentTemplate()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            this.ScaleTo(1, 300);
            base.OnBindingContextChanged();
        }
    }
}