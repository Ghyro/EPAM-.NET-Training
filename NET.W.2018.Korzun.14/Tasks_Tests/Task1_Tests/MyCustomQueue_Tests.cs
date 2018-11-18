using NUnit.Framework;
using System;
using System.Linq;
using Tasks.Task_1;

namespace Tasks_Tests.Task1_Tests
{
    [TestFixture]
    class MyCustomQueue_Tests
    {
        [Test]
        public void Enqueue_InputCorrectListNumbers_NUnit()
        {
            // Arrange
            MyCustomQueue<int> queue = new MyCustomQueue<int>();            

            int[] expected = { 10, 12, 2, 7 };

            // Act
            queue.Enqueue(10);
            queue.Enqueue(12);
            queue.Enqueue(2);
            queue.Enqueue(7);

            bool result = expected.SequenceEqual(queue);
                       
            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void Enqueue_InputCorrectListStrings_NUnit()
        {
            // Arrange
            MyCustomQueue<string> queueStr = new MyCustomQueue<string>();           

            string[] expected = { "Kirill", "Oleg", "Vasya" };

            // Act
            queueStr.Enqueue("Kirill");
            queueStr.Enqueue("Oleg");
            queueStr.Enqueue("Vasya");

            bool result = expected.SequenceEqual(queueStr);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Dequeue_InputCorrectListNumbers_NUnit()
        {
            // Arrange
            MyCustomQueue<int> queue = new MyCustomQueue<int>();           

            int expected = 10;

            // Act
            queue.Enqueue(10);
            queue.Enqueue(12);
            queue.Enqueue(2);
            queue.Enqueue(7);

            int result = queue.Dequeue();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Dequeue_InputCorrectListStrings_NUnit()
        {
            // Arrange
            MyCustomQueue<string> queueStr = new MyCustomQueue<string>();            

            string expected = "Kirill";

            // Act
            queueStr.Enqueue("Kirill");
            queueStr.Enqueue("Oleg");
            queueStr.Enqueue("Vasya");

            string result = queueStr.Dequeue();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Peek_InputCorrectListNumber_NUnit()
        {
            // Arrange
            MyCustomQueue<int> queue = new MyCustomQueue<int>();            

            int expected = 10;

            // Act
            queue.Enqueue(10);
            queue.Enqueue(12);
            queue.Enqueue(2);
            queue.Enqueue(7);

            int result = queue.Peek();

            // Assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void Dequeue_Empty_InvalidOperationException_NUnit()
        {
            // Arrange
            MyCustomQueue<int> queue = new MyCustomQueue<int>();

            // Assert
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }
    }
}
