using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    public class ContainerPanel : Panel
    {
        #region Public Properties
        private ChildrenList _children;
        public ChildrenList Children
        {
            get
            {
                _children = _children ?? new ChildrenList(this);
                return _children;
            }
        }
        protected override IEnumerable<UIElement> GetChildren()
        {
            return Children;
        }

        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            double maxHeight = 0.0;
            double maxWidth = 0.0;
            foreach (var child in Children)
            {
                child.Measure(new Size(double.PositiveInfinity, availableSize.Height));
                maxWidth = Math.Max(maxWidth, child.DesiredSize.Width);
                maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
            }

            return new Size(maxWidth, maxHeight);
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (var child in Children)
            {
                child.Arrange(new Rect(0.0, 0.0, finalSize.Width, finalSize.Height));
            }

            return finalSize;
        }
        #endregion

    }
}
