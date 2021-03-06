﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Tasks.Task3_Tests;

namespace Tasks_Tests.Task3_Tests
{
    [TestFixture]
    class BinarySearchTree_Tests
    {
        [Test]
        public void Add_InOrderSortNumbers_NUnit()
        {
            // Arrange
            int[] result = new int[] { 1, 2, 7, 3, 6, 10, 8, 9 };

            int[] expected = new int[] { 1, 2, 3, 6, 7, 8, 9, 10 };

            var binaryTree = new BinarySearchTree<int>();

            binaryTree.Add(result);

            // Act
            int i = 0;

            foreach (var item in binaryTree)
            {
                result[i++] = item;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_InOrderSortString_NUnit()
        {
            // Arrange
            string[] result = new string[] { "Kirill", "Alex", "Bob" };

            string[] expected = new string[] { "Alex", "Bob", "Kirill" };

            var binaryTree = new BinarySearchTree<string>();

            binaryTree.Add(result);

            // Act
            int i = 0;

            foreach (var item in binaryTree)
            {
                result[i++] = item;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_InOrderSortAuthor_NUnit()
        {            
            // Arrange
            CustomBook book2 = new CustomBook { Author = "Leo Tolstoy" };           
            CustomBook book4 = new CustomBook { Author = "Anton Chekhov" };
            CustomBook book5 = new CustomBook { Author = "Agatha Christie" };

            var binaryTree = new BinarySearchTree<CustomBook>();

            CustomBook[] result = new CustomBook[3];

            CustomBook[] expected = { book5, book4, book2 };

            // Act
            binaryTree.Add(book2);
            binaryTree.Add(book4);
            binaryTree.Add(book5);            

            int i = 0;

            foreach(var item in binaryTree)
            {
                result[i++] = item;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_InOrderSortPoint_NUnit()
        {
            // Arrange
            Point point1 = new Point() { X = 3, Y = 2 };
            Point point2 = new Point() { X = 510, Y = 3 };
            Point point3 = new Point() { X = 21, Y = 4 };

            var comparer = new CustomPoint();

            var binaryTree = new BinarySearchTree<Point>(comparer.Compare);           

            var result = new Point[3];

            Point[] expected = { point1, point3, point2 };            

            // Act
            binaryTree.Add(point1);
            binaryTree.Add(point2);
            binaryTree.Add(point3);

            int i = 0;

            foreach (var item in binaryTree)
            {
                result[i++] = item;
            }

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_ArgumentNullException_NUnit()
        {
            // Arrange
            int[] array = null;

            var binaryTree = new BinarySearchTree<int>();

            // Assert
            Assert.Throws<ArgumentNullException>(() => binaryTree.Add(array));
        }        
    }
}
