using Models;
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
    public partial class DodajUrediVozac : Form
    {
        private int _IDVozac;
        public DodajUrediVozac(int? idVozac)
        {
            InitializeComponent();
            if (idVozac.HasValue)
            {
                _IDVozac = idVozac.Value;
                this.Text = $"Uredi vozaca";
                btnOK.Text = $"Uredi vozaca";

                try
                {
                    Vozac vozac = SqlHandler.GetVozac(idVozac.Value);
                    PuniTxtBoxove(vozac);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Text = $"Dodaj novog vozaca";
                btnOK.Text = $"Dodaj novog";
                _IDVozac = 0;
            }
        }

        private void PuniTxtBoxove(Vozac vozac)
        {
            tbIme.Text = vozac.Ime;
            tbPrezime.Text = vozac.Prezime;
            tbMobitel.Text = vozac.Mobitel;
            tbVozacka.Text = vozac.VozackaDozvola;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidirajUnos())
            {
                this.DialogResult = DialogResult.None;
                return;
            }
            else
            {
                Vozac vozac = new Vozac
                {
                    IDVozac = _IDVozac == 0 ? 0 : _IDVozac,
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    Mobitel = tbMobitel.Text,
                    VozackaDozvola = tbVozacka.Text
                };
                if (_IDVozac != 0)
                    try
                    {
                        SqlHandler.EditVozac(vozac);
                    }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.None;
                        lblInfo.Text = $"{ex.Message}";
                    }
                else
                    try
                    {
                        SqlHandler.AddVozac(vozac);

                    }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.None;
                        lblInfo.Text = $"{ex.Message}";
                    };
            }
        }

        private bool ValidirajUnos()
        {
            foreach (Control control in tblVozac.Controls)
            {
                if (control is TextBox && string.IsNullOrEmpty(control.Text))
                {
                    lblInfo.Text = $"Sva polja moraju biti popunjena!!!";
                    return false;
                }
            }
            return true;
        }
    }
}
