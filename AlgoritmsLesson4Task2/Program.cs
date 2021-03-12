using System;

namespace AlgoritmsLesson4Task2
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

            BinaryTree binaryTree2 = new BinaryTree();
            binaryTree2.AddItem(30);
            binaryTree2.AddItem(12);
            binaryTree2.AddItem(45);
            binaryTree2.AddItem(10);
            binaryTree2.AddItem(18);
            binaryTree2.AddItem(40);
            binaryTree2.AddItem(60);
            binaryTree2.AddItem(5);
            binaryTree2.AddItem(11);
            binaryTree2.AddItem(17);
            binaryTree2.AddItem(19);
            binaryTree2.AddItem(35);
            binaryTree2.AddItem(43);
            binaryTree2.AddItem(50);
            binaryTree2.AddItem(75);
            binaryTree2.AddItem(15);
            binaryTree2.AddItem(16);
            binaryTree2.AddItem(14);


            Console.WriteLine(binaryTree.GetHashCode() == binaryTree2.GetHashCode());

            Console.WriteLine(binaryTree.Equals(binaryTree2));

            binaryTree.PrintTree();


        }
    }
}
