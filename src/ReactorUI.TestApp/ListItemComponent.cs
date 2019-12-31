using ReactorUI.Skia.Theme.Modern.Controls;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.TestApp
{
    public class ListItemComponent : Component
    {
        private readonly int _index;

        public ListItemComponent(int index)
        {
            _index = index;
        }

        public override VisualNode Render()
        {
            return new ContainerPanel(
                new Border()
                    .Width(32)
                    .Height(32)
                    .Background(Brushes.CommunicationCommunicationShade10)
                    .VerticalAlignment(Primitives.VerticalAlignment.Top)
                    .HorizontalAlignment(Primitives.HorizontalAlignment.Right)
                    .Margin(10),
                new TextBlock($"Item {_index}")
                    .Margin(50,10,10,10)
                    //.VerticalAlignment(Primitives.VerticalAlignment.Stretch)
                    ,
                new TextBlock("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.")
                    .Margin(50,30,10,10)
                    .VerticalAlignment(Primitives.VerticalAlignment.Top)
                    );
        }
    }
}
