using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class DevolucionDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public DevolucionDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int insertarDevolucion(string numero_parte, string responsable, DateTime fecha, int cantidad_ingresada, string descripcion)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Devolucion(Numero_Parte,Responsable,Fecha,Cantidad_Ingresada,Descripcion)values(@Numero_Parte,@Responsable,@Fecha,@Cantidad_Ingresada,@Descripcion)";
            comando.Parameters.AddWithValue("@Numero_Parte", numero_parte); ;
            comando.Parameters.AddWithValue("@Responsable", responsable);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Cantidad_Ingresada", cantidad_ingresada);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);


            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Devolucion> MostrarDevolucion()
        {
            List<Devolucion> devoluciones = new List<Devolucion>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Devolucion";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                devoluciones.Add(new Devolucion(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetDateTime(2).ToString("yyyy/MM/dd"),
                    list.GetInt32(3),
                    list.GetString(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return devoluciones;

        }



    }
}