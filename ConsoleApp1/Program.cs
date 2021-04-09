using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase db = new SqlDatabase(cs);
        private const string DRZAVE = "select * from drzave";
        private const string GRADOVI = "select * from gradovi";
        private const string INITINSERT = "Initinsert";
        private static readonly string[] TABLICE = { "SERVISNA_KNJIGA", "PUTNI_NALOZI", "GRADOVI", "DRZAVE", "VOZACI", "VOZILA" };
        static void Main(string[] args)

        {

            //using (IDataReader dr = db.ExecuteReader(CommandType.Text,DRZAVE))
            //{
            //    DataTable dt = new DataTable("tbl");
            //    dt.Load(dr);
            //    dt.WriteXml(@"C:\Users\TomoNova\Desktop\temporuša\drzave.xml", XmlWriteMode.WriteSchema);
            //}
            //using (IDataReader dr = db.ExecuteReader(CommandType.Text, GRADOVI))
            //{
            //    DataTable dt = new DataTable("tbl");
            //    dt.Load(dr);
            //    dt.WriteXml(@"C:\Users\TomoNova\Desktop\temporuša\gradovi.xml", XmlWriteMode.WriteSchema);
            //}

            //DataTable dt = new DataTable("tbl");
            //dt.ReadXml(@"C:\Users\TomoNova\Desktop\temporuša\gradovi.xml");

            //foreach (DataRow row in dt.Rows)
            //{
            //    db.ExecuteNonQuery($"{INITINSERT}Gradovi",row.ItemArray[0],row.ItemArray[1],row.ItemArray[2],row.ItemArray[3],row.ItemArray[4]);
            //}

            List<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            string konkat = string.Join(" ", lista.ToArray());
            Console.WriteLine(konkat);
        }
    }
}
