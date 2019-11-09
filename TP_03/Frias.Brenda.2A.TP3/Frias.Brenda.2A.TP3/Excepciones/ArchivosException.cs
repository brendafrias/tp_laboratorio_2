using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ArchivosException"/>.
        /// </summary>
        public ArchivosException(Exception innerException) : base("Error en el archivo", innerException)
        {

        }
        #endregion
    }
}
