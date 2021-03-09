using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsLesson4Task2
{
    class BinaryTree : ITree
    {
        TreeNode root;

        /// <summary>
        /// Добавление нода, с указанным значением в дерево
        /// </summary>
        /// <param name="value"></param>
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

        /// <summary>
        /// Получение ссылки на нод, с указанным значением.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public TreeNode GetNodeByValue(int value)
        {
            if (root == null) return null;

            return FindNodeByValue(value, root);
        }

        /// <summary>
        /// Возврат корня дерева
        /// </summary>
        /// <returns></returns>
        public TreeNode GetRoot()
        {
            return root;
        }

        
        /// <summary>
        /// Удаление нода с указанным значением
        /// </summary>
        /// <param name="value">Значение нода, которое следует удалить</param>
        public void RemoveItem(int value)
        {
            if (root == null) return;   //Выход при пустом дереве

            TreeNode treeNode = FindNodeByValue(value, root);   //Полуение ссылки на нод, который требуется удалить

            if (treeNode == null) return;   //Если ссылка пустая, то выходим

            
            //Удаление листа
            if (treeNode.LeftChild == null && treeNode.RightChild == null)
            {
                if (treeNode == root)
                {
                    root = null;
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

                if (parentNode?.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                else if (parentNode?.RightChild == treeNode) parentNode.RightChild = treeNode.RightChild;
                else if (treeNode == root) root = treeNode.LeftChild;

                TreeNode leftChildCurrentNode = treeNode.LeftChild;
                leftChildCurrentNode.Parent = parentNode;

                return;
            }

            //Удаление нода не имеющего левого поддерева
            if (treeNode.LeftChild == null && treeNode.RightChild != null)
            {
                TreeNode parentNode = treeNode.Parent;

                //if (parentNode.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                //else parentNode.RightChild = treeNode.RightChild;

                if (parentNode?.LeftChild == treeNode) parentNode.LeftChild = treeNode.LeftChild;
                else if (parentNode?.RightChild == treeNode) parentNode.RightChild = treeNode.RightChild;
                else if (treeNode == root) root = treeNode.RightChild;

                TreeNode rightChildCurrentNode = treeNode.RightChild;
                rightChildCurrentNode.Parent = parentNode;

                return;
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

                if (parentNodeToRemove?.LeftChild == treeNode) parentNodeToRemove.LeftChild = nodeToReplace;
                else if (parentNodeToRemove?.RightChild == treeNode) parentNodeToRemove.RightChild = nodeToReplace;
                else if (treeNode == root) root = nodeToReplace;

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
            //Понять сколько этажей
            //в очередь добавляем все ноды (вместо пустых веток нужен null)
            //постепенно формировать массив строк
            //Считать, что на каждом "этаже" всегда есть по 2 ветки от родительского нода
            //В таком случае для этажа выше расположение нода считаться по формуле (макс длина символов / на возможное кол-во нодов)
            //с учетом колв-ва символов для нода
            throw new NotImplementedException();
        }
    }
}
