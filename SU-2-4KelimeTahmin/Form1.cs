using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU_2_4KelimeTahmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string kelimem,gizli;
        amantur m = new amantur();

        int sayac;
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (sayac<3)
            {
                if (textBox1.Text != "")
                {
                    char harfim = Convert.ToChar(textBox1.Text);
                    textBox1.Clear();
                    gizli = m.dene(harfim, kelimem, gizli);
                    label1.Text = gizli;
                    if (kelimem == gizli)
                        MessageBox.Show("Bildiniz");
                }
                sayac++;
            }
            else
            {
                MessageBox.Show("20 hakkınız bitti");
                textBox1.Enabled = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tahmin = textBox2.Text;
            if (kelimem == tahmin)
            {
                label1.Text = tahmin;
                MessageBox.Show("Bildiniz");
                textBox2.Clear();
                textBox1.Enabled = false;
            }
            else
            { 
                MessageBox.Show("Yanlış");
                textBox2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           DialogResult secim= MessageBox.Show("Emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secim==DialogResult.Yes) Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "KELİME TAHMİN-MaNaS-V1.0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sayac = 0;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            bool secim;
            if (checkBox1.Checked == true)
                secim = true;
            else
                secim = false;
            kelimem=m.kelime_getir(secim);
            kelimem = kelimem.Trim();//boşlukları karakterlerini temizledik
            gizli=m.kelime_gizle(kelimem);
            label1.Text = gizli;//bastığımız kelimeyi labela gönderdik
        }
    }
}
