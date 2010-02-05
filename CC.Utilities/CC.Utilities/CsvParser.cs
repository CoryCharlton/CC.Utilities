using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CC.Utilities
{
    /// <summary>
    /// Provides CSV parsing functionality per RFC4180 http://tools.ietf.org/html/rfc4180
    /// </summary>
    public static class CsvParser
    {
        #region Private Constants
        // ReSharper disable InconsistentNaming
        // ReSharper restore InconsistentNaming
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        /// <summary>
        /// Parses a CSV file.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> containing the CSV data.</param>
        /// <returns>A <see cref="DataTable"/> containing the parsed CSV rows</returns>
        public static DataTable Parse(StreamReader streamReader)
        {
            return Parse(streamReader, false);
        }

        /// <summary>
        /// Parses a CSV file.
        /// </summary>
        /// <param name="streamReader">The <see cref="StreamReader"/> containing the CSV data.</param>
        /// <param name="hasHeader">True if the CSV file has a header row; False otherwise</param>
        /// <returns>A <see cref="DataTable"/> containing the parsed CSV rows</returns>
        public static DataTable Parse(StreamReader streamReader, bool hasHeader)
        {
            DataTable returnValue = new DataTable();

            int currentRowIndex = 0;

            while (!streamReader.EndOfStream)
            {
                string currentLine = streamReader.ReadLine();
                List<string> currentRow = new List<string>();
                int nextComma = -1;

                while (currentLine.Length > 0) // Parse the current line
                {
                    bool inQuote;

                    // NOTE: The RFC states: "Spaces are considered part of a field and should not be ignored" but also states "Each field may or may not be enclosed in double quotes". It's not entirely clear but I'm assuming that whitespace before a double quote should not be part of the field
                    if (currentLine.TrimStart(null).StartsWith("\""))
                    {
                        currentLine = currentLine.TrimStart(null);
                        int nextQuote = currentLine.IndexOf("\"", 1);

                        // NOTE: Check this hard. Should handle double double quotes
                        while (nextQuote > -1 && currentLine.Substring(nextQuote + 1, 1) == "\"")
                        {
                            nextQuote = currentLine.IndexOf("\"", nextQuote + 2);
                        }

                        if (nextQuote < 0)
                        {
                            inQuote = true;
                            currentLine += Environment.NewLine + streamReader.ReadLine();
                        }
                        else
                        {
                            inQuote = false;
                            nextComma = currentLine.IndexOf(",", nextQuote);
                            currentRow.Add(currentLine.Substring(1, (nextQuote >= 2) ? nextQuote - 2 : 0));
                        }
                    }
                    else
                    {
                        inQuote = false;
                        nextComma = currentLine.IndexOf(",");
                        currentRow.Add(nextComma > -1 ? currentLine.Substring(0, nextComma) : currentLine);
                    }

                    if (!inQuote) // Remove the last added field from the current line
                    {
                        currentLine = (nextComma > -1) ? currentLine.Substring(nextComma + 1) : string.Empty;
                    }
                }

                if (currentRowIndex == 0 && hasHeader)
                {
                    for (int i = 0; i < currentRow.Count; i++)
                    {
                        returnValue.Columns.Add(currentRow[i]);                        
                    }
                }
                else
                {
                    returnValue.Rows.Add(returnValue.NewRow(currentRow));
                }

                currentRowIndex++;
            }

            return returnValue;
        }

        /// <summary>
        /// Parses a CSV file.
        /// </summary>
        /// <param name="path">The CSV file to be parsed.</param>
        /// <returns>A <see cref="DataTable"/> containing the parsed CSV rows</returns>
        public static DataTable Parse(string path)
        {
            return Parse(path, false);
        }

        /// <summary>
        /// Parses a CSV file.
        /// </summary>
        /// <param name="path">The CSV file to be parsed.</param>
        /// <param name="hasHeader">True if the CSV file has a header row; False otherwise</param>
        /// <returns>A <see cref="DataTable"/> containing the parsed CSV rows</returns>
        public static DataTable Parse(string path, bool hasHeader)
        {
            using (StreamReader streamReader = File.OpenText(path))
            {
                return Parse(streamReader, hasHeader);
            }
        }

        #endregion
    }
}
