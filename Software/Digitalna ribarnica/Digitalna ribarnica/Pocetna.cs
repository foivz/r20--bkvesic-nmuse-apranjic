﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digitalna_ribarnica
{
    public partial class formPocetna : Form
    {


        
        public formPocetna()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formPocetna pocetna = new formPocetna();
            this.Hide();
            Prijava prijava = new Prijava();
            prijava.ShowDialog();
            pocetna.ShowDialog();
        }
    }
}
