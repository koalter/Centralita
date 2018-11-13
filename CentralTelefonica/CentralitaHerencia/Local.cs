using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CentralitaHerencia
{
    public class Local : Llamada, IGuardar<Local>
    {
        protected float costo;

        public override float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }

        public string RutaDeArchivo
        {
            get
            {
                return "Locales.xml";
            }
            set
            {

            }
        }

        #region Metodos
        public Local() { }

        public Local(Llamada llamada, float costo) 
            : this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo) { }

        public Local(string origen, float duracion, string destino, float costo) 
            : base(duracion, destino, origen)
        {
            this.costo = costo;
        }

        private float CalcularCosto()
        {
            return this.Duracion * this.costo;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("COSTO DE LA LLAMADA: $" + this.CostoLlamada);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Local);
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public bool Guardar()
        {
            bool retorno;

            if (this != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Local));
                XmlTextWriter writer = new XmlTextWriter(this.RutaDeArchivo, Encoding.UTF8);

                serializer.Serialize(writer, this);
                writer.Close();

                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        public Local Leer()
        {
            Local llamada = new Local();
            XmlSerializer serializer = new XmlSerializer(typeof(Local));
            XmlTextReader reader = new XmlTextReader(this.RutaDeArchivo);
            try
            {
                llamada = (Local)serializer.Deserialize(reader);
                return llamada;
            }
            finally
            {
                reader.Close();
            }
        }
        #endregion
    }
}
