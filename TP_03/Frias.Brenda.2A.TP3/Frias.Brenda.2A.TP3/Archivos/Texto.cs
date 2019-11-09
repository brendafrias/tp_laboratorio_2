using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto
    {
        #region Metodos

        /// <summary>
        /// Metodo usado para guardar datos especificados en un archivo,
        /// en caso de no poder hacerlo arrojara un excepcion con el tipo de error ocurrido.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se guardo exitosamente, <see cref="false"/> si no pudo guardar el archivo.</returns>
        public bool Guardar(string archivo,string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter stream = new StreamWriter(archivo, false))
                {
                    stream.Write(datos);
                    retorno = true;
                    stream.Close();
                   
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }


        /// <summary>
        /// Metodo usado para leer un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Parametro de salida de los datos</param>
        /// <returns>Retorna <see cref="true"/> si se pudo lerr el archivo, <see cref="false"/> si no pudo leerse el archivo.</returns>
        public bool Leer(string archivo,out string datos)
        {
            datos = "";
            bool retorno = false;
            try
            {
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    stream.Close();
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        #endregion
    }
}
