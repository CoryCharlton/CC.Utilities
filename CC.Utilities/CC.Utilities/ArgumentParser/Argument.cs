using System;

namespace CC.Utilities
{
    public enum ArgumentValue
    {
        None,
        Optional,
        Required
    }

    public class Argument
    {
        #region Constructor
        public Argument(string name) : this(name, ArgumentValue.Optional, false, string.Empty)
        {
            // Empty method
        }

        public Argument(string name, ArgumentValue argumentValue) : this(name, argumentValue, false, string.Empty)
        {
            // Empty method
        }

        public Argument(string name, bool hasPrefix) : this(name, ArgumentValue.Optional, hasPrefix, string.Empty)
        {
            // Empty method
        }

        public Argument(string name, ArgumentValue argumentValue, bool hasPrefix) : this(name, argumentValue, hasPrefix, string.Empty)
        {
            // Empty method
        }

        public Argument(string name, ArgumentValue argumentValue, bool hasPrefix, string value)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw  new ArgumentException("name is null or empty.", "name");
            }

            ArgumentValue = argumentValue;
            HasPrefix = hasPrefix;
            Name = (HasPrefix ? name.ToLower() : name).Trim();
            Value = value;
        }
        #endregion

        #region Public Properties
        public ArgumentValue ArgumentValue { get; private set; }

        public bool HasPrefix { get; private set; }

        public string Name { get; private set; }

        public bool IsValid { get; set; }
        
        public string Value { get; set; }
        #endregion

        #region Public Methods
        public Argument Clone()
        {
            return new Argument(Name, ArgumentValue, HasPrefix, Value) {IsValid = IsValid};
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool detailed)
        {
            string returnValue = Name;

            if (!string.IsNullOrEmpty(Value))
            {
                returnValue += " == " + Value;
            }

            if (detailed)
            {
                returnValue = string.Format("{0} [HasPrefix: {1} IsValid: {2}]", returnValue, HasPrefix, IsValid);
            }

            return returnValue;
        }
        #endregion
    }
}
