using Models;
using PPPK_Proj.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Proj
{
    public partial class Vozaci : Form
    {
        public Vozaci()
        {
            InitializeComponent();
        }

        private void Vozaci_Load(object sender, EventArgs e) => popuniVozace();

        private void popuniVozace()
        {
            try
            {
                lbVozaci.DataSource = SqlHandler.GetVozaci();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbVozaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbVozaci.SelectedIndex > -1)
            {
                Vozac vozac = (Vozac)lbVozaci.SelectedItem;
                tbIme.Text = vozac.Ime;
                tbPrezime.Text = vozac.Prezime;
                tbMobitel.Text = vozac.Mobitel;
                tbVozacka.Text = vozac.VozackaDozvola;
            }
        }

        private void btnUrediVozaca_Click(object sender, EventArgs e)
        {
            if (lbVozaci.SelectedItem is Vozac vozac)
            {
                new DodajUrediVozac(vozac.IDVozac).ShowDialog();
            }
            Rifresh();
        }

        private void Rifresh()
        {
            lbVozaci.ClearSelected();
            popuniVozace();
        }

        private void btnNoviVozac_Click(object sender, EventArgs e)
        {
            new DodajUrediVozac(null).ShowDialog();
            Rifresh();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show($"Jesi siguran da daješ otkaz {lbVozaci.SelectedItem}?"
                ,"POTVRDI BRISANJE"
                ,MessageBoxButtons.OKCancel
                ,MessageBoxIcon.Warning);
            if (lbVozaci.SelectedItem is Vozac vozac)
            {
                if (potvrda == DialogResult.OK)
                {
                    try
                    {
                        if (SqlHandler.DelVozac((Vozac)lbVozaci.SelectedItem) > 0)
                        {
                            Rifresh();
                        }
                        else
                        {
                            MessageBox.Show("Nismo ga mogli otpustiti, sindikat garant");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void putniNaloziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PutniNalozi pn = new PutniNalozi();
            pn.Show();
        }
    }
}
