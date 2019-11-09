using System;
using System.Collections.Generic;
using System.Text;
using EntidadesInstansiables;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        /// <summary>
        /// Construcotr por default de la clase Universitario
        /// </summary>
        #region Constructor
        public Universitario()
        {

        }

        /// <summary>
        /// Construcotr con 5 parametros, asigna las propiedades de la clase base(persona)
        /// y a la clase Universitario.
        /// </summary>
        /// <param name="legajo">Atibuto de la clase Universitario</param>
        /// <param name="nombre">Atributo heredado de la clase Persona</param>
        /// <param name="apellido">Atributo heredado de la clase Persona</param>
        /// <param name="dni">Atributo heredado de la clase Persona</param>
        /// <param name="nacionalidad">Atributo heraddo de la clase Persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo Equals, sobreescrito verifica que el obejeto (obj) pasado por parametro
        /// sea del tipo Universitario y si lo es retorna el objeto casteado, si no lo es retornara false
        /// </summary>
        /// <param name="obj">Objeto a ser verificado</param>
        /// <returns>un obj de tipo Universitario si el obj es uUniversitario, o false si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                retorno = (((Universitario)obj) == this);
            }
            return retorno;
        }
        /// <summary>
        /// Muestra los datos de la clase base(Persona) mas el atributo legajo
        /// de la clase Universitario
        /// </summary>
        /// <returns>Retorna una cadena con todos los atributos de la clase Persona mas un atributo de la clase Universitario</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLEGAJO NUMERO: " + this.legajo + "\n";
        }

        /// <summary>
        /// Metodo sin implementacion
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara que los parametros pasados no sean iguales,
        /// llama al operador ==.
        /// </summary>
        /// <param name="pg1">obj a ser comparado</param>
        /// <param name="pg2">obj a ser comparado</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Compara que los parametros sean iguales, teniendo encuenta los atributos
        /// legajo o DNI.
        /// </summary>
        /// <param name="pg1">obj a ser comparado</param>
        /// <param name="pg2">obj a ser comparado</param>
        /// <returns>retorna true si los objetos considen en legajo o en dni, retorna false si los objetos no coinsiden</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {

            if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
