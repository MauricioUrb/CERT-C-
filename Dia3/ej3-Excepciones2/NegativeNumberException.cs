using System;
using System.Collections.Generic;
using System.Text;

namespace ej3_Excepciones2
{
    class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base("Opearción inválida con número negativo") { }
        public NegativeNumberException(string Mensaje) : base(Mensaje) { }
    }
}
