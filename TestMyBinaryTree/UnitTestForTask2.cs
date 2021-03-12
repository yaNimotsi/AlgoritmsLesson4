using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoritmsLesson4Task2;
using System.Collections.Generic;

namespace TestMyBinaryTree
{
    [TestClass]
    public class UnitTestForTask2
    {
        
        [TestMethod]
        public void TestAddMethodWithOutOtherNode()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            TreeNode expected = new TreeNode()
            {
                Depth = 1,
                Parent = null,
                LeftChild = null,
                RightChild = null,
                Value = 50
            };

            //Act
            testsTree.AddItem(50);

            //Assert
            var actual = testsTree.Root;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddMethodWithSomeNode()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            

            TreeNode expected1 = new TreeNode()
            {
                Depth = 2,
                Parent = testsTree.Root,
                LeftChild = null,
                RightChild = null,
                Value = 30
            };
            TreeNode expected2 = new TreeNode()
            {
                Depth = 2,
                Parent = testsTree.Root,
                LeftChild = null,
                RightChild = null,
                Value = 60
            };

            //Act
            testsTree.AddItem(50);
            testsTree.AddItem(30);
            testsTree.AddItem(60);

            //Assert
            var actual1 = testsTree.Root.LeftChild;
            var actual2 = testsTree.Root.RightChild;
            
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void TestGetNodeByValue_WhenNodeIsContains_LeftVector()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            testsTree.AddItem(50);
            testsTree.AddItem(40);
            testsTree.AddItem(30);
            testsTree.AddItem(45);
            testsTree.AddItem(42);
            testsTree.AddItem(5);
            testsTree.AddItem(600);
            testsTree.AddItem(70);
            testsTree.AddItem(88);
            testsTree.AddItem(90);

            TreeNode expected = new TreeNode()
            {
                Depth = 3,
                LeftChild = testsTree.Root.LeftChild.RightChild.LeftChild,
                RightChild = null,
                Parent = testsTree.Root.LeftChild,
                Value = 45
            };

            //Act
            var actual = testsTree.GetNodeByValue(45);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetNodeByValue_WhenNodeIsContains_RightVector()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            testsTree.AddItem(50);
            testsTree.AddItem(40);
            testsTree.AddItem(30);
            testsTree.AddItem(45);
            testsTree.AddItem(42);
            testsTree.AddItem(5);
            testsTree.AddItem(600);
            testsTree.AddItem(70);
            testsTree.AddItem(88);
            testsTree.AddItem(90);

            TreeNode expected = new TreeNode()
            {
                Depth = 2,
                LeftChild = testsTree.Root.RightChild.LeftChild,
                RightChild = null,
                Parent = testsTree.Root,
                Value = 600
            };

            //Act
            var actual = testsTree.GetNodeByValue(600);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetNodeByValue_WhenNodeIsNotContains()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            testsTree.AddItem(50);
            testsTree.AddItem(40);
            testsTree.AddItem(30);
            testsTree.AddItem(45);
            testsTree.AddItem(42);
            testsTree.AddItem(5);
            testsTree.AddItem(600);
            testsTree.AddItem(70);
            testsTree.AddItem(88);
            testsTree.AddItem(90);

            TreeNode expected = null;

            //Act
            var actual = testsTree.GetNodeByValue(100);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestOverrideGetHashCode()
        {
            //Arrange
            BinaryTree testsTree = new BinaryTree();
            testsTree.AddItem(50);
            testsTree.AddItem(40);
            testsTree.AddItem(30);
            testsTree.AddItem(45);
            testsTree.AddItem(42);
            testsTree.AddItem(5);
            testsTree.AddItem(600);
            testsTree.AddItem(70);
            testsTree.AddItem(88);
            testsTree.AddItem(90);


            Queue<TreeNode> queueTreeNode = new Queue<TreeNode>();
            queueTreeNode.Enqueue(testsTree.GetRoot());

            TreeNode currentNode;

            int expected = 0;

            while (queueTreeNode.Count != 0)
            {
                currentNode = queueTreeNode.Dequeue();
                expected = expected ^ currentNode.GetHashCode();

                if (currentNode.LeftChild != null) queueTreeNode.Enqueue(currentNode.LeftChild);
                if (currentNode.RightChild != null) queueTreeNode.Enqueue(currentNode.RightChild);
            }
            //Act
            var actual = testsTree.GetHashCode();

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveItem_UnConteinsValue()
        {
            //Arrange
            BinaryTree expected = new BinaryTree();
            expected.AddItem(50);
            expected.AddItem(40);
            expected.AddItem(30);
            expected.AddItem(45);
            expected.AddItem(42);
            expected.AddItem(5);
            expected.AddItem(600);
            expected.AddItem(70);
            expected.AddItem(88);
            expected.AddItem(90);

            int expectedHash = expected.GetHashCode();
            //Act
            BinaryTree actual = new BinaryTree();
            actual.AddItem(50);
            actual.AddItem(40);
            actual.AddItem(30);
            actual.AddItem(45);
            actual.AddItem(42);
            actual.AddItem(5);
            actual.AddItem(600);
            actual.AddItem(70);
            actual.AddItem(88);
            actual.AddItem(90);

            actual.RemoveItem(100);

            int actualHash = actual.GetHashCode();
            //Assert
            Assert.AreEqual(expectedHash, actualHash);
        }

        [TestMethod]
        public void TestRemoveItem_ValueIsList()
        {
            //Arrange
            BinaryTree expectedTree = new BinaryTree();
            expectedTree.AddItem(50);
            expectedTree.AddItem(40);
            expectedTree.AddItem(30);
            expectedTree.AddItem(45);
            expectedTree.AddItem(42);
            expectedTree.AddItem(600);
            expectedTree.AddItem(70);
            expectedTree.AddItem(88);
            expectedTree.AddItem(90);

            int expected = expectedTree.GetHashCode();
            //Act
            BinaryTree actualTree = new BinaryTree();
            actualTree.AddItem(50);
            actualTree.AddItem(40);
            actualTree.AddItem(30);
            actualTree.AddItem(45);
            actualTree.AddItem(42);
            actualTree.AddItem(5);
            actualTree.AddItem(600);
            actualTree.AddItem(70);
            actualTree.AddItem(88);
            actualTree.AddItem(90);

            actualTree.RemoveItem(5);

            int actual = actualTree.GetHashCode();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveItem_VithOutRightVector()
        {
            //Arrange
            BinaryTree expectedTree = new BinaryTree();
            expectedTree.AddItem(50);
            expectedTree.AddItem(40);
            expectedTree.AddItem(22);
            expectedTree.AddItem(45);
            expectedTree.AddItem(42);
            expectedTree.AddItem(600);
            expectedTree.AddItem(70);
            expectedTree.AddItem(88);
            expectedTree.AddItem(90);

            int expected = expectedTree.GetHashCode();
            //Act
            BinaryTree actualTree = new BinaryTree();
            actualTree.AddItem(50);
            actualTree.AddItem(40);
            actualTree.AddItem(30);
            actualTree.AddItem(22);
            actualTree.AddItem(45);
            actualTree.AddItem(42);
            actualTree.AddItem(600);
            actualTree.AddItem(70);
            actualTree.AddItem(88);
            actualTree.AddItem(90);

            actualTree.RemoveItem(30);

            int actual = actualTree.GetHashCode();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveItem_VithOutLefttVector()
        {
            //Arrange
            BinaryTree expectedTree = new BinaryTree();
            expectedTree.AddItem(50);
            expectedTree.AddItem(40);
            expectedTree.AddItem(30);
            expectedTree.AddItem(22);
            expectedTree.AddItem(43);
            expectedTree.AddItem(600);
            expectedTree.AddItem(70);
            expectedTree.AddItem(88);
            expectedTree.AddItem(90);

            int expected = expectedTree.GetHashCode();
            //Act
            BinaryTree actualTree = new BinaryTree();
            actualTree.AddItem(50);
            actualTree.AddItem(40);
            actualTree.AddItem(30);
            actualTree.AddItem(22);
            actualTree.AddItem(42);
            actualTree.AddItem(43);
            actualTree.AddItem(600);
            actualTree.AddItem(70);
            actualTree.AddItem(88);
            actualTree.AddItem(90);

            actualTree.RemoveItem(42);

            int actual = actualTree.GetHashCode();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemoveItem_VithTwoVectors()
        {
            //Arrange
            BinaryTree expectedTree = new BinaryTree();
            expectedTree.AddItem(50);
            expectedTree.AddItem(31);
            expectedTree.AddItem(30);
            expectedTree.AddItem(22);
            expectedTree.AddItem(45);
            expectedTree.AddItem(42);
            expectedTree.AddItem(600);
            expectedTree.AddItem(70);
            expectedTree.AddItem(88);
            expectedTree.AddItem(90);

            int expected = expectedTree.GetHashCode();
            //Act
            BinaryTree actualTree = new BinaryTree();
            actualTree.AddItem(50);
            actualTree.AddItem(40);
            actualTree.AddItem(30);
            actualTree.AddItem(31);
            actualTree.AddItem(22);
            actualTree.AddItem(45);
            actualTree.AddItem(42);
            actualTree.AddItem(600);
            actualTree.AddItem(70);
            actualTree.AddItem(88);
            actualTree.AddItem(90);

            actualTree.RemoveItem(40);

            int actual = actualTree.GetHashCode();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
