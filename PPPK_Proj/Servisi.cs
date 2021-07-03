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
                try
                {
                    lbServisi.DataSource = SqlHandler.GetServisi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbServisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbServisi.SelectedIndex > -1)
            {
                SERVISNA_KNJIGA servis = (SERVISNA_KNJIGA)lbServisi.SelectedItem;
                tbDatum.Text = servis.Datum.ToString("dd/MM/yyyy");
                tbCijena.Text = servis.Trosak.ToString();
                tbVozilo.Text = $"{servis.VOZILA.Marka} {servis.VOZILA.Tip}";
                loadStavke(servis.IDServis);
            }
        }

        private void loadStavke(int iDServis)
        {
            try
            {
                lbStavke.DataSource = SqlHandler.GetStavke(iDServis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var potvrda = MessageBox.Show($"Jesi siguran da brišeš Servis?{lbServisi.SelectedItem}?"
                , "POTVRDI BRISANJE"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Warning);
            if (lbServisi.SelectedItem is SERVISNA_KNJIGA servis)
            {
                if (potvrda == DialogResult.OK)
                {
                    try
                    {
                        if (SqlHandler.DelServis((SERVISNA_KNJIGA)lbServisi.SelectedItem))
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

        private void Rifresh()
        {
            lbServisi.ClearSelected();
            popuniServise();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new MngServis(null).ShowDialog();
            Rifresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbServisi.SelectedItem is SERVISNA_KNJIGA servis)
            {
                new MngServis(servis.IDServis).ShowDialog();
            }
            Rifresh();
        }
    }
}
