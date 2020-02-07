using System;

namespace ej5_Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona p1 = new Persona("Mauricio", 23);
            p1.Saludar();
            Console.WriteLine(p1.ToString());

            Empleado e1 = new Empleado("Antonio", 25, "Gerente General de Asuntos Generales", 30000);
            e1.Saludar();
            e1.Trabajar();
            Console.WriteLine(e1.ToString());

            Persona p2 = new Persona("Xotla", 22);
            Persona p3 = new Persona("Baruch", 22);

            Persona[] gente = new Persona[4];
            gente[0] = p1;
            gente[1] = p2;
            gente[2] = p3;
            gente[3] = e1;

            Console.WriteLine("\nLista de personas que son empleados:");
            foreach(var per in gente)
            {
                if(per is Empleado)
                {
                    Console.WriteLine(per.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
