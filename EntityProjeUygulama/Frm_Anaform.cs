﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frm_Anaform : Form
    {
        public Frm_Anaform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_Urun frm = new Frm_Urun();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_Istatistik fr = new Frm_Istatistik();
            fr.Show();
        }
    }
}
