using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI
{
    public class VisualTree
    {
        public VisualTree(VisualNode root)
        {
            Root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public VisualNode Root { get; }

        public void Layout()
        {
            Root.Layout();
        }

        public void MergeWith(VisualNode newRoot)
        {
            Root.MergeWith(newRoot);
        }
    }
}
