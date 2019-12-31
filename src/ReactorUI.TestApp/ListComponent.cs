using ReactorUI.Primitives;
using ReactorUI.Skia.Theme.Modern.Controls;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactorUI.TestApp
{
    public class ListComponent : Component
    {
        public override VisualNode Render()
        {
            return new Border(
               new ScrollViewer(
                   new UniformStackPanel(
                       Enumerable.Range(1, 1000).Select(i => new ComponentHost(new ListItemComponent(i))).ToArray()
                       //Enumerable.Range(1, 20).Select(i => new TextBlock($"Item {i}")).ToArray()
                       )
                   .Orientation(Orientation.Vertical)
                   .ChildSize(300, 100)
                   )
               
               
               
               )
               .Background(new SolidColorBrush(255, 255, 255));
        }
    }
}
