using System;

namespace ejercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente c1 = new Cliente("Mauricio");
            Console.WriteLine(c1.Nombre);
            Console.WriteLine(c1.Edad);
            Console.WriteLine(c1.Cuenta);

            Console.WriteLine(Cliente.mensaje());
            Console.WriteLine(c1.Dinero);

            c1.Despositar(1000);

            Console.WriteLine(c1.Dinero);

            Console.WriteLine(c1.ToString());

            Console.ReadKey();
        }
    }
}
