/*
 * Se debe simular una agenda telefónica. Cuando inicie el programa se debe desplegar un menú con las opciones:
 * Agregar contacto
 * Eliminar contacto
 * Mostrar contacto
 * Salir
 * Los contactos van a ser almacenados en un diccionario (investiguen la colección Dictionary)
 * en donde las llaves son los nombres de los contactos y sus valores van a ser los teléfonos.
 */

using System;
using System.Collections.Generic;

namespace ej5
{
    class Program
    {
        static int Main(string[] args)
        {
            int opcion;
            string nombre;
            int telefono;
            Dictionary<string, int> contacto = new Dictionary<string, int>();//Se crea el objeto contacto de tipo diccionario
            while (true)//bucle infinito
            {
                Console.WriteLine("\n\n*************************Menú*************************");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Eliminar contacto");
                Console.WriteLine("3. Mostrar contactos");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Selecciona tu opción: ");
                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());//Se valida que se ingrese un entero para seleccionar la opción elegida
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message); 
                    Console.WriteLine("Debes ingresar un número para seleccionar una de las opciones.\nIntentalo de nuevo.");
                    continue;
                }
                switch (opcion)//De acuerdo al la opción elegida, se ingresa al respectivo caso
                {
                    case 1://Agregar nuevo contacto
                        Console.WriteLine("\nNombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Teléfono: ");
                        try
                        {
                            telefono = Convert.ToInt32(Console.ReadLine());////Validación de ingreso de número entero
                        }
                        catch (FormatException formatException)
                        {
                            Console.WriteLine("\n" + formatException.Message); 
                            Console.WriteLine("Debes ingresar un número.\nNo se pudo agregar el contacto.");
                            break;
                        }
                        try
                        {
                            contacto.Add(nombre, telefono);
                            Console.WriteLine("Contacto agregado exitosamente!");
                        }
                        catch (ArgumentException)//Si el nombre del contacto ya existe, no se agregará
                        {
                            Console.WriteLine("Ya existe el contacto {0}.", nombre);
                        }
                        break;
                    case 2://Remover contacto
                        Console.WriteLine("\nQué contacto quieres remover?");
                        nombre = Console.ReadLine();
                        if (!contacto.ContainsKey(nombre))//Verificar si existe el contacto
                        {
                            Console.WriteLine("\nEste contacto no existe!");
                        }
                        else
                        {
                            contacto.Remove(nombre);
                            Console.WriteLine("Contacto removido exitosamente!");
                        }
                        break;
                    case 3://Mostrar todos los contactos
                        Console.WriteLine("\n*********************************************");
                        foreach (KeyValuePair<string, int> element in contacto)
                            Console.WriteLine("\nNombre: {0}\nTeléfono: {1}", element.Key, element.Value);
                        Console.WriteLine("\n*********************************************");
                        break;
                    case 4://Salir del programa
                        Console.WriteLine("\nHasta pronto!");
                        return 0;
                    default://Opciones no válidas
                        Console.WriteLine("\nOpcion no válida!");
                        break;
                }
            }
        }
    }
}
