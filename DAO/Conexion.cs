using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class Conexion
    {
        private static SqlConnection objConexion;
        private static string error;

        public Conexion() { }
        public static SqlConnection getConexion()
        {
            if (objConexion != null)
            {
                return objConexion;
            }
            objConexion = new SqlConnection();
            objConexion.ConnectionString = "Data Source=localhost;Initial Catalog=SIMM ;User ID=Montres;Password=root;";
            try
            {
                objConexion.Open();
                return objConexion;
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }
        }
        public static void cerrarConexion()
        {
            if (objConexion != null)
            {
                objConexion.Close();
            }
        }
    }
}