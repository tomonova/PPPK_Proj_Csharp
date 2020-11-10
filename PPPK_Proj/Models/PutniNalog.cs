using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PutniNalog
    {
        public PutniNalog()
        {

        }
        public PutniNalog(int id)
        {
            IDPutniNalog = id;
        }
        public PutniNalog(int id,DateTime otvaranje,DateTime zatvaranje, Vozac vozac, Vozilo vozilo, Grad start, Grad cilj, PutniNalogStatus status):this(id)
        {
            Otvaranje = otvaranje;
            Zatvaranje = zatvaranje;
            Vozac = vozac;
            Vozilo = vozilo;
            Start = start;
            Cilj = cilj;
            NalogStatus = status;
        }
        public int IDPutniNalog { get; set; }
        public DateTime Otvaranje { get; set; }
        public DateTime Zatvaranje { get; set; }
        public Vozac Vozac { get; set; }
        public Vozilo Vozilo { get; set; }
        public Grad Start { get; set; }
        public Grad Cilj { get; set; }
        public PutniNalogStatus NalogStatus { get; set; }
    }
}
