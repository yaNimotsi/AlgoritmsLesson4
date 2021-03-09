using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsLesson4Task2
{
    class BinaryTree : ITree
    {
        TreeNode root;

        public void AddItem(int value)
        {
            TreeNode treeNode = new TreeNode()
            {
                Value = value,
                LeftChild = null,
                RightChild = null,
                Parent = null
            };

            if (root == null)
            {
                root = treeNode;
            }
            else
            {
                TreeNode currentNode = root;
                while (true)
                {
                    if (value > currentNode.Value)
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = treeNode;
                            treeNode.Parent = currentNode;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = treeNode;
                            treeNode.Parent = currentNode;
                            return;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (root == null) return null;

            return FindNodeByValue(value, root);
        }

        public TreeNode GetRoot()
        {
            return root;
        }

        public void PrintTree()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int value)
        {
            if (root == null) return;

            TreeNode treeNode = FindNodeByValue(value, root);

            if (treeNode == null) return;

            
            //Удаление листа
            if (treeNode.LeftChild == null && treeNode.RightChild == null)
            {
                TreeNode parentNode = treeNode.Parent;
                
                if (parentNode.LeftChild == treeNode) parentNode.LeftChild = null;
                else parentNode.RightChild = null;
            }


            //Удаление нода не имеющего правого поддерева
            if (treeNode.LeftChild != null && treeNode.RightChild == null)
            {
                TreeNode parentNode = treeNode.Parent;

                if (parentNode.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                else parentNode.RightChild = treeNode.RightChild;

                TreeNode leftChildCurrentNode = treeNode.LeftChild;
                leftChildCurrentNode.Parent = parentNode;
            }

            //Удаление нода не имеющего левого поддерева
            if (treeNode.LeftChild == null && treeNode.RightChild != null)
            {
                TreeNode parentNode = treeNode.Parent;

                if (parentNode.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                else parentNode.RightChild = treeNode.RightChild;

                TreeNode rightChildCurrentNode = treeNode.RightChild;
                rightChildCurrentNode.Parent = parentNode;
            }

            //Удаление нода с двумя ветками
            if (treeNode.LeftChild != null && treeNode.RightChild != null)
            {
                TreeNode nodeToReplace = FindMaxOnRight(treeNode);

                TreeNode parentNodfeToReplace = nodeToReplace.Parent;
                parentNodfeToReplace.RightChild = null;

                nodeToReplace.Parent = treeNode.Parent;
                nodeToReplace.RightChild = treeNode.RightChild;
                nodeToReplace.LeftChild = treeNode.LeftChild;

                TreeNode parentNodeToRemove = treeNode.Parent;

                if (parentNodeToRemove.LeftChild == treeNode) parentNodeToRemove.LeftChild = nodeToReplace;
                else parentNodeToRemove.RightChild = nodeToReplace;
            }
            
        }

        private static TreeNode FindMaxOnRight(TreeNode startNode)
        {
            TreeNode currentNod = startNode.LeftChild;

            while (currentNod.RightChild != null)
            {
                currentNod = currentNod.RightChild;
            }
            return currentNod;
        }

        private static TreeNode FindNodeByValue(int value, TreeNode root)
        {
            TreeNode currentNode = root;
            while (true)
            {
                if (currentNode == null) return null;
                else if (currentNode.Value == value) return currentNode;

                if (value > currentNode.Value)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    currentNode = currentNode.LeftChild;
                }
            }
        }
    }
}
