using System;

namespace ej3_Excepciones2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingresa un valor para calcular raís cuadrada:");
                double dato = Convert.ToDouble(Console.ReadLine());
                double resultado = RaizCuadrada(dato);
                Console.WriteLine("La raiz cuadrada de {0} es {1}", dato, resultado);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("\n" +  fe.Message);
                Console.WriteLine("Ingresa un numero");
            }
            catch (NegativeNumberException NNE)
            {
                Console.WriteLine("\n" + NNE.Message);
                Console.WriteLine("Mi excepcion: no hay raíces de números negativos.");
            }
        }
        public static double RaizCuadrada(double dato)
        {
            if(dato < 0)
            {
                throw new NegativeNumberException("No pongas números negativos");
            }
            else
            {
                return Math.Sqrt(dato);
            }
        }
    }
}
