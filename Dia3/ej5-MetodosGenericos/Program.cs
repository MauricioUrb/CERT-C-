using System;

namespace ej5_MetodosGenericos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = { 1, 2, 3, 4, 5, 6 };
            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6, 7.7 };
            char[] charArray = { 'H', 'O', 'L', 'A' };

            Console.WriteLine("intArray contiene: ");
            MuestraArreglo(intArray);
            Console.WriteLine("doubleArray contiene: ");
            MuestraArreglo(doubleArray);
            Console.WriteLine("charArray contiene: ");
            MuestraArreglo(charArray);
            Console.ReadKey();
        }
        public static void MuestraArreglo<T>(T[] inputArray)
        {
            foreach(T elemto in inputArray)
            {
                Console.Write(elemto + " ");
            }
            Console.WriteLine("\n");
        }
    }
}