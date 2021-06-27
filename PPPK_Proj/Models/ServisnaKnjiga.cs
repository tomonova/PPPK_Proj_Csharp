using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Servis
    {
        public Servis(int iD, Vozilo vozilo, DateTime datumServisa, decimal trosak)
        {
            ID = iD;
            Vozilo = vozilo;
            DatumServisa = datumServisa;
            Trosak = trosak;
        }

        public int ID { get; set; }
        public Vozilo Vozilo { get; set; }
        public DateTime DatumServisa { get; set; }
        public decimal Trosak { get; set; }

        public override bool Equals(object obj) => obj is Servis other ? ID == other.ID : false;
        public override int GetHashCode() => ID.GetHashCode();
    }
}
