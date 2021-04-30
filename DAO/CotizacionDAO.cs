using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class CotizacionDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;
        auxiliar aux = new auxiliar();
        public CotizacionDAO()
        {
            this.conexion = Conexion.getConexion();
        }



        public Cotizaciones MostrarCotizacion(string ID)
        {
            Cotizaciones devoluciones = new Cotizaciones();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Cotizacion where  ID_Cotizacion = @ID";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Cotizaciones coti = new Cotizaciones(
                    aux.GetBadgeString(list.GetInt32(0)),
                    list.GetDateTime(1).ToString(),
                    list.GetString(2),
                    list.GetString(3),
                    list.GetDouble(4));
                devoluciones = coti;
            }
            list.Dispose();
            comando.Dispose();
            return devoluciones;

        }
        public int Maximo()
        {
            Cotizaciones devoluciones = new Cotizaciones();
            SqlCommand comando = new SqlCommand();
            int Max = 0;
            comando.Connection = conexion;
            comando.CommandText = "SELECT MAX(ID_Cotizacion) FROM Cotizacion";
       

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Max = list.GetInt32(0);
            }
            list.Dispose();
            comando.Dispose();
            return Max;

        }

        public List<Cotizaciones> MostrarCotizaciones()
        {
            List<Cotizaciones> devoluciones = new List<Cotizaciones>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Cotizacion where Estado= '1'";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                devoluciones.Add(new Cotizaciones(
                  aux.GetBadgeString(list.GetInt32(0)),
                    list.GetDateTime(1).ToString("yyyy/MM/dd"),
                    list.GetString(2),
                    list.GetString(3),
                  
                    list.GetDouble(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return devoluciones;

        }
        public List<Cotizaciones> MostrarCotizacionesAceptadas()
        {
            List<Cotizaciones> devoluciones = new List<Cotizaciones>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Cotizacion where Estado ='0'";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                devoluciones.Add(new Cotizaciones(
                   aux.GetBadgeString(list.GetInt32(0)),
                    list.GetDateTime(1).ToString(),
                    list.GetString(2),
                    list.GetString(3),
                   
                    list.GetDouble(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return devoluciones;

        }
        public decimal insertar(Cotizaciones cotizacion)
        {

            decimal result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Cotizacion(Fecha,Cliente,Estado,Total) values(@Fecha,@Cliente,@Estado,@Total); SELECT SCOPE_IDENTITY() AS PK;";
            comando.Parameters.AddWithValue("@Fecha", cotizacion.Fecha);
            comando.Parameters.AddWithValue("@Cliente", cotizacion.Cliente);
            comando.Parameters.AddWithValue("@Estado", "1");
            comando.Parameters.AddWithValue("@Total", cotizacion.Total);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                result = list.GetDecimal(0);


            }
            list.Dispose();
            comando.Dispose();

            return result;

        }
    }

}