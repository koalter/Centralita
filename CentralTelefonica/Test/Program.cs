﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralitaHerencia;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mi central
            Centralita c = new Centralita("Fede Center");
            Console.WriteLine(c.Llamadas);
            // Mis 4 llamadas
            Local l1 = new Local("Bernal", 30, "Rosario", 2.65f);
            Provincial l2 = new Provincial("Morón", Franja.Franja_1, 21, "Bernal");
            Local l3 = new Local("Lanús", 45, "San Rafael", 1.99f);
            Provincial l4 = new Provincial(Franja.Franja_3, l2);
            // Las llamadas se irán registrando en la Centralita.
            // La centralita mostrará por pantalla todas las llamadas según las vaya registrando.
            c += l1;
            c += l2;
            c += l3;
            // El operador debería detectar que es la misma llamada que l2 y por lo tanto no agregarla a la centralita.
            try
            {
                c += l4;
            } catch (CentralitaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Ordeno las llamadas
            c.OrdenarLlamadas();
            // Muestro...
            Console.WriteLine(c.ToString());
            // Guardo el registro de llamadas en un archivo de texto, lo leo y lo muestro por pantalla
            try
            {
                c.Guardar();
            } catch (FallaLogException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(c.Leer());
            }
            Console.ReadKey();
        }
    }
}
