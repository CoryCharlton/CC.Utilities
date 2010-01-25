using System;
using System.Collections.Generic;
using System.Text;

namespace CC.Utilities
{
    //TODO: Needs comments...

    /// <summary>
    /// <see cref="ArgumentParser"/> allows the user to easily parse command line arguments.
    /// </summary>
    public class ArgumentParser
    {
        #region Constructor
        public ArgumentParser() : this(CommonPrefixes, false, null)
        {
            // Empty Method
        }

        public ArgumentParser(IEnumerable<string> prefixes) : this(prefixes, false, null)
        {
            // Empty Method
        }

        public ArgumentParser(bool requirePrefix) : this(CommonPrefixes, requirePrefix, null)
        {
            // Empty Method
        }

        public ArgumentParser(IEnumerable<string> prefixes, bool requirePrefix) : this(prefixes, requirePrefix, null)
        {
            // Empty Method
        }

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
        public ArgumentDictionary AllowedArguments
        {
            get { return _AllowedArguments; }
        }

        public ArgumentDictionary ParsedArguments
        {
            get { return _ParsedArguments; }
        }

        public List<string> Prefixes
        {
            get { return _Prefixes; }
            set { _Prefixes = value; }
        }

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
            foreach (Argument argument in ParsedArguments)
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
        public void AddAllowedArgument(string argumentName)
        {
            AddAllowedArgument(new Argument(argumentName, true));
        }

        public void AddAllowedArgument(Argument argument)
        {
            string argumentName = argument.Name;
            GetArgumentNameWithoutPrefix(ref argumentName);
            AllowedArguments.Add(new Argument(argumentName, argument.ArgumentValue, true));
        }

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

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool detailed)
        {
            StringBuilder returnValue = new StringBuilder();
            ArgumentDictionary invalidArguments = ParsedArguments.GetInvalidArguments();
            ArgumentDictionary validArguments = ParsedArguments.GetValidArguments();

            if (validArguments.Count > 0)
            {
                returnValue.AppendLine("Valid Arguments:");
                returnValue.AppendLine();

                foreach (Argument validArgument in validArguments)
                {
                    returnValue.AppendLine(validArgument.ToString(detailed));
                }
            }

            if (invalidArguments.Count > 0)
            {
                returnValue.AppendLine();
                returnValue.AppendLine("Invalid Arguments:");
                returnValue.AppendLine();

                foreach (Argument invalidArgument in invalidArguments)
                {
                    returnValue.AppendLine(invalidArgument.ToString(detailed));
                }
            }

            return returnValue.ToString();
        }
        #endregion
    }
}
