namespace ABC_Analyse
{
    partial class Stringeingabe
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
            this.button_Eingabe = new System.Windows.Forms.Button();
            this.label_Thema = new System.Windows.Forms.Label();
            this.textBox_Eingabe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Eingabe
            // 
            this.button_Eingabe.Location = new System.Drawing.Point(15, 94);
            this.button_Eingabe.Name = "button_Eingabe";
            this.button_Eingabe.Size = new System.Drawing.Size(190, 23);
            this.button_Eingabe.TabIndex = 0;
            this.button_Eingabe.Text = "Bestätigen";
            this.button_Eingabe.UseVisualStyleBackColor = true;
            this.button_Eingabe.Click += new System.EventHandler(this.button_Eingabe_Click);
            // 
            // label_Thema
            // 
            this.label_Thema.Location = new System.Drawing.Point(15, 9);
            this.label_Thema.Name = "label_Thema";
            this.label_Thema.Size = new System.Drawing.Size(190, 56);
            this.label_Thema.TabIndex = 1;
            this.label_Thema.Text = "Wie soll die Datei heißen?";
            // 
            // textBox_Eingabe
            // 
            this.textBox_Eingabe.Location = new System.Drawing.Point(15, 68);
            this.textBox_Eingabe.Name = "textBox_Eingabe";
            this.textBox_Eingabe.Size = new System.Drawing.Size(190, 20);
            this.textBox_Eingabe.TabIndex = 2;
            // 
            // Stringeingabe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 129);
            this.Controls.Add(this.textBox_Eingabe);
            this.Controls.Add(this.label_Thema);
            this.Controls.Add(this.button_Eingabe);
            this.Name = "Stringeingabe";
            this.Text = "Stringeingabe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Eingabe;
        private System.Windows.Forms.TextBox textBox_Eingabe;
        public System.Windows.Forms.Label label_Thema;
    }
}