using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public abstract class Llamada
    {
        public enum TipoLlamada
        {
            Local,
            Provincial,
            Todas
        }

        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        #region Propiedades
        public abstract float CostoLlamada
        {
            get;
        }

        public float Duracion
        {
            get
            {
                return this.duracion;
            }
        }
        public string NroDestino
        {
            get
            {
                return this.nroDestino;
            }
        }
        public string NroOrigen
        {
            get
            {
                return this.nroOrigen;
            }
        }
        #endregion

        #region Metodos
        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }

        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DURACION: " + this.duracion);
            sb.AppendLine("NRO ORIGEN: " + this.nroOrigen);
            sb.AppendLine("NRO DESTINO: " + this.nroDestino);

            return sb.ToString();
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if (llamada1.duracion > llamada2.duracion)
            {
                return 1;
            }
            else
            {
                if (llamada1.duracion < llamada2.duracion)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static bool operator ==(Llamada llamada1, Llamada llamada2)
        {
            return llamada1.Equals(llamada2) 
                && llamada1.NroDestino == llamada2.NroDestino 
                && llamada1.NroOrigen == llamada2.NroOrigen;
        }
        public static bool operator !=(Llamada llamada1, Llamada llamada2)
        {
            return !(llamada1 == llamada2);
        }
        #endregion
    }
}
