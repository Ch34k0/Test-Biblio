namespace ABC_Analyse
{
    partial class Klassen_Toleranz
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
            this.button_Use = new System.Windows.Forms.Button();
            this.label_C = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.label_A = new System.Windows.Forms.Label();
            this.numeric_AB = new System.Windows.Forms.NumericUpDown();
            this.numeric_BC = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_AB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_BC)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Use
            // 
            this.button_Use.Location = new System.Drawing.Point(12, 114);
            this.button_Use.Name = "button_Use";
            this.button_Use.Size = new System.Drawing.Size(181, 23);
            this.button_Use.TabIndex = 0;
            this.button_Use.Text = "Übernehmen";
            this.button_Use.UseVisualStyleBackColor = true;
            this.button_Use.Click += new System.EventHandler(this.button_Use_Click);
            // 
            // label_C
            // 
            this.label_C.Location = new System.Drawing.Point(12, 92);
            this.label_C.Name = "label_C";
            this.label_C.Size = new System.Drawing.Size(75, 19);
            this.label_C.TabIndex = 16;
            this.label_C.Text = "C: ";
            // 
            // label_B
            // 
            this.label_B.Location = new System.Drawing.Point(12, 73);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(75, 19);
            this.label_B.TabIndex = 15;
            this.label_B.Text = "B: ";
            // 
            // label_A
            // 
            this.label_A.Location = new System.Drawing.Point(12, 54);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(75, 19);
            this.label_A.TabIndex = 14;
            this.label_A.Text = "A: ";
            // 
            // numeric_AB
            // 
            this.numeric_AB.Location = new System.Drawing.Point(93, 55);
            this.numeric_AB.Name = "numeric_AB";
            this.numeric_AB.Size = new System.Drawing.Size(100, 20);
            this.numeric_AB.TabIndex = 17;
            this.numeric_AB.ValueChanged += new System.EventHandler(this.numeric_AB_ValueChanged);
            this.numeric_AB.Leave += new System.EventHandler(this.numeric_AB_Leave);
            // 
            // numeric_BC
            // 
            this.numeric_BC.Location = new System.Drawing.Point(93, 81);
            this.numeric_BC.Name = "numeric_BC";
            this.numeric_BC.Size = new System.Drawing.Size(100, 20);
            this.numeric_BC.TabIndex = 18;
            this.numeric_BC.ValueChanged += new System.EventHandler(this.numeric_BC_ValueChanged);
            this.numeric_BC.Leave += new System.EventHandler(this.numeric_BC_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Bestimmen Sie die Toleranz!";
            // 
            // Klassen_Toleranz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeric_BC);
            this.Controls.Add(this.numeric_AB);
            this.Controls.Add(this.label_C);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.label_A);
            this.Controls.Add(this.button_Use);
            this.Name = "Klassen_Toleranz";
            this.Text = "Klassen_Toleranz";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_AB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_BC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Use;
        private System.Windows.Forms.Label label_C;
        private System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.NumericUpDown numeric_AB;
        private System.Windows.Forms.NumericUpDown numeric_BC;
        private System.Windows.Forms.Label label1;
    }
}