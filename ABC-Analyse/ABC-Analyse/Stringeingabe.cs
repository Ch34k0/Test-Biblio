using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Analyse
{
    public partial class Stringeingabe : Form
    {
        public Stringeingabe()
        {
            InitializeComponent();
        }

        private void button_Eingabe_Click(object sender, EventArgs e)
        {

            if (File.Exists(@"Dateien\" + Ausgabe() + ".pdf") && label_Thema.Text == "Bitte geben Sie ein, unter welchem Namen die Datei gespeichert werden soll.")
            {
                DialogResult r;
                r = MessageBox.Show("Diese Datei existiert bereits!" + Environment.NewLine + "Soll die Datei überschrieben werden?", "Doppelter Dateiname", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    textBox_Eingabe.Focus();
                }
            }
            else
            {
                this.Close();
            }
        }
        public string Ausgabe()
        {
            return textBox_Eingabe.Text;
        }
    }
}
