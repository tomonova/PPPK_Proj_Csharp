using Repository.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repository.DAL
{
    internal class DBRepo : IRepo
    {
        private string cs;
        public DBRepo(string connectionString)
        { 
            cs = connectionString;
        }
        public Grad GetGrad()
        {
            throw new System.NotImplementedException();
        }

        public List<Grad> GetGradovi()
        {
            throw new System.NotImplementedException();
        }

        public PutniNalog GetPutniNalog()
        {
            throw new System.NotImplementedException();
        }

        public List<PutniNalog> GetPutniNalozi()
        {
            throw new System.NotImplementedException();
        }

        public ServisnaKnjiga GetServisnaKnjiga()
        {
            throw new System.NotImplementedException();
        }

        public List<ServisnaKnjiga> GetServisneKnjige()
        {
            throw new System.NotImplementedException();
        }

        public Vozac GetVozac()
        {
            throw new System.NotImplementedException();
        }

        public List<Vozac> GetVozaci()
        {
            List<Vozac> people = new List<Vozac>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozaci);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(new Vozac
                            (
                                (int)dr[nameof(Vozac.ID)],
                                dr[nameof(Vozac.Ime)].ToString(),
                                dr[nameof(Vozac.Prezime)].ToString(),
                                dr[nameof(Vozac.Mobitel)].ToString(),
                                dr[nameof(Vozac.VozackaDozvola)].ToString()
                            ));
                        }
                    }
                }
            }
            return people;
        }

        public List<Vozilo> GetVozila()
        {
            throw new System.NotImplementedException();
        }

        public Vozilo GetVozilo()
        {
            throw new System.NotImplementedException();
        }
    }
}