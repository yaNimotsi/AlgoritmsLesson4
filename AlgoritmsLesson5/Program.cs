using System;
using System.Collections.Generic;

using AlgoritmsLesson4Task2;

namespace AlgoritmsLesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            binaryTree.AddItem(30);
            binaryTree.AddItem(12);
            binaryTree.AddItem(45);
            binaryTree.AddItem(10);
            binaryTree.AddItem(18);
            binaryTree.AddItem(40);
            binaryTree.AddItem(60);
            binaryTree.AddItem(5);
            binaryTree.AddItem(11);
            binaryTree.AddItem(17);
            binaryTree.AddItem(19);
            binaryTree.AddItem(35);
            binaryTree.AddItem(43);
            binaryTree.AddItem(50);
            binaryTree.AddItem(75);
            binaryTree.AddItem(15);
            binaryTree.AddItem(16);
            binaryTree.AddItem(14);

            TreeNode root = binaryTree.GetRoot();

            var treeNode = BFS(binaryTree.Root, 14);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            treeNode = DFS(binaryTree.Root, 14);
        }

        static TreeNode BFS(TreeNode root, int searchedVal)
        {
            TreeNode currentNode;

            Queue<TreeNode> queueTreeNode = new Queue<TreeNode>();
            queueTreeNode.Enqueue(root);

            while (queueTreeNode.Count != 0)
            {
                currentNode = queueTreeNode.Dequeue();

                if (currentNode.Value == searchedVal)
                {
                    Console.Write($"{currentNode.Value} = {searchedVal};   ");
                    return currentNode;
                }
                else
                {
                    Console.Write($"{currentNode.Value} != {searchedVal};   ");
                    if (currentNode.LeftChild != null) queueTreeNode.Enqueue(currentNode.LeftChild);
                    if (currentNode.RightChild != null) queueTreeNode.Enqueue(currentNode.RightChild);
                }
            }

            return null;
        }

        static TreeNode DFS(TreeNode root, int searchedVal)
        {
            TreeNode currentNode;
            Stack<TreeNode> stackTreeNode = new Stack<TreeNode>();

            stackTreeNode.Push(root);

            while(stackTreeNode.Count != 0)
            {
                currentNode = stackTreeNode.Pop();

                if (currentNode.Value == searchedVal)
                {
                    Console.Write($"{currentNode.Value} = {searchedVal};   ");
                    return currentNode;
                }
                else
                {
                    Console.Write($"{currentNode.Value} != {searchedVal};   ");
                    if (currentNode.LeftChild != null) stackTreeNode.Push(currentNode.LeftChild);
                    if (currentNode.RightChild != null) stackTreeNode.Push(currentNode.RightChild);
                }
            }

            return null;
        }
    }
}
