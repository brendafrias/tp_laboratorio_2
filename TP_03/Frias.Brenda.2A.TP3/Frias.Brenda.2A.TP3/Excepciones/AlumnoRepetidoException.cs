using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AlumnoRepetidoException"/>.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
        #endregion
    }
}
