using System;
using System.Collections.Generic;
using System.Text;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Constructor
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SinProfesorException"/>.
        /// </summary>
        public SinProfesorException() : base("No hay profesor para la clase")
        {

        }
        #endregion
    }
}
