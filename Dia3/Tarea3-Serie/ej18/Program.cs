/*
 * Realizar una investigación del manejo de archivos en C# y hacer un programa libre que implique
 * el manejo de archivos.
 */
using System;
using System.IO;

namespace ej18
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string archivo = @"C:\Users\User\Documents\ej18Archivo.txt";
                if (!File.Exists(archivo))
                {
                    // Crea el archivo para escribir en él
                    using (StreamWriter sw = File.CreateText(archivo))
                    {
                        sw.WriteLine("Se está creando un archivo.");
                        sw.WriteLine("Esta es otra línea.");
                        sw.WriteLine("Esta será otra línea.");
                    }
                }

                // Abrimos el archivo para leerlo.
                using (StreamReader sr = File.OpenText(archivo))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            catch
            {
                Console.WriteLine("La ruta o el archivo no existe.");
            }

        }
    }
}
