using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using itextsharp.pdfa.iTextSharp.text.pdf.intern;
using System.Runtime.InteropServices;


namespace ABC_Analyse
{
    public partial class Dokument : Form
    {
        public Dokument()
        {
            InitializeComponent();
        }





        public Paragraph Boden_Informationen(Document doc, string Prio, bool aenderung)
        {
            Range kopfinfo;
            kopfinfo = doc.Range(doc.Content.End - 1, doc.Content.End);
            kopfinfo.Font.Size = 12;
            kopfinfo.Font.Underline = WdUnderline.wdUnderlineNone;
            kopfinfo.Font.Spacing = 0;

            Paragraph kopf;
            kopf = doc.Content.Paragraphs.Add();
            kopf.Range.ListFormat.ApplyBulletDefault();
            kopf.Range.InsertBefore("Erstellt am " + Datum_ermitteln(DateTime.Today) + "\n");

            if (aenderung)
            {
                kopf.Range.InsertBefore("Priorisiert nach " + Prio + "\n");
                kopf.Range.InsertBefore("Daten wurden nachträglich verändert!");
            }
            else
            {
                kopf.Range.InsertBefore("Priorisiert nach " + Prio + "");
            }
            return kopf;
        }

        public string Datum_ermitteln(DateTime Heute)
        {
            string Datum = String.Empty;
            Datum += Heute.Day.ToString() + ".";
            Datum += Heute.Month.ToString() + ".";
            Datum += Heute.Year.ToString();
            return Datum;
        }

        public Table Haupt_Tabelle(Document doc, List<Artikel> Liste, DataGridView Tabelle)
        {
            Range tabellen_feld;
            tabellen_feld = doc.Range(doc.Content.End - 1, doc.Content.End);
            tabellen_feld.Font.Bold = 0;
            tabellen_feld.Font.Size = 12;
            tabellen_feld.Underline = WdUnderline.wdUnderlineNone;
            tabellen_feld.Font.Spacing = 0;

            Table tab;
            tab = doc.Tables.Add(tabellen_feld, Tabelle.RowCount, 7);
            tab.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            tab.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            tab.Cell(1, 1).Range.Text = "ID";
            tab.Cell(1, 2).Range.Text = "Bezeichnung";
            tab.Cell(1, 3).Range.Text = "Menge";
            tab.Cell(1, 4).Range.Text = "Menge in %";
            tab.Cell(1, 5).Range.Text = "Wert";
            tab.Cell(1, 6).Range.Text = "Wert in %";
            tab.Cell(1, 7).Range.Text = "Klasse";

            int a = 2;
            foreach (var item in Liste)
            {
                tab.Cell(a, 1).Range.Text = item.ID.ToString();
                tab.Cell(a, 2).Range.Text = item.Name.ToString();
                tab.Cell(a, 3).Range.Text = String.Format("{0:0}", item.Menge);
                tab.Cell(a, 4).Range.Text = String.Format("{0:0} %", item.Menge_Prozent);
                tab.Cell(a, 5).Range.Text = String.Format("{0:0,000.00} €", item.Wert_absolut);
                tab.Cell(a, 6).Range.Text = String.Format("{0:0} %", item.Wert_Prozent);
                tab.Cell(a, 7).Range.Text = item.Klasse.ToString();
                a++;
            }

            tab.Rows.SetHeight(15, WdRowHeightRule.wdRowHeightExactly);
            tab.Rows[1].SetHeight(25, WdRowHeightRule.wdRowHeightExactly);
            for (int i = 1; i < 8; i++)
            {
                tab.Cell(1, i).Range.Bold = 1;
                tab.Cell(1, i).Range.Font.Size = 14;
                tab.Columns[i].AutoFit();
            }

            return tab;
        }

        public Range Ueberschrift(Document doc, string Thema)
        {
            Range Ueberschrift;
            Ueberschrift = doc.Range(doc.Content.Start, doc.Content.Start + 1);
            Ueberschrift.Font.Size = 20;
            Ueberschrift.Underline = WdUnderline.wdUnderlineSingle;
            Ueberschrift.Font.Spacing = 0;
            if (Thema.Length != 0)
            {
                Ueberschrift.Text = "ABC-Analyse - " + Thema + "\n";
            }
            else
            {
                Ueberschrift.Text = "ABC-Analyse\n";
            }
            return Ueberschrift;
        }

        public void Dokument_erstellen(DataGridView Tabelle, string Prio, string Thema, string Dateiname, bool aenderung)
        {
            Dateigedoens(Tabelle, Prio, Thema, Dateiname, aenderung);
            Close();
        }

        public void Dateigedoens(DataGridView Tabelle, string Prio, string Thema, string Dateiname, bool aenderung)
        {
            Word.Application word;
            Document doc;
            Table haupt_tabelle;
            Paragraph boden_informationen;
            Range thematik;
            Object Fname;
            DirectoryInfo PDF;
            FileInfo wordF;
            List<Artikel> Liste;
            word = Arbeitsflaeche_vorbereiten();
            PDF = Ordnerinfo_geben();
            wordF = Bearbeitungsdatei_geben(PDF);
            Fname = Fname_geben(wordF);
            doc = Dokument_bearbeitbar_machen(Fname, word);
            doc.Activate();
            Liste = Listenlogik.Liste_nehmen(Tabelle);
            thematik = Ueberschrift(doc, Thema);
            haupt_tabelle = Haupt_Tabelle(doc, Liste, Tabelle);
            boden_informationen = Boden_Informationen(doc, Prio, aenderung);
            Zu_PDF_umwandeln(doc, wordF);
            Abspeichern(doc, word);
            Dateien_Formatieren(Dateiname);
            doc = null;
        }

        public static Word.Application Arbeitsflaeche_vorbereiten()
        {
            Word.Application word;
            word = new Word.Application();
            word.Visible = false;
            word.ScreenUpdating = false;
            //word.ActiveWindow.Visible = false;
            return word;
        }

        public static DirectoryInfo Ordnerinfo_geben()
        {
            return new DirectoryInfo(@"Dateien\");
        }

        public static FileInfo Bearbeitungsdatei_geben(DirectoryInfo PDF)
        {
            return PDF.GetFiles("Neu.docx")[0];
        }

        public static Document Dokument_bearbeitbar_machen(Object Fname, Word.Application word)
        {
            Document doc;
            object oMissing;
            oMissing = System.Reflection.Missing.Value;
            doc = word.Documents.Open(ref Fname,
ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            return doc;
        }

        public static Object Fname_geben(FileInfo wordF)
        {
            return (Object)wordF.FullName;
        }

        public static void Zu_PDF_umwandeln(Document doc, FileInfo wordF)
        {
            object Fnameout;
            object Fformat;
            object oMissing;
            oMissing = System.Reflection.Missing.Value;
            Fnameout = wordF.FullName.Replace(".docx", ".pdf");
            Fformat = WdSaveFormat.wdFormatPDF;
            doc.SaveAs(ref Fnameout, ref Fformat, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing,
        ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }

        public static void Abspeichern(Document doc, Word.Application word)
        {
            object Save;
            Save = WdSaveOptions.wdSaveChanges;
            ((_Document)doc).Close(ref Save);
            ((_Application)word).Quit();
        }

        public static void Dateien_Formatieren(string Dateiname)
        {
            if (File.Exists(@"Dateien\" + Dateiname + ".pdf"))
            {
                File.Delete(@"Dateien\" + Dateiname + ".pdf");
            }
            File.Copy(@"Dateien\Neu.pdf", @"Dateien\" + Dateiname + ".pdf");
            File.Delete(@"Dateien\Neu.pdf");
            File.Delete(@"Dateien\Neu.docx");
            File.Create(@"Dateien\Neu.docx");
        }

        public static void Dokument_zeigen(string[] Dateiname)
        {
            foreach (var item in Dateiname)
            {
                Process.Start(@"Dateien\" + item + "");
            }
        }

        public static void Dokument_drucken(string[] Dateiname)
        {
            DialogResult result = new PrintDialog().ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (var item in Dateiname)
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        Verb = "print",
                        FileName = @"Dateien\" + item + ""
                    };

                    p.Start();
                }
            }
        }

        public static void Dokument_loeschen(string[] Dateiname)
        {
            foreach (var item in Dateiname)
            {
                if (File.Exists(@"Dateien\" + item))
                {
                    try
                    {
                        File.Delete(@"Dateien\" + item);
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
