using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public class RepoFactory
    {
        private string CS;
        public RepoFactory(string cs)
        {
            CS = cs;
        }
        public IRepo GetRepo() => new DBRepo(CS);
    }
}
