namespace ABC_Analyse
{
    partial class ABC_Analyse
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tabelle = new System.Windows.Forms.DataGridView();
            this.button_Laden = new System.Windows.Forms.Button();
            this.button_Berechnen = new System.Windows.Forms.Button();
            this.button_Look = new System.Windows.Forms.Button();
            this.button_Print = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Menge_Klasse = new System.Windows.Forms.Button();
            this.label_MA = new System.Windows.Forms.Label();
            this.label_MB = new System.Windows.Forms.Label();
            this.label_MC = new System.Windows.Forms.Label();
            this.label_WC = new System.Windows.Forms.Label();
            this.label_WB = new System.Windows.Forms.Label();
            this.label_WA = new System.Windows.Forms.Label();
            this.button_Wert_Klasse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radio_Menge = new System.Windows.Forms.RadioButton();
            this.radio_Wert = new System.Windows.Forms.RadioButton();
            this.button_empty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Tabelle)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabelle
            // 
            this.Tabelle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabelle.Location = new System.Drawing.Point(174, 12);
            this.Tabelle.Name = "Tabelle";
            this.Tabelle.RowHeadersVisible = false;
            this.Tabelle.Size = new System.Drawing.Size(913, 287);
            this.Tabelle.TabIndex = 0;
            this.Tabelle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tabelle_CellValueChanged);
            // 
            // button_Laden
            // 
            this.button_Laden.Location = new System.Drawing.Point(12, 12);
            this.button_Laden.Name = "button_Laden";
            this.button_Laden.Size = new System.Drawing.Size(156, 23);
            this.button_Laden.TabIndex = 1;
            this.button_Laden.Text = "Liste laden";
            this.button_Laden.UseVisualStyleBackColor = true;
            this.button_Laden.Click += new System.EventHandler(this.button_Laden_Click);
            // 
            // button_Berechnen
            // 
            this.button_Berechnen.Location = new System.Drawing.Point(12, 41);
            this.button_Berechnen.Name = "button_Berechnen";
            this.button_Berechnen.Size = new System.Drawing.Size(156, 23);
            this.button_Berechnen.TabIndex = 2;
            this.button_Berechnen.Text = "Berechnen";
            this.button_Berechnen.UseVisualStyleBackColor = true;
            this.button_Berechnen.Click += new System.EventHandler(this.button_Berechnen_Click);
            // 
            // button_Look
            // 
            this.button_Look.Location = new System.Drawing.Point(12, 99);
            this.button_Look.Name = "button_Look";
            this.button_Look.Size = new System.Drawing.Size(75, 23);
            this.button_Look.TabIndex = 3;
            this.button_Look.Text = "Vorschau";
            this.button_Look.UseVisualStyleBackColor = true;
            this.button_Look.Click += new System.EventHandler(this.button_Look_Click);
            // 
            // button_Print
            // 
            this.button_Print.Location = new System.Drawing.Point(93, 99);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(75, 23);
            this.button_Print.TabIndex = 4;
            this.button_Print.Text = "Drucken";
            this.button_Print.UseVisualStyleBackColor = true;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(12, 70);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(156, 23);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Datei speichern";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Menge_Klasse
            // 
            this.button_Menge_Klasse.Location = new System.Drawing.Point(9, 216);
            this.button_Menge_Klasse.Name = "button_Menge_Klasse";
            this.button_Menge_Klasse.Size = new System.Drawing.Size(78, 23);
            this.button_Menge_Klasse.TabIndex = 6;
            this.button_Menge_Klasse.Text = "Menge";
            this.button_Menge_Klasse.UseVisualStyleBackColor = true;
            this.button_Menge_Klasse.Click += new System.EventHandler(this.button_Menge_Klasse_Click);
            // 
            // label_MA
            // 
            this.label_MA.Location = new System.Drawing.Point(9, 242);
            this.label_MA.Name = "label_MA";
            this.label_MA.Size = new System.Drawing.Size(75, 19);
            this.label_MA.TabIndex = 7;
            this.label_MA.Text = "A: ";
            // 
            // label_MB
            // 
            this.label_MB.Location = new System.Drawing.Point(9, 261);
            this.label_MB.Name = "label_MB";
            this.label_MB.Size = new System.Drawing.Size(75, 19);
            this.label_MB.TabIndex = 8;
            this.label_MB.Text = "B: ";
            // 
            // label_MC
            // 
            this.label_MC.Location = new System.Drawing.Point(9, 280);
            this.label_MC.Name = "label_MC";
            this.label_MC.Size = new System.Drawing.Size(75, 19);
            this.label_MC.TabIndex = 9;
            this.label_MC.Text = "C: ";
            // 
            // label_WC
            // 
            this.label_WC.Location = new System.Drawing.Point(93, 280);
            this.label_WC.Name = "label_WC";
            this.label_WC.Size = new System.Drawing.Size(75, 19);
            this.label_WC.TabIndex = 13;
            this.label_WC.Text = "C: ";
            // 
            // label_WB
            // 
            this.label_WB.Location = new System.Drawing.Point(93, 261);
            this.label_WB.Name = "label_WB";
            this.label_WB.Size = new System.Drawing.Size(75, 19);
            this.label_WB.TabIndex = 12;
            this.label_WB.Text = "B: ";
            // 
            // label_WA
            // 
            this.label_WA.Location = new System.Drawing.Point(93, 242);
            this.label_WA.Name = "label_WA";
            this.label_WA.Size = new System.Drawing.Size(75, 19);
            this.label_WA.TabIndex = 11;
            this.label_WA.Text = "A: ";
            // 
            // button_Wert_Klasse
            // 
            this.button_Wert_Klasse.Location = new System.Drawing.Point(93, 216);
            this.button_Wert_Klasse.Name = "button_Wert_Klasse";
            this.button_Wert_Klasse.Size = new System.Drawing.Size(75, 23);
            this.button_Wert_Klasse.TabIndex = 10;
            this.button_Wert_Klasse.Text = "Wert";
            this.button_Wert_Klasse.UseVisualStyleBackColor = true;
            this.button_Wert_Klasse.Click += new System.EventHandler(this.button_Wert_Klasse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Priorisieren nach:";
            // 
            // radio_Menge
            // 
            this.radio_Menge.AutoSize = true;
            this.radio_Menge.Checked = true;
            this.radio_Menge.Location = new System.Drawing.Point(12, 170);
            this.radio_Menge.Name = "radio_Menge";
            this.radio_Menge.Size = new System.Drawing.Size(58, 17);
            this.radio_Menge.TabIndex = 15;
            this.radio_Menge.TabStop = true;
            this.radio_Menge.Text = "Menge";
            this.radio_Menge.UseVisualStyleBackColor = true;
            // 
            // radio_Wert
            // 
            this.radio_Wert.AutoSize = true;
            this.radio_Wert.Location = new System.Drawing.Point(12, 193);
            this.radio_Wert.Name = "radio_Wert";
            this.radio_Wert.Size = new System.Drawing.Size(48, 17);
            this.radio_Wert.TabIndex = 16;
            this.radio_Wert.Text = "Wert";
            this.radio_Wert.UseVisualStyleBackColor = true;
            // 
            // button_empty
            // 
            this.button_empty.Location = new System.Drawing.Point(12, 128);
            this.button_empty.Name = "button_empty";
            this.button_empty.Size = new System.Drawing.Size(156, 23);
            this.button_empty.TabIndex = 17;
            this.button_empty.Text = "Ordner leeren";
            this.button_empty.UseVisualStyleBackColor = true;
            this.button_empty.Click += new System.EventHandler(this.button_empty_Click);
            // 
            // ABC_Analyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 307);
            this.Controls.Add(this.button_empty);
            this.Controls.Add(this.radio_Wert);
            this.Controls.Add(this.radio_Menge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_WC);
            this.Controls.Add(this.label_WB);
            this.Controls.Add(this.label_WA);
            this.Controls.Add(this.button_Wert_Klasse);
            this.Controls.Add(this.label_MC);
            this.Controls.Add(this.label_MB);
            this.Controls.Add(this.label_MA);
            this.Controls.Add(this.button_Menge_Klasse);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Print);
            this.Controls.Add(this.button_Look);
            this.Controls.Add(this.button_Berechnen);
            this.Controls.Add(this.button_Laden);
            this.Controls.Add(this.Tabelle);
            this.Name = "ABC_Analyse";
            this.Text = "ABC-Analyse";
            this.Load += new System.EventHandler(this.ABC_Analyse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tabelle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Tabelle;
        private System.Windows.Forms.Button button_Laden;
        private System.Windows.Forms.Button button_Berechnen;
        private System.Windows.Forms.Button button_Look;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Menge_Klasse;
        private System.Windows.Forms.Label label_MA;
        private System.Windows.Forms.Label label_MB;
        private System.Windows.Forms.Label label_MC;
        private System.Windows.Forms.Label label_WC;
        private System.Windows.Forms.Label label_WB;
        private System.Windows.Forms.Label label_WA;
        private System.Windows.Forms.Button button_Wert_Klasse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_Menge;
        private System.Windows.Forms.RadioButton radio_Wert;
        private System.Windows.Forms.Button button_empty;
    }
}

