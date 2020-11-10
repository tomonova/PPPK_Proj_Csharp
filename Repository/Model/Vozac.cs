using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Vozac
    {
        public Vozac(int id, string ime, string prezime, string mob, string vDozvola)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Mobitel = mob;
            VozackaDozvola = vDozvola;
        }
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mobitel { get; set; }
        public string VozackaDozvola { get; set; }
        public override string ToString() => $"{Ime} {Prezime}";
    }
}
