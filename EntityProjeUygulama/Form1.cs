using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using EntityProjeUygulama;  

namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = textBox2.Text;   
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori eklendi ","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var kt = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(kt);
            db.SaveChanges();
            MessageBox.Show("Kategori silnidi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var kt = db.TBLKATEGORI.Find(x);
            kt.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
