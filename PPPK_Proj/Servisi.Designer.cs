
namespace PPPK_Proj
{
    partial class Servisi
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
            this.lbServisi = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbStavke = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDatum = new System.Windows.Forms.TextBox();
            this.tbVozilo = new System.Windows.Forms.TextBox();
            this.tbCijena = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbServisi
            // 
            this.lbServisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbServisi.FormattingEnabled = true;
            this.lbServisi.ItemHeight = 15;
            this.lbServisi.Location = new System.Drawing.Point(12, 12);
            this.lbServisi.Name = "lbServisi";
            this.lbServisi.Size = new System.Drawing.Size(285, 424);
            this.lbServisi.TabIndex = 0;
            this.lbServisi.SelectedIndexChanged += new System.EventHandler(this.lbServisi_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(324, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(324, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vozilo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(324, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stavke servisa:";
            // 
            // lbStavke
            // 
            this.lbStavke.FormattingEnabled = true;
            this.lbStavke.Location = new System.Drawing.Point(327, 159);
            this.lbStavke.Name = "lbStavke";
            this.lbStavke.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbStavke.Size = new System.Drawing.Size(250, 277);
            this.lbStavke.Sorted = true;
            this.lbStavke.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(324, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cijena:";
            // 
            // tbDatum
            // 
            this.tbDatum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbDatum.Location = new System.Drawing.Point(392, 26);
            this.tbDatum.Name = "tbDatum";
            this.tbDatum.ReadOnly = true;
            this.tbDatum.Size = new System.Drawing.Size(185, 22);
            this.tbDatum.TabIndex = 8;
            // 
            // tbVozilo
            // 
            this.tbVozilo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbVozilo.Location = new System.Drawing.Point(392, 63);
            this.tbVozilo.Name = "tbVozilo";
            this.tbVozilo.ReadOnly = true;
            this.tbVozilo.Size = new System.Drawing.Size(185, 22);
            this.tbVozilo.TabIndex = 9;
            // 
            // tbCijena
            // 
            this.tbCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbCijena.Location = new System.Drawing.Point(392, 104);
            this.tbCijena.Name = "tbCijena";
            this.tbCijena.ReadOnly = true;
            this.tbCijena.Size = new System.Drawing.Size(185, 22);
            this.tbCijena.TabIndex = 10;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNew.Location = new System.Drawing.Point(12, 458);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(151, 49);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "NOVI SERVIS";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUpdate.Location = new System.Drawing.Point(169, 458);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(151, 49);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "UREDI SERVIS";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(426, 458);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(151, 49);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "OBRIŠI SERVIS";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Servisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 519);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.tbCijena);
            this.Controls.Add(this.tbVozilo);
            this.Controls.Add(this.tbDatum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbStavke);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbServisi);
            this.Name = "Servisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servisi";
            this.Load += new System.EventHandler(this.Servisi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbServisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbStavke;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDatum;
        private System.Windows.Forms.TextBox tbVozilo;
        private System.Windows.Forms.TextBox tbCijena;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}