/*
 * Crea una calculadora que haga operaciones entre dos números. Las operaciones que deberá
 * soportar serán suma, resta, multiplicación y división. El programa debe de contener un menú
 * que me permita elegir cualquier opción y la última de ellas debe ser para salir. Si se termina
 * una operación debo de volver al menú de inicio. No debe haber forma de salirse del programa a
 * menos que sea con la opción salir. Considerar todas las excepciones posibles e implementarlas
 * para evitar errores en tiempo de ejecución. Considera: División entre cero, números demasiado
 * grandes, cadenas en vez de números, entre otras que a ti se te puedan ocurrir.
 */
using System;

namespace ej15
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            double num1, num2;
            Console.WriteLine("\t\tCalculadora");
            bool val_num = true;
            bool val_op = true;
            while (val_op)
            {
                try
                {
                    val_num = true;
                    Console.WriteLine("\n\n***************Calculadora***************");
                    Console.WriteLine("1. Sumar");
                    Console.WriteLine("2. Restar");
                    Console.WriteLine("3. Multiplicar");
                    Console.WriteLine("4. Dividir");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("\nSelecciona la opción a realizar: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            while (val_num)
                            {
                                try
                                {
                                    Console.WriteLine("\nIngresa el primer número:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Ingresa el segundo número:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("\n{0} + {1} = {2}", num1, num2, num1 + num2);
                                    val_num = false;
                                }
                                catch (FormatException formatException)
                                {
                                    Console.WriteLine("\n" + formatException.Message);
                                    Console.WriteLine("Debes ingresar dos números.");
                                }
                            }
                            break;
                        case 2:
                            while (val_num)
                            {
                                try
                                {
                                    Console.WriteLine("\nIngresa el primer número:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Ingresa el segundo número:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("\n{0} - {1} = {2}", num1, num2, num1 - num2);
                                    val_num = false;
                                }
                                catch (FormatException formatException)
                                {
                                    Console.WriteLine("\n" + formatException.Message);
                                    Console.WriteLine("Debes ingresar dos números.");
                                }
                            }
                            break;
                        case 3:
                            while (val_num)
                            {
                                try
                                {
                                    Console.WriteLine("\nIngresa el primer número:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Ingresa el segundo número:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("\n{0} * {1} = {2}", num1, num2, num1 * num2);
                                    val_num = false;
                                }
                                catch (FormatException formatException)
                                {
                                    Console.WriteLine("\n" + formatException.Message);
                                    Console.WriteLine("Debes ingresar dos números.");
                                }
                            }
                            break;
                        case 4:
                            while (val_num)
                            {
                                try
                                {
                                    Console.WriteLine("\nIngresa el primer número:");
                                    num1 = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("Ingresa el segundo número:");
                                    num2 = Convert.ToDouble(Console.ReadLine());
                                    if (num2 == 0)
                                        Console.WriteLine("\nNo se puede dividir entre cero.");
                                    else
                                        Console.WriteLine("\n{0} / {1} = {2}", num1, num2, num1 / num2);
                                    val_num = false;
                                }
                                catch (FormatException formatException)
                                {
                                    Console.WriteLine("\n" + formatException.Message);
                                    Console.WriteLine("Debes ingresar dos números.");
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("\nHasta pronto.");
                            Console.ReadKey();
                            val_op = false;
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes un entero.");
                }
            }
        }
    }
}
