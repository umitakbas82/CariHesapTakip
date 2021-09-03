using System;
using System.Data;
using System.Windows.Forms;

namespace CariHesapTakip
{
    public partial class Form1 : Form
    {
        DbHelper helper = new DbHelper();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            helper.VTBaglantiAc();
            
            string tarih = textBox1.Text;
            string aciklama = textBox2.Text;
            string tip = comboBox1.Text;
            double borcalacak = Convert.ToDouble(textBox4.Text);

            bool ba = false;

            if (radioButton1.Checked == true)
            {
                ba = true;
            }
            else if (radioButton2.Checked == true)
            {
                ba = false;
            }

            string sql = "";

            if (ba == true)
            {
                sql = "INSERT INTO BA(TARIH,ACIKLAMA,TIP,BORC,ALACAK) VALUES('" +
                tarih + "','" +
                aciklama + "','" +
                tip + "','" +
                borcalacak + "','0')";

            }
            else
            {
                sql = "INSERT INTO BA(TARIH,ACIKLAMA,TIP,BORC,ALACAK) VALUES('" +
                tarih + "','" +
                aciklama + "','" +
                tip + "','" +
                "0','" + borcalacak + "')";
            }


            helper.VeriGonder(sql);

            helper.VTBaglantiKapat();

            button2.PerformClick();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            helper.VTBaglantiAc();


            string sql = "SELECT * FROM BA ORDER BY ID DESC";


            DataTable dt =  helper.VeriGetir(sql);

            dataGridView1.DataSource = dt;

            helper.VTBaglantiKapat();

            
        }
        
        private void TextBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
