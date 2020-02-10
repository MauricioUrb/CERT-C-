/*
 * Se tendrá una clase llamada Carro que tendrá de atributos peso y altura junto con un atributo
 * llamado " encendido" de tipo booleano inicilizado en false. En el constructor deberás indicarle
 * los valores peso y altura.La misma clase contará con los métodos encender y apagar, que cambiarán
 * el estado del atributo " encendido" y desplegarás un mensaje indicando si se encendió
 * o se apagó.
 * Crear métodos get para poder obtener su peso y altura.
 * Se contará con un método llamado " Estado"para verificar si el auto se encuentra encendido
 * o no.
 * El último método de la clase, es toString() el cual nos servirá para imprimir un mensaje,
 * este mensaje deberá indicar el peso y altura del Carro.
 * Crear dos clases más que hereden de Carro, con nombres como CarroBWM, CarroVW, etc. Esta
 * clase tendrá un atributo llamado modelo. Implementa su constructor y también implementa
 * su método toString() para que pueda imprimir todos sus atributos. En una clase de prueba(en
 * el método Main), crea objetos de las dos clases hijas y manda a llamar todos sus métodos. Al
 * final deberá verse una impresión como la siguiente, para los dos objetos que hayas creado:
 * >El carro está apagado
 * >El carro está encendido
 * >Está encendido
 * >Tengo turbo
 * >El peso es: 100,000.
 * >La altura es: 1.90.
 * >El modelo es: BMW
 */
 using System;

namespace ej13
{
    class Carro
    {
        public double Peso { get; set; }
        public double Altura { get; set; }
        public bool Encendido { get; set; }
        public Carro(double peso, double altura)
        {
            Peso = peso;
            Altura = altura;
            Encendido = false;
        }
        public void Encender()
        {
            if (Encendido)
                Console.WriteLine("\nEl carro ya está encendido");
            else
            {
                Encendido = true;
                Console.WriteLine("\nEl carro se ha encendido");
            }
        }
        public void Apagar()
        {
            if (Encendido)
            {
                Encendido = false;
                Console.WriteLine("\nEl carro se ha apagado");
            }
            else
                Console.WriteLine("\nEl carro ya está apagado.");
        }
        public void Estado()
        {
            Console.WriteLine("{0}",Encendido ? "\nEl carro está encendido" : "\nEl carro está apagado.");
        }
        public override string ToString()
        {
            return string.Format("\nPeso: {0}\nAltura: {1}",Peso, Altura);
        }
    }
    class CarroBMW : Carro
    {
        public string Modelo { get; set; }
        public CarroBMW(double peso, double altura, string modelo) : base(peso, altura)
        {
            Modelo = modelo;
        }
        public override string ToString()
        {
            return string.Format("\nModelo: {0}\nPeso: {1}\nAltura: {2}", Modelo, Peso, Altura);
        }
    }
    class CarroVW : Carro
    {
        public string Modelo { get; set; }
        public CarroVW(double peso, double altura, string modelo) : base(peso, altura)
        {
            Modelo = modelo;
        }
        public override string ToString()
        {
            return string.Format("\nModelo: {0}\nPeso: {1}\nAltura: {2}", Modelo, Peso, Altura);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarroBMW c1 = new CarroBMW(120, 150, "BMW");
            Console.WriteLine(c1.ToString());
            c1.Encender();
            c1.Estado();
            c1.Apagar();

            CarroVW c2 = new CarroVW(150, 160, "VW");
            Console.WriteLine(c2.ToString());
            c2.Encender();
            c2.Apagar();
            c2.Estado();

            Console.ReadKey();
        }
    }
}
