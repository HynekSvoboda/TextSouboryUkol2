using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TextSouboryUkol2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            label3.Visible = true;
            label1.Visible = true;
            StreamReader cteni = new StreamReader("knihy.txt",Encoding.GetEncoding("windows-1250"));
            StreamWriter zapis1 = new StreamWriter("soubor1.txt", true, Encoding.GetEncoding("windows-1250"));
            StreamWriter zapis2 = new StreamWriter("soubor2.txt", true, Encoding.GetEncoding("windows-1250"));
            string hledac = textBox1.Text;
            bool prvni = true;
            try
            {
                while (!cteni.EndOfStream)
                {
                    string radek = cteni.ReadLine();
                    if (radek != "")
                    {
                        listBox1.Items.Add(radek);
                        string[] rozdeleni = radek.Split(';');
                        if (rozdeleni[1] == hledac && prvni)
                        {
                            label1.Text = radek;
                            prvni = false;
                        }
                        if (int.Parse(rozdeleni[4]) > 1950) zapis1.WriteLine(radek);
                        else zapis2.WriteLine(radek);
                    }
                }
                cteni.Close();
                zapis1.Close();
                zapis2.Close();
            }
            catch
            {
                MessageBox.Show("Něco se nepovedlo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Je dán textový soubor knihy.txt, kde na každém řádku je Název;Autor;Umístění;Žánr;Datum. Každý údaj je oddělen středníkem. Soubor zobraz do ListBoxu. Rozdělte soubor na dva textové soubory. V 1. souboru budou knihy mladší než rok 1950 a ve 2. souboru knihy starší. Do TextBoxu zadejte jméno autora a zobrazte informace o první jeho knížce zapsané v původním souboru.", "INFO", MessageBoxButtons.OK);
        }
    }
}
