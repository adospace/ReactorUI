using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    public class StackPanel : Panel
    {
        public StackPanel()
        {
            Children = new ChildrenList(this);
        }

        #region Public Properties
        public ChildrenList Children { get; }

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

        protected override IEnumerable<UIElement> GetChildren()
        {
            return Children;
        }
        #endregion

        #region  Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            var mySize = new Size();

            if (this.Children.Count == 0)
                return mySize;

            foreach (var child in Children)
            {
                if (Orientation == Orientation.Horizontal)
                {
                    child.Measure(new Size(double.PositiveInfinity, availableSize.Height));
                    mySize.Width += child.DesiredSize.Width;
                    mySize.Height = Math.Max(mySize.Height, child.DesiredSize.Height);
                }
                else
                {
                    child.Measure(new Size(availableSize.Width, double.PositiveInfinity));
                    mySize.Width = Math.Max(mySize.Width, child.DesiredSize.Width);
                    mySize.Height += child.DesiredSize.Height;
                }
            };

            return mySize;
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            var posChild = new Vector();
            var childrenSize = new Size();

            foreach (var child in Children)
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

                child.Arrange(new Rect(posChild.X, posChild.Y, sizeChild.Width, sizeChild.Height));

                if (Orientation == Orientation.Horizontal)
                {
                    posChild.X += sizeChild.Width;
                    childrenSize.Width += sizeChild.Width;
                    childrenSize.Height = Math.Max(childrenSize.Height, sizeChild.Height);
                }
                else
                {
                    posChild.Y += sizeChild.Height;
                    childrenSize.Width = Math.Max(childrenSize.Width, sizeChild.Width);
                    childrenSize.Height += sizeChild.Height;
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
