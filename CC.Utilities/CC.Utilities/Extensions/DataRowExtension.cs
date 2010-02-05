using System;
using System.Data;

namespace CC.Utilities
{
    /// <summary>
    /// Extensions methods for the <see cref="DataRow"/> object
    /// </summary>
    public static class DataRowExtension
    {
        /// <summary>
        /// Get the column value as <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">The target <see cref="Type"/></typeparam>
        /// <param name="dataRow">The <see cref="DataRow"/></param>
        /// <param name="columnIndex">The column index.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The column value as <see cref="T"/></returns>
        public static T GetColumn<T>(this DataRow dataRow, int columnIndex, T defaultValue)
        {
            T returnValue = defaultValue;

            if (dataRow != null)
            {
                if (dataRow[columnIndex] != null && dataRow[columnIndex] != DBNull.Value && !string.IsNullOrEmpty(dataRow[columnIndex].ToString()))
                {
                    T tempValue;

                    if (Utilities.TryParse(dataRow[columnIndex].ToString(), out tempValue))
                    {
                        returnValue = tempValue;
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Get the column value as <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">The target <see cref="Type"/></typeparam>
        /// <param name="dataRow">The <see cref="DataRow"/></param>
        /// <param name="columnName">The column name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The column value as <see cref="T"/></returns>
        public static T GetColumn<T>(this DataRow dataRow, string columnName, T defaultValue)
        {
            T returnValue = defaultValue;

            if (dataRow != null)
            {
                int columnIndex = dataRow.Table.Columns.IndexOf(columnName);

                if (columnIndex > -1)
                {
                    returnValue = GetColumn(dataRow, columnIndex, defaultValue);
                }
            }

            return returnValue;
        }
    }
}
