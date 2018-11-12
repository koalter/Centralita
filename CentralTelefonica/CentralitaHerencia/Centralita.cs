using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita : IGuardar<string>
    {
        List<Llamada> listaDeLlamadas;
        protected string razonSocial;

        #region Propiedades
        public float GananciasPorLocal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Local);
            }
        }
        public float GananciasPorProvincial
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GananciasPorTotal
        {
            get
            {
                return this.CalcularGanancia(TipoLlamada.Todas);
            }
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }

        public string RutaDeArchivo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
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

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float valorDeLoRecaudado = 0;
            int length = this.Llamadas.Count;

            switch (tipo)
            {
                case TipoLlamada.Local:
                    foreach (Llamada llamada in this.Llamadas)
                    {
                        if (llamada.GetType() == typeof(Local))
                        {
                            valorDeLoRecaudado += ((Local)llamada).CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Provincial:
                    foreach (Llamada llamada in this.Llamadas)
                    {
                        if (llamada.GetType() == typeof(Provincial))
                        {
                            valorDeLoRecaudado += ((Provincial)llamada).CostoLlamada;
                        }
                    }
                    break;
                case TipoLlamada.Todas:
                    valorDeLoRecaudado = this.CalcularGanancia(TipoLlamada.Local) + this.CalcularGanancia(TipoLlamada.Provincial);
                    break;
            }

            return valorDeLoRecaudado;
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            if (this.razonSocial != String.Empty)
            {
                sb.AppendLine("RAZON SOCIAL: " + this.razonSocial);
            }
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
                    sb.AppendLine(((Local)llamada).ToString());
                }
                else if(llamada.GetType() == typeof(Provincial))
                {
                    sb.AppendLine(((Provincial)llamada).ToString());
                }
            }
            //sb.AppendLine("**************************************************************************");

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

        public override string ToString()
        {
            return this.Mostrar();
        }

        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.Llamadas.Add(nuevaLlamada);
        }

        public static bool operator ==(Centralita c, Llamada llamada)
        {
            foreach (Llamada item in c.Llamadas)
            {
                if (llamada == item)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Centralita c, Llamada llamada)
        {
            return !(c == llamada);
        }

        public static Centralita operator +(Centralita c, Llamada nuevaLlamada)
        {
            if (c != nuevaLlamada)
            {
                c.AgregarLlamada(nuevaLlamada);
                return c;
            }
            else
            {
                string clase = nameof(nuevaLlamada);
                string metodo = String.Format("public static Centralita operator +({0}, {1})", nameof(c), clase);
                throw new CentralitaException("La llamada ya se encuentra registrada en el sistema \n", clase, metodo);
            }
        }


        public bool Guardar()
        {
            this.ToString();

            return true;
        }

        public string Leer()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
