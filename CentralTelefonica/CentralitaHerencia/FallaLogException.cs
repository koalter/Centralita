using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class FallaLogException : Exception
    {
        public FallaLogException() : base() { }

        public FallaLogException(string mensaje) : base(mensaje) { }
    }
}
