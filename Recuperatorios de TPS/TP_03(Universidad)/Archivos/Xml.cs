using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo Guardar ---> De la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"> PATH del archivo </param>
        /// <param name="datos"> Datos a serializar </param>
        /// <returns> TRUE -> Se pudo guardar // FALSE -> No se pudo guardar </returns>
        /// 
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
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
        /// Metodo para leer ---> De la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"> PATH del archivo </param>
        /// <param name="datos"> Datos que se van a leer </param>
        /// <returns> TRUE -> Se pudo leer // FALSE -> No se pudo leer </returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
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

