﻿using Models;
using PPPK_Proj.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPPK_Proj
{
    public partial class PutniNalozi : Form
    {
        private DateTimePicker dtp;
        private Rectangle rectangle;
        private int filterChoice = 0;
        private const string headerTekst = "--BIRAJ--";
        private const string filterItem = "SVI";
        private const string dateTimeFormat = "dd/MM/yyy HH:mm";
        public PutniNalozi()
        {
            InitializeComponent();
            DateTimePickerInit();
        }
        private void PutniNalozi_Load(object sender, EventArgs e)
        {

            FillGrid();
            FillFilter();
        }

        private void FillGrid()
        {
            FillComboBoxes();
            try
            {
                DataTable dtPN = SqlHandler.GetPutniNalozi(filterChoice);
                foreach (DataRow drow in dtPN.Rows)
                {
                    dgPutniNalozi.Rows.Add(drow.ItemArray);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillComboBoxes()
        {
            DataTable dtNalogStatus = Utils.DataUtils.EnumToDataTable(typeof(PutniNalogStatus));
            FillComboBox(cbStatus, dtNalogStatus);
        }
        private void FillComboBox(DataGridViewComboBoxColumn comboBox, DataTable dataTable)
        {
            comboBox.ValueMember = dataTable.Columns[0].ToString();
            comboBox.DisplayMember = dataTable.Columns[1].ToString();
            if (dataTable.Rows[0].ItemArray[1].ToString() != headerTekst)
            {
                DataRow headerItem = dataTable.NewRow();
                headerItem[0] = 0;
                headerItem[1] = headerTekst;
                dataTable.Rows.InsertAt(headerItem, 0);
            }
            comboBox.DataSource = dataTable;
        }

        private void FillFilter()
        {
            DataTable dtl = Utils.DataUtils.EnumToDataTable(typeof(PutniNalogStatus), filterItem);
            cbStatusNaloga.DataSource = dtl;
            cbStatusNaloga.DisplayMember = dtl.Columns[1].ToString();
            cbStatusNaloga.ValueMember = dtl.Columns[0].ToString();
        }
        private void DateTimePickerInit()
        {
            dtp = new DateTimePicker();
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.ShowUpDown = true;
            dtp.CustomFormat = dateTimeFormat;
            dtp.TextChanged += new EventHandler(Dtp_TextChanged);
            dgPutniNalozi.Controls.Add(dtp);
        }

        private void DateTimePickerDisplay(DataGridViewCellEventArgs e)
        {
            rectangle = dgPutniNalozi.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            dtp.Size = new Size(rectangle.Width, rectangle.Height);
            dtp.Location = new Point(rectangle.X, rectangle.Y);
            dtp.Visible = true;
        }
        private void Dtp_TextChanged(object sender, EventArgs e)
        {
            dgPutniNalozi.CurrentCell.Value = dtp.Text.ToString();
        }

        private void cbStatusNaloga_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterChoice = cbStatusNaloga.SelectedIndex;
            Rifresh();
        }

        private void btnAddPN_Click(object sender, EventArgs e)
        {
            PutniNalogForm pn = new PutniNalogForm(this,null);
            pn.Show();
        }

        private void btnObrisiNalog_Click(object sender, EventArgs e)
        {
            List<int> selektaniPutniNalozi = new List<int>();
            DialogResult potvrda = DialogResult.Cancel;
            foreach (DataGridViewRow row in dgPutniNalozi.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[8].Value);
                if (isSelected == true)
                {
                    selektaniPutniNalozi.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
            }
            if (selektaniPutniNalozi.Any())
            {
                potvrda = MessageBox.Show($"Želiš li obristai odabrane naloge?"
                , "POTVRDI BRISANJE"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"Nisi odabrao niti jedan nalog");
            }
            if (potvrda == DialogResult.OK)
            {
                try
                {
                    if (SqlHandler.DelPutniNalog(selektaniPutniNalozi) > 0)
                    {
                        Rifresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Rifresh()
        {
            dgPutniNalozi.Rows.Clear();
            FillGrid();
        }

        private void dgPutniNalozi_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            List<int> selektaniPutniNalozi = new List<int>();
            DialogResult potvrda = DialogResult.Cancel;
            foreach (DataGridViewRow row in dgPutniNalozi.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells[8].Value);
                if (isSelected == true)
                {
                    selektaniPutniNalozi.Add(int.Parse(row.Cells[0].Value.ToString()));
                }
            }
            if (selektaniPutniNalozi.Count ==1)
            {
                PutniNalogForm pn = new PutniNalogForm(this, selektaniPutniNalozi.First());
                pn.Show();
            }
            else if (selektaniPutniNalozi.Count > 1)
            {
                potvrda = MessageBox.Show($"Želiš li urediti odabrane naloge?"
                , "POTVRDI UREDJIVANJE"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Warning);
                if (potvrda == DialogResult.OK)
                {
                    foreach (int item in selektaniPutniNalozi)
                    {
                        PutniNalogForm pn = new PutniNalogForm(this, item);
                        pn.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Nisi odabrao niti jedan nalog");
            }
            
        }
        public void RefreshPN()
        {
            Rifresh();
        }
        private void dgPutniNalozi_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string value1 = e.CellValue1 != null ? e.CellValue1.ToString() : string.Empty;
            string value2 = e.CellValue2 != null ? e.CellValue2.ToString() : string.Empty;

            e.SortResult = String.Compare(value1, value2);
            e.Handled = true;
        }
    }
}
