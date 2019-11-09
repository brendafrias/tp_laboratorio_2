using System;
using System.Collections.Generic;
using System.Text;
using EntidadesInstansiables;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Apellido: es usada para asignarle un valor al atributo privado apellido,
        /// tambien es usado para retornar el valor de dicho atributo
        /// </summary>
        public string Apellido { get { return this.apellido; } set { this.ValidarNombreApellido(value); } }

        /// <summary>
        /// Propiedad DNI: es usada para asignarle un valor al atributo privado dni comprobando
        /// sus valores con el metodo ValidarDni().
        /// tambien es usado para retornar el valor de dicho atributo
        /// </summary>
        public int DNI { get { return this.dni; } set { this.dni = this.ValidarDni(this.nacionalidad, value); } }

        /// <summary>
        /// Propiedad Nacionalidad: es usada para asignarle un valor al atributo privado nacionalidad,
        /// tambien es usado para retornar el valor de dicho atributo
        /// </summary>
        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }

        /// <summary>
        /// Propiedad Nombre: es usada para asignarle un valor al atributo privado nombre
        /// validando que el parametro sea correcto mediante el metodo ValidarNombreApellido 
        /// tambien es usado para retornar el valor de dicho atributo
        /// </summary>
        public string Nombre { get { return this.nombre; } set { this.nombre = this.ValidarNombreApellido(value); } }

        /// <summary>
        /// Propiedad StringToDNI: establece el dni de una persona de tipo string.
        /// </summary>
        public string StringToDNI { set { this.DNI = ValidarDni(this.Nacionalidad, value); } }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por default de la clase Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de la clase Persona, recibe tres parametros
        /// y se los asigna a los atributos correspondientes.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de la clase Persona, recibe cuatro parametros,
        /// llama a otro constructor con 3 parametros para reutilizar codigo,
        /// y asigna el parametro sobrante al atributo correspondiente.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionaldiad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionaldiad) : this(nombre, apellido, nacionaldiad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor sobrecargado, la variacion de este constructor es que
        /// el parametro dni cambia de int a string, utiliza el metodo StringToDNI
        /// para hacer una convercion explicita.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }


        /// <summary>
        ///Sobre escritura del metodo ToString
        ///Devuelve los atributos de una persona(apellido,nombre,nacionalidad)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            return sb.ToString();
        }

        /// <summary>
        /// Este metodo valida que el dni sea valido y que corresponda a la nacionalidad dada
        /// valida que el dni sea mayor o igual a 1 y menor o igual que 89999999
        /// o que sea mayor que 90000000 y menor o igual que 99999999, caso contrario
        /// arrojara la excepcion NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona para ser utilizada en las validaciones</param>
        /// <param name="dato">Dato a ser validado</param>
        /// <returns>Retornara la variable dato en caso de cumplir con las validaciones caso contrario retornara 0</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = 0;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:

                    if (dato >= 1 && dato <= 89999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;

                default:
                    break;
            }
            return retorno;

        }

        /// <summary>
        /// Este metodo convierte un dni de tipo string a int, caso contrario
        /// arrojara la excepcion DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona para ser utilizada en las validaciones</param>
        /// <param name="dato">Dato a ser validado</param>
        /// <returns>Retornara la variable dato en caso de cumplir con las validaciones caso contrario retornara 0</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            int retorno = 0;
            if (dato.Length >= 1 && dato.Length <= 8 && (int.TryParse(dato, out dni)))
            {
                retorno = dni;
            }
            else
            {
                throw new DniInvalidoException();
            }
            return retorno;
        }


        /// <summary>
        /// Metodo utilizado para validar al parametro dato que todos sus caracteres sean letras
        /// </summary>
        /// <param name="dato">Dato a validar que contenga solo letras</param>
        /// <returns>Retornara el dato en caso de que solo contenga letras, caso contrario retornara false</returns>
        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            string retorno = "";
            foreach (char item in dato)
            {
                if (!(Char.IsLetter(item)))
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                retorno = dato;
            }
            return retorno;
        }
        #endregion

        #region Enumerados
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
