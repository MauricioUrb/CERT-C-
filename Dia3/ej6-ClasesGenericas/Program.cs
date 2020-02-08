using System;

namespace ej6_ClasesGenericas
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<double> stack = new Stack<double>(10);
            stack.Push(5.5);
            stack.Push(10.5);
            //stack.Push(3.4);
            double x = stack.Pop();
            double y = stack.Pop();

            Console.WriteLine("x: {0}, y: {1},", x, y);

            Stack<Tortilla> pila = new Stack<Tortilla>();
            pila.Push(new Tortilla());
            pila.Push(new Tortilla());
            Console.WriteLine(pila.Pop().color);
            Console.WriteLine(pila.Pop().color);

            Console.ReadKey();
        }
    }
}
