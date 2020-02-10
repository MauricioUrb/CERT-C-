/*
 * 2. Realizar un programa en el que se le pida al usuario dos números del 1 al 9, num1 y num2.
 * Después va a imprimir todos los números naturales del 1 al 100, sin embargo, cuando un
 * número sea múltiplo de num1 o num2 o contenga alguno de estos números, va a imprimir
 * ‘clap’.
*/

using System;

namespace ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0;
            int num2 = 0;
            bool ok = false;
            bool val = false;
            string tmp; //cadena para almacenar el número a evaluar
            while (ok != true)
            {
                try
                {
                    while (val != true)
                    {
                        Console.WriteLine("\nDame el primer número entero entre el 1 y el 9: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        if (num1 < 0 || num1 > 9)
                            Console.WriteLine("Debes ingresar un entero entre 1 y 9.");
                        else
                            val = true;
                    }
                    val = false;
                    while (val != true)
                    {
                        Console.WriteLine("\nDame el segundo número entero entre el 1 y el 9: ");
                        num2 = Convert.ToInt32(Console.ReadLine());
                        if (num2 < 0 || num2 > 9)
                            Console.WriteLine("Debes ingresar un entero entre 1 y 9.");
                        else
                            val = true;
                    }
                    for (int i = 1; i <= 100; i++)
                    {
                        tmp = i.ToString(); //Se convierte a string el número
                                            //Se evalua si los números ingresados están en el número a evaluar
                        if (tmp.Contains(num1.ToString()) || tmp.Contains(num2.ToString()))
                        {
                            Console.WriteLine("clap ");
                        }
                        else if (i % num1 == 0 || i % num2 == 0) //Se evalúa si los números son múltiplos del número actual
                        {
                            Console.WriteLine("clap ");
                        }
                        else //Cualquier otro caso, se imprime el número
                        {
                            Console.WriteLine("{0} ", i);
                        }
                    }
                    ok = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar dos enteros entre 1 y 9.");
                }
            }
            Console.ReadKey();
        }
    }
}
