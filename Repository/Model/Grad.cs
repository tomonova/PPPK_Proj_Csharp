using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class Grad
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public Drzava Drzava { get; set; }
    }
}
