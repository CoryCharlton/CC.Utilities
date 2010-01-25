using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CC.Utilities
{
    //TODO: Needs comments...

    public class ArgumentDictionary : IDictionary<string, Argument>
    {
        #region Constructor
        public ArgumentDictionary()
        {
            
        }

        public ArgumentDictionary(IEnumerable<Argument> arguments)
        {
            AddRange(arguments);
        }
        #endregion

        #region Private Fields
        private readonly List<string> _Keys = new List<string>();
        private readonly List<Argument> _Values = new List<Argument>();
        #endregion
        
        #region Public Events
        public event EventHandler DictionaryChanged;
        #endregion

        #region Public Properties
        public Argument this[int argumentIndex]
        {
            get { return _Values[argumentIndex]; }
            set { _Values[argumentIndex] = value; }
        }

        public Argument this[string argumentName]
        {
            get { return _Values[IndexOf(argumentName)]; }
            set { _Values[IndexOf(argumentName)] = value; }
        }

        public int Count
        {
            get { return _Keys.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public ICollection<string> Keys
        {
            get { return _Keys.ToList(); }
        }

        public ICollection<Argument> Values
        {
            get { return _Values.ToList(); }
        }
        #endregion

        #region Protected Methods
        protected void OnDictionaryChanged(EventArgs eventArgs)
        {
            if (DictionaryChanged != null)
            {
                DictionaryChanged(this, eventArgs);
            }
        }
        #endregion

        #region Public Methods
        public void Add(Argument argument)
        {
            if (!Contains(argument.Name))
            {
                _Keys.Add(argument.Name);
                _Values.Add(argument);
            }
            else
            {
                // NOTE: Should I confirm the settings other than value are the same?
                this[argument.Name] = argument;
            }

            OnDictionaryChanged(EventArgs.Empty);
        }

        public void Add(string key, Argument value)
        {
            // NOTE: Should I confirm key == value.Name?
            Add(value);
        }

        public void Add(KeyValuePair<string, Argument> item)
        {
            Add(item.Value);
        }

        public void AddRange(IEnumerable<Argument> arguments)
        {
            foreach (Argument argument in arguments)
            {
                Add(argument);
            }
        }

        public void Clear()
        {
            _Keys.Clear();
            _Values.Clear();

            OnDictionaryChanged(EventArgs.Empty);
        }

        public bool Contains(string argumentName)
        {
            return _Keys.Contains(argumentName) || _Keys.Contains(argumentName.ToLower());
        }

        public bool Contains(Argument argument)
        {
            return Contains(argument.Name);
        }

        public bool Contains(KeyValuePair<string, Argument> item)
        {
            return Contains(item.Value.Name);
        }

        public bool ContainsKey(string argumentName)
        {
            return Contains(argumentName);
        }

        public void CopyTo(KeyValuePair<string, Argument>[] array, int arrayIndex)
        {
            if ((Count + arrayIndex + 1) > array.Length)
            {
                int difference = (Count + arrayIndex + 1) - array.Length;
                Array.Resize(ref array, array.Length + difference);
            }

            for (int i = 0; i < _Values.Count; i++)
            {
                array[arrayIndex + i] = new KeyValuePair<string, Argument>(_Values[i].Name, _Values[i]);
            }
        }

        public IEnumerator<KeyValuePair<string, Argument>> GetEnumerator()
        {
            return new ArgumentDictionaryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ArgumentDictionary GetInvalidArguments()
        {
            return new ArgumentDictionary((from argument in _Values where argument.IsValid == false select argument).ToList());
        }

        public ArgumentDictionary GetValidArguments()
        {
            return new ArgumentDictionary((from argument in _Values where argument.IsValid select argument).ToList());
        }

        public int IndexOf(string argumentName)
        {
            int index = _Keys.IndexOf(argumentName);

            if (index < 0)
            {
                index = _Keys.IndexOf(argumentName.ToLower());
            }

            return index;
        }

        public int IndexOf(Argument argument)
        {
            return IndexOf(argument.Name);
        }

        public bool Remove(string argumentName)
        {
            bool returnValue = false;
            int index = IndexOf(argumentName);

            if (index > -1)
            {
                RemoveAt(index);
                returnValue = true;
            }

            return returnValue;
        }

        public bool Remove(Argument argument)
        {
            return Remove(argument.Name);
        }

        public bool Remove(KeyValuePair<string, Argument> item)
        {
            return Remove(item.Value);
        }

        public void RemoveAt(int index)
        {
            _Keys.RemoveAt(index);
            _Values.RemoveAt(index);

            OnDictionaryChanged(EventArgs.Empty);
        }

        public bool TryGetValue(string argumentName, out Argument value)
        {
            value = null;
            bool returnValue = false;

            if (Contains(argumentName))
            {
                value = this[argumentName];
                returnValue = true;
            }

            return returnValue;
        }
        #endregion
    }
}
