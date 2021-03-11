using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoritmsLesson4Task2;

namespace TestForLesson5
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBFSMethod_UnContainsValue()
        {
            //Arrange
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
            TreeNode expected = binaryTree.GetNodeByValue(100);

            //Act
            TreeNode actual = binaryTree.BFS(100);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBFSMethod_ContainsValue()
        {
            //Arrange
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
            TreeNode expected = binaryTree.GetNodeByValue(19);

            //Act
            TreeNode actual = binaryTree.BFS(19);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDFSMethod_UnContainsValue()
        {
            //Arrange
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
            TreeNode expected = binaryTree.GetNodeByValue(123);

            //Act
            TreeNode actual = binaryTree.BFS(123);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDFSMethod_ContainsValue()
        {
            //Arrange
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
            TreeNode expected = binaryTree.GetNodeByValue(60);

            //Act
            TreeNode actual = binaryTree.BFS(60);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
