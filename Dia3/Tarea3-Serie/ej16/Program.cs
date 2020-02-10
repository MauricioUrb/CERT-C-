/*
 * Realiza un programa que haga un claro ejemplo de Polimorsmo, estas clases pueden ser de
 * tu elección. Recuerda que polimorsmo no necesariamente es hacer una interfaz o hacer una
 * clase abstracta.
 */
using System;
using System.Collections.Generic;

namespace ej16
{
    public class Forma
    {
        public virtual void Dibujando()
        {
            Console.WriteLine("Dibujando figuras.");
        }
    }

    class Circulo : Forma
    {
        public override void Dibujando()
        {
            Console.WriteLine("Dibujando un círculo.");
            base.Dibujando();
        }
    }
    class Rectangulo : Forma
    {
        public override void Dibujando()
        {
            Console.WriteLine("Dibujandoun rectangulo.");
            base.Dibujando();
        }
    }
    class Triangulo : Forma
    {
        public override void Dibujando()
        {
            Console.WriteLine("Dibujando un triángulo.");
            base.Dibujando();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fig = new List<Forma>
        {
            new Rectangulo(),
            new Triangulo(),
            new Circulo()
        };

        foreach (var figura in fig)
            figura.Dibujando();
        
        Console.ReadKey();
        }
    }
}
