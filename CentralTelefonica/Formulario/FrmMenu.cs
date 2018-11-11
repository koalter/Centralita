using System;
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
    public partial class FrmMenu : Form
    {
        public Centralita c;

        public FrmMenu()
        {
            InitializeComponent();
            c = new Centralita();
        }

        private void btnGenerarLlamada_Click(object sender, EventArgs e)
        {
            FrmLlamador llamador = new FrmLlamador(c);
            llamador.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            FrmMostrar todas = new FrmMostrar(c, TipoLlamada.Todas);
            todas.ShowDialog();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            FrmMostrar locales = new FrmMostrar(c, TipoLlamada.Local);
            locales.ShowDialog();
        }

        private void btnProvincial_Click(object sender, EventArgs e)
        {
            FrmMostrar provinciales = new FrmMostrar(c, TipoLlamada.Provincial);
            provinciales.ShowDialog();
        }
    }
}
