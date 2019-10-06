using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerado
        public enum ETipo { Entera, Descremada }
        #endregion

        #region Atributos
        private ETipo tipo;
        private short cantidadCalorias = 20;
        #endregion


        #region Construcotr
        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            tipo = ETipo.Entera;
        }

        public Leche(EMarca marca,string codigo,ConsoleColor color , ETipo tipo) 
            :this(marca,codigo,color)
        {
            this.tipo = tipo;
        }

        #endregion


        #region Propiedades
        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return this.cantidadCalorias;
            }
        }
        #endregion

        #region Metodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("LECHE \n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : " + this.tipo);
            sb.AppendFormat("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        
        #endregion
    }
}
