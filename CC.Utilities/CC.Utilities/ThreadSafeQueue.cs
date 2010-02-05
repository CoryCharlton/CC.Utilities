using System.Collections.Generic;

namespace CC.Utilities
{
    /// <summary>
    /// Represents a thread safe <see cref="Queue{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ThreadSafeQueue<T>: Queue<T>
    {
        #region Private Fields
        private readonly object _LockObject = new object();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the number of elements contained in the <see cref="ThreadSafeQueue{T}"/>
        /// </summary>
        public new int Count
        {
            get
            {
                int returnValue;

                lock (_LockObject)
                {
                    returnValue = base.Count;
                }
                
                return returnValue;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Removes all objects from the <see cref="ThreadSafeQueue{T}"/>
        /// </summary>
        public new void Clear()
        {
            lock (_LockObject)
            {
                base.Clear();
            }
        }

        /// <summary>
        /// Removes and returns the object at the beggining of the <see cref="ThreadSafeQueue{T}"/>
        /// </summary>
        /// <returns></returns>
        public new T Dequeue()
        {
            T returnValue;

            lock (_LockObject)
            {
                returnValue = base.Dequeue();
            }

            return returnValue;
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ThreadSafeQueue{T}"/>
        /// </summary>
        /// <param name="item">The object to add to the <see cref="ThreadSafeQueue{T}"/></param>
        public new void Enqueue(T item)
        {
            lock (_LockObject)
            {
                base.Enqueue(item);
            }
        }

        /// <summary>
        /// Set the capacity to the actual number of elements in the <see cref="ThreadSafeQueue{T}"/>, if that number is less than 90 percent of current capactity.
        /// </summary>
        public new void TrimExcess()
        {
            lock (_LockObject)
            {
                base.TrimExcess();
            }
        }
        #endregion
    }
}
