using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Models;
using PPPK_Proj.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Proj.DAO
{
    static class SqlHandler
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase db = new SqlDatabase(cs);
        private const string ID_VOZAC = "@IDVozac";
        private const string ID_PUTNI_NALOG = "@IDNalog";
        private const string VOZAC_ID = "@VozacID";
        private const string VOZILO_ID = "@VoziloID";
        private const string MJESTOSTART_ID = "@MjestoStartID";
        private const string MJESTOCILJ_ID = "@MjestoCiljID";
        private const string OTVARANJE_PN = "@Otvaranje";
        private const string ZATVARANJE_PN = "@Zatvaranje";
        private const string IME_VOZAC = "@Ime";
        private const string PREZIME_VOZAC = "@Prezime";
        private const string MOBITEL_VOZAC = "@Mobitel";
        private const string VOZACKA_DOZVOLA_VOZAC = "@VozackaDozvola";
        private const string STATUS_NALOGA = "@StatusNaloga";
        private const string TIP_VREMENA = "@TipVremena";
        private const string dateTimeFormat = "yyyy-MM-dd HH:mm";
        private const string emptyDate = "0001-01-01 00:00";
        private static readonly string[] TABLICE = { "SERVISNA_KNJIGA", "PUTNI_NALOZI", "GRADOVI", "DRZAVE", "VOZACI", "VOZILA" };

        internal static List<Vozac> GetVozaci()
        {
            List<Vozac> vozaci = new List<Vozac>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozaci);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vozaci.Add(new Vozac
                            (
                                (int)dr[nameof(Vozac.IDVozac)],
                                dr[nameof(Vozac.Ime)].ToString(),
                                dr[nameof(Vozac.Prezime)].ToString(),
                                dr[nameof(Vozac.Mobitel)].ToString(),
                                dr[nameof(Vozac.VozackaDozvola)].ToString()
                            ));
                        }
                    }
                }
            }
            return vozaci;
        }

        internal static string GetTime(int iDNalog, string tipVremena)
        {
            string dt;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetTime);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    cmd.Parameters.Add(TIP_VREMENA, SqlDbType.NVarChar);
                    cmd.Parameters[TIP_VREMENA].Value = tipVremena;
                    dt = cmd.ExecuteScalar().ToString();
                }
            }
            return dt;
        }

        internal static bool CheckFiles(string selectedPath)
        {
            List<string> xmlFiles = Directory.GetFiles(selectedPath, "*.xml").ToList();
            if (xmlFiles == null)
                return false;
            List<string> checkTables = TABLICE.ToList();
            List<string> fileNames = getFileNames(xmlFiles);
            foreach (string tableName in checkTables)
            {
                if (!fileNames.Contains(tableName))
                    return false;
            }
            return true;
        }

        private static List<string> getFileNames(List<string> xmlFiles)
        {
            List<string> tempList = new List<string>();
            foreach (string fileName in xmlFiles)
            {
                tempList.Add(Path.GetFileNameWithoutExtension(fileName));
            }
            return tempList;
        }

        internal static void ImportData(string selectedPath)
        {
            DataSet ds = new DataSet("importPodataka");
            List<string> xmlFiles = Directory.GetFiles(selectedPath, "*.xml").ToList();
            try
            {
                foreach (string xmlFile in xmlFiles)
                {
                    ds.ReadXml(xmlFile, XmlReadMode.ReadSchema);
                }
                CreateTables();
                ImportTables(ds);
                AddConstraint();
                SetDBStatus(DBSTatus.FULL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CreateTables() => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name);
        private static void ImportTables(DataSet ds)
        {
            InitinsertServisnaKnjiga(ds.Tables[TABLICE[0]]);
            InitinsertPutniNalozi(ds.Tables[TABLICE[1]]);
            InitinsertGradovi(ds.Tables[TABLICE[2]]);
            InitinsertDrzave(ds.Tables[TABLICE[3]]);
            InitinsertVozaca(ds.Tables[TABLICE[4]]);
            InitinsertVozila(ds.Tables[TABLICE[5]]);
        }

        private static void InitinsertServisnaKnjiga(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1], row[2], row[3]);
            }
        }

        private static void InitinsertPutniNalozi(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
        }

        private static void InitinsertVozila(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1].ToString(), row[2].ToString(), row[3], row[4], row[5]);
            }
        }

        private static void InitinsertVozaca(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5]);
            }
        }

        private static void InitinsertGradovi(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1].ToString(), row[2], row[3], row[4]);
            }
        }

        private static void InitinsertDrzave(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[0], row[1].ToString());
            }
        }
        private static void AddConstraint() => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name);
        private static void SetDBStatus(DBSTatus status) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, status);

        internal static void ExportData(string selectedPath)
        {
            DataSet ds = new DataSet("SviPodaci");
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(MethodBase.GetCurrentMethod().Name, con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.Fill(ds);
                    SetTableNames(ds);
                    try
                    {
                        SaveXML(ds, selectedPath);
                        MessageBox.Show("Podaci uspješno exportani", "EXPORT PODATKA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal static void CreatePutniNaloziXML(List<int> selektaniPutniNalozi, string fileName)
        {
            string putniNaloziID = string.Join(",", selektaniPutniNalozi.ToArray());
            try
            {
                DataSet ds = CreatePNDataSet(putniNaloziID);
                ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal static DataSet CreatePNDataSet(string putniNaloziID)
        {
            string[] tablice4XML = { TABLICE[1], TABLICE[2], TABLICE[4], TABLICE[5] };
            DataSet ds = new DataSet("PutniNalozi");
            db.LoadDataSet(MethodBase.GetCurrentMethod().Name, ds, tablice4XML, putniNaloziID);
            DataRelation pn2GradStartRelation = new DataRelation
                (
                    "pn2GradStartRelation",
                    ds.Tables[1].Columns[nameof(Grad.IDGrad)],
                    ds.Tables[0].Columns["MjestoStartID"]
                );
            ds.Relations.Add(pn2GradStartRelation);
            DataRelation pn2GradCiljRelation = new DataRelation
                (
                    "pn2GradCiljRelation",
                    ds.Tables[1].Columns[nameof(Grad.IDGrad)],
                    ds.Tables[0].Columns["MjestoCiljID"]
                );
            ds.Relations.Add(pn2GradCiljRelation);
            DataRelation pn2VozacRelation = new DataRelation
                (
                    "pn2VozacRelation",
                    ds.Tables[2].Columns[nameof(Vozac.IDVozac)],
                    ds.Tables[0].Columns["VozacID"]
                );
            ds.Relations.Add(pn2VozacRelation);
            DataRelation pn2VoziloRelation = new DataRelation
                (
                    "pn2VoziloRelation",
                    ds.Tables[3].Columns[nameof(Vozilo.IDVozilo)],
                    ds.Tables[0].Columns["VoziloID"]
                );
            ds.Relations.Add(pn2VoziloRelation);
            return ds;
        }
        internal static int ImportPutniNaloziXML(string fileName)
        {
            DataSet ds = new DataSet("importPodataka");
            try
            {
                ds.ReadXml(fileName, XmlReadMode.ReadSchema);
                return InsertPutniNalog(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int InsertPutniNalog(DataTable dataTable)
        {
            int insertedNum = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                 insertedNum += db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
            return insertedNum;
        }

        private static void SetTableNames(DataSet ds)
        {
            for (int i = 0; i < TABLICE.Length; i++)
            {
                ds.Tables[i].TableName = TABLICE[i];
            }
        }

        private static void SaveXML(DataSet ds, string selectedPath)
        {
            for (int i = 0; i < TABLICE.Length; i++)
            {
                try
                {
                    ds.Tables[i].WriteXml($"{selectedPath}\\{TABLICE[i]}.xml", XmlWriteMode.WriteSchema);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        internal static string GetStatusNalogaPN(int iDNalog)
        {
            string status = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetStatusNalogaPN);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    status = cmd.ExecuteScalar().ToString();
                }
            }
            return status;
        }

        internal static bool GetDBStatus() => Convert.ToBoolean(db.ExecuteScalar(MethodBase.GetCurrentMethod().Name));
        internal static void DeletePodataka() => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name);

        internal static string GetVoziloPN(int iDNalog)
        {
            string vozilo = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVoziloPN);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    vozilo = cmd.ExecuteScalar().ToString();
                }
            }
            return vozilo;
        }

        internal static string GetVozacPN(int iDNalog)
        {
            string vozac = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozacPN);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    vozac = cmd.ExecuteScalar().ToString();
                }
            }
            return vozac;
        }

        internal static string GetMjestoCilj(int iDNalog)
        {
            string mjesto = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetMjestoCilj);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    mjesto = cmd.ExecuteScalar().ToString();
                }
            }
            return mjesto;
        }

        internal static int AddEditPN(PutniNalog pn)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    SqlTransaction transaction;
                    transaction = con.BeginTransaction("AddEditPN");
                    cmd.Transaction = transaction;
                    try
                    {
                        cmd.CommandText = nameof(AddEditPN);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                        cmd.Parameters[ID_PUTNI_NALOG].Value = pn.IDPutniNalog;
                        if (pn.Otvaranje == DateTime.Parse(emptyDate))
                            cmd.Parameters.AddWithValue(OTVARANJE_PN, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(OTVARANJE_PN, pn.Otvaranje.ToString(dateTimeFormat));
                        if (pn.Zatvaranje == DateTime.Parse(emptyDate))
                            cmd.Parameters.AddWithValue(ZATVARANJE_PN, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(ZATVARANJE_PN, pn.Zatvaranje.ToString(dateTimeFormat));
                        if (pn.Vozac.IDVozac == 0)
                            cmd.Parameters.AddWithValue(VOZAC_ID, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(VOZAC_ID, pn.Vozac.IDVozac);
                        if (pn.Vozilo.IDVozilo == 0)
                            cmd.Parameters.AddWithValue(VOZILO_ID, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(VOZILO_ID, pn.Vozilo.IDVozilo);
                        if (pn.Start.IDGrad == 0)
                            cmd.Parameters.AddWithValue(MJESTOSTART_ID, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(MJESTOSTART_ID, pn.Start.IDGrad);
                        if (pn.Cilj.IDGrad == 0)
                            cmd.Parameters.AddWithValue(MJESTOCILJ_ID, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(MJESTOCILJ_ID, pn.Cilj.IDGrad);
                        if (pn.NalogStatus == 0)
                            cmd.Parameters.AddWithValue(STATUS_NALOGA, DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue(STATUS_NALOGA, pn.NalogStatus);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        internal static string GetMjestoStart(int iDNalog)
        {
            string mjesto = "";
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetMjestoStart);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                    cmd.Parameters[ID_PUTNI_NALOG].Value = iDNalog;
                    mjesto = cmd.ExecuteScalar().ToString();
                }
            }
            return mjesto;
        }

        internal static DataTable GetVozilaFree(DateTime dtO, DateTime dtZ)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozilaFree);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(OTVARANJE_PN, dtO.ToString(dateTimeFormat));
                    cmd.Parameters.AddWithValue(ZATVARANJE_PN, dtZ.ToString(dateTimeFormat));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        internal static DataTable GetVozilaCB()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozilaCB);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        internal static DataTable GetVozaciFree(DateTime dtO, DateTime dtZ)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozaciFree);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(OTVARANJE_PN, dtO.ToString(dateTimeFormat));
                    cmd.Parameters.AddWithValue(ZATVARANJE_PN, dtZ.ToString(dateTimeFormat));
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        internal static DataTable GetVozaciCB()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozaciCB);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        internal static DataTable GetGradoviCB()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetGradoviCB);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        internal static DataTable GetPutniNalozi(int filterChoice)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetPutniNalozi);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(STATUS_NALOGA, SqlDbType.Int);
                    cmd.Parameters[STATUS_NALOGA].Value = filterChoice;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        internal static Vozac GetVozac(int idVozac)
        {
            using (DataSet ds = db.ExecuteDataSet(MethodBase.GetCurrentMethod().Name, idVozac))
            {
                DataRow dr = ds?.Tables?[0]?.Rows?[0];
                return dr != null ? new Vozac
                            (
                                (int)dr[nameof(Vozac.IDVozac)],
                                dr[nameof(Vozac.Ime)].ToString(),
                                dr[nameof(Vozac.Prezime)].ToString(),
                                dr[nameof(Vozac.Mobitel)].ToString(),
                                dr[nameof(Vozac.VozackaDozvola)].ToString()
                            ) : null;
            }
        }
        internal static void AddVozac(Vozac vozac) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, vozac.Ime, vozac.Prezime, vozac.Mobitel, vozac.VozackaDozvola);
        internal static void EditVozac(Vozac vozac) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, vozac.IDVozac, vozac.Ime, vozac.Prezime, vozac.Mobitel, vozac.VozackaDozvola);
        internal static int DelVozac(Vozac vozac) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, vozac.IDVozac);
        internal static int DelPutniNalog(List<int> selektaniPutniNalozi)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    int result = 0;
                    foreach (int pnID in selektaniPutniNalozi)
                    {
                        cmd.CommandText = nameof(DelPutniNalog);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(ID_PUTNI_NALOG, SqlDbType.Int);
                        cmd.Parameters[ID_PUTNI_NALOG].Value = pnID;
                        result += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    return result;
                }
            }
        }

        private static void SqlMessagesSubscription(SqlConnection con)
        {
            con.FireInfoMessageEventOnUserErrors = true;
            con.InfoMessage += Con_InfoMessage;
            con.StateChange += Con_StateChange;
        }

        private static void Con_StateChange(object sender, StateChangeEventArgs e)
        {
            try
            {
                Logger.LogMessage($"Original state: {e.OriginalState}");
                Logger.LogMessage($"Current state: {e.CurrentState}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            try
            {
                foreach (SqlError error in e.Errors)
                {
                    Logger.LogMessage($"ERROR Source: {error.Source}");
                    Logger.LogMessage($"ERROR State: {error.State}");
                    Logger.LogMessage($"ERROR Number: {error.Number}");
                    Logger.LogMessage($"ERROR Procedure: {error.Procedure}");
                    Logger.LogMessage($"ERROR Message: {error.Message}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal static List<SERVISNA_KNJIGA> GetServisi()
        {
            using (var db = new ModelContainer())
            {
                return db.SERVISNA_KNJIGA.OrderByDescending(x => x.Datum).ToList();
            }
        }
    }
}
