using System;
using System.Collections.Generic;
using System.Text;

namespace Ej1_Polimorfismo
{
    public class Rectangulo : Figura1
    {
        public int Base { get; set; }
        public int Altura { get; set; }
        public double CalcularArea()
        {
            return Base * Altura;
        }
        public void DatosRectangulo()
        {
            Console.WriteLine("Base: {0}, Altura: {1}", Base, Altura);
        }
    }
}
