using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_Proj.Models
{
    class Stavka
    {
        public int IDStavka { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public override string ToString() => $"{Naziv} : {Cijena}";
        public override bool Equals(object obj) => obj is Stavka other ? IDStavka == other.IDStavka : false;
        public override int GetHashCode() => IDStavka.GetHashCode();
    }
}
