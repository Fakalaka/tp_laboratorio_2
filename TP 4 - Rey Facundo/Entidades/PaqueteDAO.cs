using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Inicializa la conexión.
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True;");
        }

        /// <summary>
        /// Guarda los datos de un paquete en la base de datos.
        /// </summary>
        /// <param name="p">Paquete a guardar</param>
        /// <returns>True si hubo éxito</returns>
        public static bool Insertar(Paquete p)
        {
            conexion.Open();
            string command = String.Format("INSERT INTO Paquetes(direccionEntrega,trackingID,alumno) VALUES('{0}','{1}','{2}')",
                p.DireccionEntrega, p.TrackingID, "Facundo Rey 2D");
            comando = new SqlCommand(command, conexion);

            try
            {
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
