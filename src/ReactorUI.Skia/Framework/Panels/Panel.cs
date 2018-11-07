using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Panels
{
    internal class Panel : FrameworkElement
    {
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


    }
}
