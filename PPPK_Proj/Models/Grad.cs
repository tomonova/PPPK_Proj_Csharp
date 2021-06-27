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

        public Grad(int iDGrad, string ime, int drzavaID, double latitude, double longitude) : this(iDGrad)
        {
            Ime = ime;
            DrzavaID = drzavaID;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int IDGrad { get; set; }
        public string Ime { get; set; }
        public int DrzavaID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public override string ToString() => $"Ime";
        public override bool Equals(object obj) => obj is Grad other ? IDGrad == other.IDGrad : false;
        public override int GetHashCode() => IDGrad.GetHashCode();
    }
}
