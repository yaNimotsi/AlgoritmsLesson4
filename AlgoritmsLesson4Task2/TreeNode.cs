using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsLesson4Task2
{
    public class TreeNode
    {
        int _value;
        int _depth;
        TreeNode _leftChild;
        TreeNode _rightChild;
        TreeNode _parent;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public int Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
        public TreeNode LeftChild
        {
            get { return _leftChild; }
            set { _leftChild = value; }
        }
        public TreeNode RightChild
        {
            get { return _rightChild; }
            set { _rightChild = value; }
        }
        public TreeNode Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public override bool Equals(object obj)
        {
            var treeNode = obj as TreeNode;

            if (treeNode == null) return false;

            return treeNode._value == Value && treeNode?.LeftChild?.Value == _leftChild?.Value && 
                treeNode?._rightChild?.Value == RightChild?.Value && treeNode.Depth == _depth;
        }

        public override int GetHashCode()
        {
            int valueHash = Value.GetHashCode();
            int leftChildHash = LeftChild?.GetHashCode() ?? 0;
            int rightChildHash = RightChild?.GetHashCode() ?? 0;

            return valueHash ^ leftChildHash ^ rightChildHash;
        }
    }
}
