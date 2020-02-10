/*
 1. Programa que permite calcular la suma de los primeros n números naturales, siendo n un número natural ingresado por el usuario.
 */

using System;

namespace ej1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            int res = 0;
            bool ok = false;
            while (ok != true)
            {
                Console.WriteLine("\nEscribe el n número natural que quieras realizar la suma de los anteriores: ");
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    //Los números naturales son los enteros comnezando desde cero hasta infinito positivo
                    for (int i = 0; i < num; i++) //Se suma hasta la cantidad indicada
                    {
                        if(i < num -1)
                            Console.Write(i + " + ");
                        else
                            Console.Write(i);
                        res += i;
                    }
                    Console.WriteLine("\nResultado: {0}", res); 
                    ok = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar un número entero.");
                }
            }
            Console.ReadKey();
        }
    }
}
