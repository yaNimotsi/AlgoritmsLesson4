﻿using System;
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

            TreeNode nodeParent = treeNode?.Parent ?? null;
            TreeNode leftChild = treeNode?.LeftChild ?? null;
            TreeNode rightChild = treeNode?.RightChild ?? null;


            if (nodeParent.LeftChild == treeNode)   //Удаление из левой ветки
            {

                if (leftChild == null && rightChild == null)
                {
                    nodeParent.LeftChild = null;
                }
            }
            else    //Удаление из правой ветики
            {
                if (leftChild == null && rightChild == null)
                {
                    nodeParent.RightChild = null;
                }
            }
            
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