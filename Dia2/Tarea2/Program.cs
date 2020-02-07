using System;

namespace Tarea2
{
    class Alumno
    {
        public string Nombre { get; set; }
        public string ApPat { get; set; }
        public string ApMat { get; set; }
        public int CalProy { get; set; }
        public int CantTareas { get; set; }
        public int CantPart { get; set; }
        public Alumno() { }
        public Alumno(string nombre, string appat, string apmat, int calproy, int cantareas, int cantpart)
        {
            Nombre = nombre;
            ApPat = appat;
            ApMat = apmat;
            CalProy = calproy;
            CantTareas = cantareas;
            CantPart = cantpart;
        }
        public override string ToString()
        {
            int promedio = 0;
            promedio += (CalProy * 60) / 10;
            promedio += (CantTareas * 40) / 5;
            if(CantPart > 5)
            {
                promedio += 8;
            }
            return string.Format("\nLa calificación final de {0} {1} {2} es de: {3}/100.\n", ApPat, ApMat, Nombre, promedio);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name, appaterno, apmaterno;
            int dat1, dat2, dat3;
            Console.WriteLine("Ingresa el número de alumnos a calificar: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            Alumno[] alm = new Alumno[cantidad];
            for(int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("\n\nDatos del alumno {0}", i+1);
                Console.WriteLine("Nombre:");
                name = Console.ReadLine();
                Console.WriteLine("Apellido Paterno:");
                appaterno = Console.ReadLine();
                Console.WriteLine("Apellido Materno:");
                apmaterno = Console.ReadLine();
                Console.WriteLine("Calificación del proyecto:");
                dat1= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cantidad de tareas:");
                dat2= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Cantidad de participaciones:");
                dat3 = Convert.ToInt32(Console.ReadLine());
                alm[i] = new Alumno(name, appaterno, apmaterno, dat1, dat2, dat3);
            }
            Console.WriteLine("Calificaciones:");
            for(int i = 0; i < cantidad; i++)
            {
                Console.WriteLine(alm[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
