using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class EntradaDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public EntradaDAO()
        {
            this.conexion = Conexion.getConexion();
        }



        public List<Entrada> MostrarEntradas()
        {
            List<Entrada> Entradas = new List<Entrada>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Entrada_Partes";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Entrada client = new Entrada();
                client.Numero_Parte = list.GetString(0);
                client.Responsable = list.GetString(1);
                client.Fecha = list.GetDateTime(2).ToString("yyyy/MM/dd");        
                client.Cantidad_Ingresada = list.GetInt32(3);
                client.Descripcion = list.GetString(4);
                client.Proveedor = list.GetString(5);
                client.Numero_Factura = list.GetString(6);
                client.Precio = list.GetDouble(7);
                Entradas.Add(client);

            }
            list.Dispose();
            comando.Dispose();
            return Entradas;

        }

        public int insertarEntrada(string Numero_Parte, string Responsable, DateTime Fecha, int Cantidad_Ingresada, string Descripcion, double Precio, string Numero_Factura, string Proveedor)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Entrada_Partes(Numero_Parte,Responsable,Fecha,Cantidad_Ingresada,Descripcion,Precio,Numero_Factura,Proveedor)values(@Numero_Parte,@Responsable,@Fecha,@Cantidad_Ingresada,@Descripcion,@Precio,@Numero_Factura,@Proveedor)";
            comando.Parameters.AddWithValue("@Numero_Parte", Numero_Parte); ;
            comando.Parameters.AddWithValue("@Responsable", Responsable);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Cantidad_Ingresada", Cantidad_Ingresada);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@Numero_Factura",Numero_Factura);
            comando.Parameters.AddWithValue("@Proveedor", Proveedor);

            result = comando.ExecuteNonQuery();

            return result;

        }

    }
}