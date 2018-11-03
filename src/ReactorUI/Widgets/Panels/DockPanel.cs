using ReactorUI.Contracts;
using ReactorUI.Primitives;
using ReactorUI.Styles;
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

        public DockPanel DockLeft(VisualNode child)
        {
            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Left);
            InternalChildren.Add(child);
            return this;
        }

        public DockPanel DockTop(VisualNode child)
        {
            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Top);
            InternalChildren.Add(child);
            return this;
        }

        public DockPanel DockBottom(VisualNode child)
        {
            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Bottom);
            InternalChildren.Add(child);
            return this;
        }

        public DockPanel DockRight(VisualNode child)
        {
            ((IMetadataProvider)child).SetMetadata(DockMetadataKey, Dock.Right);
            InternalChildren.Add(child);
            return this;
        }

        private VisualNode _fillChild = null;
        public DockPanel Fill(VisualNode child)
        {
            if (_fillChild != null)
                throw new InvalidOperationException("Only one child can fill remaining space");

            _fillChild = child;
            InternalChildren.Add(child);
            return this;
        }
    }

    public static class DockPanelExtensions
    {

    }
}
