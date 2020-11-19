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
    public partial class PutniNalogForm : Form
    {
        private int IDNalog;
        private int? _IDNalog;
        private const string headerTekst = "--BIRAJ--";
        private const string dateTimeFormat = "yyyy-MM-dd HH:mm";
        private const string emptyDate = "0001-01-01 00:00";
        PutniNalozi pn; 
        public PutniNalogForm(PutniNalozi putniNalozi, int? IDNalog)
        {
            InitializeComponent();
            pn = putniNalozi;
            _IDNalog = IDNalog;
            if (IDNalog.HasValue)
            {
                this.IDNalog = IDNalog.Value;
            }
        }

        private void PutniNalog_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            FillComboBoxes();
            if (_IDNalog.HasValue)
            {
                lblNalogID.Text = $"Putni nalog br: {IDNalog}";
                try
                {
                    setTime(dtpOtvaranje);
                    setTime(dtpZatvaranje);
                    cbMjestoStart.SelectedValue = SqlHandler.GetMjestoStart(IDNalog)
                        == String.Empty ? "0"
                        : SqlHandler.GetMjestoStart(IDNalog);
                    cbMjestoCilj.SelectedValue = SqlHandler.GetMjestoCilj(IDNalog)
                        == String.Empty ? "0"
                        : SqlHandler.GetMjestoCilj(IDNalog);
                    cbVozac.SelectedValue = SqlHandler.GetVozacPN(IDNalog)
                        == String.Empty ? "0"
                        : SqlHandler.GetVozacPN(IDNalog);
                    cbVozilo.SelectedValue = SqlHandler.GetVoziloPN(IDNalog)
                        == String.Empty ? "0"
                        : SqlHandler.GetVoziloPN(IDNalog);
                    cbStatusNaloga.SelectedValue = SqlHandler.GetStatusNalogaPN(IDNalog)
                        == String.Empty ? "0"
                        : SqlHandler.GetStatusNalogaPN(IDNalog);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
            }
            else
            {
                lblNalogID.Text = $"Unesite novi putni nalog";
                dtpOtvaranje.Value = DateTime.Now;
                dtpZatvaranje.CustomFormat = " ";
            }
        }

        private void setTime(DateTimePicker dtpField)
        {
            string dateTimeTemp =String.Empty;
            try
            {
                dateTimeTemp = SqlHandler.GetTime(IDNalog, dtpField.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (dateTimeTemp == String.Empty)
            {
                dtpField.CustomFormat = "  ";
            }
            else
            {
                dtpField.CustomFormat = dateTimeTemp;
                dtpField.Value = DateTime.Parse(dateTimeTemp);
            }
        }

        private void FillComboBoxes()
        {
            DataTable dtGradoviStart = SqlHandler.GetGradoviCB();
            DataTable dtGradoviCilj = SqlHandler.GetGradoviCB();
            DataTable dtVozaci = SqlHandler.GetVozaciCB();
            DataTable dtVozila = SqlHandler.GetVozilaCB();
            DataTable dtNalogStatus = Utils.DataUtils.EnumToDataTable(typeof(PutniNalogStatus));
            FillComboBox(cbMjestoStart, dtGradoviStart);
            FillComboBox(cbMjestoCilj, dtGradoviCilj);
            FillComboBox(cbVozac, dtVozaci);
            FillComboBox(cbVozilo, dtVozila);
            FillComboBox(cbStatusNaloga, dtNalogStatus);
            cbVozac.Enabled = false;
            cbVozilo.Enabled = false;
        }

        private void FillComboBox(ComboBox comboBox, DataTable dataTable)
        {
            comboBox.ValueMember = dataTable.Columns[0].ToString();
            comboBox.DisplayMember = dataTable.Columns[1].ToString();
            if ( dataTable.Rows.Count==0 || dataTable.Rows[0].ItemArray[1].ToString() != headerTekst)
            {
                createHeader(dataTable);
            }
            comboBox.DataSource = dataTable;
        }

        private static void createHeader(DataTable dataTable)
        {
            DataRow headerItem = dataTable.NewRow();
            headerItem[0] = 0;
            headerItem[1] = headerTekst;
            dataTable.Rows.InsertAt(headerItem, 0);
        }

        private void dtpOtvaranje_ValueChanged(object sender, EventArgs e)
        {
            dtpOtvaranje.CustomFormat = dateTimeFormat;
        }   

        private void dtpZatvaranje_ValueChanged(object sender, EventArgs e)
        {
            dtpZatvaranje.CustomFormat = dateTimeFormat;
            DateTime dtO = String.IsNullOrWhiteSpace(dtpOtvaranje.Text) ? new DateTime() : DateTime.Parse(dtpOtvaranje.Text);
            DateTime dtZ = String.IsNullOrWhiteSpace(dtpZatvaranje.Text) ? new DateTime() : DateTime.Parse(dtpZatvaranje.Text);
            if (checkDateRange(dtO,dtZ))
            {
                DataTable dtVozaci = SqlHandler.GetVozaciFree(dtO,dtZ);
                DataTable dtVozila = SqlHandler.GetVozilaFree(dtO,dtZ);
                FillComboBox(cbVozac, dtVozaci);
                FillComboBox(cbVozilo, dtVozila);
                cbVozac.Enabled = true;
                cbVozilo.Enabled = true;
            }
            else
            {
                cbVozac.Enabled = false;
                cbVozilo.Enabled = false;
            }
        }

        private bool checkDateRange(DateTime dtO, DateTime dtZ)
        {
            if ((dtO == DateTime.Parse(emptyDate) || dtZ == DateTime.Parse(emptyDate)) || (dtZ < dtO))
                return false;
            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bntPotvrdi_Click(object sender, EventArgs e)
        {
            if (cbStatusNaloga.SelectedValue.ToString()=="0")
            {
                lblNalogID.Text = $"Obavezno ispuni status naloga!";
                lblNalogID.ForeColor = Color.Red;
                lblNalogID.Font = new Font(Font, FontStyle.Bold);
                return;
            }
            DateTime dtO = String.IsNullOrWhiteSpace(dtpOtvaranje.Text) ? new DateTime(): DateTime.Parse(dtpOtvaranje.Text);
            DateTime dtZ = String.IsNullOrWhiteSpace(dtpZatvaranje.Text) ? new DateTime() : DateTime.Parse(dtpZatvaranje.Text);
            if (dtZ == DateTime.Parse(emptyDate) ||dtZ>dtO)
            {
                PutniNalog putni = new PutniNalog(
                    _IDNalog.HasValue ? _IDNalog.Value : 0,
                    dtO,
                    dtZ,
                    new Vozac(int.Parse(cbVozac.SelectedValue.ToString())),
                    new Vozilo(int.Parse(cbVozilo.SelectedValue.ToString())),
                    new Grad(int.Parse(cbMjestoStart.SelectedValue.ToString())),
                    new Grad(int.Parse(cbMjestoCilj.SelectedValue.ToString())),
                    (PutniNalogStatus)int.Parse(cbStatusNaloga.SelectedValue.ToString())
                    );
                int result = 0;
                try
                {
                    result = SqlHandler.AddEditPN(putni);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    this.DialogResult = DialogResult.None;
                }
                if (result == 0)
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show("Nekaj ne valja nismo uspjeli upisati niš u bazu");
                }
                else
                {
                    this.Close();
                    pn.RefreshPN();
                }
            }
            else
            {
                MessageBox.Show("Ne može brate vrijeme zatvaranja biti manje od otvaranja!!");
                return;
            }

            
        }

        private void dtpZatvaranje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode==Keys.Back)
            {
                dtpZatvaranje.CustomFormat = " ";
            }
        }

        private void dtpOtvaranje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                dtpOtvaranje.CustomFormat = " ";
            }
        }
    }
}
