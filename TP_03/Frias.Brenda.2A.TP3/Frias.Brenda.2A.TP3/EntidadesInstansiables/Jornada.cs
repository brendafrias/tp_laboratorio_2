using System;
using System.Collections.Generic;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstansiables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad que le asigna el valor al atributo alumnos, tambien retorna el valor del mismo.
        /// </summary>
        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        /// <summary>
        /// Propiedad que le asigna el valor al atributo Clase, tambien retorna el valor del mismo.
        /// </summary>
        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }
        /// <summary>
        /// Propiedad que le asigna el valor al atributo instructor, tambien retorna el valor del mismo.
        /// </summary>
        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda un archivo de texto "Jornada.txt" del objeto pasado por parametros del tipo Jornada
        /// en caso de no poder tira una exception personalizada de archivos.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>Retorna true si puede guardar el archivo, false si no lo puede guardar</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto writer = new Texto();

            try
            {
                return writer.Guardar("Jornada.txt", jornada.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Constructor por default de la clase Jornada. inizializa atravez de la propiedad Alumnos
        /// una nueva lista de alumnos, para que no sea null.
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de la clase Jornada. con 2 parametros, hereda del constructor por default,
        /// que inicializa la lista alumnos, le asigna atravez de propiedades los valores correspondientes
        /// de los parametros.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase,Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Lee un archivo de texto, del tipo Jornada, en caso de no poder leerlo arroja la
        /// exception: ArchivosException
        /// </summary>
        /// <returns>Retorna un string de lo que contiene el archivo o nada</returns>
        public string Leer()
        {
            Texto reader = new Texto();
            string retorno =" ";

            try
            {
                reader.Leer("Jornada.txt", out retorno);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }

        /// <summary>
        /// Verifica que el alumno no este en la jornada atravez del operador ==.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a una jornada, si este no se encuentra ya en ella.
        /// si se encuentra arroja la exception_ AlumnoRepetidoException.
        /// </summary>
        /// <param name="j">Jornada en la que se verificara si esta el alumno</param>
        /// <param name="a">Alumno a ser verificado</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }

        /// <summary>
        /// Verifica si un alumno esta dentro de una jornada en especifica.
        /// </summary>
        /// <param name="j">Jornada en la que se verificara si el alumno se encuentra a ella</param>
        /// <param name="a">Alumno a ser verificado</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Metodo sobreescrito, retornara un string con la informacion de la clase, y del instructor.
        /// </summary>
        /// <returns>Retorna un string con la clase y el instructor</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }
            return sb.ToString();
        }



        #endregion
    }
}
