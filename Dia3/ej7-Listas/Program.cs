using System;
using System.Collections.Generic;

namespace ej7_Listas
{
    class Program
    {
        private static readonly string[] colors = { "Magenta", "Rojo", "Blanco", "Azul", "Cyan" };
        private static readonly string[] removeColors = { "Rojo", "Blanco", "Azul" };
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            foreach(var color in colors)
            {
                list.Add(color);
            }
            List<string> removeList = new List<string>(removeColors);
            MostrarLista(list);
            //Console.WriteLine("");
            Console.ReadKey();
        }
        private static void MostrarLista(List<string> list)
        {
            foreach(var elemento in list)
            {
                Console.Write("{0} ", elemento);
            }
        }
    }
}
