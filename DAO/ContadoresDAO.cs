using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class ContadoresDAO
    {

        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ContadoresDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int Contar_Partes()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Partes";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Salidas()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Salida_Producto";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Devoluciones()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Devolucion";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Minimos()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select * from Partes where Cantidad_Stock <= Cantidad_Minima and Cantidad_Minima != 0";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Cotizaciones()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select * from Cotizacion";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }

        public int Contar_Usuarios()
        {
            int contador = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select * from Usuario";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                contador = contador + 1;
            }
            list.Dispose();

            return contador;

        }



    }
}