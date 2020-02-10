/*
 * Una persona se dirige al BecarioMart a realizar sus compras semanales. Dicha persona no sabe
 * cuántos productos va a comprar y tampoco sabe su valor. Para poder ayudarlo deberás de
 * implementar dos Listas. Una contiene los nombres de los productos y otro contiene los precios
 * de los productos. Tanto el nombre como el precio, deberán ser ingresados por el usuario y en
 * seguida, deberán de ser agregados a las listas. Al momento de pagar le aparece una lista de
 * todos los productos que ha llevado con su respectivo precio, sin embargo, se da cuenta de
 * que sólo tiene $500:00, por lo que, si ha excedido su cuenta, deberá elegir unos productos y
 * dejar otros. Para lograr eso, debe poder acceder al índice del producto y así poder elegirlo para
 * eliminarlo de su lista, hasta que finalmente la cuenta sea menor o igual a los $500:00.
 * El programa debe preguntar al usuario si desea agregar un producto a su lista, si es así deberá
 * ingresar tanto el nombre como el precio a las Listas. En caso de que ya no quiera agregar más
 * productos, le aparecerá en pantalla la lista de todos los productos que ha llevado (nombre y
 * precio) así como la suma de los precios. Cuando aparezca la lista, deberá tener dos opciones:
 * Comprar.
 * Dejar productos.
 * Para la primera opción deberás de tener validaciones para ver si el dinero que tiene es suficiente.
 * Si el dinero es suficiente, deberá imprimir un mensaje que diga "Gracias por su compra!",
 * en caso contrario debe mandarlo a la opción "Dejar productos". Si el usuario elige la opción 2
 * deberá poder ver los índices de los productos en las listas para así poder decidir cuál eliminar.
 * Una vez eliminados los productos, debes imprimir de nuevo la lista de productos a comprar
 * con su precio y darle a elegir de nuevo entre las dos opciones.
 */
using System;
using System.Collections.Generic;

namespace ej12
{
    class Program
    {
        //Esta función es la final, donde se le muestra al usuario su lista de compras final y decide si pagar dejar productos
        static void MenuFinal(List<string> prod, List<double> prec)
        {
            int opcion, opcion_quitar;
            while (true)
            {
                try//Validación para comprar o dejar
                {
                    ImprimeLista(prod, prec);
                    Console.WriteLine("\n1. Comprar.\n2. Dejar productos.");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 1) {//El usuario compra sus productos
                        Console.WriteLine("\nGracias por su compra!");
                        break;
                    }
                    else if (opcion == 2)//El usuario va a dejar un producto
                    {
                        try//Validación de la opción del producto a dejar
                        {
                            Console.WriteLine("\nEscoje un producto para quitar de tu lista:");
                            opcion_quitar = Convert.ToInt32(Console.ReadLine());
                            if (opcion_quitar < 1 || opcion_quitar > prod.Count)//Si el producto no está en el rango, se le avisa que el producto no existe
                                Console.WriteLine("\nNo se puede quitar el producto {0} porque no existe.", opcion_quitar);
                            else//Si sí existe, se elimina de la lista
                            {
                                prod.RemoveAt(opcion_quitar - 1);
                                prec.RemoveAt(opcion_quitar - 1);
                            }
                        }
                        catch (FormatException formatException)
                        {
                            Console.WriteLine("\n" + formatException.Message);
                            Console.WriteLine("Debes ingresar un entero.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nOpción no válida.");
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes un entero.");
                }
            }

        }
        //Función que imprime el ticket
        static double ImprimeLista(List<string> prod, List<double> prec)
        {
            double total = 0; 
            Console.WriteLine("\n\n************************************************************");
            Console.WriteLine("\n\tTicket\n");
            for (int i = 0; i < prod.Count; i++)
            {
                Console.WriteLine("{0}\t{1}\t\t{2:C}", i+1, prod[i], prec[i]);
            }
            Console.WriteLine("--------------------------------------------------------------");
            foreach (double element in prec)
                total += element;
            Console.WriteLine("\tTotal a pagar: {0:C}", total);
            return total;
        }
        //Primer menú una vez que el usuario dejaba de agregar productos
        static void ListaCompletada(List<string> prod, List<double> prec)
        {
            double dinero = 500;//Límite de dinero del cliente
            double total;
            bool ok = false;
            int opcion_quitar;
            char Ag_Prod;
            bool agregar = false;
            bool agregar2 = false;
            string nuevo_prod;
            double nuevo_precio;
            while (ok != true)
            {
                try//Validacion elemento a quitar que se ingrese un entero
                {
                    total = ImprimeLista(prod, prec);
                    if (total > dinero)//Si la lista de productos cuesta más que el presupuesto del usuario, se obliga a dejar un producto
                    {
                        Console.WriteLine("\nEl dinero que tienes no es suficiente.\nEscoje un producto para quitar de tu lista:");
                        opcion_quitar = Convert.ToInt32(Console.ReadLine());
                        if (opcion_quitar < 1 || opcion_quitar > prod.Count)//Si el ínidice del producto no está, se notifica al usuario
                            Console.WriteLine("\nNo se puede quitar el producto {0} porque no existe.", opcion_quitar);
                        else
                        {
                            prod.RemoveAt(opcion_quitar - 1);
                            prec.RemoveAt(opcion_quitar - 1);
                        }
                    }
                    else
                    {
                        agregar = false;
                        while (agregar != true)
                        {
                            try//Validacion de si se desea agregar o no otro producto a la lista
                            {
                                Console.WriteLine("\n¿Desea agregar otro producto a su lista? (y/n)");
                                Ag_Prod = Convert.ToChar(Console.ReadLine());
                                if (Ag_Prod == 'n')//No se agregarán más productos
                                {
                                    MenuFinal(prod, prec);
                                    agregar = true;
                                    ok = true;
                                }
                                else if (Ag_Prod == 'y')//Agregar otro producto
                                {
                                    while (agregar2 != true)
                                    {
                                        try//Validación del precio del producto a agregar
                                        {
                                            Console.WriteLine("\nNombre:");
                                            nuevo_prod = Console.ReadLine();
                                            Console.WriteLine("Precio:");
                                            nuevo_precio = Convert.ToDouble(Console.ReadLine());
                                            prod.Add(nuevo_prod);
                                            prec.Add(nuevo_precio);
                                            //Se ordena una vez agregado
                                            prod.Sort();
                                            prec.Sort();
                                            agregar2 = true;
                                        }
                                        catch (FormatException formatException)
                                        {
                                            Console.WriteLine("\n" + formatException.Message);
                                            Console.WriteLine("Precio del producto no válido.\nProducto no agregado a la lista de compras.");
                                        }
                                    }
                                }
                                else//El usuario no escogió una opción válida
                                {
                                    Console.WriteLine("\nOpción no válida.");
                                }
                                agregar = true;
                            }
                            catch
                            {
                                Console.WriteLine("\nOpción no válida.");
                            }
                        }
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar un entero.");
                }
            }
        }
        static void Main(string[] args)
        {
            string producto;
            double precio;
            bool lista = false;
            bool agregar = false;
            char Ag_Prod;
            List<string> prod = new List<string>();
            List<double> prec = new List<double>();
            Console.WriteLine("\n************************************************************");
            Console.WriteLine("\n\tBienvenido a BecarioMart\n");
            Console.WriteLine("Escribe el nombre y precio de los productos a comprar:\n");
            while (true)
            {
                try//Validación del precio del producto
                {
                    while (lista != true)
                    {
                        agregar = false;
                        //Se agrega un producto obligatoriamente
                        Console.WriteLine("\nNombre:");
                        producto = Console.ReadLine();
                        Console.WriteLine("Precio:");
                        precio = Convert.ToDouble(Console.ReadLine());
                        prod.Add(producto);
                        prec.Add(precio);
                        Console.WriteLine("\nProducto agregado exitosamente!");
                        while (agregar != true)
                        {
                            try//Validación para la pregunta de agregar otro producto
                            {
                                Console.WriteLine("\n¿Agregar otro producto? (y/n)");
                                Ag_Prod = Convert.ToChar(Console.ReadLine());
                                if (Ag_Prod == 'n')//Si no se agrega otro producto, se ordena la lista y se manda al siguiente menú
                                {
                                    prod.Sort();
                                    prec.Sort();
                                    ListaCompletada(prod, prec);
                                    lista = true;
                                    agregar = true;
                                }
                                else if( Ag_Prod == 'y')//Se agregará otro producto
                                {
                                    agregar = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nOpción no válida.");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("\nOpción no válida.");
                            }
                        }
                    }
                    break;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Precio del producto no válido.\nProducto no agregado a la lista de compras.");
                }
            }
            Console.ReadKey();
        }
    }
}
