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
    public partial class FrmMostrar : Form
    {
        Centralita c;
        TipoLlamada tipoLlamada;

        public Centralita Factura
        {
            set
            {
                StringBuilder sb = new StringBuilder();
                switch (this.tipoLlamada)
                {
                    case TipoLlamada.Local:
                        sb.AppendLine("GANANCIA LOCAL: $" + value.GananciasPorLocal);
                        foreach (Llamada ll in value.Llamadas)
                        {
                            if (ll.GetType() == typeof(Local))
                            {
                                sb.AppendLine("--------------------------------------------------");
                                sb.AppendLine(((Local)ll).ToString());
                            }
                        }
                        break;
                    case TipoLlamada.Provincial:
                        sb.AppendLine("GANANCIA PROVINCIAL: $" + value.GananciasPorProvincial);
                        foreach (Llamada ll in value.Llamadas)
                        {
                            if (ll.GetType() == typeof(Provincial))
                            {
                                sb.AppendLine("--------------------------------------------------");
                                sb.AppendLine(((Provincial)ll).ToString());
                            }
                        }
                        break;
                    case TipoLlamada.Todas:
                        sb.AppendLine(value.ToString());
                        break;
                }

                rtbFactura.Text = sb.ToString();
            }
        }

        public FrmMostrar(Centralita c, TipoLlamada tipoLlamada)
        {
            InitializeComponent();

            this.tipoLlamada = tipoLlamada;
            this.c = c;
        }

        private void FrmMostrar_Load(object sender, EventArgs e)
        {
            this.Factura = this.c;
        }
    }
}
