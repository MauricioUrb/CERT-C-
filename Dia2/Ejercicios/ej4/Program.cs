using System;

namespace ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = { 34, 72, 13, 44, 25, 30, 10 };
            int[] temp = new int[list.Length];
            Console.WriteLine("Arreglo original: ");
            MostrarArreglo(list);

            //generar copia del arreglo original
            Array.Copy(list, temp, list.Length);

            //invierte el arreglo
            Array.Reverse(temp);
            Console.WriteLine("Arreglo invertido: ");
            MostrarArreglo(temp);

            //Ordena el arreglo
            Array.Sort(list);
            Console.WriteLine("Arreglo ordenado: ");
            MostrarArreglo(temp);

            Console.WriteLine("Indice del número 44: " + Array.IndexOf(temp, 44));
            Console.ReadKey();
        }
        static void MostrarArreglo(int[] arreglo)
        {
            foreach (int i in arreglo)
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}
