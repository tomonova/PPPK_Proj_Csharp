using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vozilo
    {
        public Vozilo()
        {

        }
        public Vozilo(int id)
        {
            IDVozilo = id;
        }
        public int IDVozilo { get; set; }
        public string  Tip { get; set; }
        public string Marka { get; set; }
        public DateTime GodinaProizvodnje { get; set; }
        public DateTime GodinaUnosa { get; set; }
        public int InicijalniKM { get; set; }
        public override string ToString() => $"{Marka} {Tip}";
    }
}
