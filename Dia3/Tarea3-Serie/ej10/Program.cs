/*
 * Realiza una clase llamada "Persona"que tenga los atributos: nombre edad, estatura(metros)
 * y peso(Kg). El usuario ingresará los datos dichos datos. Crea algunos métodos (mínimo 3) y
 * mandalos llamar en una clase principal.
 */
 using System;

namespace ej10
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Estatura { get; set; }
        public double Peso { get; set; }
        public Persona(string nombre, int edad, double estarura, double peso)
        {
            Nombre = nombre; Edad = edad; Estatura = estarura; Peso = peso;
        }
        public void IMC()
        {
            Console.WriteLine("El índice de masa corporal de esta persona es: {0}", Peso / Math.Pow(Estatura, 2));
        }
        public void Obesidad()
        {
            double obeso = Peso / Math.Pow(Estatura, 2);
            if (obeso >= 18.5 && obeso < 25)
                Console.WriteLine("\nEl peso es el indicado.");
            else if (obeso >= 25 && obeso < 30)
                Console.WriteLine("\nTiene sobrepeso.");
            else if (obeso >= 30 && obeso < 35)
                Console.WriteLine("\nTiene obesidad  de Grado 1");
            else if(obeso >= 35 && obeso < 40)
                Console.WriteLine("\nTiene obesidad  de Grado 2");
            else if(obeso >= 40)
                Console.WriteLine("\nTiene obesidad  de Grado 3");
            else
                Console.WriteLine("\nLos datos que ingresaste no sirven para este cálculo.");
        }
        public override string ToString()
        {
            return string.Format("\nDatos de la persona:\nNombre: {0}\nEdad: {1}\nEstatura: {2} m\nPeso: {3} kg", Nombre, Edad, Estatura, Peso);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int edad;
            double estatura;
            double peso;
            bool ok = false;
            //Console.WriteLine("\n");
            while (ok != true)
            {
                try
                {
                    Console.WriteLine("\nIngresa los datos de la persona:\nNombre:");
                    nombre = Console.ReadLine();

                    Console.WriteLine("\nEdad:");
                    edad = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("\nEstatura:");
                    estatura = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("\nPeso:");
                    peso = Convert.ToDouble(Console.ReadLine());

                    Persona p1 = new Persona(nombre, edad, estatura, peso);
                    Console.WriteLine("\nDatos de la persona:");
                    Console.WriteLine(p1.ToString());
                    Console.WriteLine("\nÍndice de masa corporal:");
                    p1.IMC();
                    Console.WriteLine("\nDe acuerdo al IMC de esta persona:");
                    p1.Obesidad();

                    ok = true;
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("\n" + formatException.Message);
                    Console.WriteLine("Debes ingresar la edad como un número entero, estarura y peso como un números enteros o con decimal.");
                }
            }
            Console.ReadKey();
        }
    }
}
