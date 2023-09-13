using System;
using System.Data;
using System.Data.SqlClient;

namespace webapp_impl_service.dbaccess
{
	public class DBAccessHelper
	{
		public DBAccessHelper()
		{
		}

        public static string mensajes = string.Empty;
        public static bool opStatus = false;

        public static SqlCommand CreateSQLCommand(string nombreProcedimiento)
        {
            string conexionBD = DBConfiguration.DBConnection;
            SqlConnection cnx = new SqlConnection(conexionBD);
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandText = nombreProcedimiento;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }
        /// <summary>
        /// Crear parametros para el comando
        /// </summary>
        public static SqlParameter ParameterAdd(SqlCommand cmd, string nombre, SqlDbType tipo, object valor)
        {
            SqlParameter para = new SqlParameter();
            para = cmd.CreateParameter();
            para.ParameterName = nombre;
            para.Value = valor;
            para.SqlDbType = tipo;
            cmd.Parameters.Add(para);
            return para;
        }
        public static DataTable ExecuteSQLSelect(SqlCommand command)
        {
            DataTable tabla = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                tabla.Load(reader);
                reader.Close();
                opStatus = true;
            }
            catch (Exception ex)
            {
                opStatus = false;
                mensajes = "Ha ocurrido un error al intentar establecer comunicación con el servidor. Contacte a su administrador de sistemas\nEl detalle del error es:" + ex.Data.ToString();
            }
            finally
            {
                command.Connection.Close();
            }
            return tabla;
        }

        /// <summary>
        /// Ejecutar Scalar
        /// </summary>
        /// <param name="command">Comando SQL</param>
        /// <returns></returns>
        public static object ExecuteSQLScalar(SqlCommand command)
        {
            object valorObtenido = "";
            try
            {
                command.Connection.Open();
                valorObtenido = command.ExecuteScalar();
                opStatus = true;
            }
            catch (Exception)
            {
                opStatus = false;
                mensajes = "Ha ocurrido un error al intentar establecer comunicación con el servidor. Contacte a su administrador de sistemas";
            }
            finally
            {
                command.Connection.Close();
            }
            return valorObtenido;
        }
        /// <summary>
        /// Ejecutar NonQuery
        /// </summary>
        /// <param name="command">Comando SQL</param>
        /// <returns></returns>
        public static int ExecuteSQLNonQuery(SqlCommand command)
        {
            int renglonesAfectados = -1;
            try
            {
                command.Connection.Open();
                renglonesAfectados = command.ExecuteNonQuery();
                opStatus = true;
            }
            catch (Exception)
            {
                opStatus = false;
                mensajes = "Ha ocurrido un error al intentar establecer comunicación con el servidor. Contacte a su administrador de sistemas";
            }
            finally
            {
                command.Connection.Close();
            }
            return renglonesAfectados;
        }
    }
}

