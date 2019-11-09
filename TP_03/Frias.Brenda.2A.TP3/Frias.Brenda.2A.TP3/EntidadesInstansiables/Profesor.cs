using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstansiables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Metodos
        /// <summary>
        /// Genera clases random para un profesor.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
            this.clasesDelDia.Enqueue(((Universidad.EClases)Profesor.random.Next(0, 4)));
        }

        /// <summary>
        /// Metodo sobreescrito, retornara un string con toda la informacion del profesor mas
        /// la participacion de la clase.
        /// </summary>
        /// <returns>Retornara una cadena con los atributos del profesor mas la participacion de clase</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }


        /// <summary>
        /// Verifica que el profesor no este en esa clase, retornara true si no esta
        /// o false si esta en ninguna clase del dia.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }


        /// <summary>
        /// Verifica que el profesor este en esa clase, retornara true si esta
        /// o false si no esta en ninguna clase del dia.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clases)
        {
            bool retorno = false;
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clases)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo sobreescrito, retornara un string diciendo cual es la clase deldia,
        /// para eso recorre las clasesDelDia.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases clases in this.clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por default de la clase Profesor. inizializa
        /// el atributo random para que no sea null.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        /// <summary>
        /// Constructor por default de la clase Profesor (vacio).
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructor de la clase Profesor con 5 parametros hereda del base Universitario
        /// carga los atributos de Universitario y los atributos propios claseDelDia , _randomClases.
        /// </summary>
        /// <param name="id">Atributo heredado de Universitario</param>
        /// <param name="nombre">Atributo heredado de Universitario</param>
        /// <param name="apellido">Atributo heredado de Universitario</param>
        /// <param name="dni">Atributo heredado de Universitario</param>
        /// <param name="nacionalidad">Atributo heredado de Universitario</param>
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad) : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Metodo sobreescrito, retorna un string con todos
        /// los atributos de la clase Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion
    }
}
