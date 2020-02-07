using System;

namespace TiposAnonimos
{
    class Program
    {
        static void Main(string[] args)
        {
            var anonimo = new
            {
                Modelo = "Bocho",
                Precio = 80000,
                Placas = "ABC123"
            };
            Console.WriteLine("Datos del objeto anonimo:");
            Console.WriteLine(anonimo.Modelo);
            Console.WriteLine(anonimo.Precio);
            Console.WriteLine(anonimo.Placas);
        }
    }
}
