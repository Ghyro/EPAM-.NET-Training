using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Task_1
{
    /// <summary>
    /// Develop a generic <see cref="MyCustomQueue{T}"/> collection class that implements the basic operations
    /// for working with the queue, and provides the ability to iterate by implementing
    /// an iterator "manually" (without using the yield block iterator).
    /// Test the methods of the developed class.
    /// </summary>
    /// <typeparam name="T">Input generic parameter</typeparam>
    public class MyCustomQueue<T> : IEnumerable<T>
    {
        #region private fields
        private T[] container;
        private int size;
        private int front; // Head
        private int rear; // Tail
        private int capacity = 10;
        #endregion

        #region constructor
        public MyCustomQueue()
        {
            container = new T[capacity];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add an item to the end of the queue
        /// </summary>
        /// <param name="element">Input element</param>
        public void Enqueue(T element)
        {
            if (size == capacity)
            {
                T[] newCustomQueue = new T[2 * capacity];

                for (int i = 0; i < size; i++)
                {
                    newCustomQueue[i] = container[(i + front) % capacity];
                }

                container = newCustomQueue;

                capacity *= 2;
            }

            size++;

            container[rear++ % capacity] = element;
        }

        /// <summary>
        /// Retrieves and returns the first item in the queue
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// if <see cref="size"> == 0 </see>/>
        /// </exception>
        /// <returns>The first item in the queue</returns>
        public T Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException(nameof(size));
            }

            size--;

            return container[front++ % capacity];
        }

        /// <summary>
        /// Returns the first item in the queue
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// if <see cref="size"> == 0 </see>/>
        /// </exception>
        /// <returns>The first item in the queue</returns>
        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException(nameof(size));
            }

            return this.container[this.front];
        }
        #endregion

        #region IEnumerable
        public CustomQueueIterator GetEnumerator()
        {
            return new CustomQueueIterator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        /// <summary>
        /// Consist implementation of <see cref="IEnumerator{T}"> interface for iterating through the collection</see>/>
        /// </summary>
        public class CustomQueueIterator : IEnumerator<T>
        {
            #region private fields
            private readonly MyCustomQueue<T> listQueue;
            private int currentIndex;
            #endregion

            #region constructor
            public CustomQueueIterator(MyCustomQueue<T> list)
            {
                this.currentIndex = list.front - 1;
                this.listQueue = list;
            }
            #endregion

            #region Methods
            /// <summary>
            /// The <see cref="Current"/> property returns an object in the sequence pointed to by the pointer.
            /// </summary>
            /// <exception cref="InvalidOperationException">
            /// <if><see cref="currentIndex"/> == <see cref="listQueue.size"/></if>
            /// </exception>
            public T Current
            {
                get
                {
                    if (currentIndex == listQueue.size)
                    {
                        throw new InvalidOperationException();
                    }

                    return listQueue.container[currentIndex % listQueue.capacity];
                }
            }

            /// <summary>
            /// Return current <see cref="Current"/>
            /// </summary>
            object IEnumerator.Current => (object)Current;

            /// <summary>
            /// The <see cref="Reset"/> method resets the position indicator to its initial position.
            /// </summary>
            public void Reset()
            {
                currentIndex = listQueue.front - 1;
            }

            /// <summary>
            /// The <see cref="MoveNext"/> method moves the pointer to the current element to the next position in the sequence.
            /// </summary>
            /// <returns>
            /// <true>If the sequence has not yet ended, then returns true.</true>
            /// <false>If the sequence has ended, then false is returned.</false>
            /// </returns>
            public bool MoveNext()
            {
                if (currentIndex < listQueue.size)
                {
                    currentIndex++;

                    return currentIndex < listQueue.size;
                }

                return false;
            }

            public void Dispose()
            {
            }
            #endregion
        }
    }
}
