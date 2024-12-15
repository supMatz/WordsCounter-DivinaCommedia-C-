namespace Divina_Commedia_Cerioni
{
    partial class FrmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
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
            this.btCaricaFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlInserimento = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbScansionamentoFile = new System.Windows.Forms.ProgressBar();
            this.nudLettereMin = new System.Windows.Forms.NumericUpDown();
            this.lblNumLettere = new System.Windows.Forms.Label();
            this.pnlOutput = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btSalva = new System.Windows.Forms.Button();
            this.lvParole = new System.Windows.Forms.ListView();
            this.chParola = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRipetizioni = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCantica = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlInserimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLettereMin)).BeginInit();
            this.pnlOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCaricaFile
            // 
            this.btCaricaFile.Location = new System.Drawing.Point(105, 40);
            this.btCaricaFile.Name = "btCaricaFile";
            this.btCaricaFile.Size = new System.Drawing.Size(75, 23);
            this.btCaricaFile.TabIndex = 0;
            this.btCaricaFile.Text = "Carica";
            this.btCaricaFile.UseVisualStyleBackColor = true;
            this.btCaricaFile.Click += new System.EventHandler(this.btCaricaFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inserisci un File txt :";
            // 
            // pnlInserimento
            // 
            this.pnlInserimento.Controls.Add(this.label3);
            this.pnlInserimento.Controls.Add(this.pbScansionamentoFile);
            this.pnlInserimento.Controls.Add(this.nudLettereMin);
            this.pnlInserimento.Controls.Add(this.lblNumLettere);
            this.pnlInserimento.Controls.Add(this.btCaricaFile);
            this.pnlInserimento.Controls.Add(this.label1);
            this.pnlInserimento.Location = new System.Drawing.Point(12, 12);
            this.pnlInserimento.Name = "pnlInserimento";
            this.pnlInserimento.Size = new System.Drawing.Size(636, 98);
            this.pnlInserimento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Creazione classifica :";
            // 
            // pbScansionamentoFile
            // 
            this.pbScansionamentoFile.Location = new System.Drawing.Point(112, 69);
            this.pbScansionamentoFile.Name = "pbScansionamentoFile";
            this.pbScansionamentoFile.Size = new System.Drawing.Size(275, 23);
            this.pbScansionamentoFile.TabIndex = 4;
            // 
            // nudLettereMin
            // 
            this.nudLettereMin.Location = new System.Drawing.Point(146, 8);
            this.nudLettereMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLettereMin.Name = "nudLettereMin";
            this.nudLettereMin.Size = new System.Drawing.Size(33, 20);
            this.nudLettereMin.TabIndex = 3;
            this.nudLettereMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblNumLettere
            // 
            this.lblNumLettere.AutoSize = true;
            this.lblNumLettere.Location = new System.Drawing.Point(5, 10);
            this.lblNumLettere.Name = "lblNumLettere";
            this.lblNumLettere.Size = new System.Drawing.Size(135, 13);
            this.lblNumLettere.TabIndex = 2;
            this.lblNumLettere.Text = "Minimo lettere delle parole :";
            // 
            // pnlOutput
            // 
            this.pnlOutput.Controls.Add(this.label2);
            this.pnlOutput.Controls.Add(this.btSalva);
            this.pnlOutput.Controls.Add(this.lvParole);
            this.pnlOutput.Location = new System.Drawing.Point(12, 116);
            this.pnlOutput.Name = "pnlOutput";
            this.pnlOutput.Size = new System.Drawing.Size(636, 264);
            this.pnlOutput.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-1, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Parole più usate nel file";
            // 
            // btSalva
            // 
            this.btSalva.Enabled = false;
            this.btSalva.Location = new System.Drawing.Point(520, 34);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(109, 26);
            this.btSalva.TabIndex = 1;
            this.btSalva.Text = "Salva classifica";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // lvParole
            // 
            this.lvParole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvParole.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chParola,
            this.chRipetizioni,
            this.chCantica});
            this.lvParole.FullRowSelect = true;
            this.lvParole.HideSelection = false;
            this.lvParole.Location = new System.Drawing.Point(0, 34);
            this.lvParole.Name = "lvParole";
            this.lvParole.Size = new System.Drawing.Size(514, 211);
            this.lvParole.TabIndex = 0;
            this.lvParole.UseCompatibleStateImageBehavior = false;
            this.lvParole.View = System.Windows.Forms.View.Details;
            // 
            // chParola
            // 
            this.chParola.Text = "Parola";
            this.chParola.Width = 114;
            // 
            // chRipetizioni
            // 
            this.chRipetizioni.Text = "Ripetizioni";
            this.chRipetizioni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chRipetizioni.Width = 134;
            // 
            // chCantica
            // 
            this.chCantica.Text = "Cantica";
            this.chCantica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chCantica.Width = 160;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(660, 383);
            this.Controls.Add(this.pnlOutput);
            this.Controls.Add(this.pnlInserimento);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.pnlInserimento.ResumeLayout(false);
            this.pnlInserimento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLettereMin)).EndInit();
            this.pnlOutput.ResumeLayout(false);
            this.pnlOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCaricaFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlInserimento;
        private System.Windows.Forms.Panel pnlOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.ListView lvParole;
        private System.Windows.Forms.NumericUpDown nudLettereMin;
        private System.Windows.Forms.Label lblNumLettere;
        private System.Windows.Forms.ColumnHeader chParola;
        private System.Windows.Forms.ColumnHeader chRipetizioni;
        private System.Windows.Forms.ColumnHeader chCantica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar pbScansionamentoFile;
    }
}

