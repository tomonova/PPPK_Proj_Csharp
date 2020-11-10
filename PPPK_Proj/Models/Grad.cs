using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Grad
    {
        public Grad()
        {

        }
        public Grad(int id)
        {
            IDGrad = id;
        }
        public int IDGrad { get; set; }
        public string Ime { get; set; }
        public Drzava Drzava { get; set; }
    }
}
