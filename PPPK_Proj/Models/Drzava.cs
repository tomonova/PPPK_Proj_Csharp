using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Drzava
    {
        public Drzava(int iD, string ime)
        {
            ID = iD;
            Ime = ime;
        }

        public int ID { get; set; }
        public string Ime { get; set; }
    }
}
