using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class Partes_CotizacionDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public Partes_CotizacionDAO()
        {
            this.conexion = Conexion.getConexion();
        }


        public List<Partes> MostrarCotizacion(string ID)
        {
            List<Partes> devoluciones = new List<Partes>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select distinct p.Cantidad, pa.Descripcion, pa.Numero_Parte, pa.Ubicacion, pa.Precio from Cotizacion c, Partes_Cotizacion p , Partes pa where  pa.Numero_Parte = p.FK_Parte  and        c.ID_Cotizacion = p.FK_Cotizacion and    c.ID_Cotizacion = @ID";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                devoluciones.Add(new Partes(
                    list.GetInt32(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetString(3),
                    list.GetDouble(4)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return devoluciones;

        }




        public void insertar(List<Partes> partes, string FK_Cotzacion)
        {

            foreach (Partes entidad in partes)
            {

                int result = 0;
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = "insert into Partes_Cotizacion(FK_Parte,Cantidad,FK_Cotizacion)values(@FK_Parte,@Cantidad,@FK_Cotizacion)";
                comando.Parameters.AddWithValue("@FK_Parte", entidad.Numero_Parte); ;
                comando.Parameters.AddWithValue("@Cantidad", entidad.Cantidad_Stock);
                comando.Parameters.AddWithValue("@FK_Cotizacion", FK_Cotzacion);


                result = comando.ExecuteNonQuery();
            }

        }




        public int Eliminar(string ID)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "delete from Partes_Cotizacion where FK_Cotizacion = @ID";
            comando.Parameters.AddWithValue("@ID", ID);
            result = comando.ExecuteNonQuery();

            return result;

        }


        public int actualizar(string ID)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Cotizacion set Estado='0' where ID_Cotizacion = @ID";
            comando.Parameters.AddWithValue("@ID", ID);


            result = comando.ExecuteNonQuery();

            return result;

        }
    }
}