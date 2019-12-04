using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo de la Interfaz para ghuardar archivos.
        /// </summary>
        /// <param name="archivo"> Archivo </param>
        /// <param name="datos"> Datos </param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);


        /// <summary>
        /// Metodo de interfaz para leer los datos del archivo.
        /// </summary>
        /// <param name="archivo"> Archivo </param>
        /// <param name="datos"> Datos </param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
