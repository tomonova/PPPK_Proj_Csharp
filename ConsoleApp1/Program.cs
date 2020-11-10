using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPPK_Proj;


namespace ConsoleApp1
{
    enum PutniNalogStatus
    {
        ZATVOREN = 1,
        OTVOREN = 2,
        BUDUCI = 3
    }
    class Program
    {
        static void Main(string[] args)
        {

            DataTable dt = SqlHandler.GetPutniNalozi();
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    Console.WriteLine(row[i].ToString());
                }
                //foreach (var item in row.ItemArray)
                //{
                //    Console.WriteLine(item);
                //}
            }


        }
        public static DataTable EnumToDataTable(Type enumType, string opis = "Opis", string header = "none")
        {
            DataTable table = new DataTable();


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
