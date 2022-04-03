using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Styles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlStyles : ResourceDictionary
    {
        public ControlStyles()
        {
            InitializeComponent();
        }
    }
}