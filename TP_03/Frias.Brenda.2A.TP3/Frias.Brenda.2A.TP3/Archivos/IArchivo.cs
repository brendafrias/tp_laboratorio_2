using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz creada para poder guardar y leer archivos en formato
    /// Texto y formato Xml
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo usado para guardar datos especificados en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Datos a guardar en el archivo</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se guardo exitosamente, <see cref="false"/> si no pudo guardar el archivo.</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo usado para leer un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta al archivo.</param>
        /// <param name="datos">Parametro de salida de los datos</param>
        /// <returns>Retorna <see cref="true"/> si se pudo lerr el archivo, <see cref="false"/> si no pudo leerse el archivo.</returns>
        bool Leer(string archivo, out T datos);
    }
}