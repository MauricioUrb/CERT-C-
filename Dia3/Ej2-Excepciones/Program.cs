using System;

namespace Ej2_Excepciones
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Convert.ToInt32 genera FormatException
                Console.WriteLine("Ingresa el numerador: ");
                int numerador = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Ingresa el denominador: ");
                int denominador = Convert.ToInt32(Console.ReadLine());

                //La división entre cero genera DivideByZeroException
                double resultado = numerador / denominador;
                Console.WriteLine("\nResultado: {0} / {1} = {2} ",numerador, denominador, resultado);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine("\n" + formatException.Message);
                Console.WriteLine("Debes ingresar dos enteros.");
            }
            catch (DivideByZeroException cero)
            {
                Console.WriteLine("\n" + cero.Message);
                Console.WriteLine("No puedes dividir entre cero.");
            }
            finally
            {
                Console.WriteLine("Fin del programa.");
            }
            Console.ReadKey();
        }
    }
}
