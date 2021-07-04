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
    public partial class MngServis : Form
    {
        private int _IDServis =0;
        private int DOHVATI_SVE = 0;
        private decimal ukupnaCijena = 0;
        public MngServis(int? idServis)
        {
            InitializeComponent();
            RacunajCijenu(ukupnaCijena);
            if (idServis.HasValue)
            {
                _IDServis = idServis.Value;
                this.Text = $"Uredi servis";
                btnOK.Text = $"Uredi servis";

                try
                {
                    try
                    {
                        SERVISNA_KNJIGA servis = SqlHandler.GetServis(idServis.Value);
                        PuniTxtBoxove(servis);
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
            else
            {
                this.Text = $"Dodaj novi servis";
                btnOK.Text = $"Dodaj novi";
                PuniServisneStavke(DOHVATI_SVE,new SERVISNA_KNJIGA());
                _IDServis = 0;
            }
        }

        private void RacunajCijenu(decimal novaStavka)
        {
            ukupnaCijena += novaStavka;
            lblCijena.Text = $"{ukupnaCijena} kn";
        }

        private void PuniTxtBoxove(SERVISNA_KNJIGA servis)
        {
            dtpDate.Value = servis.Datum;
            lblCijena.Text = servis.Trosak.ToString();
            popuniStavkeNaServisu(servis);
            PuniServisneStavke(DOHVATI_SVE,servis);
        }
        
        private void popuniStavkeNaServisu(SERVISNA_KNJIGA servis)
        {
            List<SERVIS_STAVKE> stavke =  servis.SERVISI.Select(ss => ss.SERVIS_STAVKE).ToList();
            foreach (var stavka in stavke)
            {
                lbStavkeNaServisu.Items.Add(stavka);
                RacunajCijenu(stavka.Cijena);
            }

        }

        private void PuniServisneStavke(int stavka, SERVISNA_KNJIGA servisna_knjiga)
        {
            try
            {
                lbStavke.DataSource = SqlHandler.GetServisneStavke(DOHVATI_SVE);
                lbVozila.DataSource = SqlHandler.GetVozila(DOHVATI_SVE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (servisna_knjiga.VOZILA!=null)
            {
                int index = 0;
                string ime_auta = servisna_knjiga.VOZILA.ToString();
                foreach (var item in lbVozila.Items)
                {
                    if (item.ToString() == ime_auta)
                    {
                        lbVozila.SelectedIndex = index;
                    }
                    index++;
                }
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            DodajStavku();
        }

        private void DodajStavku()
        {
            if (lbStavke.SelectedIndex>=0)
            {
                SERVIS_STAVKE stavka = (SERVIS_STAVKE)lbStavke.SelectedItem;
                lbStavkeNaServisu.Items.Add(stavka);
                RacunajCijenu(stavka.Cijena);
            }
            else
            {
                MessageBox.Show("Nije izabrana stavka za prebacivanje");
            }
        }

        private void btnMakni_Click(object sender, EventArgs e)
        {
            if (lbStavkeNaServisu.SelectedIndex>=0)
            {
                SERVIS_STAVKE stavka = (SERVIS_STAVKE)lbStavkeNaServisu.SelectedItem;
                RacunajCijenu(-stavka.Cijena);
                lbStavkeNaServisu.Items.RemoveAt(lbStavkeNaServisu.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nije izabrana niti jedna stavka za micanje");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SERVISNA_KNJIGA servis = new SERVISNA_KNJIGA();
            servis.IDServis = _IDServis;
            servis.Datum = dtpDate.Value;
            servis.Trosak = ukupnaCijena;
            servis.VoziloID = ((VOZILA)lbVozila.SelectedItem).IDVozilo;
            servis.SERVISI= IzvuciStavkeServisa();
            try
            {
                SqlHandler.ManageServisa(servis);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<SERVISI> IzvuciStavkeServisa()
        {
            List<SERVISI> stavkeServisa = new List<SERVISI>();
            foreach (SERVIS_STAVKE item in lbStavkeNaServisu.Items)
            {
                SERVISI servisStavka = new SERVISI
                {
                    ServisID = _IDServis,
                    StavkaID = item.IDStavka
                };
                stavkeServisa.Add(servisStavka);
            }
            return stavkeServisa;
        }
    }
}
