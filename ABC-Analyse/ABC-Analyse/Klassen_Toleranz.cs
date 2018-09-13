using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Analyse
{
    public partial class Klassen_Toleranz : Form
    {
        public string Modus;
        public Klassen_Toleranz()
        {
            InitializeComponent();
        }

        public void Werte_geben(int min, int max) {
            numeric_AB.Value = min;
            numeric_BC.Value = max;
            Werte_aktuell(Modus);        
        }

        public void Werte_aktuell(string Mode) {
            if (Mode == "Menge") {
                numeric_AB.Minimum = 10;
                numeric_AB.Maximum = numeric_BC.Value - 1;
                numeric_BC.Minimum = numeric_AB.Value + 1;
                numeric_BC.Maximum = 95;
            }
            else {
                numeric_AB.Maximum = 95;
                numeric_AB.Minimum = numeric_BC.Value + 1;
                numeric_BC.Maximum = numeric_AB.Value - 1;
                numeric_BC.Minimum = 10;
            }
        }

        public void Werte_zeigen(string Mode) {
            if (Mode == "Menge")
            {
                label_A.Text = "A: 0 - " + numeric_AB.Value;
                label_B.Text = "B: " + numeric_AB.Value + " - " + numeric_BC.Value;
                label_C.Text = "C: " + numeric_BC.Value + " - 100";
            }
            else {
                label_A.Text = "A: " + numeric_AB.Value + " - 100";
                label_B.Text = "B: " + numeric_AB.Value + " - " + numeric_BC.Value;
                label_C.Text = "C: 0 - " + numeric_BC.Value;
            }
        }


        private void button_Use_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int AB_geben() {
            return (int)numeric_AB.Value;
        }
        public int BC_geben()
        {
            return (int)numeric_BC.Value;
        }

        private void numeric_AB_ValueChanged(object sender, EventArgs e)
        {
            Werte_zeigen(Modus);
        }

        private void numeric_BC_ValueChanged(object sender, EventArgs e)
        {
            Werte_zeigen(Modus);
        }

        private void numeric_BC_Leave(object sender, EventArgs e)
        {
            Werte_aktuell(Modus);
        }

        private void numeric_AB_Leave(object sender, EventArgs e)
        {
            Werte_aktuell(Modus);
        }
    }
}
