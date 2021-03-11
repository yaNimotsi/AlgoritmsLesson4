using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsLesson4Task2
{
    public class BinaryTree : ITree
    {
        TreeNode _root;

        public TreeNode Root
        {
            get { return _root; }
        }
        /// <summary>
        /// Добавление нода, с указанным значением в дерево
        /// </summary>
        /// <param name="value"></param>
        public void AddItem(int value)
        {
            TreeNode treeNode = new TreeNode()
            {
                Value = value,
                Depth = 1,
                LeftChild = null,
                RightChild = null,
                Parent = null
            };

            if (_root == null)
            {
                _root = treeNode;
            }
            else
            {
                TreeNode currentNode = _root;
                while (true)
                {
                    if (value > currentNode.Value)
                    {
                        if (currentNode.RightChild == null)
                        {
                            treeNode.Depth++;
                            currentNode.RightChild = treeNode;
                            treeNode.Parent = currentNode;
                            return;
                        }
                        else
                        {
                            treeNode.Depth++;
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else
                    {
                        if (currentNode.LeftChild == null)
                        {
                            treeNode.Depth++;
                            currentNode.LeftChild = treeNode;
                            treeNode.Parent = currentNode;
                            return;
                        }
                        else
                        {
                            treeNode.Depth++;
                            currentNode = currentNode.LeftChild;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Получение ссылки на нод, с указанным значением.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (_root == null) return null;

            return FindNodeByValue(value, _root);
        }

        /// <summary>
        /// Возврат корня дерева
        /// </summary>
        /// <returns></returns>
        public TreeNode GetRoot()
        {
            return _root;
        }


        /// <summary>
        /// Удаление нода с указанным значением
        /// </summary>
        /// <param name="value">Значение нода, которое следует удалить</param>
        public void RemoveItem(int value)
        {
            if (_root == null) return;   //Выход при пустом дереве

            TreeNode treeNode = FindNodeByValue(value, _root);   //Полуение ссылки на нод, который требуется удалить

            if (treeNode == null) return;   //Если ссылка пустая, то выходим


            //Удаление листа
            if (treeNode.LeftChild == null && treeNode.RightChild == null)
            {
                if (treeNode == _root)
                {
                    _root = null;
                    return;
                }

                TreeNode parentNode = treeNode.Parent;

                if (parentNode.LeftChild == treeNode) parentNode.LeftChild = null;
                else parentNode.RightChild = null;

                return;
            }


            //Удаление нода не имеющего правого поддерева
            if (treeNode.LeftChild != null && treeNode.RightChild == null)
            {
                TreeNode parentNode = treeNode.Parent;

                if (parentNode?.LeftChild == treeNode)
                    parentNode.LeftChild = treeNode.LeftChild;
                else if (treeNode == _root)
                    treeNode.Depth = 1;

                TreeNode leftChildCurrentNode = treeNode.LeftChild;
                leftChildCurrentNode.Parent = parentNode;
                leftChildCurrentNode.Depth--;

                return;
            }

            //Удаление нода не имеющего левого поддерева
            if (treeNode.LeftChild == null && treeNode.RightChild != null)
            {
                TreeNode parentNode = treeNode.Parent;

                //if (parentNode.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                //else parentNode.RightChild = treeNode.RightChild;

                if (parentNode?.RightChild == treeNode)
                    parentNode.RightChild = treeNode.RightChild;
                else if (treeNode == _root)
                    _root = treeNode.RightChild;

                TreeNode rightChildCurrentNode = treeNode.RightChild;
                rightChildCurrentNode.Parent = parentNode;
                rightChildCurrentNode.Depth--;

                return;
            }

            //Удаление нода с двумя ветками
            if (treeNode.LeftChild != null && treeNode.RightChild != null)
            {
                TreeNode nodeToReplace = FindMaxOnRight(treeNode);

                TreeNode parentNodfeToReplace = nodeToReplace.Parent;
                parentNodfeToReplace.RightChild = null;

                nodeToReplace.Parent = treeNode.Parent;
                nodeToReplace.Depth = treeNode.Depth;
                nodeToReplace.RightChild = treeNode.RightChild;
                nodeToReplace.LeftChild = treeNode.LeftChild;


                TreeNode parentNodeToRemove = treeNode.Parent;

                if (parentNodeToRemove?.LeftChild == treeNode) parentNodeToRemove.LeftChild = nodeToReplace;
                else if (parentNodeToRemove?.RightChild == treeNode) parentNodeToRemove.RightChild = nodeToReplace;
                else if (treeNode == _root) _root = nodeToReplace;

                return;
            }
        }

        /// <summary>
        /// Поиск нода находящегося максимально глубоко в левом потомке правой подведке
        /// </summary>
        /// <param name="startNode"> Нод, с которого начинается поиск</param>
        /// <returns></returns>
        private static TreeNode FindMaxOnRight(TreeNode startNode)
        {
            TreeNode currentNod = startNode.LeftChild;

            while (currentNod.RightChild != null)
            {
                currentNod = currentNod.RightChild;
            }
            return currentNod;
        }

        /// <summary>
        /// Поиск нода по входному значению. Если совпадений не найдено, вернет null
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <param name="root">Корень дерева</param>
        /// <returns></returns>
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

        /// <summary>
        /// Вывод дерева в консоль
        /// </summary>
        public void PrintTree()
        {
            PrintTreeUnRecurs();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            PrintTreeRecurs(_root);
        }

        private void PrintTreeUnRecurs()
        {
            if (_root == null) return;

            TreeNode parentNode = _root;
            TreeNode currentNode = _root.LeftChild;

            Console.WriteLine($"R({_root.Value})");

            HashSet<TreeNode> isUsed = new HashSet<TreeNode>();

            isUsed.Add(_root);

            string indent = "";
            char vector = 'L';

            while (true)
            {
                if (!isUsed.Contains(currentNode))
                {
                    indent = new string(' ', (currentNode.Depth-1) * 3);
                    Console.WriteLine($"{indent} {vector}({currentNode.Value})");
                    isUsed.Add(currentNode);
                }

                if (currentNode.LeftChild != null && !isUsed.Contains(currentNode.LeftChild))
                {
                    vector = 'L';
                    currentNode = currentNode.LeftChild;
                    parentNode = currentNode.Parent;
                }
                else if (currentNode.RightChild != null && !isUsed.Contains(currentNode.RightChild))
                {
                    vector = 'R';
                    currentNode = currentNode.RightChild;
                    parentNode = currentNode.Parent;
                }
                else
                {
                    currentNode = parentNode;
                    if (currentNode == null && parentNode == null) return;  //Для выхода из цикла
                    parentNode = parentNode?.Parent;
                }

            }
        }

        private void PrintTreeRecurs(TreeNode root, string indent = "")
        {
            if (root != null)
            {
                Console.WriteLine($"| {indent} {root.Value}");

                indent += new string(' ', 3);
                PrintTreeRecurs(root.LeftChild, indent);
                PrintTreeRecurs(root.RightChild, indent);
            }
        }

        public TreeNode BFS(int searchedVal)
        {
            if (_root == null) return null;

            TreeNode currentNode;

            Queue<TreeNode> queueTreeNode = new Queue<TreeNode>();
            queueTreeNode.Enqueue(_root);

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

        public TreeNode DFS(int searchedVal)
        {
            if (_root == null) return null;
            TreeNode currentNode;
            Stack<TreeNode> stackTreeNode = new Stack<TreeNode>();

            stackTreeNode.Push(_root);

            while (stackTreeNode.Count != 0)
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
