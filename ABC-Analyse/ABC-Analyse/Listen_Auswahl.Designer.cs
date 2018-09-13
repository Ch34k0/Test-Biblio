namespace ABC_Analyse
{
    partial class Listen_Auswahl
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
            this.button_Nothing = new System.Windows.Forms.Button();
            this.button_All = new System.Windows.Forms.Button();
            this.button_Waehlen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_Datei = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button_Nothing
            // 
            this.button_Nothing.Location = new System.Drawing.Point(196, 81);
            this.button_Nothing.Name = "button_Nothing";
            this.button_Nothing.Size = new System.Drawing.Size(75, 42);
            this.button_Nothing.TabIndex = 9;
            this.button_Nothing.Text = "Alles abwählen";
            this.button_Nothing.UseVisualStyleBackColor = true;
            // 
            // button_All
            // 
            this.button_All.Location = new System.Drawing.Point(196, 28);
            this.button_All.Name = "button_All";
            this.button_All.Size = new System.Drawing.Size(75, 42);
            this.button_All.TabIndex = 8;
            this.button_All.Text = "Alles auswählen";
            this.button_All.UseVisualStyleBackColor = true;
            // 
            // button_Waehlen
            // 
            this.button_Waehlen.Location = new System.Drawing.Point(11, 129);
            this.button_Waehlen.Name = "button_Waehlen";
            this.button_Waehlen.Size = new System.Drawing.Size(260, 23);
            this.button_Waehlen.TabIndex = 7;
            this.button_Waehlen.Text = "Datei wählen";
            this.button_Waehlen.UseVisualStyleBackColor = true;
            this.button_Waehlen.Click += new System.EventHandler(this.button_Waehlen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wählen Sie eine Datei!";
            // 
            // listBox_Datei
            // 
            this.listBox_Datei.FormattingEnabled = true;
            this.listBox_Datei.Location = new System.Drawing.Point(11, 28);
            this.listBox_Datei.Name = "listBox_Datei";
            this.listBox_Datei.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Datei.Size = new System.Drawing.Size(182, 95);
            this.listBox_Datei.TabIndex = 5;
            // 
            // Listen_Auswahl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 157);
            this.Controls.Add(this.button_Nothing);
            this.Controls.Add(this.button_All);
            this.Controls.Add(this.button_Waehlen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Datei);
            this.Name = "Listen_Auswahl";
            this.Text = "Listen_Auswahl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Nothing;
        private System.Windows.Forms.Button button_All;
        private System.Windows.Forms.Button button_Waehlen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Datei;
    }
}