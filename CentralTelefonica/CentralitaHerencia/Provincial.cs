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
    public enum Franja
    {
        Franja_1,
        Franja_2,
        Franja_3
    }

    public class Provincial : Llamada, IGuardar<Provincial>
    {

        protected Franja franjaHoraria;

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
                return "Provinciales.xml";
            }
            set
            {

            }
        }

        #region Metodos
        public Provincial() { }

        public Provincial(Franja miFranja, Llamada llamada) 
            : this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino) { }

        public Provincial(string origen, Franja miFranja, float duracion, string destino) 
            : base(duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }

        private float CalcularCosto()
        {
            float costo = 0;
            switch (this.franjaHoraria)
            {
                case Franja.Franja_1:
                    costo = 0.99F;
                    break;
                case Franja.Franja_2:
                    costo = 1.25F;
                    break;
                case Franja.Franja_3:
                    costo = 0.66F;
                    break;
            }

            return this.Duracion * costo;
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine("FRANJA HORARIA: " + this.franjaHoraria);
            sb.AppendLine("COSTO DE LA LLAMADA: $" + this.CostoLlamada);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Provincial);
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
                XmlSerializer serializer = new XmlSerializer(typeof(Provincial));
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

        public Provincial Leer()
        {
            Provincial llamada = new Provincial();
            XmlSerializer serializer = new XmlSerializer(typeof(Provincial));
            XmlTextReader reader = new XmlTextReader(this.RutaDeArchivo);

            try
            {
                llamada = (Provincial)serializer.Deserialize(reader);
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
