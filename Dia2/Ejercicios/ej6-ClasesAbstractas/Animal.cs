using System;
using System.Collections.Generic;
using System.Text;

namespace ej6_ClasesAbstractas
{
    abstract class Animal
    {
        public Animal(string s)
        {
            NombreComun = s;
        }
        private string nombre;
        public string NombreComun
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public abstract string Come
        {
            get;
        }
        public override string ToString()
        {
            return nombre + " " + Come;
        }
    }
}
