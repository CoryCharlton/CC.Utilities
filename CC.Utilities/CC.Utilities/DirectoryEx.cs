using System;
using System.IO;

namespace CC.Utilities
{
    /// <summary>
    /// Improves on the performance (or lack thereof) of the <see cref="Directory"/> class.
    /// </summary>
    public static class DirectoryEx 
    {
        //NOTE: The documentation for System.IO.Directory indicates Directory.Move() can be used on files or folders. My implementation below only supports folders are the recursive folder moving is the performance hit on the original implementation.
        
        #region Public Methods
        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the directory to move.</param>
        /// <param name="destDirName">The path to the new location</param>
        public static void Move(string sourceDirName, string destDirName)
        {
            Move(sourceDirName, destDirName, false, true);
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the directory to move.</param>
        /// <param name="destDirName">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        public static void Move(string sourceDirName, string destDirName, bool overwrite)
        {
            Move(sourceDirName, destDirName, overwrite, true);
        }

        /// <summary>
        /// Moves a directory and it's contents to a new location.
        /// </summary>
        /// <param name="sourceDirName">The path of the directory to move.</param>
        /// <param name="destDirName">The path to the new location</param>
        /// <param name="overwrite">true if the destination can be overwritten; otherwise false</param>
        /// <param name="moveEmptyFolders"></param>
        public static void Move(string sourceDirName, string destDirName, bool overwrite, bool moveEmptyFolders)
        {
#if DEBUG
            DateTime enterTime = Logging.EnterMethod("CC.Utilities.DirectoryEx.Move()");
#endif
            if (sourceDirName == null || destDirName == null)
            {
                throw new ArgumentNullException((sourceDirName == null) ? "sourceDirName" : "destDirName", "sourceDirName or destDirName is a null reference");
            }

            bool containsInvalidPathChar = false;

            foreach (char invalidPathChar in Path.GetInvalidPathChars())
            {
                if (destDirName.Contains(invalidPathChar.ToString()) || sourceDirName.Contains(invalidPathChar.ToString()))
                {
                    containsInvalidPathChar = true;
                    break;
                }
            }

            if (sourceDirName == string.Empty || destDirName == string.Empty || sourceDirName.ToLower() == destDirName.ToLower() || containsInvalidPathChar)
            {
                throw new ArgumentException("sourceDirName or destDirName is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.");
            }

            if (sourceDirName.Length >= 248 || destDirName.Length >= 248)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed the system-defined maximum length.");
            }

            if (!overwrite && Directory.Exists(destDirName))
            {
                throw new IOException("destDirName already exists: " + destDirName);
            }

            if (!Directory.Exists(sourceDirName))
            {
                throw new DirectoryNotFoundException("The path specified by sourceDirName is invalid (for example, it is on an unmapped drive): " + sourceDirName);
            }

            // All is good?

            if (!sourceDirName.EndsWith("\\"))
            {
                sourceDirName += "\\";
            }

            if (!destDirName.EndsWith("\\"))
            {
                destDirName += "\\";
            }

            string[] subDirectories = Directory.GetDirectories(sourceDirName);
            Array.Sort(subDirectories);

            string[] files = Directory.GetFiles(sourceDirName);
            Array.Sort(files);

            //NOTE: The recursision here can be *HEAVY* on the stack depending on the number of folders. Going to look into using a Queue<T>. The only drawback from a Queue<T> would be if Directory.Delete(sourceDirName, true) is also slow like the default Move(). With a Queue<T> I can move all the files and folders individually but will only get one Delete() operation. Time for some testing...
            if (moveEmptyFolders || (subDirectories.Length > 0 || files.Length > 0))
            {
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                foreach (string subDirectory in subDirectories)
                {
                    Move(subDirectory, subDirectory.Replace(sourceDirName, destDirName), overwrite, moveEmptyFolders);
                }

                foreach (string file in files)
                {
                    File.Copy(file, file.Replace(sourceDirName, destDirName), overwrite);
                }
            }

            Directory.Delete(sourceDirName, true);
#if DEBUG
            Logging.ExitMethod("CC.Utilities.DirectoryEx.Move()", enterTime);
#endif
        }
        #endregion
    }
}
