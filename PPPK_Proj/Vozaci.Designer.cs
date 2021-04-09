namespace PPPK_Proj
{
    partial class Vozaci
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbVozaci = new System.Windows.Forms.ListBox();
            this.btnUrediVozaca = new System.Windows.Forms.Button();
            this.btnNoviVozac = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbVozacka = new System.Windows.Forms.TextBox();
            this.tbMobitel = new System.Windows.Forms.TextBox();
            this.tbPrezime = new System.Windows.Forms.TextBox();
            this.tbIme = new System.Windows.Forms.TextBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.putniNaloziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.podaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brisanjeBazeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPodatakaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbVozaci
            // 
            this.lbVozaci.FormattingEnabled = true;
            this.lbVozaci.Location = new System.Drawing.Point(12, 36);
            this.lbVozaci.Name = "lbVozaci";
            this.lbVozaci.Size = new System.Drawing.Size(398, 225);
            this.lbVozaci.Sorted = true;
            this.lbVozaci.TabIndex = 0;
            this.lbVozaci.SelectedIndexChanged += new System.EventHandler(this.lbVozaci_SelectedIndexChanged);
            // 
            // btnUrediVozaca
            // 
            this.btnUrediVozaca.Location = new System.Drawing.Point(583, 267);
            this.btnUrediVozaca.Name = "btnUrediVozaca";
            this.btnUrediVozaca.Size = new System.Drawing.Size(128, 45);
            this.btnUrediVozaca.TabIndex = 1;
            this.btnUrediVozaca.Text = "Uredi Vozaca";
            this.btnUrediVozaca.UseVisualStyleBackColor = true;
            this.btnUrediVozaca.Click += new System.EventHandler(this.btnUrediVozaca_Click);
            // 
            // btnNoviVozac
            // 
            this.btnNoviVozac.Location = new System.Drawing.Point(12, 267);
            this.btnNoviVozac.Name = "btnNoviVozac";
            this.btnNoviVozac.Size = new System.Drawing.Size(128, 45);
            this.btnNoviVozac.TabIndex = 2;
            this.btnNoviVozac.Text = "Dodaj Vozaca";
            this.btnNoviVozac.UseVisualStyleBackColor = true;
            this.btnNoviVozac.Click += new System.EventHandler(this.btnNoviVozac_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(59, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prezime:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(65, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mobitel:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Vozacka dozvola:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbVozacka, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbMobitel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPrezime, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbIme, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(416, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(302, 169);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tbVozacka
            // 
            this.tbVozacka.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbVozacka.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbVozacka.Location = new System.Drawing.Point(128, 136);
            this.tbVozacka.Name = "tbVozacka";
            this.tbVozacka.ReadOnly = true;
            this.tbVozacka.Size = new System.Drawing.Size(167, 23);
            this.tbVozacka.TabIndex = 10;
            // 
            // tbMobitel
            // 
            this.tbMobitel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbMobitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMobitel.Location = new System.Drawing.Point(128, 93);
            this.tbMobitel.Name = "tbMobitel";
            this.tbMobitel.ReadOnly = true;
            this.tbMobitel.Size = new System.Drawing.Size(167, 23);
            this.tbMobitel.TabIndex = 9;
            // 
            // tbPrezime
            // 
            this.tbPrezime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbPrezime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPrezime.Location = new System.Drawing.Point(128, 51);
            this.tbPrezime.Name = "tbPrezime";
            this.tbPrezime.ReadOnly = true;
            this.tbPrezime.Size = new System.Drawing.Size(167, 23);
            this.tbPrezime.TabIndex = 8;
            // 
            // tbIme
            // 
            this.tbIme.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbIme.Location = new System.Drawing.Point(128, 9);
            this.tbIme.Name = "tbIme";
            this.tbIme.ReadOnly = true;
            this.tbIme.Size = new System.Drawing.Size(167, 23);
            this.tbIme.TabIndex = 7;
            // 
            // btnObrisi
            // 
            this.btnObrisi.BackColor = System.Drawing.Color.Red;
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnObrisi.ForeColor = System.Drawing.SystemColors.Window;
            this.btnObrisi.Location = new System.Drawing.Point(282, 267);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(128, 45);
            this.btnObrisi.TabIndex = 8;
            this.btnObrisi.Text = "Obrisi vozaca";
            this.btnObrisi.UseVisualStyleBackColor = false;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podaciToolStripMenuItem,
            this.putniNaloziToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // putniNaloziToolStripMenuItem
            // 
            this.putniNaloziToolStripMenuItem.Name = "putniNaloziToolStripMenuItem";
            this.putniNaloziToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.putniNaloziToolStripMenuItem.Text = "Putni nalozi";
            this.putniNaloziToolStripMenuItem.Click += new System.EventHandler(this.putniNaloziToolStripMenuItem_Click);
            // 
            // podaciToolStripMenuItem
            // 
            this.podaciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportPodatakaToolStripMenuItem,
            this.brisanjeBazeToolStripMenuItem,
            this.importPodatakaToolStripMenuItem});
            this.podaciToolStripMenuItem.Name = "podaciToolStripMenuItem";
            this.podaciToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.podaciToolStripMenuItem.Text = "Podaci";
            // 
            // exportPodatakaToolStripMenuItem
            // 
            this.exportPodatakaToolStripMenuItem.Name = "exportPodatakaToolStripMenuItem";
            this.exportPodatakaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportPodatakaToolStripMenuItem.Text = "Export podataka";
            this.exportPodatakaToolStripMenuItem.Click += new System.EventHandler(this.exportPodatakaToolStripMenuItem_Click);
            // 
            // brisanjeBazeToolStripMenuItem
            // 
            this.brisanjeBazeToolStripMenuItem.Name = "brisanjeBazeToolStripMenuItem";
            this.brisanjeBazeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brisanjeBazeToolStripMenuItem.Text = "Brisanje Podataka";
            this.brisanjeBazeToolStripMenuItem.Click += new System.EventHandler(this.brisanjeBazeToolStripMenuItem_Click);
            // 
            // importPodatakaToolStripMenuItem
            // 
            this.importPodatakaToolStripMenuItem.Name = "importPodatakaToolStripMenuItem";
            this.importPodatakaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importPodatakaToolStripMenuItem.Text = "Import Podataka";
            this.importPodatakaToolStripMenuItem.Click += new System.EventHandler(this.importPodatakaToolStripMenuItem_Click);
            // 
            // Vozaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 322);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnNoviVozac);
            this.Controls.Add(this.btnUrediVozaca);
            this.Controls.Add(this.lbVozaci);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Vozaci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vozaci";
            this.Load += new System.EventHandler(this.Vozaci_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbVozaci;
        private System.Windows.Forms.Button btnUrediVozaca;
        private System.Windows.Forms.Button btnNoviVozac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbVozacka;
        private System.Windows.Forms.TextBox tbMobitel;
        private System.Windows.Forms.TextBox tbPrezime;
        private System.Windows.Forms.TextBox tbIme;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem putniNaloziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPodatakaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brisanjeBazeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPodatakaToolStripMenuItem;
    }
}