﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ej1_Polimorfismo
{
    public class Circulo : Figura1
    {
        public int Radio { get; set; }
        public double CalcularArea()
        {
            return Math.PI * Radio * Radio;
        }
        public void DatosCirculo()
        {
            Console.WriteLine("Radio: {0}", Radio);
        }
    }
}
