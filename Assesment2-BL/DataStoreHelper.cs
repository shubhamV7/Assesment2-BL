using System.Collections.Generic;

namespace Assesment2_BL_DataStoreHelper
{
    public class DataStoreHelper
    {
        private Queue<string> _queue;
        private int _bufferSize;

        /// <summary>
        /// Constructor to initialize a new queue and buffer size
        /// </summary>
        /// <param name="bufferSize"> user defined buffer size</param>
        public DataStoreHelper(int bufferSize)
        {
            this._bufferSize = bufferSize;
            _queue = new Queue<string>(this._bufferSize);
        }

        /// <summary>
        /// Method to add elements into in-memory buffer,
        /// it will return - <br/>
        /// true  - if successfully added <br/>
        /// false - if buffer is full and element is not added
        /// </summary>
        /// <param name="element">string value to add into buffer</param>
        /// <returns>boolen value (true / false)</returns>
        public bool Add(string element)
        {
            if (_queue.Count < this._bufferSize)
            {
                _queue.Enqueue(element);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method to overwrite the oldest value present in the buffer
        /// </summary>
        /// <param name="element"> string value to add(overwrite) into buffer</param>
        /// <returns>Oldest element of the buffer that is overwritten <br/> type - string</returns>
        public string OverWriteOldestValue(string element)
        {
            string oldestVal = _queue.Dequeue();
            _queue.Enqueue(element);

            return oldestVal;
        }

        /// <summary>
        /// Method to get an IEnumerable<string> of the buffer
        /// to iterate the buffer
        /// </summary>
        /// <returns>IEnumerable<string></returns>
        public IEnumerable<string> GetEnumerable()
        {
            return _queue;
        }
    }
}