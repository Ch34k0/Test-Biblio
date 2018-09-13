namespace ABC_Analyse
{
    partial class Datei_Auswahl
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
            this.listBox_Datei = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Waehlen = new System.Windows.Forms.Button();
            this.button_All = new System.Windows.Forms.Button();
            this.button_Nothing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_Datei
            // 
            this.listBox_Datei.FormattingEnabled = true;
            this.listBox_Datei.Location = new System.Drawing.Point(12, 31);
            this.listBox_Datei.Name = "listBox_Datei";
            this.listBox_Datei.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Datei.Size = new System.Drawing.Size(182, 95);
            this.listBox_Datei.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wählen Sie eine Datei!";
            // 
            // button_Waehlen
            // 
            this.button_Waehlen.Location = new System.Drawing.Point(12, 132);
            this.button_Waehlen.Name = "button_Waehlen";
            this.button_Waehlen.Size = new System.Drawing.Size(260, 23);
            this.button_Waehlen.TabIndex = 2;
            this.button_Waehlen.Text = "Datei wählen";
            this.button_Waehlen.UseVisualStyleBackColor = true;
            this.button_Waehlen.Click += new System.EventHandler(this.button_Waehlen_Click);
            // 
            // button_All
            // 
            this.button_All.Location = new System.Drawing.Point(197, 31);
            this.button_All.Name = "button_All";
            this.button_All.Size = new System.Drawing.Size(75, 42);
            this.button_All.TabIndex = 3;
            this.button_All.Text = "Alles auswählen";
            this.button_All.UseVisualStyleBackColor = true;
            this.button_All.Click += new System.EventHandler(this.button_All_Click);
            // 
            // button_Nothing
            // 
            this.button_Nothing.Location = new System.Drawing.Point(197, 84);
            this.button_Nothing.Name = "button_Nothing";
            this.button_Nothing.Size = new System.Drawing.Size(75, 42);
            this.button_Nothing.TabIndex = 4;
            this.button_Nothing.Text = "Alles abwählen";
            this.button_Nothing.UseVisualStyleBackColor = true;
            this.button_Nothing.Click += new System.EventHandler(this.button_Nothing_Click);
            // 
            // Datei_Auswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 163);
            this.Controls.Add(this.button_Nothing);
            this.Controls.Add(this.button_All);
            this.Controls.Add(this.button_Waehlen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Datei);
            this.Name = "Datei_Auswahl";
            this.Text = "Datei";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Datei;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Waehlen;
        private System.Windows.Forms.Button button_All;
        private System.Windows.Forms.Button button_Nothing;
    }
}