using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class SalidaDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public SalidaDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public List<Salida> MostrarSalidas()
        {
            List<Salida> salidas = new List<Salida>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Salida_Producto";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                salidas.Add(new Salida(
                    list.GetInt32(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetString(4),
                    list.GetString(5),
                    list.GetDateTime(7).ToString("yyyy/MM/dd"),
                    list.GetString(8)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return salidas;

        }

        public int actualizar_salida(int id_salida, int cantidad)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Salida_Producto set Cantidad=@cantidad where ID_Salida=@id_salida";
            comando.Parameters.AddWithValue("@id_salida", id_salida);
            comando.Parameters.AddWithValue("@cantidad", cantidad);

            result = comando.ExecuteNonQuery();

            return result;

        }

    }
}