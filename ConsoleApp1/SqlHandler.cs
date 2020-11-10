using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class SqlHandler
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string ID_VOZAC = "@IDVozac";
        private const string IME_VOZAC = "@Ime";
        private const string PREZIME_VOZAC = "@Prezime";
        private const string MOBITEL_VOZAC = "@Mobitel";
        private const string VOZACKA_DOZVOLA_VOZAC = "@VozackaDozvola";
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

        internal static DataTable GetPutniNalozi()
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

        }

        private static void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }
    }
}
