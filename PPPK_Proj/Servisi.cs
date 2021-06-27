using PPPK_Proj.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Proj
{
    public partial class Servisi : Form
    {
        public Servisi()
        {
            InitializeComponent();
        }

        private void Servisi_Load(object sender, EventArgs e) => popuniServise();

        private void popuniServise()
        {
            try
            {
                lbServisi.DataSource = SqlHandler.GetServisi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbServisi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
