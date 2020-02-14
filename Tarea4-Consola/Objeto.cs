using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Linq;

namespace Tarea4_Consola
{
    class Objeto
    {
        public static string rutaOrigen { get; set; }
        public static string rutaDestino { get; set; }
        public Objeto(string origen, string destino)
        {
            rutaOrigen = origen;
            rutaDestino = destino;
        }
        public void Copiar()
        {
            File.Copy(rutaOrigen, rutaDestino, true);
        }
        public void Mover()
        {
            File.Move(rutaOrigen, rutaDestino, true);
        }
    }
}
