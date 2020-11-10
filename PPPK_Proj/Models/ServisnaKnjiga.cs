using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ServisnaKnjiga
    {
        public int ID { get; set; }
        public Vozilo Vozilo { get; set; }
        public DateTime DatumServisa { get; set; }
        public decimal Trosak { get; set; }
    }
}
