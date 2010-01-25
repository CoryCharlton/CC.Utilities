using System;
using System.Collections.Generic;
using System.Linq;

namespace CC.Utilities
{
    //TODO: Needs comments...

    public class ArgumentDictionary : IEnumerable<Argument>
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

        public IEnumerator<Argument> GetEnumerator()
        {
            return _Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
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
