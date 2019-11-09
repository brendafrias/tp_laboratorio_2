using System;
using System.Collections.Generic;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstansiables
{
    public sealed class Alumno : Universitario
    {
        #region Aributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por default de la clase Alumno.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de la clase Alumno, con seis parametros, hereda de Universitario
        /// asigna un atributo propio de su clase (claseQueToma).
        /// </summary>
        /// <param name="id">atributo heredado</param>
        /// <param name="nombre">atributo heredado</param>
        /// <param name="apellido">atributo heredado</param>
        /// <param name="dni">atributo heredado</param>
        /// <param name="nacionalidad">atributo heredado</param>
        /// <param name="claseQueToma">atributo propio</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Construcor de la clase Alumno con siete parametros, hereda de Universitario.
        /// </summary>
        /// <param name="id">parametro heredado</param>
        /// <param name="nombre">Parametro heredado</param>
        /// <param name="apellido">parametro heredado</param>
        /// <param name="dni">Parametro heredado</param>
        /// <param name="nacionalidad">Parametro heredado</param>
        /// <param name="claseQueToma">Parametro propio</param>
        /// <param name="estadoCuenta">Parametro propio</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Metodo sobreescrito, muestra una cadena con todos los atributos heredados y propios.
        /// tambien verifica el estado de cuenta y lo retorna en la cadena.
        /// </summary>
        /// <returns>retorna una cadena con todos los atributos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendFormat("\nESTADO DE CUENTA: {0}", "Cuota al día");
                    break;
                case EEstadoCuenta.Deudor:
                case EEstadoCuenta.Becado:
                    sb.AppendFormat("\nESTADO DE CUENTA: {0}", this.estadoCuenta);
                    break;
                default:
                    break;
            }
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        ///  retorna la clase que toma un alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("\nTOMA CLASES DE {0}", this.claseQueToma ,"\n");
        }
        /// <summary>
        /// Muestra todos los atributos mediante el metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Verifica que el alumno toma esa clase y que el estado de cuenta no sea deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// verifica que la clase que toma no sea igual a la clase pasada por parametro
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma != clase);
        }
        #endregion

        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        #endregion
    }
}
