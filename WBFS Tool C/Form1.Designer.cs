namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BTApriUnità = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBNGiochi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBGBTotali = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBGBUsati = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBGBLiberi = new System.Windows.Forms.TextBox();
            this.RTBGiochi = new System.Windows.Forms.RichTextBox();
            this.BTSave = new System.Windows.Forms.Button();
            this.BTCheatDL = new System.Windows.Forms.Button();
            this.FBCheat = new System.Windows.Forms.FolderBrowserDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BTCoverDL = new System.Windows.Forms.Button();
            this.FBCover = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officialPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RBIta = new System.Windows.Forms.RadioButton();
            this.RBEng = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CBDrives = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTApriUnità
            // 
            this.BTApriUnità.Location = new System.Drawing.Point(194, 134);
            this.BTApriUnità.Name = "BTApriUnità";
            this.BTApriUnità.Size = new System.Drawing.Size(77, 24);
            this.BTApriUnità.TabIndex = 0;
            this.BTApriUnità.Text = "Apri Unità";
            this.BTApriUnità.UseVisualStyleBackColor = true;
            this.BTApriUnità.Click += new System.EventHandler(this.BTApriUnità_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scegli la lettera di unità della tua partizione WBFS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(68, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Informazioni sulla partizione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(31, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "N° di giochi:";
            // 
            // TBNGiochi
            // 
            this.TBNGiochi.Location = new System.Drawing.Point(120, 201);
            this.TBNGiochi.Name = "TBNGiochi";
            this.TBNGiochi.Size = new System.Drawing.Size(127, 20);
            this.TBNGiochi.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(32, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "GB Totali";
            // 
            // TBGBTotali
            // 
            this.TBGBTotali.Location = new System.Drawing.Point(119, 227);
            this.TBGBTotali.Name = "TBGBTotali";
            this.TBGBTotali.Size = new System.Drawing.Size(128, 20);
            this.TBGBTotali.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(32, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "GB Usati";
            // 
            // TBGBUsati
            // 
            this.TBGBUsati.Location = new System.Drawing.Point(119, 280);
            this.TBGBUsati.Name = "TBGBUsati";
            this.TBGBUsati.Size = new System.Drawing.Size(127, 20);
            this.TBGBUsati.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(31, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "GB Liberi";
            // 
            // TBGBLiberi
            // 
            this.TBGBLiberi.Location = new System.Drawing.Point(119, 253);
            this.TBGBLiberi.Name = "TBGBLiberi";
            this.TBGBLiberi.Size = new System.Drawing.Size(126, 20);
            this.TBGBLiberi.TabIndex = 11;
            // 
            // RTBGiochi
            // 
            this.RTBGiochi.Location = new System.Drawing.Point(280, 137);
            this.RTBGiochi.Name = "RTBGiochi";
            this.RTBGiochi.ReadOnly = true;
            this.RTBGiochi.Size = new System.Drawing.Size(436, 177);
            this.RTBGiochi.TabIndex = 12;
            this.RTBGiochi.Text = "";
            // 
            // BTSave
            // 
            this.BTSave.Enabled = false;
            this.BTSave.Location = new System.Drawing.Point(294, 325);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(413, 34);
            this.BTSave.TabIndex = 13;
            this.BTSave.Text = "Salva lista giochi";
            this.BTSave.UseVisualStyleBackColor = true;
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // BTCheatDL
            // 
            this.BTCheatDL.Enabled = false;
            this.BTCheatDL.Location = new System.Drawing.Point(53, 319);
            this.BTCheatDL.Name = "BTCheatDL";
            this.BTCheatDL.Size = new System.Drawing.Size(173, 34);
            this.BTCheatDL.TabIndex = 14;
            this.BTCheatDL.Text = "Scarica Cheats";
            this.BTCheatDL.UseVisualStyleBackColor = true;
            this.BTCheatDL.Click += new System.EventHandler(this.BTCheatDL_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(408, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Elenco dei giochi presenti nella partizione:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(524, 380);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Coded by Zer0_byt3 for www.hackwii.it";
            // 
            // BTCoverDL
            // 
            this.BTCoverDL.Enabled = false;
            this.BTCoverDL.Location = new System.Drawing.Point(53, 359);
            this.BTCoverDL.Name = "BTCoverDL";
            this.BTCoverDL.Size = new System.Drawing.Size(172, 34);
            this.BTCoverDL.TabIndex = 15;
            this.BTCoverDL.Text = "Scarica Cover";
            this.BTCoverDL.UseVisualStyleBackColor = true;
            this.BTCoverDL.Click += new System.EventHandler(this.BTCoverDL_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.officialPageToolStripMenuItem,
            this.chiudiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // officialPageToolStripMenuItem
            // 
            this.officialPageToolStripMenuItem.Name = "officialPageToolStripMenuItem";
            this.officialPageToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.officialPageToolStripMenuItem.Text = "Official Website";
            this.officialPageToolStripMenuItem.Click += new System.EventHandler(this.officialPageToolStripMenuItem_Click);
            // 
            // chiudiToolStripMenuItem
            // 
            this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
            this.chiudiToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.chiudiToolStripMenuItem.Text = "Chiudi";
            this.chiudiToolStripMenuItem.Click += new System.EventHandler(this.chiudiToolStripMenuItem_Click);
            // 
            // RBIta
            // 
            this.RBIta.AutoSize = true;
            this.RBIta.BackColor = System.Drawing.Color.Transparent;
            this.RBIta.Location = new System.Drawing.Point(242, 376);
            this.RBIta.Name = "RBIta";
            this.RBIta.Size = new System.Drawing.Size(59, 17);
            this.RBIta.TabIndex = 17;
            this.RBIta.Text = "Italiano";
            this.RBIta.UseVisualStyleBackColor = false;
            // 
            // RBEng
            // 
            this.RBEng.AutoSize = true;
            this.RBEng.BackColor = System.Drawing.Color.Transparent;
            this.RBEng.Checked = true;
            this.RBEng.Location = new System.Drawing.Point(307, 376);
            this.RBEng.Name = "RBEng";
            this.RBEng.Size = new System.Drawing.Size(59, 17);
            this.RBEng.TabIndex = 18;
            this.RBEng.TabStop = true;
            this.RBEng.Text = "Inglese";
            this.RBEng.UseVisualStyleBackColor = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(164, 401);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 18);
            this.progressBar1.TabIndex = 19;
            // 
            // CBDrives
            // 
            this.CBDrives.FormattingEnabled = true;
            this.CBDrives.Location = new System.Drawing.Point(24, 134);
            this.CBDrives.Name = "CBDrives";
            this.CBDrives.Size = new System.Drawing.Size(140, 21);
            this.CBDrives.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(728, 431);
            this.Controls.Add(this.CBDrives);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RBEng);
            this.Controls.Add(this.RBIta);
            this.Controls.Add(this.BTCoverDL);
            this.Controls.Add(this.BTCheatDL);
            this.Controls.Add(this.BTSave);
            this.Controls.Add(this.RTBGiochi);
            this.Controls.Add(this.TBGBLiberi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TBGBUsati);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBGBTotali);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBNGiochi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTApriUnità);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "WBFS Tool BETA 2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTApriUnità;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBNGiochi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBGBTotali;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBGBUsati;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBGBLiberi;
        private System.Windows.Forms.RichTextBox RTBGiochi;
        private System.Windows.Forms.Button BTSave;
        private System.Windows.Forms.Button BTCheatDL;
        private System.Windows.Forms.FolderBrowserDialog FBCheat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BTCoverDL;
        private System.Windows.Forms.FolderBrowserDialog FBCover;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem officialPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiudiToolStripMenuItem;
        private System.Windows.Forms.RadioButton RBIta;
        private System.Windows.Forms.RadioButton RBEng;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox CBDrives;
    }
}

