using ReactorUI.Widgets.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReactorUI.WPF.Controls
{
    internal class FrameworkElement<T, I> : UIElement<T, I> where T : System.Windows.FrameworkElement, new() where I : IFrameworkElement
    {

        public override void Update(I widget)
        {
            base.Update(widget);
        }
    }
}
