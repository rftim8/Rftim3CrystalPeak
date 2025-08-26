using System.Data;

namespace Rftim3Console.System.Data
{
    internal class RftData
    {
        public RftData()
        {
            // Create a new DataTable
            DataTable table = new("Names");
            // Define columns
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            // Create a new DataRow
            DataRow row = table.NewRow();
            row["FirstName"] = "John";
            row["LastName"] = "Doe";
            // Add the DataRow to the DataTable
            table.Rows.Add(row);
            // Display the data
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine($"{column.ColumnName}: {row[column]}");
            }
        }
    }
}
