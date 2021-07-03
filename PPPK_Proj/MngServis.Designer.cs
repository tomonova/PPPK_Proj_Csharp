
namespace PPPK_Proj
{
    partial class MngServis
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStavke = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lbStavkeNaServisu = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnMakni = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCijena = new System.Windows.Forms.Label();
            this.lbVozila = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vozilo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stavke:";
            // 
            // lbStavke
            // 
            this.lbStavke.FormattingEnabled = true;
            this.lbStavke.Location = new System.Drawing.Point(446, 13);
            this.lbStavke.Name = "lbStavke";
            this.lbStavke.ScrollAlwaysVisible = true;
            this.lbStavke.Size = new System.Drawing.Size(217, 524);
            this.lbStavke.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(16, 550);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 48);
            this.btnOK.TabIndex = 6;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(523, 550);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Zaboravi";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(125, 13);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 8;
            // 
            // lbStavkeNaServisu
            // 
            this.lbStavkeNaServisu.FormattingEnabled = true;
            this.lbStavkeNaServisu.Location = new System.Drawing.Point(125, 111);
            this.lbStavkeNaServisu.Name = "lbStavkeNaServisu";
            this.lbStavkeNaServisu.Size = new System.Drawing.Size(200, 342);
            this.lbStavkeNaServisu.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stavke servisa:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(331, 158);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(109, 23);
            this.btnDodaj.TabIndex = 11;
            this.btnDodaj.Text = "Dodaj Stavku";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnMakni
            // 
            this.btnMakni.Location = new System.Drawing.Point(331, 216);
            this.btnMakni.Name = "btnMakni";
            this.btnMakni.Size = new System.Drawing.Size(109, 23);
            this.btnMakni.TabIndex = 12;
            this.btnMakni.Text = "Makni Stavku";
            this.btnMakni.UseVisualStyleBackColor = true;
            this.btnMakni.Click += new System.EventHandler(this.btnMakni_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 487);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Cijena:";
            // 
            // lblCijena
            // 
            this.lblCijena.AutoSize = true;
            this.lblCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCijena.ForeColor = System.Drawing.Color.Blue;
            this.lblCijena.Location = new System.Drawing.Point(125, 482);
            this.lblCijena.Name = "lblCijena";
            this.lblCijena.Size = new System.Drawing.Size(0, 20);
            this.lblCijena.TabIndex = 14;
            // 
            // lbVozila
            // 
            this.lbVozila.FormattingEnabled = true;
            this.lbVozila.Location = new System.Drawing.Point(125, 61);
            this.lbVozila.Name = "lbVozila";
            this.lbVozila.Size = new System.Drawing.Size(200, 21);
            this.lbVozila.TabIndex = 15;
            // 
            // MngServis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 610);
            this.Controls.Add(this.lbVozila);
            this.Controls.Add(this.lblCijena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMakni);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.lbStavkeNaServisu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbStavke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MngServis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MngServis";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbStavke;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ListBox lbStavkeNaServisu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnMakni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCijena;
        private System.Windows.Forms.ComboBox lbVozila;
    }
}