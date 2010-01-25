using System.Collections;
using System.Collections.Generic;

namespace CC.Utilities
{
    public class ArgumentDictionaryEnumerator: IEnumerator<KeyValuePair<string, Argument>>
    {
        #region Constructor
        public ArgumentDictionaryEnumerator(ArgumentDictionary argumentDictionary)
        {
            _ArgumentDictionary = argumentDictionary;
        }
        #endregion

        #region Private Fields
        private ArgumentDictionary _ArgumentDictionary;
        private int _Index = -1;
        #endregion

        #region Implementation of IDisposable
        public void Dispose()
        {
            _ArgumentDictionary = null;
        }
        #endregion

        #region Implementation of IEnumerator
        public bool MoveNext()
        {
            bool returnValue = false;
            
            if (_Index + 1 < _ArgumentDictionary.Count)
            {
                _Index++;

                returnValue = true;
            }

            return returnValue;
        }

        public void Reset()
        {
            _Index = -1;
        }

        public KeyValuePair<string, Argument> Current
        {
            get
            {
                Argument argument = _ArgumentDictionary[_Index];
                return new KeyValuePair<string, Argument>(argument.Name, argument);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
        #endregion
    }
}
