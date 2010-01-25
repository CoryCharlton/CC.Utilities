using System;

namespace CC.Utilities
{
    /// <summary>
    /// Specifies constants that indicate the state of an <see cref="Argument"/>'s value property.
    /// </summary>
    public enum ArgumentValue
    {
        None,
        Optional,
        Required
    }

    /// <summary>
    /// Represents a single command line argument.
    /// </summary>
    public class Argument
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="Argument"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        public Argument(string name) : this(name, ArgumentValue.Optional, false, string.Empty)
        {
            // Empty method
        }

        /// <summary>
        /// Creates a new <see cref="Argument"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="argumentValue">The state of the argument's Value property.</param>
        public Argument(string name, ArgumentValue argumentValue) : this(name, argumentValue, false, string.Empty)
        {
            // Empty method
        }

        /// <summary>
        /// Creates a new <see cref="Argument"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="hasPrefix">True if the <see cref="Argument"/> has a prefix.</param>
        public Argument(string name, bool hasPrefix) : this(name, ArgumentValue.Optional, hasPrefix, string.Empty)
        {
            // Empty method
        }

        /// <summary>
        /// Creates a new <see cref="Argument"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="argumentValue">The state of the argument's Value property.</param>
        /// <param name="hasPrefix">True if the <see cref="Argument"/> has a prefix.</param>
        public Argument(string name, ArgumentValue argumentValue, bool hasPrefix) : this(name, argumentValue, hasPrefix, string.Empty)
        {
            // Empty method
        }

        /// <summary>
        /// Creates a new <see cref="Argument"/>.
        /// </summary>
        /// <param name="name">The argument name.</param>
        /// <param name="argumentValue">The state of the argument's Value property.</param>
        /// <param name="hasPrefix">True if the <see cref="Argument"/> has a prefix.</param>
        /// <param name="value">The argument value.</param>
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
        /// <summary>
        /// The state of the <see cref="Value"/> property.
        /// </summary>
        public ArgumentValue ArgumentValue { get; private set; }

        /// <summary>
        /// True if the <see cref="Argument"/> has a prefix.
        /// </summary>
        public bool HasPrefix { get; private set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// True if the <see cref="Argument"/> is valid.
        /// </summary>
        public bool IsValid { get; set; }
        
        /// <summary>
        /// The value.
        /// </summary>
        public string Value { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Clones this <see cref="Argument"/> to a new instance.
        /// </summary>
        /// <returns>An <see cref="Argument"/></returns>
        public Argument Clone()
        {
            return new Argument(Name, ArgumentValue, HasPrefix, Value) {IsValid = IsValid};
        }

        /// <summary>
        /// Returns this <see cref="Argument"/> in a human readable format.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        /// Returns this <see cref="Argument"/> in a human readable format.
        /// </summary>
        /// <param name="detailed">True if the output should be detailed.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public string ToString(bool detailed)
        {
            string returnValue = Name;

            if (!string.IsNullOrEmpty(Value))
            {
                returnValue += " == " + Value;
            }

            if (detailed)
            {
                returnValue = string.Format("[HasPrefix: {0,5} | IsValid: {1,5}] {2}", HasPrefix, IsValid, returnValue);
            }

            return returnValue;
        }
        #endregion
    }
}
