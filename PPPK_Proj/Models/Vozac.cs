using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vozac
    {
        public Vozac()
        {

        }
        public Vozac(int id)
        {
            IDVozac = id;
        }
        public Vozac(int id, string ime, string prezime, string mob, string vDozvola):this (id)
        {
            Ime = ime;
            Prezime = prezime;
            Mobitel = mob;
            VozackaDozvola = vDozvola;
        }
        public int IDVozac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mobitel { get; set; }
        public string VozackaDozvola { get; set; }
        public override string ToString() => $"{Ime} {Prezime}";
        public override bool Equals(object obj) => obj is Vozac other ? IDVozac == other.IDVozac : false;
        public override int GetHashCode() => IDVozac.GetHashCode();
    }
}
