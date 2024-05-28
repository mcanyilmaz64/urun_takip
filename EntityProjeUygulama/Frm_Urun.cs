using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityProjeUygulama
{
    public partial class Frm_Urun : Form
    {
        public Frm_Urun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,
                                            x.DURUM

                                        }).ToList();
        }

        private void BtnkEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = Convert.ToInt16(TxtStok.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.DURUM = true;
            t.KATEGORI = Convert.ToInt16(CmbKategori.Text);

            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            int x = int.Parse(Txtid.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Txtid.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = TxtUrunAd.Text;
            urun.DURUM = true;
            urun.MARKA = TxtMarka.Text;
            urun.STOK = Convert.ToInt16(TxtStok.Text);
            urun.KATEGORI = Convert.ToInt16(CmbKategori.Text);
            urun.FIYAT = decimal.Parse(TxtFiyat.Text);

            db.SaveChanges();
            MessageBox.Show("Urun Güncellendi ", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            Txtid.Text = row.Cells[0].Value.ToString();
            TxtUrunAd.Text = row.Cells[1].Value.ToString();
            TxtMarka.Text = row.Cells[2].Value.ToString();
            TxtStok.Text = row.Cells[3].Value.ToString();
            TxtFiyat.Text = row.Cells[4].Value.ToString();
            TxtDurum.Text = row.Cells[5].Value.ToString();
            CmbKategori.Text = row.Cells[6].Value.ToString();
        }

        private void Frm_Urun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,

                                   x.AD
                               }
                              ).ToList();

            CmbKategori.ValueMember = "ID ";
            CmbKategori.DisplayMember = "AD";
            CmbKategori.DataSource = kategoriler;
        }
    }
}
