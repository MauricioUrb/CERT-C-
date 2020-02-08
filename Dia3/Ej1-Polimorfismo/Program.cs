using System;

namespace Ej1_Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Circulo C1 = new Circulo();
            C1.Radio = 5;
            C1.DatosCirculo();

            //Otra forma: Upcasting
            Figura1 f1 = new Circulo { Radio = 5 };
            f1.CalcularArea();

            Figura1 f2 = new Triangulo { Base = 10, Altura = 9 };
            Figura1 f3 = new Rectangulo { Base = 10, Altura = 9 };

            Figura1[] figuras = new Figura1[] { f1, f2, f3, C1 };
            foreach (var figura in figuras)
            {
                Console.WriteLine(figura.CalcularArea());
            }

            //Downcasting
            Circulo C = f1 as Circulo;
            //C.Radio = 5;
            Console.WriteLine("Datos del circulos");
            C.DatosCirculo();
            Console.ReadKey();
        }
    }
}
