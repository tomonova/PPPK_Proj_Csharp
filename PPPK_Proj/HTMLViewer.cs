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
    public partial class HTMLViewer : Form
    {
        private SERVISNA_KNJIGA servis;
        private string servisHTML;

        public HTMLViewer(SERVISNA_KNJIGA servis)
        {
            this.servis = servis;
            InitializeComponent();
        }

        private void HTMLViewer_Load(object sender, EventArgs e)
        {
            servisHTML= CreateHTML();
            wbServis.DocumentText = servisHTML;
        }

        private string CreateHTML()
        {
            List<SERVISI> stavkeServisa = SqlHandler.GetStavke(servis.IDServis);
            StringBuilder sb = new StringBuilder();
            sb.Append($"<!DOCTYPE html>");
            sb.Append($"<html>");
            sb.Append($"<head>");
            sb.Append($"<style>");
            sb.Append("table, th, td {border: 1px solid black;}");
            sb.Append("th, td {padding: 5px;}");
            sb.Append("td, th {text-align: left;}");
            sb.Append($"</style>");
            sb.Append($"</head>");
            sb.AppendLine($@"<h2>Servis za vozilo {servis.VOZILA} na datum {servis.Datum.ToString("dd/MM/yyyy")}</h2>");
            sb.AppendLine($"<p> Ukupna cijena servisa: <b>{servis.Trosak}</b></p>");
            sb.AppendLine($"<lr><lr><lr>");
            sb.AppendLine($"<table style='width: 100 % '>");
            sb.AppendLine($"<tr>");
            sb.AppendLine($"<th>Stavka servisa</th>");
            sb.AppendLine($"<th>Cijena pojedinačne stavke</th>");
            sb.AppendLine($"</tr>");
            foreach (var item in stavkeServisa)
            {
                sb.AppendLine($"<tr>");
                sb.AppendLine($"<td>{item.SERVIS_STAVKE.Naziv}</td>");
                sb.AppendLine($"<td>{item.SERVIS_STAVKE.Cijena} kn</td>");
                sb.AppendLine($"</tr>");
            }
            sb.AppendLine($"</table>");
            sb.Append($"</html>");
            return sb.ToString();
        }
    }
}
