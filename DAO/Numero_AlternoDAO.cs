using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class Numero_AlternoDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Numero_AlternoDAO()
        {
            this.conexion = Conexion.getConexion();
        }


        public int insertar(String numero_parte, String numero_alterno)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Numeros_Partes(Numero_Parte,Partes_Numeros)values(@Numero_Parte,@Numero_Alterno)";
            comando.Parameters.AddWithValue("@Numero_Parte", numero_parte); 
            comando.Parameters.AddWithValue("@Numero_Alterno", numero_alterno);


            result = comando.ExecuteNonQuery();

            return result;

        }



        public List<Numero_Alterno> MostrarAlternoFiltrado(string ID)
        {
            List<Numero_Alterno> Numero_Alternos = new List<Numero_Alterno>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Numeros_Partes where Numero_Parte=@ID";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Numero_Alternos.Add(new Numero_Alterno(
                    list.GetString(0),
                    list.GetString(1)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return Numero_Alternos;

        }

         public List<Numero_Alterno> MostrarPartesAlternativo()
        {
            List<Numero_Alterno> Numero_Alternos = new List<Numero_Alterno>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Numeros_Partes";
           

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Numero_Alternos.Add(new Numero_Alterno(
                    list.GetString(0),
                    list.GetString(1)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return Numero_Alternos;

        }


        public int Eliminar(string numero_parte, string alternativo)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "delete from Numeros_Partes where Numero_Parte=@Numero_Parte and Partes_Numeros=@Partes_Numeros";
            comando.Parameters.AddWithValue("@Numero_Parte", numero_parte);
            comando.Parameters.AddWithValue("@Partes_Numeros", alternativo);
            result = comando.ExecuteNonQuery();

            return result;

        }


        public List<Partes> listaMinimos()
        {
            List<Partes> partes = new List<Partes>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select Numero_Parte,Descripcion,Ubicacion,Cantidad_Minima,Cantidad_Stock from Partes where Cantidad_Stock <= Cantidad_Minima and Cantidad_Minima != 0";
            

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                partes.Add(new Partes(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetInt32(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return partes;

        }

        public List<Partes> listaMinimos2()
        {
            List<Partes> partes = new List<Partes>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select Numero_Parte,Descripcion,Ubicacion,Cantidad_Minima,Cantidad_Stock from Partes where Cantidad_Stock <= Cantidad_Minima and Cantidad_Minima != 0";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                partes.Add(new Partes(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetInt32(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return partes;

        }


        public List<Partes> listaMinimosVacio()
        {
            List<Partes> partes = new List<Partes>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "Select Numero_Parte,Descripcion,Ubicacion,Cantidad_Minima,Cantidad_Stock from Partes where Cantidad_Stock = '0' and Cantidad_Minima != 0";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                partes.Add(new Partes(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetInt32(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return partes;

        }
    }
}