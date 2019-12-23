using ReactorUI.Contracts;
using ReactorUI.Contracts.Panels;
using ReactorUI.Primitives;
using ReactorUI.Styles;
using ReactorUI.Styles.Panels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Panels
{
    public class DockPanel : Panel<IDockPanel, DockPanelStyle>, IDockPanel
    {
        public DockPanel()
        {
            
        }

        public const string DockMetadataKey = "Dock";

        public Orientation Orientation { get; set; }

        public DockPanel DockLeft(VisualNode child)
        {
            if (Children.Count > 0 && Orientation == Orientation.Vertical)
                throw new ArgumentException();

            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Left);
            AddChild(child);
            Orientation = Orientation.Horizontal;
            return this;
        }

        public DockPanel DockTop(VisualNode child)
        {
            if (Children.Count > 0 && Orientation == Orientation.Horizontal)
                throw new ArgumentException();

            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Top);
            RemoveChild(child);
            Orientation = Orientation.Vertical;
            return this;
        }

        public DockPanel DockBottom(VisualNode child)
        {
            if (Children.Count > 0 && Orientation == Orientation.Horizontal)
                throw new ArgumentException();

            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Bottom);
            AddChild(child);
            Orientation = Orientation.Vertical;
            return this;
        }

        public DockPanel DockRight(VisualNode child)
        {
            if (Children.Count > 0 && Orientation == Orientation.Vertical)
                throw new ArgumentException();

            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Right);
            RemoveChild(child);
            Orientation = Orientation.Horizontal;
            return this;
        }

        private VisualNode _fillChild = null;
        public DockPanel Fill(VisualNode child)
        {
            if (_fillChild != null)
                throw new InvalidOperationException("Only one child can fill remaining space");

            _fillChild = child;
            AddChild(child);
            return this;
        }
    }

    public static class DockPanelExtensions
    {

    }
}
