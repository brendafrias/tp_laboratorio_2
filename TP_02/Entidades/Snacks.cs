using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {

        #region Constructor
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        #endregion

        #region Metodos
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("SNACKS \n");
            sb.AppendFormat(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
