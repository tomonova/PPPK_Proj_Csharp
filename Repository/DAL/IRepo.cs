using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public interface IRepo
    {
        List<Vozac> GetVozaci();
        Vozac GetVozac();
        List<Grad> GetGradovi();
        Grad GetGrad();
        List<Vozilo> GetVozila();
        Vozilo GetVozilo();
        List<PutniNalog> GetPutniNalozi();
        PutniNalog GetPutniNalog();
        List<ServisnaKnjiga> GetServisneKnjige();
        ServisnaKnjiga GetServisnaKnjiga();
    }
}
