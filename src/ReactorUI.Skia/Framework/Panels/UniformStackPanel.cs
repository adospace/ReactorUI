using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    public class UniformStackPanel : Panel, ISupportOffset
    {
        #region Public Properties
        private ChildrenList _children;
        public ChildrenList Children
        {
            get
            {
                _children ??= new ChildrenList(this);
                return _children;
            }
        }

        protected override IEnumerable<UIElement> GetChildren()
        {
            return Children;
        }

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
        
        private Size _childSize = new Size(19.0, 19.0);
        public Size ChildSize
        {
            get => _childSize;
            set
            {
                if (!_childSize.IsCloseTo(value))
                {
                    _childSize = value;
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private Vector _offset;
        Vector ISupportOffset.Offset
        {
            get => _offset;
            set
            {
                if (!_offset.IsCloseTo(value))
                {
                    _offset = value.MinMax(new Size(), this.ViewportSize);
                    Invalidate(InvalidateMode.Measure);
                }
            }
        }

        private Size ViewportSize => new Size(_childSize.Width + Children.Count, _childSize.Height * Children.Count);
        Size ISupportOffset.ViewportSize
        {
            get => ViewportSize;
        }
        #endregion

        #region Measure Pass
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Orientation == Orientation.Horizontal)
            {
                double currentX = 0.0;
                bool offscreen;
                double maxHeight = 0.0;
                foreach (var child in Children)
                {
                    offscreen = currentX + ChildSize.Width < _offset.X ||
                        currentX > _offset.X + availableSize.Width;

                    if (offscreen)
                    {
                        child.SuspendLayout();
                    }
                    else
                    {
                        child.ResumeLayout();
                        child.Measure(new Size(ChildSize.Width, availableSize.Height));
                        maxHeight = Math.Max(maxHeight, child.DesiredSize.Height);
                    }

                    currentX += ChildSize.Width;
                }

                return new Size(ChildSize.Width * Children.Count, maxHeight);
            }
            else
            {
                double currentY = 0.0;
                bool offscreen;
                double maxWidth = 0.0;
                foreach (var child in Children)
                {
                    offscreen = currentY + ChildSize.Height < _offset.Y ||
                        currentY > _offset.Y + availableSize.Height;

                    if (offscreen)
                    {
                        child.SuspendLayout();
                    }
                    else
                    {
                        child.ResumeLayout();
                        child.Measure(new Size(ChildSize.Width, availableSize.Height));
                        maxWidth = Math.Max(maxWidth, child.DesiredSize.Height);
                    }

                    currentY += ChildSize.Height;
                }

                return new Size(maxWidth, ChildSize.Height * Children.Count);
            }
        }
        #endregion

        #region Arrange Pass
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Orientation == Orientation.Horizontal)
            {
                double currentX = 0.0;
                bool offscreen;
                foreach (var child in Children)
                {
                    offscreen = currentX + ChildSize.Width < _offset.X ||
                        currentX > _offset.X + finalSize.Width;

                    if (offscreen)
                    {
                        child.SuspendLayout();
                    }
                    else
                    {
                        child.ResumeLayout();
                        child.Arrange(new Rect(currentX - _offset.X, 0.0, ChildSize.Width, finalSize.Height));
                    }

                    currentX += ChildSize.Width;
                }
            }
            else
            {
                double currentY = 0.0;
                bool offscreen;
                foreach (var child in Children)
                {
                    offscreen = currentY + ChildSize.Height < _offset.Y ||
                        currentY > _offset.Y + finalSize.Height;

                    if (offscreen)
                    {
                        child.SuspendLayout();
                    }
                    else
                    {
                        child.ResumeLayout();
                        child.Arrange(new Rect(0.0, currentY - _offset.Y, finalSize.Width, ChildSize.Height));
                    }

                    currentY += ChildSize.Height;
                }
            }

            return finalSize;
        }
        #endregion

    }
}
