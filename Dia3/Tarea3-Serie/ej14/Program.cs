/*
 * Implementa una interfaz con los métodos que tú desees. Crearás 3 clases diferentes que puedan
 * hacer uso de esta interfaz, así como una clase de prueba donde podrás probar su uso. Incluir
 * en comentarios cuál es el objetivo de la interfaz.
 */
using System;

namespace ej14
{
    public interface Alumno
    {
        double Calificacion();
    }
    public class Licenciatura : Alumno
    {
        public double Tareas { get; set; }
        public double Proyecto { get; set; }
        public double Examen { get; set; }
        public double Calificacion()
        {
            return (Tareas * .2) + (Examen * .4) + (Proyecto * .4);
        }
    }
    public class Preparatoria : Alumno
    {
        public double Tareas { get; set; }
        public double Proyecto { get; set; }
        public double Examen { get; set; }
        public double Participaciones { get; set; }
        public double Calificacion()
        {
            return (Tareas * .2) + (Examen * .4) + (Proyecto * .3) + (Participaciones * .1);
        }
    }
    public class Posgrado : Alumno
    {
        public double Proyecto { get; set; }
        public double Examen { get; set; }
        public double Calificacion()
        {
            return (Examen * .6) + (Proyecto * .4);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\n");
            //Preparatoria al1 = new Preparatoria { Tareas = 3, Proyecto = 9, Examen = 7, Participaciones = 8 };
            Preparatoria al1 = new Preparatoria();
            al1.Tareas = 3;
            al1.Participaciones = 8;
            al1.Proyecto = 9;
            al1.Examen = 7;
            Console.WriteLine("Calificación del alumno de preparatoria: {0}",al1.Calificacion());
            
            Alumno al2 = new Licenciatura { Tareas = 7, Proyecto = 8, Examen = 6 };
            Console.WriteLine("Calificación del alumno de licenciatuda: {0}", al2.Calificacion());
            Alumno al3 = new Posgrado { Proyecto = 8, Examen = 7 };
            Console.WriteLine("Calificación del alumno de posgrado: {0}", al3.Calificacion());


            Console.ReadKey();
        }
    }
}
