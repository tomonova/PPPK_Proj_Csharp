using Models;
using PPPK_Proj.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Proj.DAO
{
    static class SqlHandler
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
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
                            cmd.Parameters.AddWithValue(ZATVARANJE_PN, pn.Otvaranje.ToString(dateTimeFormat));
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

            Vozac vozac = null;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozac);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_VOZAC, SqlDbType.Int);
                    cmd.Parameters[ID_VOZAC].Value = idVozac;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            vozac = new Vozac
                            (
                                (int)dr[nameof(Vozac.IDVozac)],
                                dr[nameof(Vozac.Ime)].ToString(),
                                dr[nameof(Vozac.Prezime)].ToString(),
                                dr[nameof(Vozac.Mobitel)].ToString(),
                                dr[nameof(Vozac.VozackaDozvola)].ToString()
                            );
                        }
                    }
                }
            }
            return vozac;
        }

        internal static int DelVozac(Vozac vozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(DelVozac);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_VOZAC, SqlDbType.Int);
                    cmd.Parameters[ID_VOZAC].Value = vozac.IDVozac;
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
        }

        internal static void AddVozac(Vozac vozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(AddVozac);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(IME_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[IME_VOZAC].Value = vozac.Ime;
                    cmd.Parameters.Add(PREZIME_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[PREZIME_VOZAC].Value = vozac.Prezime;
                    cmd.Parameters.Add(MOBITEL_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[MOBITEL_VOZAC].Value = vozac.Mobitel;
                    cmd.Parameters.Add(VOZACKA_DOZVOLA_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[VOZACKA_DOZVOLA_VOZAC].Value = vozac.VozackaDozvola;
                    cmd.ExecuteNonQuery();
                }
            }
        }

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

        internal static void EditVozac(Vozac vozac)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlMessagesSubscription(con);
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(EditVozac);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(ID_VOZAC, SqlDbType.Int);
                    cmd.Parameters[ID_VOZAC].Value = vozac.IDVozac;
                    cmd.Parameters.Add(IME_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[IME_VOZAC].Value = vozac.Ime;
                    cmd.Parameters.Add(PREZIME_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[PREZIME_VOZAC].Value = vozac.Prezime;
                    cmd.Parameters.Add(MOBITEL_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[MOBITEL_VOZAC].Value = vozac.Mobitel;
                    cmd.Parameters.Add(VOZACKA_DOZVOLA_VOZAC, SqlDbType.NVarChar);
                    cmd.Parameters[VOZACKA_DOZVOLA_VOZAC].Value = vozac.VozackaDozvola;
                    cmd.ExecuteNonQuery();
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
    }
}
