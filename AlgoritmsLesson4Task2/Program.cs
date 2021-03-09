using System;

namespace AlgoritmsLesson4Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.AddItem(10);
            binaryTree.AddItem(15);
            binaryTree.AddItem(9);
            binaryTree.AddItem(8);

            TreeNode treeNode = binaryTree.GetNodeByValue(3);
        }
    }
}
