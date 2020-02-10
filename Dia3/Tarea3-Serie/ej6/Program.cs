/*
 * Se debe diseñar una clase CuentaBancaria que va a tener los métodos mostrarInformación,
 * depósito y retiro, como atributos, cada objeto va a tener un saldo y un nombre. El método
 * mostrar información va a imprimir el nombre de la cuenta y el saldo, el método depósito va
 * a agregar una cantidad al saldo de la cuenta y va a mostrar información. El método retiro va
 * a retirar dinero de la cuenta, pero antes tendrá que comprobar que se cuente con el dinero
 * suficiente, terminando el retiro va a mostrar información. Cada vez que se cree un objeto,
 * va a mostrar información de la cuenta. Se debe crear dos objetos y llamar sus métodos para
 * probarlos.
 */
using System;

namespace ej6
{
    class CuentaBancaria
    {
        public double Saldo { get; set; }
        public string Nombre { get; set; }
        public CuentaBancaria(string nombre, double saldo)
        {
            Nombre = nombre;
            Saldo = saldo;
            Console.WriteLine("\n************************************************************\nNueva cuenta creada:\nNombre: {0}\nSaldo: {1:C}", Nombre, Saldo);
        }
        public void mostrarInformación() {
            Console.WriteLine("******************************\nDatos de la cuenta:\nNombre: {0}\nSaldo: {1:C}", Nombre, Saldo);
        }
        public void deposito(double depositar) {
            Console.WriteLine("******************************\nSaldo a depositar: {0:C}", depositar); 
            Saldo += depositar;
            Console.WriteLine("\nSaldo actualizado:\nNombre: {0}\nSaldo: {1:C}", Nombre, Saldo);
        }
        public void retiro(double retirar) {
            if(Saldo > retirar)//Se evalua si hay saldo suficiente para poder realizar la transacción
            {
                Console.WriteLine("******************************\nSaldo a retirar: {0:C}", retirar);
                Saldo = Saldo - retirar;
                Console.WriteLine("\nSaldo actualizado:\nNombre: {0}\nSaldo: {1:C}", Nombre, Saldo);
            }
            else
            {
                Console.WriteLine("******************************\nSaldo insuficiente.\nNo se pueden retirar {0:C} de la cuenta.",retirar);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            CuentaBancaria c1 = new CuentaBancaria("Mauricio",130);
            c1.deposito(52);
            c1.mostrarInformación();
            c1.retiro(15.5);
            c1.mostrarInformación();
            c1.retiro(500);//Prueba para saldo insuficiente
            c1.mostrarInformación();

            CuentaBancaria c2 = new CuentaBancaria("Alberto", 90);
            c2.deposito(40.5);
            c2.mostrarInformación();
            c2.retiro(35.8);
            c2.mostrarInformación();
            c2.retiro(500);//Prueba para saldo insuficiente
            c2.mostrarInformación();
            Console.ReadKey();
        }
    }
}
