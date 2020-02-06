using System;

namespace ejercicio2
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Persona(string nombre, int edad)
        {
            Nombre = nombre;
            Edad = edad;
        }
        //Persona1.Equals(Persona2)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Persona p = obj as Persona;
            return (Nombre == p.Nombre) && (Edad == p.Edad);
        }
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Mauricio", 23);
            Persona p2 = new Persona("Luis", 23);
            Persona p3 = new Persona("Beto", 23);
            Persona p4 = new Persona("Beto", 23);

            //Comparación por referencia
            Console.WriteLine("Referencias p1 y p2 son iguales?");
            Console.WriteLine(p1 == p2);
            Console.WriteLine("Referencias p2 y p3 son iguales?");
            Console.WriteLine(p2 == p3);
            Console.WriteLine("Referencias p3 y p4 son iguales?");
            Console.WriteLine(p3 == p4);

            //Comparación de objetos
            Console.WriteLine("Objetos p1 y p2 son iguales?");
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine("Objetos p2 y p3 son iguales?");
            Console.WriteLine(p2.Equals(p3));
            Console.WriteLine("Objetos p3 y p4 son iguales?");
            Console.WriteLine(p3.Equals(p4));

            Console.ReadKey(true);
        }
    }
}
