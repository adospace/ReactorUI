using ReactorUI.Skia.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    public abstract class Panel : FrameworkElement
    {
        protected Panel()
        {
        }

        public class ChildrenList : IReadOnlyList<UIElement>
        {
            private List<UIElement> _internalList = new List<UIElement>();
            private readonly Panel _owner;

            internal ChildrenList(Panel owner)
            {
                this._owner = owner;
            }

            public void Add(UIElement element)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(nameof(element));
                }

                _internalList.Add(element);
                if (element.Parent != null && element.Parent != _owner)
                    throw new InvalidOperationException();
                element.Parent = _owner;
                _owner.Invalidate(InvalidateMode.Measure);
            }

            public bool Remove(UIElement element)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(nameof(element));
                }

                if (_internalList.Remove(element))
                {
                    element.Parent = null;
                    _owner.Invalidate(InvalidateMode.Measure);
                    return true;
                }

                return false;
            }

            public UIElement this[int index] => _internalList[index];

            public int Count => _internalList.Count;

            public IEnumerator<UIElement> GetEnumerator()
            {
                return _internalList.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _internalList.GetEnumerator();
            }
        }

        protected abstract IEnumerable<UIElement> GetChildren();

        #region Render Pass
        protected override void RenderOverride(RenderContext context)
        {
            foreach (var child in GetChildren())
            {
                child.Render(context.Canvas);
            }

            base.RenderOverride(context);
        }
        #endregion

        #region Mouse
        protected override void OnHitTest(double x, double y, MouseEventsContext context)
        {
            foreach (var child in GetChildren())
                child.HandleMouseMove(x, y, context);

            base.OnHitTest(x, y, context);
        }

        protected override void OnMouseDown(double x, double y, MouseEventsContext context)
        {
            foreach (var child in GetChildren())
                child.HandleMouseDown(x, y, context);
            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseUp(double x, double y, MouseEventsContext context)
        {
            foreach (var child in GetChildren())
                child.HandleMouseUp(x, y, context);
            base.OnMouseUp(x, y, context);
        }

        #endregion

    }
}
