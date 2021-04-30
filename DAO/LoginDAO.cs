using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class LoginDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public LoginDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int consultamenu(Usuario1 user)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select Rol from Usuario where Cedula=@Cedula and Contrasena=@Contrasena and Estado='Activo'";
            comando.Parameters.AddWithValue("@Cedula", user.user);
            comando.Parameters.AddWithValue("@Contrasena", user.contra);
            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return result;

        }
    }
}