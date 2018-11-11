﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CentralitaHerencia;

namespace Formulario
{
    public partial class FrmLlamador : Form
    {
        Centralita c;

        public FrmLlamador(Centralita c)
        {
            InitializeComponent();
            this.c = c;

            // Carga
            cmbFranja.DataSource = Enum.GetValues(typeof(Franja));
            // Lectura
            Franja franjas;
            Enum.TryParse<Franja>(cmbFranja.SelectedValue.ToString(), out franjas);
        }

        public Centralita Central
        {
            get
            {
                return this.c;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "*";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text += "#";
        }

        private void btnLlamar_Click(object sender, EventArgs e)
        {
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNroDestino.Text = String.Empty;
        }

        private void txtNroDestino_TextChanged(object sender, EventArgs e)
        {
            cmbFranja.Enabled = txtNroDestino.Text.StartsWith("#");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
