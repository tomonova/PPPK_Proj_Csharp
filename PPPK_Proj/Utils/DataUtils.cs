using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace PPPK_Proj.Utils
{
    class DataUtils
    {
        public static DataTable EnumToDataTable(Type enumType, string header = "none", string opis = "Opis")
        {
            DataTable table = new DataTable();
            if (header != "none") 
            {
                table.Columns.Add("ID", Enum.GetUnderlyingType(enumType));
                table.Columns.Add(opis, typeof(string));
                DataRow headerItem = table.NewRow();
                headerItem[0] = 0;
                headerItem[1] = header;
                table.Rows.InsertAt(headerItem, 0);
                foreach (var item in Enum.GetValues(enumType))
                {
                    table.Rows.Add((int)item, Enum.Parse(enumType, item.ToString()));
                }
                return table;
            }

            table.Columns.Add("ID", Enum.GetUnderlyingType(enumType));
            table.Columns.Add(opis, typeof(string));
            foreach (var item in Enum.GetValues(enumType))
            {
                table.Rows.Add((int)item, Enum.Parse(enumType, item.ToString()));
            }
            return table;
        }
    }
}
