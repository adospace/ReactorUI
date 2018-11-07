using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    internal class DockPanel : Panel
    {
        #region Public Properties
        private Orientation _orientation;
        public Orientation Orientation
        {
            get => _orientation;
            set
            {
                if (_orientation != value)
                {
                    _orientation = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        ChildrenList _dockPreviousChildren = null;
        public ChildrenList DockPreviousChildren
        {
            get
            {
                _dockPreviousChildren = _dockPreviousChildren ?? new ChildrenList(this);
                return _dockPreviousChildren;
            }
        }
        ChildrenList _dockNextChildren = null;
        public ChildrenList DockNextChildren
        {
            get
            {
                _dockNextChildren = _dockNextChildren ?? new ChildrenList(this);
                return _dockNextChildren;
            }
        }

        UIElement _fillChild;
        public UIElement FillChild
        {
            get => _fillChild;
            set
            {
                if (_fillChild != value)
                {
                    _fillChild = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = new Size();

            if (Orientation == Orientation.Horizontal)
            {
                var currentLeftWidth = 0.0;
                foreach (var leftChild in DockPreviousChildren)
                {
                    leftChild.Measure(new Size(double.PositiveInfinity, availableSize.Height));
                    currentLeftWidth += leftChild.DesiredSize.Width;
                }

                var currentRightWidth = 0.0;
                foreach (var rightChild in DockNextChildren)
                {
                    rightChild.Measure(new Size(double.PositiveInfinity, availableSize.Height));
                    currentRightWidth += rightChild.DesiredSize.Width;
                }

                if (FillChild != null)
                {
                    FillChild.Measure(new Size(
                        double.IsPositiveInfinity(availableSize.Width) ?
                            double.PositiveInfinity : Math.Max(0.0, availableSize.Width - (currentLeftWidth + currentRightWidth)),
                        availableSize.Height));
                }
            }
            else
            {
                var currentTopHeight = 0.0;
                foreach (var topChild in DockPreviousChildren)
                {
                    topChild.Measure(new Size(availableSize.Width, double.PositiveInfinity));
                    currentTopHeight += topChild.DesiredSize.Height;
                }

                var currentBottomHeight = 0.0;
                foreach (var bottomChild in DockNextChildren)
                {
                    bottomChild.Measure(new Size(availableSize.Width, double.PositiveInfinity));
                    currentBottomHeight += bottomChild.DesiredSize.Height;
                }

                if (FillChild != null)
                {
                    FillChild.Measure(new Size(
                        availableSize.Width,
                        double.IsPositiveInfinity(availableSize.Height) ?
                            double.PositiveInfinity : Math.Max(0.0, availableSize.Height - (currentTopHeight + currentBottomHeight))));
                }
            }

            return mySize;
        }

        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            var posPreviousChild = new Vector();
            var posNextChild = new Vector();
            var childrenSize = new Size();

            foreach (var child in DockPreviousChildren)
            {
                var sizeChild = new Size();
                if (Orientation == Orientation.Horizontal)
                {
                    sizeChild.Width = child.DesiredSize.Width;
                    sizeChild.Height = Math.Max(finalSize.Height, child.DesiredSize.Height);
                }
                else
                {
                    sizeChild.Height = child.DesiredSize.Height;
                    sizeChild.Width = Math.Max(finalSize.Width, child.DesiredSize.Width);
                }

                child.Arrange(new Rect(posPreviousChild.X, posPreviousChild.Y, sizeChild.Width, sizeChild.Height));

                if (Orientation == Orientation.Horizontal)
                {
                    posPreviousChild.X += sizeChild.Width;
                    childrenSize.Width += sizeChild.Width;
                    childrenSize.Height = Math.Max(childrenSize.Height, sizeChild.Height);
                }
                else
                {
                    posPreviousChild.Y += sizeChild.Height;
                    childrenSize.Width = Math.Max(childrenSize.Width, sizeChild.Width);
                    childrenSize.Height += sizeChild.Height;
                }
            }

            foreach (var child in DockNextChildren)
            {
                var sizeChild = new Size();
                if (Orientation == Orientation.Horizontal)
                {
                    sizeChild.Width = child.DesiredSize.Width;
                    sizeChild.Height = Math.Max(finalSize.Height, child.DesiredSize.Height);

                    child.Arrange(new Rect(finalSize.Width - posNextChild.X - sizeChild.Width, posNextChild.Y, sizeChild.Width, sizeChild.Height));
                }
                else
                {
                    sizeChild.Height = child.DesiredSize.Height;
                    sizeChild.Width = Math.Max(finalSize.Width, child.DesiredSize.Width);

                    child.Arrange(new Rect(posNextChild.X, finalSize.Height - posNextChild.Y - sizeChild.Height, sizeChild.Width, sizeChild.Height));
                }


                if (Orientation == Orientation.Horizontal)
                {
                    posNextChild.X += sizeChild.Width;
                    childrenSize.Width += sizeChild.Width;
                    childrenSize.Height = Math.Max(childrenSize.Height, sizeChild.Height);
                }
                else
                {
                    posNextChild.Y += sizeChild.Height;
                    childrenSize.Width = Math.Max(childrenSize.Width, sizeChild.Width);
                    childrenSize.Height += sizeChild.Height;
                }
            }

            if (FillChild != null)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    FillChild.Arrange(new Rect(posPreviousChild.X, 0.0, Math.Max(0.0, finalSize.Width - posNextChild.X - posPreviousChild.X), finalSize.Height));
                }
                else
                {
                    FillChild.Arrange(new Rect(0.0, posPreviousChild.Y, finalSize.Width, Math.Max(0.0, finalSize.Height - posNextChild.Y - posPreviousChild.Y)));
                }
            }

            if (Orientation == Orientation.Horizontal)
                return new Size(Math.Max(finalSize.Width, childrenSize.Width), finalSize.Height);
            else
                return new Size(finalSize.Width, Math.Max(finalSize.Height, childrenSize.Height));
        }
        #endregion

    }
}
