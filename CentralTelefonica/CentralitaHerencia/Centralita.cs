﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public string RutaDeArchivo
        {
            get
            {
                return "log.txt";
            }  
            set
            {

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
                if (c.Guardar() == false)
                {
                    throw new FallaLogException("No se pudieron guardar todos los datos.");
                }
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
            bool retorno;

            if (this != null && this.Llamadas.Count > 0)
            {
                StreamWriter sw = new StreamWriter(this.RutaDeArchivo);

                foreach (Llamada llamada in this.Llamadas)
                {
                    sw.WriteLine(DateTime.Now.ToString("dddd dd \\de MMMM \\de yyyy hh:mm") + " - Se realizó una llamada");
                }
                
                sw.Close();
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public string Leer()
        {
            string retorno = String.Empty;

            if (File.Exists(this.RutaDeArchivo))
            {
                StreamReader sw = new StreamReader(this.RutaDeArchivo);
                retorno = sw.ReadToEnd();
                sw.Close();
            }
            return retorno;
        }
        #endregion
    }
}
