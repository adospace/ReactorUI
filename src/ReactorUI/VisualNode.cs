﻿using ReactorUI.Contracts;
using System.Collections.Generic;

namespace ReactorUI
{
    public abstract class VisualNode : IMetadataProvider
    {
        protected VisualNode()
        {
            System.Diagnostics.Debug.WriteLine($"{this}->Created()");
        }

        public object Key { get; set; }

        public VisualNode Parent { get; private set; }

        private bool _invalidated = false;
        protected void Invalidate()
        {
            _invalidated = true;
            System.Diagnostics.Debug.WriteLine($"{this}->Invalidated()");
        }

        private IReadOnlyList<VisualNode> _children = null;
        public IReadOnlyList<VisualNode> Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new List<VisualNode>(RenderChildren());
                    foreach (var child in _children)
                        child.Parent = this;
                }
                return _children;
            }
        }

        internal virtual void MergeWith(VisualNode newNode)
        {
            if (newNode == this)
                return;

            for (int i = 0; i < Children.Count; i++)
            {
                if (newNode.Children.Count > i)
                {
                    Children[i].MergeWith(newNode.Children[i]);
                }
            }

            for (int i = newNode.Children.Count; i < Children.Count; i++)
            {
                Children[i].OnUnmount();
                Children[i].Parent = null;
            }

            Parent = null;
        }

        internal virtual void MergeChildrenFrom(IReadOnlyList<VisualNode> oldChildren)
        {
            for (int i = 0; i < Children.Count; i++)
            {
                if (oldChildren.Count > i)
                {
                    oldChildren[i].MergeWith(Children[i]);
                }
            }

            for (int i = Children.Count; i < oldChildren.Count; i++)
            {
                oldChildren[i].OnUnmount();
                oldChildren[i].Parent = null;
            }
        }

        protected abstract IEnumerable<VisualNode> RenderChildren();

        protected bool _isMounted = false;
        protected bool _stateChanged = true;

        internal void Layout()
        {
            if (_invalidated)
            {
                System.Diagnostics.Debug.WriteLine($"{this}->Layout(Invalidated)");
                var oldChildren = Children;
                _children = null;
                MergeChildrenFrom(oldChildren);
                _invalidated = false;
            }

            if (!_isMounted && Parent != null)
                OnMount();

            OnAnimate();

            if (_stateChanged)
                OnUpdate();

            foreach (var child in Children)
                child.Layout();

        }

        protected virtual void OnAnimate()
        {

        }

        protected virtual void OnMount()
        {
            _isMounted = true;
        }

        protected virtual void OnUnmount()
        {
            _isMounted = false;
        }

        protected virtual void OnUpdate()
        {
            _stateChanged = false;
        }


        private Dictionary<string, object> _metadata = null;
        void IMetadataProvider.SetMetadata<T>(string key, T value)
        {
            _metadata = _metadata ?? new Dictionary<string, object>();
            _metadata[key] = value;
        }

        T IMetadataProvider.GetMetadata<T>(string key, T defaultValue)
        {
            if (_metadata == null)
                return defaultValue;

            if (_metadata.TryGetValue(key, out var value))
                return (T)value;

            return defaultValue;
        }

        bool IMetadataProvider.ContainsMetadata(string key)
        {
            if (_metadata == null ||
                !_metadata.ContainsKey(key))
                return false;

            return true;
        }
    }

}
