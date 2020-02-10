/*
 * Escribir un programa que pida al usuario una cadena de texto e imprima la misma cadena de
 * texto, pero antes de cada vocal, agregue una f.
*/
using System;

namespace ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe una cadena de texto: ");
            string cadena = Console.ReadLine();
            char[] caracteres = {'A', 'E', 'I', 'O', 'U', 'Á', 'É', 'Í', 'Ó', 'Ú', 'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú' };
            bool tmp;
            for(int i = 0; i < cadena.Length; i++)
            {
                tmp = false;
                foreach(char value in caracteres)
                {
                    if(cadena[i] == value)
                        tmp = true;
                }
                if (tmp)
                    Console.Write("f{0}", cadena[i]);
                else
                    Console.Write("{0}", cadena[i]);
            }
            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}
