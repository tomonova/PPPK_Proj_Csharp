namespace PPPK_Proj
{
    partial class PutniNalozi
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgPutniNalozi = new System.Windows.Forms.DataGridView();
            this.cbStatusNaloga = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPN = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnObrisiNalog = new System.Windows.Forms.Button();
            this.sqlHandlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txIDNalog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txOtvaranje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txZatvaranje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbVozac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbVozilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMjestoStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbMjestoCilj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPutniNalozi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlHandlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPutniNalozi
            // 
            this.dgPutniNalozi.AllowUserToAddRows = false;
            this.dgPutniNalozi.AllowUserToDeleteRows = false;
            this.dgPutniNalozi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPutniNalozi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPutniNalozi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txIDNalog,
            this.txOtvaranje,
            this.txZatvaranje,
            this.cbVozac,
            this.cbVozilo,
            this.cbMjestoStart,
            this.cbMjestoCilj,
            this.cbStatus,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPutniNalozi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPutniNalozi.Location = new System.Drawing.Point(16, 70);
            this.dgPutniNalozi.Name = "dgPutniNalozi";
            this.dgPutniNalozi.RowHeadersVisible = false;
            this.dgPutniNalozi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPutniNalozi.Size = new System.Drawing.Size(1319, 667);
            this.dgPutniNalozi.TabIndex = 0;
            this.dgPutniNalozi.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgPutniNalozi_DataError);
            this.dgPutniNalozi.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgPutniNalozi_Scroll);
            this.dgPutniNalozi.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgPutniNalozi_SortCompare);
            // 
            // cbStatusNaloga
            // 
            this.cbStatusNaloga.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbStatusNaloga.FormattingEnabled = true;
            this.cbStatusNaloga.Location = new System.Drawing.Point(118, 34);
            this.cbStatusNaloga.Name = "cbStatusNaloga";
            this.cbStatusNaloga.Size = new System.Drawing.Size(181, 24);
            this.cbStatusNaloga.TabIndex = 1;
            this.cbStatusNaloga.SelectedIndexChanged += new System.EventHandler(this.cbStatusNaloga_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status naloga:";
            // 
            // btnAddPN
            // 
            this.btnAddPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddPN.Location = new System.Drawing.Point(305, 29);
            this.btnAddPN.Name = "btnAddPN";
            this.btnAddPN.Size = new System.Drawing.Size(161, 32);
            this.btnAddPN.TabIndex = 3;
            this.btnAddPN.Text = "Novi Putni Nalog";
            this.btnAddPN.UseVisualStyleBackColor = true;
            this.btnAddPN.Click += new System.EventHandler(this.btnAddPN_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUredi.Location = new System.Drawing.Point(472, 29);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(161, 32);
            this.btnUredi.TabIndex = 4;
            this.btnUredi.Text = "Uredi Putni Nalog";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // btnObrisiNalog
            // 
            this.btnObrisiNalog.BackColor = System.Drawing.Color.Red;
            this.btnObrisiNalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnObrisiNalog.ForeColor = System.Drawing.Color.White;
            this.btnObrisiNalog.Location = new System.Drawing.Point(1170, 29);
            this.btnObrisiNalog.Name = "btnObrisiNalog";
            this.btnObrisiNalog.Size = new System.Drawing.Size(161, 32);
            this.btnObrisiNalog.TabIndex = 5;
            this.btnObrisiNalog.Text = "Obrisi Putni Nalog";
            this.btnObrisiNalog.UseVisualStyleBackColor = false;
            this.btnObrisiNalog.Click += new System.EventHandler(this.btnObrisiNalog_Click);
            // 
            // sqlHandlerBindingSource
            // 
            this.sqlHandlerBindingSource.DataSource = typeof(PPPK_Proj.DAO.SqlHandler);
            // 
            // txIDNalog
            // 
            this.txIDNalog.DataPropertyName = "IDNalog";
            this.txIDNalog.HeaderText = "IDNalog";
            this.txIDNalog.Name = "txIDNalog";
            this.txIDNalog.ReadOnly = true;
            this.txIDNalog.Visible = false;
            // 
            // txOtvaranje
            // 
            this.txOtvaranje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txOtvaranje.DataPropertyName = "OtvaranjeNaloga";
            dataGridViewCellStyle1.Format = "yyyy/MM/dd HH:mm";
            dataGridViewCellStyle1.NullValue = null;
            this.txOtvaranje.DefaultCellStyle = dataGridViewCellStyle1;
            this.txOtvaranje.FillWeight = 90.2379F;
            this.txOtvaranje.HeaderText = "Otvaranje";
            this.txOtvaranje.Name = "txOtvaranje";
            this.txOtvaranje.ReadOnly = true;
            // 
            // txZatvaranje
            // 
            this.txZatvaranje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txZatvaranje.DataPropertyName = "ZatvaranjeNaloga";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd HH:mm";
            dataGridViewCellStyle2.NullValue = null;
            this.txZatvaranje.DefaultCellStyle = dataGridViewCellStyle2;
            this.txZatvaranje.FillWeight = 90.2379F;
            this.txZatvaranje.HeaderText = "Zatvaranje";
            this.txZatvaranje.Name = "txZatvaranje";
            this.txZatvaranje.ReadOnly = true;
            // 
            // cbVozac
            // 
            this.cbVozac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbVozac.DataPropertyName = "Vozac";
            this.cbVozac.FillWeight = 90.2379F;
            this.cbVozac.HeaderText = "Vozac";
            this.cbVozac.Name = "cbVozac";
            this.cbVozac.ReadOnly = true;
            this.cbVozac.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cbVozilo
            // 
            this.cbVozilo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbVozilo.DataPropertyName = "Vozilo";
            this.cbVozilo.FillWeight = 90.2379F;
            this.cbVozilo.HeaderText = "Vozilo";
            this.cbVozilo.Name = "cbVozilo";
            this.cbVozilo.ReadOnly = true;
            this.cbVozilo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cbMjestoStart
            // 
            this.cbMjestoStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbMjestoStart.DataPropertyName = "MjestoStart";
            this.cbMjestoStart.FillWeight = 90.2379F;
            this.cbMjestoStart.HeaderText = "Mjesto start";
            this.cbMjestoStart.Name = "cbMjestoStart";
            this.cbMjestoStart.ReadOnly = true;
            this.cbMjestoStart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cbMjestoCilj
            // 
            this.cbMjestoCilj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbMjestoCilj.DataPropertyName = "MjestoCilj";
            this.cbMjestoCilj.FillWeight = 90.2379F;
            this.cbMjestoCilj.HeaderText = "Mjesto cilj";
            this.cbMjestoCilj.Name = "cbMjestoCilj";
            this.cbMjestoCilj.ReadOnly = true;
            this.cbMjestoCilj.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cbStatus.DataPropertyName = "StatusNaloga";
            this.cbStatus.FillWeight = 90.2379F;
            this.cbStatus.HeaderText = "Status Naloga";
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.ReadOnly = true;
            this.cbStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.FillWeight = 91.81183F;
            this.Column1.HeaderText = "Odaberi";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // PutniNalozi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 749);
            this.Controls.Add(this.btnObrisiNalog);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.btnAddPN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStatusNaloga);
            this.Controls.Add(this.dgPutniNalozi);
            this.Name = "PutniNalozi";
            this.Text = "Putni Nalozi";
            this.Load += new System.EventHandler(this.PutniNalozi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPutniNalozi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sqlHandlerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPutniNalozi;
        private System.Windows.Forms.BindingSource sqlHandlerBindingSource;
        private System.Windows.Forms.ComboBox cbStatusNaloga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddPN;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnObrisiNalog;
        private System.Windows.Forms.DataGridViewTextBoxColumn txIDNalog;
        private System.Windows.Forms.DataGridViewTextBoxColumn txOtvaranje;
        private System.Windows.Forms.DataGridViewTextBoxColumn txZatvaranje;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbVozac;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbVozilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbMjestoStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cbMjestoCilj;
        private System.Windows.Forms.DataGridViewComboBoxColumn cbStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}