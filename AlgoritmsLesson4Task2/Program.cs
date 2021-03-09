using System;

namespace AlgoritmsLesson4Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();
            binaryTree.AddItem(30);
            binaryTree.AddItem(15);
            binaryTree.AddItem(45);
            binaryTree.AddItem(10);
            binaryTree.AddItem(18);
            binaryTree.AddItem(40);
            binaryTree.AddItem(60);
            binaryTree.AddItem(5);
            binaryTree.AddItem(13);
            binaryTree.AddItem(17);
            binaryTree.AddItem(19);
            binaryTree.AddItem(35);
            binaryTree.AddItem(43);
            binaryTree.AddItem(50);
            binaryTree.AddItem(75);


            TreeNode treeNode = binaryTree.GetNodeByValue(3);

            binaryTree.RemoveItem(30);
        }
    }
}
