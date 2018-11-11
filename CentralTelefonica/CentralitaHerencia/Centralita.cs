using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        #region Propiedades
        public float GananciasPorLocal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Local);
            }
        }
        public float GananciasPorProvincial
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Provincial);
            }
        }
        public float GananciasPorTotal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Todas);
            }
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }
        #endregion

        #region Metodos
        public Centralita()
        {
            this.listaDeLlamadas = new List<Llamada>();
        }
        public Centralita(string nombreEmpresa) : this()
        {
            this.razonSocial = nombreEmpresa;
        }

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float valorDeLoRecaudado = 0;
            int length = this.Llamadas.Count;

            switch (tipo)
            {
                case Llamada.TipoLlamada.Local:
                    foreach (Llamada llamada in this.Llamadas)
                    {
                        if (llamada.GetType() == typeof(Local))
                        {
                            valorDeLoRecaudado += ((Local)llamada).CostoLlamada;
                        }
                    }
                    break;
                case Llamada.TipoLlamada.Provincial:
                    foreach (Llamada llamada in this.Llamadas)
                    {
                        if (llamada.GetType() == typeof(Provincial))
                        {
                            valorDeLoRecaudado += ((Provincial)llamada).CostoLlamada;
                        }
                    }
                    break;
                case Llamada.TipoLlamada.Todas:
                    valorDeLoRecaudado = this.CalcularGanancia(Llamada.TipoLlamada.Local) + this.CalcularGanancia(Llamada.TipoLlamada.Provincial);
                    break;
            }

            return valorDeLoRecaudado;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("RAZON SOCIAL: " + this.razonSocial);
            sb.AppendLine("GANANCIA TOTAL: $" + this.GananciasPorTotal);
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("GANANCIA LOCAL: $" + this.GananciasPorLocal);
            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine("GANANCIA PROVINCIAL: $" + this.GananciasPorProvincial);
            foreach (Llamada llamada in this.Llamadas)
            {
                sb.AppendLine("--------------------------------------------------");
                if (llamada.GetType() == typeof(Local))
                {
                    sb.AppendLine(((Local)llamada).Mostrar());
                }
                else if(llamada.GetType() == typeof(Provincial))
                {
                    sb.AppendLine(((Provincial)llamada).Mostrar());
                }
            }
            sb.AppendLine("**************************************************************************");

            return sb.ToString();
        }

        public void OrdenarLlamadas()
        {
            int length = this.Llamadas.Count;
            Llamada auxiliar;

            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i; j < length; j++)
                {
                    if (Llamada.OrdenarPorDuracion(this.Llamadas[i], this.Llamadas[j]) == 1)
                    {
                        auxiliar = this.Llamadas[i];
                        this.Llamadas[i] = this.Llamadas[j];
                        this.Llamadas[j] = auxiliar;
                    }
                }
            }
        }
        #endregion
    }
}
