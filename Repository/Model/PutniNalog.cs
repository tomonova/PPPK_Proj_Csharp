using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class PutniNalog
    {
        public int ID { get; set; }
        public DateTime Otvaranje { get; set; }
        public DateTime Zatvaranje { get; set; }
        public Vozac Vozac { get; set; }
        public Vozilo Vozilo { get; set; }
        public Grad Start { get; set; }
        public Grad Cilj { get; set; }
        public PutniNalogStatus NalogStatus { get; set; }
    }
}
