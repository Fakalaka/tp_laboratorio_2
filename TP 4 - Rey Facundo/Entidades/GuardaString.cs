using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda un texto en un archivo.
        /// </summary>
        /// <param name="texto">Texto a guardar</param>
        /// <param name="archivo">Ruta del archivo</param>
        /// <returns>True si se pudo, false si no</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(texto);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
