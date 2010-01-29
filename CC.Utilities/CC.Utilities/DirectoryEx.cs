using System;
using System.Collections.Generic;
using System.IO;

namespace CC.Utilities
{
    /// <summary>
    /// Don't use this right now :-)
    /// </summary>
    public static class DirectoryEx 
    {
        //NOTE: I wrote this code a long time ago and along the way something has changed (Framework?, environment?, sun spots?) because the Directory.Move() method is currently outperforming any of my methods below (by a substantial ammount)
        
        #region Public Methods
        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirectory">The path of the directory to move.</param>
        /// <param name="destinationDirectory">The path to the new location</param>
        public static void Move(string sourceDirectory, string destinationDirectory)
        {
            Move(sourceDirectory, destinationDirectory, false, true);
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirectory">The path of the directory to move.</param>
        /// <param name="destinationDirectory">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        public static void Move(string sourceDirectory, string destinationDirectory, bool overwrite)
        {
            Move(sourceDirectory, destinationDirectory, overwrite, true);
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirectory">The path of the directory to move.</param>
        /// <param name="destinationDirectory">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        /// <param name="moveEmptyDirectories">true if the empty directories should be moved; otherwise false</param>
        public static void Move(string sourceDirectory, string destinationDirectory, bool overwrite, bool moveEmptyDirectories)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.DirectoryEx.Move()");
#endif
            if (sourceDirectory == null || destinationDirectory == null)
            {
                throw new ArgumentNullException((sourceDirectory == null) ? "sourceDirectory" : "destinationDirectory", "sourceDirectory or destinationDirectory is a null reference");
            }

            bool containsInvalidPathChar = false;

            foreach (char invalidPathChar in Path.GetInvalidPathChars())
            {
                if (destinationDirectory.Contains(invalidPathChar.ToString()) || sourceDirectory.Contains(invalidPathChar.ToString()))
                {
                    containsInvalidPathChar = true;
                    break;
                }
            }

            if (sourceDirectory == string.Empty || destinationDirectory == string.Empty || sourceDirectory.ToLower() == destinationDirectory.ToLower() || containsInvalidPathChar)
            {
                throw new ArgumentException("sourceDirectory or destinationDirectory is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.");
            }

            if (sourceDirectory.Length >= 248 || destinationDirectory.Length >= 248)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed the system-defined maximum length.");
            }

            if (!overwrite && Directory.Exists(destinationDirectory))
            {
                throw new IOException("destinationDirectory already exists: " + destinationDirectory);
            }

            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException("The path specified by sourceDirectory is invalid (for example, it is on an unmapped drive): " + sourceDirectory);
            }

            // All is good?

            if (!sourceDirectory.EndsWith("\\"))
            {
                sourceDirectory += "\\";
            }

            if (!destinationDirectory.EndsWith("\\"))
            {
                destinationDirectory += "\\";
            }

            string[] subDirectories = Directory.GetDirectories(sourceDirectory);
            //Array.Sort(subDirectories);

            string[] files = Directory.GetFiles(sourceDirectory);
            //Array.Sort(files);

            if (moveEmptyDirectories || (subDirectories.Length > 0 || files.Length > 0))
            {
                //if (!Directory.Exists(destinationDirectory))
                //{
                    Directory.CreateDirectory(destinationDirectory);
                //}

                foreach (string subDirectory in subDirectories)
                {
                    Move(subDirectory, subDirectory.Replace(sourceDirectory, destinationDirectory), overwrite, moveEmptyDirectories);
                }

                foreach (string file in files)
                {
                    File.Copy(file, file.Replace(sourceDirectory, destinationDirectory), overwrite);
                }
            }

            Directory.Delete(sourceDirectory, true);
#if DEBUG
            Logging.ExitMethod("CC.Utilities.DirectoryEx.Move()", enterTime);
#endif
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirectory">The path of the directory to move.</param>
        /// <param name="destinationDirectory">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        /// <param name="moveEmptyDirectories">true if the empty directories should be moved; otherwise false</param>
        public static void Move2(string sourceDirectory, string destinationDirectory, bool overwrite, bool moveEmptyDirectories)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.DirectoryEx.Move2()");
#endif
            if (sourceDirectory == null || destinationDirectory == null)
            {
                throw new ArgumentNullException((sourceDirectory == null) ? "sourceDirectory" : "destinationDirectory", "sourceDirectory or destinationDirectory is a null reference");
            }

            bool containsInvalidPathChar = false;

            foreach (char invalidPathChar in Path.GetInvalidPathChars())
            {
                if (destinationDirectory.Contains(invalidPathChar.ToString()) || sourceDirectory.Contains(invalidPathChar.ToString()))
                {
                    containsInvalidPathChar = true;
                    break;
                }
            }

            if (sourceDirectory == string.Empty || destinationDirectory == string.Empty || sourceDirectory.ToLower() == destinationDirectory.ToLower() || containsInvalidPathChar)
            {
                throw new ArgumentException("sourceDirectory or destinationDirectory is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.");
            }

            if (sourceDirectory.Length >= 248 || destinationDirectory.Length >= 248)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed the system-defined maximum length.");
            }

            if (!overwrite && Directory.Exists(destinationDirectory))
            {
                throw new IOException("destinationDirectory already exists: " + destinationDirectory);
            }

            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException("The path specified by sourceDirectory is invalid (for example, it is on an unmapped drive): " + sourceDirectory);
            }

            // All is good?
            Queue<string> sourceDirectoriesQueue = new Queue<string>();
            Stack<string> sourceDirectoriesStack = new Stack<string>();

            if (!sourceDirectory.EndsWith("\\"))
            {
                sourceDirectory += "\\";
            }

            if (!destinationDirectory.EndsWith("\\"))
            {
                destinationDirectory += "\\";
            }

            sourceDirectoriesQueue.Enqueue(sourceDirectory);
            sourceDirectoriesStack.Push(sourceDirectory);

            while (sourceDirectoriesQueue.Count > 0)
            {
                string currentSourceDirectory = sourceDirectoriesQueue.Dequeue();

                if (!currentSourceDirectory.EndsWith("\\"))
                {
                    currentSourceDirectory += "\\";
                }

                string currentDestinationDirectory = currentSourceDirectory.Replace(sourceDirectory, destinationDirectory);

                if (!currentDestinationDirectory.EndsWith("\\"))
                {
                    currentDestinationDirectory += "\\";
                }

                string[] subDirectories = Directory.GetDirectories(currentSourceDirectory);
                string[] files = Directory.GetFiles(currentSourceDirectory);

                if (moveEmptyDirectories || (subDirectories.Length > 0 || files.Length > 0))
                {
                    //if (!Directory.Exists(currentDestinationDirectory))
                    //{
                        Directory.CreateDirectory(currentDestinationDirectory);
                    //}

                    foreach (string subDirectory in subDirectories)
                    {
                        sourceDirectoriesQueue.Enqueue(subDirectory);
                        sourceDirectoriesStack.Push(subDirectory);
                    }

                    foreach (string file in files)
                    {
                        File.Copy(file, file.Replace(currentSourceDirectory, currentDestinationDirectory), overwrite);
                    }
                }
            }

            while (sourceDirectoriesStack.Count > 0)
            {
                Directory.Delete(sourceDirectoriesStack.Pop(), true);
            }
#if DEBUG
            Logging.ExitMethod("CC.Utilities.DirectoryEx.Move2()", enterTime);
#endif
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirectory">The path of the directory to move.</param>
        /// <param name="destinationDirectory">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        /// <param name="moveEmptyDirectories">true if the empty directories should be moved; otherwise false</param>
        public static void Move3(string sourceDirectory, string destinationDirectory, bool overwrite, bool moveEmptyDirectories)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.DirectoryEx.Move3()");
#endif
            if (sourceDirectory == null || destinationDirectory == null)
            {
                throw new ArgumentNullException((sourceDirectory == null) ? "sourceDirectory" : "destinationDirectory", "sourceDirectory or destinationDirectory is a null reference");
            }

            bool containsInvalidPathChar = false;

            foreach (char invalidPathChar in Path.GetInvalidPathChars())
            {
                if (destinationDirectory.Contains(invalidPathChar.ToString()) || sourceDirectory.Contains(invalidPathChar.ToString()))
                {
                    containsInvalidPathChar = true;
                    break;
                }
            }

            if (sourceDirectory == string.Empty || destinationDirectory == string.Empty || sourceDirectory.ToLower() == destinationDirectory.ToLower() || containsInvalidPathChar)
            {
                throw new ArgumentException("sourceDirectory or destinationDirectory is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.");
            }

            if (sourceDirectory.Length >= 248 || destinationDirectory.Length >= 248)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed the system-defined maximum length.");
            }

            if (!overwrite && Directory.Exists(destinationDirectory))
            {
                throw new IOException("destinationDirectory already exists: " + destinationDirectory);
            }

            if (!Directory.Exists(sourceDirectory))
            {
                throw new DirectoryNotFoundException("The path specified by sourceDirectory is invalid (for example, it is on an unmapped drive): " + sourceDirectory);
            }

            // All is good?
            Queue<string> sourceDirectoriesQueue = new Queue<string>();
            //Stack<string> sourceDirectoriesStack = new Stack<string>();

            if (!sourceDirectory.EndsWith("\\"))
            {
                sourceDirectory += "\\";
            }

            if (!destinationDirectory.EndsWith("\\"))
            {
                destinationDirectory += "\\";
            }

            sourceDirectoriesQueue.Enqueue(sourceDirectory);
            //sourceDirectoriesStack.Push(sourceDirectory);

            while (sourceDirectoriesQueue.Count > 0)
            {
                string currentSourceDirectory = sourceDirectoriesQueue.Dequeue();

                if (!currentSourceDirectory.EndsWith("\\"))
                {
                    currentSourceDirectory += "\\";
                }

                string currentDestinationDirectory = currentSourceDirectory.Replace(sourceDirectory, destinationDirectory);

                if (!currentDestinationDirectory.EndsWith("\\"))
                {
                    currentDestinationDirectory += "\\";
                }

                string[] subDirectories = Directory.GetDirectories(currentSourceDirectory);
                string[] files = Directory.GetFiles(currentSourceDirectory);

                if (moveEmptyDirectories || (subDirectories.Length > 0 || files.Length > 0))
                {
                    //if (!Directory.Exists(currentDestinationDirectory))
                    //{
                        Directory.CreateDirectory(currentDestinationDirectory);
                    //}

                    foreach (string subDirectory in subDirectories)
                    {
                        sourceDirectoriesQueue.Enqueue(subDirectory);
                        //sourceDirectoriesStack.Push(subDirectory);
                    }

                    foreach (string file in files)
                    {
                        File.Copy(file, file.Replace(currentSourceDirectory, currentDestinationDirectory), overwrite);
                    }
                }
            }

            //while (sourceDirectoriesStack.Count > 0)
            //{
                Directory.Delete(sourceDirectory, true);
            //}
#if DEBUG
            Logging.ExitMethod("CC.Utilities.DirectoryEx.Move3()", enterTime);
#endif
        }
        #endregion
    }
}
