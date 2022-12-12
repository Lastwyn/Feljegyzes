using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Feljegyzes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string beolvasottszoveg = File.ReadAllText(filename);
                string[] adatok = beolvasottszoveg.Split(';');
                foreach (string szoveg in adatok)
                {
                richTextBox_szoveg.Text += Convert.ToString(szoveg)+"    - ";             
                }
                
            }
        }

        private void button_mentes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_nev.Text))
            {
                MessageBox.Show("Nem adott meg nevet");
                return;
            }
            if (string.IsNullOrEmpty(richTextBox_szoveg.Text))
            {
                MessageBox.Show("Nem adott meg szöveget");
                return;
            }
            saveFileDialog1.Filter = "Szöveg fájl(*.txt)| *.txt|Vesszővel tagolt szövegfájl (*.csv)| *.csv|Mindenfájl| *.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szoveg = string.Join(";", textBox_nev.Text, richTextBox_szoveg.Text, dateTimePicker_datum.Text);
                string filename = saveFileDialog1.FileName;
                File.AppendAllText(filename, szoveg+";\n");
                richTextBox_szoveg.Clear();
            }
            else
            {
                MessageBox.Show("Nincs kiválasztva!");
            }
        }
    }
}
