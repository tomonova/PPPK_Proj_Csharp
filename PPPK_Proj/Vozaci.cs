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
            if (!SqlHandler.GetDBStatus())
            {
                MessageBox.Show("Ne postoje podatci u bazi, prvo učitajte podatke!!!");
                DisableSvega();
                return;
            }
            try
            {
                lbVozaci.DataSource = SqlHandler.GetVozaci();
                EnableSvega();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisableSvega()
        {
            lbVozaci.DataSource = null;
            lbVozaci.Items.Clear();
            btnNoviVozac.Enabled = false;
            btnObrisi.Enabled = false;
            btnUrediVozaca.Enabled = false;
            putniNaloziToolStripMenuItem.Enabled = false;
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


        private void exportPodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    SqlHandler.ExportData(fbd.SelectedPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void importPodatakaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK && !SqlHandler.GetDBStatus())
            {
                try
                {
                    if (!SqlHandler.CheckFiles(fbd.SelectedPath))
                    {
                        MessageBox.Show($"Nedostaju datoteke za učitavanje");
                        return;
                    }
                    SqlHandler.ImportData(fbd.SelectedPath);
                    popuniVozace();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EnableSvega()
        {
            btnNoviVozac.Enabled = true;
            btnObrisi.Enabled = true;
            btnUrediVozaca.Enabled = true;
            putniNaloziToolStripMenuItem.Enabled = true;
        }

        private void brisanjeBazeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show($"Jesi siguran da želiš obrisati sve podatke?"
                , "POTVRDI BRISANJE"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Exclamation);

            if (potvrda == DialogResult.OK && SqlHandler.GetDBStatus())
            {
                try
                {
                    SqlHandler.DeletePodataka();
                    Rifresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
