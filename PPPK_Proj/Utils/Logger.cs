using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PPPK_Proj.Utils
{
    class Logger
    {
        private static string FILENAME = $@"{DateTime.Today.ToString("dd-MM-yyyy")}.DBLog.txt";

        public static void LogMessage(string message)
        {
            try
            {
                if (!File.Exists(FILENAME))
                {
                    File.Create(FILENAME).Close();
                }
                using (StreamWriter sw = File.AppendText(FILENAME))
                {
                    sw.WriteLine($"{DateTime.Now} {message}");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
