using System.Collections.Generic;
using System.Data;

namespace CC.Utilities
{
    /// <summary>
    /// Contains extension methods for <see cref="DataTable"/>
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Creates a new <see cref="DataRow"/> with the same schema as the table using a <see cref="List{T}"/> for column values.
        /// </summary>
        /// <param name="dataTable">The <see cref="DataTable"/></param>
        /// <param name="columnValues">The values used to populate the columns</param>
        /// <returns></returns>
        public static DataRow NewRow(this DataTable dataTable, List<string> columnValues)
        {
            // TODO: Extend this so any List<object> can be used
            DataRow returnValue = dataTable.NewRow();

            while (columnValues.Count > returnValue.Table.Columns.Count)
            {
                returnValue.Table.Columns.Add();
            }

            returnValue.ItemArray = columnValues.ToArray();
            return returnValue;
        }
    }
}
