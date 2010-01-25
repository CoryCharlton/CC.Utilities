using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Utilities
{
    /// <summary>
    /// <see cref="ArgumentParser"/> allows the user to easily parse command line arguments.
    /// </summary>
    public class ArgumentParser
    {
        #region Constructor
        /// <summary>
        /// Creates a new <see cref="ArgumentParser"/>.
        /// </summary>
        public ArgumentParser() : this(CommonPrefixes, false, null)
        {
            // Empty Method
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentParser"/>.
        /// </summary>
        /// <param name="prefixes">The list of valid prefixes.</param>
        public ArgumentParser(IEnumerable<string> prefixes) : this(prefixes, false, null)
        {
            // Empty Method
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentParser"/>.
        /// </summary>
        /// <param name="requirePrefix">True if valid <see cref="Argument"/>s require a prefix.</param>
        public ArgumentParser(bool requirePrefix) : this(CommonPrefixes, requirePrefix, null)
        {
            // Empty Method
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentParser"/>.
        /// </summary>
        /// <param name="prefixes">The list of valid prefixes.</param>
        /// <param name="requirePrefix">True if valid <see cref="Argument"/>s require a prefix.</param>
        public ArgumentParser(IEnumerable<string> prefixes, bool requirePrefix) : this(prefixes, requirePrefix, null)
        {
            // Empty Method
        }

        /// <summary>
        /// Creates a new <see cref="ArgumentParser"/>.
        /// </summary>
        /// <param name="prefixes">The list of valid prefixes.</param>
        /// <param name="requirePrefix">True if valid <see cref="Argument"/>s require a prefix.</param>
        /// <param name="allowedArguments">The list of allowed <see cref="Argument"/>s.</param>
        public ArgumentParser(IEnumerable<string> prefixes, bool requirePrefix, IEnumerable<Argument> allowedArguments)
        {
            if (prefixes != null)
            {
                foreach (var prefix in prefixes)
                {
                    Prefixes.Add(prefix.Trim());
                }
            }

            RequirePrefix = requirePrefix;

            if (allowedArguments != null)
            {
                foreach (Argument allowedArgument in allowedArguments)
                {
                    AddAllowedArgument(allowedArgument);
                }
            }

            AllowedArguments.DictionaryChanged += AllowedArguments_DictionaryChanged;
        }
        #endregion

        #region Private Fields
        private readonly ArgumentDictionary _AllowedArguments = new ArgumentDictionary();
        private readonly ArgumentDictionary _ParsedArguments = new ArgumentDictionary();
        private List<string> _Prefixes = new List<string>();
        private bool _RequirePrefix;
        #endregion

        #region Private Static Fields
        private static readonly string[] _CommonPrefixes = new [] {"-", "--", "/"};
        #endregion

        #region Public Properties
        /// <summary>
        /// The list of allowed <see cref="Argument"/>s
        /// </summary>
        public ArgumentDictionary AllowedArguments
        {
            get { return _AllowedArguments; }
        }

        /// <summary>
        /// The <see cref="Argument"/>s parsed from the <see cref="Parse"/> method.
        /// </summary>
        public ArgumentDictionary ParsedArguments
        {
            get { return _ParsedArguments; }
        }

        /// <summary>
        /// The list of valid prefixes.
        /// </summary>
        public List<string> Prefixes
        {
            get { return _Prefixes; }
            set { _Prefixes = value; }
        }

        /// <summary>
        /// True if valid <see cref="Argument"/>s require a prefix.
        /// </summary>
        public bool RequirePrefix
        {
            get { return _RequirePrefix; } 
            set
            {
                if (Prefixes.Count <= 0 && value)
                {
                    throw new ArgumentException("Cannot set RequirePrefix to true unless you have specified Prefixes.", "value");
                }

                _RequirePrefix = value;
            }
        }
        #endregion

        #region Public Static Properties
        /// <summary>
        /// A list of common prefixes.
        /// </summary>
        public static string[] CommonPrefixes
        {
            get { return _CommonPrefixes; }
        }
        #endregion

        #region Private Event Handlers
        // ReSharper disable InconsistentNaming
        private void AllowedArguments_DictionaryChanged(object sender, EventArgs e)
        {
            SetArgumentIsValid();
        }
        // ReSharper restore InconsistentNaming
        #endregion

        #region Private Methods
        private Argument BuildArgument(string argumentName, bool hasPrefix)
        {
            Argument returnValue;

            if (AllowedArguments.Count > 0 && AllowedArguments.Contains(argumentName))
            {
                returnValue = AllowedArguments[argumentName].Clone();
            }
            else
            {
                returnValue = new Argument(argumentName, hasPrefix);        
            }

            SetArgumentIsValid(returnValue);

            return returnValue;
        }

        private bool GetArgumentNameWithoutPrefix(ref string argumentName)
        {
            string prefix = string.Empty;

            for (int j = 0; j < Prefixes.Count; j++)
            {
                string currentPrefix = Prefixes[j];

                if (argumentName.StartsWith(currentPrefix))
                {
                    if (string.IsNullOrEmpty(prefix) || currentPrefix.Length > prefix.Length)
                    {
                        prefix = currentPrefix;
                    }
                }
            }

            if (!string.IsNullOrEmpty(prefix))
            {
                argumentName = argumentName.Substring(prefix.Length, argumentName.Length - prefix.Length);
            }

            return !string.IsNullOrEmpty(prefix);
        }

        private void SetArgumentIsValid()
        {
            foreach (Argument argument in ParsedArguments.Values)
            {
                SetArgumentIsValid(argument);
            }
        }

        private void SetArgumentIsValid(Argument argument)
        {
            if (RequirePrefix && !argument.HasPrefix)
            {
                argument.IsValid = false;
                return;
            }

            bool allowedArgument = true;

            if (AllowedArguments.Count > 0 && argument.HasPrefix)
            {
                allowedArgument = AllowedArguments.Contains(argument);    
            }

            switch (argument.ArgumentValue)
            {
                case ArgumentValue.None:
                case ArgumentValue.Optional:
                    {
                        argument.IsValid = allowedArgument;
                        break;
                    }
                case ArgumentValue.Required:
                    {
                        argument.IsValid = allowedArgument && !string.IsNullOrEmpty(argument.Value);
                        break;
                    }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add an allowed <see cref="Argument"/>.
        /// </summary>
        /// <param name="argumentName">The argument name.</param>
        public void AddAllowedArgument(string argumentName)
        {
            AddAllowedArgument(new Argument(argumentName, true));
        }

        /// <summary>
        /// Add an allowed <see cref="Argument"/>.
        /// </summary>
        /// <param name="argument">The <see cref="Argument"/>.</param>
        public void AddAllowedArgument(Argument argument)
        {
            string argumentName = argument.Name;
            GetArgumentNameWithoutPrefix(ref argumentName);
            AllowedArguments.Add(new Argument(argumentName, argument.ArgumentValue, true));
        }

        /// <summary>
        /// Parse the array of command line arguments.
        /// </summary>
        /// <param name="args">The array of command line arguments.</param>
        public void Parse(string[] args)
        {
            _ParsedArguments.Clear();
            
            Argument lastArgumentWithPrefix = null;

            for (int i = 0; i < args.Length; i++)
            {
                string currentValue = args[i];

                if (GetArgumentNameWithoutPrefix(ref currentValue))
                {
                    lastArgumentWithPrefix = BuildArgument(currentValue, true);
                   
                    ParsedArguments.Add(lastArgumentWithPrefix);
                }
                else
                {
                    bool addArgument = true;

                    if (lastArgumentWithPrefix != null)
                    {
                        if (lastArgumentWithPrefix.ArgumentValue != ArgumentValue.None)
                        {
                            addArgument = false;
                            lastArgumentWithPrefix.Value = currentValue;

                            SetArgumentIsValid(lastArgumentWithPrefix);
                        }

                        lastArgumentWithPrefix = null;
                    }

                    if (addArgument)
                    {
                        ParsedArguments.Add(BuildArgument(currentValue, false));
                    }
                }
            }
        }

        /// <summary>
        /// Returns this <see cref="ParsedArguments"/> in a human readable format.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        /// Returns this <see cref="ParsedArguments"/> in a human readable format.
        /// </summary>
        /// <param name="detailed">True if the output should be detailed.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public string ToString(bool detailed)
        {
            StringBuilder returnValue = new StringBuilder();
            ArgumentDictionary invalidArguments = ParsedArguments.GetInvalidArguments();
            ArgumentDictionary validArguments = ParsedArguments.GetValidArguments();

            if (validArguments.Count > 0)
            {
                returnValue.AppendLine("Valid Arguments:");
                returnValue.AppendLine();

                foreach (Argument validArgument in validArguments.Values)
                {
                    returnValue.AppendLine(" " + validArgument.ToString(detailed));
                }
            }
            
            if (invalidArguments.Count > 0)
            {
                returnValue.AppendLine();
                returnValue.AppendLine("Invalid Arguments:");
                returnValue.AppendLine();

                foreach (Argument invalidArgument in invalidArguments.Values)
                {
                    returnValue.AppendLine(" " + invalidArgument.ToString(detailed));
                }
            }

            return returnValue.ToString();
        }
        #endregion
    }
}
