using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FailoverCompare
{
    class Comparrer
    {
        public DataTable OriginalTable { get; set; }
        public DataTable TargetTable { get; set; }

        public void Compare()
        {
            DataTable tableA = GetSortedOriginalTable();
            DataTable tableB = GetSortedTargetTable();

            string keyField = tableA.Columns[0].ColumnName;
            string checkField = tableA.Columns[1].ColumnName;
            for (int i = 0; i < tableA.Rows.Count; i++)
            {
                
                string keyValue = tableA.Rows[i].Field<string>(0);
                DataRow rowB = tableB.Select(keyField + " = '" + keyValue + "'").FirstOrDefault();

                if (rowB == null)
                {
                    tableA.Rows[i].SetField<bool>("Error", true);
                    AddErrorRowToTable(tableB, keyField, keyValue);
                }
                else if (string.Compare(rowB.Field<string>(checkField), tableA.Rows[i].Field<string>(checkField)) != 0)
                {
                    tableA.Rows[i].SetField<bool>("Error", true);
                    tableB.Rows[i].SetField<bool>("Error", true);
                }
            }

            for (int i = 0; i < tableB.Rows.Count; i++)
            {
                
                string keyValue = tableB.Rows[i].Field<string>(0);
                DataRow rowB = tableA.Select(keyField + " = '" + keyValue + "'").FirstOrDefault();

                if (rowB == null)
                {
                    tableB.Rows[i].SetField<bool>("Error", true);
                    AddErrorRowToTable(tableA, keyField, keyValue);
                }
                
            }

            OriginalTable = tableA;
            TargetTable = tableB;
        }

        private void AddErrorRowToTable(DataTable table, string field, string value)
        {
            DataRow newRow = table.NewRow();
            newRow.SetField<string>(field, value);
            newRow.SetField<bool>("Error", true);
            table.Rows.Add(newRow);

        }

        public DataTable GetSortedOriginalTable()
        {
            DataView view = new DataView(OriginalTable);
            view.Sort = OriginalTable.Columns[0].ColumnName;
            return view.ToTable();
        }

        public DataTable GetSortedTargetTable()
        {
            DataView view = new DataView(TargetTable);
            view.Sort = OriginalTable.Columns[0].ColumnName;
            return view.ToTable();
        }
    }
}
