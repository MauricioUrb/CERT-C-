/*
 * Elabora un programa que simule una calculadora de matrices (utilizando arreglos bidimensionales).
 * El tamaño de la matriz (arreglo) deberá ser ingresado por el usuario, así como los valores
 * contenidos en ella. En este caso sólo se soportarán matrices cuadradas (nxn). Las operaciones
 * que deberá contender la calculadora son:
 * suma
 * resta
 * multiplicación
 * Se puede utilizar cualquier tipo de dato (int, double, float). El programa debe contener un
 * menú que me permita elegir entre las operaciones de la calculadora y cuando se hagan las
 * operaciones, me debe mostrar las matrices que operan, así como el resultado. Estas matrices
 * deben mostrarse en su respectivo formato, es decir, cuadradas. Sin importar lo que el usuario
 * ingrese el programa no debe "morir", usen excepciones para controlar el ingreso de datos del
 * usuario.
 */
 using System;

namespace ej11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            bool ok = false;
            while (ok != true)
            {
                try//Validacion del tamño de la matriz
                {
                    Console.WriteLine("\nCalculadora de matrices\nIngresa el tamaño de las matrices cuadradas:");
                    n = Convert.ToInt32(Console.ReadLine());
                    Funcion(n);//Mandamos el tamaño a la creación de las matrices
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
        //Creación y asiganción de valores a las dos matrices cuadradas
        static void Funcion(int tam)
        {
            double[,] matriz1 = new double[tam, tam];
            double[,] matriz2 = new double[tam, tam];
            bool ok = false;
            bool menu = true;
            int opcion;
            while (ok != true)
            {
                try//Validación de los valores a ingresar en la matriz
                {
                    for (int i = 0; i < tam; i++)//Matriz 1
                    {
                        for (int j = 0; j < tam; j++)
                        {
                            Console.WriteLine("\nIngresa el valor de matriz1[{0}][{1}]:", i, j);
                            matriz1[i, j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }
                    for (int i = 0; i < tam; i++)//Matriz 2
                    {
                        for (int j = 0; j < tam; j++)
                        {
                            Console.WriteLine("\nIngresa el valor de matriz2[{0}][{1}]:", i, j);
                            matriz2[i, j] = Convert.ToDouble(Console.ReadLine());
                        }
                    }
                    //Menú
                    while (menu)
                    {
                        try//Validación de ingreso de opcion
                        {
                            Console.WriteLine("\n*********************Menú*********************");
                            Console.WriteLine("1. Sumar");
                            Console.WriteLine("2. Restar");
                            Console.WriteLine("3. Multiplicar"); 
                            Console.WriteLine("4. Salir");
                            Console.WriteLine("Opcion:");
                            opcion = Convert.ToInt32(Console.ReadLine());
                            if (opcion == 4)//Termina el programa
                                menu = false;
                            else
                                Operaciones(opcion, matriz1, matriz2, tam);//Se llama a la función donde se realizan las operaciones
                        }
                        catch (FormatException formatException)
                        {
                            Console.WriteLine("\n" + formatException.Message);
                            Console.WriteLine("Debes ingresar un número entero.");
                        }
                    }
                    Console.WriteLine("\nAdios!");
                    ok = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar puros números.");
                }
            }
        }
        static void Operaciones(int opcion, double[,] matriz1, double[,] matriz2, int tam)
        {
            //Se crea un arreglo especial para el resultado de la multiplicación y asignamos todos sus valores iniciales en cero
            double[,]  multiplicacion = new double[tam, tam];
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    multiplicacion[i, j] = 0;
                }
            }
            switch (opcion)
            {
                case 1://Suma
                    Console.WriteLine("\nMatriz 1:");
                    Imprimir(tam, matriz1);
                    Console.WriteLine("\nMatriz 2:");
                    Imprimir(tam, matriz2);
                    Console.WriteLine("\nMatriz resultado:");
                    for (int i = 0; i < tam; i++)//Se imprime la suma de las matrices
                    {
                        for (int j = 0; j < tam; j++)
                        {
                            Console.Write("{0}\t", matriz1[i, j] + matriz2[i, j]);
                        }
                        Console.Write("\n");
                    }
                    break;
                case 2://Resta
                    Console.WriteLine("\nMatriz 1:");
                    Imprimir(tam, matriz1);
                    Console.WriteLine("\nMatriz 2:");
                    Imprimir(tam, matriz2);
                    Console.WriteLine("\nMatriz resultado:");
                    for (int i = 0; i < tam; i++)//Se imprime la resta de las matrices
                    {
                        for (int j = 0; j < tam; j++)
                        {
                            Console.Write("{0}\t", matriz1[i, j] - matriz2[i, j]);
                        }
                        Console.Write("\n");
                    }
                    break;
                case 3://Multiplicacion
                    Console.WriteLine("\nMatriz 1:"); 
                    Imprimir(tam, matriz1);
                    Console.WriteLine("\nMatriz 2:");
                    Imprimir(tam, matriz2);
                    Console.WriteLine("\nMatriz resultado:");
                    for (int i = 0; i < tam; i++)//Cálculo de la multiplicaciones de las matrices
                    {
                        for (int j = 0; j < tam; j++)
                        {
                            for(int k = 0; k < tam; k++)
                                multiplicacion[i,j] += matriz1[i, k] * matriz2[k, j];
                        }
                    }
                    Imprimir(tam, multiplicacion);//Se imprime la matriz resultante
                    break;
                default:
                    Console.WriteLine("\nOpción no válida, intente de nuevo.");
                    break;
            }
        }
        //Impresión de la matriz enviada a la función
        static void Imprimir(int tam, double[,] matriz)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    Console.Write("{0}\t", matriz[i, j]);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
