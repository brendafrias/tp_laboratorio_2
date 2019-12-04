using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        // <summary>
        /// Metodo para guardar.
        /// </summary>
        /// <param name="archivo"> PATH del archivo </param>
        /// <param name="datos"> Datos que se van a guardar </param>
        /// <returns> True -> Guardo los datos // False -> No los guardo </returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter stream = new StreamWriter(archivo, false))
                {
                    stream.Write(datos);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Metodo para leer .
        /// </summary>
        /// <param name="archivo"> PATH del archivo </param>
        /// <param name="datos"> Cadena donde se van a guardar los que se va a leer </param>
        /// <returns> True -> Pudo leer los datos // False -> No pudo leer los datos </returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool retorno = false;
            try
            {
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
