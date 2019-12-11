using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            PaqueteDAO.comando = new SqlCommand();         
            //PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion); //El proyecto no funciona si se abre la base de datos desde properties.
            PaqueteDAO.conexion = new SqlConnection("Data Source = MONSTERPC\\SQLEXPRESS; Initial Catalog =correo-sp-2017; Integrated Security = True");//se debera cambiar en esta linea de codigo el nombre del servidor
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }

        public static bool Insertar(Paquete p)
        {
            string comando = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)" +
                " VALUES ('{0}','{1}','Frias Brenda')", p.DireccionEntrega, p.TrakingID);
            PaqueteDAO.comando.CommandText = comando;
            PaqueteDAO.conexion.Open();
            PaqueteDAO.comando.ExecuteNonQuery();
            PaqueteDAO.conexion.Close();
            return true;
        }
    }
}