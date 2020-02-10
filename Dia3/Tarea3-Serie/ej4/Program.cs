/*
 * Realizar un programa que imprima la serie de fibonacci hasta el elemento n que especifique el usuario.
 */
using System;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ok = false;
            while (ok != true)
            {
                try
                {
                    Console.WriteLine("Ingresa un número y te mostraré esa cantidad de elementos de la serie de fibonacci: ");
                    int cantidad = Convert.ToInt32(Console.ReadLine());
                    int num1 = 0;
                    int num2 = 1;
                    int nuevo;
                    cantidad -= 2;
                    Console.WriteLine("\n" + num1);
                    Console.WriteLine(num2);
                    for (int i = 0; i < cantidad; i++)
                    {
                        nuevo = num1 + num2;
                        Console.WriteLine(nuevo);
                        num1 = num2;
                        num2 = nuevo;
                    }
                    Console.WriteLine("\n");
                    ok = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar dos enteros.");
                }
            }
            Console.ReadKey();
        }
    }
}
