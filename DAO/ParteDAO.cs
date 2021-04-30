using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class ParteDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public ParteDAO()
        {
            this.conexion = Conexion.getConexion();
        }


        public List<Partes> MostrarPartes()
        {
            List<Partes> partes = new List<Partes>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Partes";

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                partes.Add(new Partes(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetInt32(4),
                    list.GetInt32(5),
                    list.GetDouble(6),
                    list.GetString(7),      
                    list.GetString(8),
                    list.GetDateTime(9).ToString("yyyy/MM/dd")
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return partes;

        }

        public int insertar(Partes parte)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Partes(Numero_Parte,Descripcion,Ubicacion,Cantidad_Inicial,Cantidad_Stock,Cantidad_Minima,Precio,Fecha_Entrada,Numero_Factura,Proveedor)values(@Numero_Parte,@Descripcion,@Ubicacion,@Cantidad_Inicial,@Cantidad_Stock,@Cantidad_Minima,@Precio,@Fecha_Entrada,@Numero_Factura,@Proveedor)";
            comando.Parameters.AddWithValue("@Numero_Parte", parte.Numero_Parte);
            comando.Parameters.AddWithValue("@Descripcion", parte.Descripcion);
            comando.Parameters.AddWithValue("@Ubicacion", parte.Ubicacion);
            comando.Parameters.AddWithValue("@Cantidad_Inicial", parte.Cantidad_Inicial);
            comando.Parameters.AddWithValue("@Cantidad_Stock", parte.Cantidad_Stock);
            comando.Parameters.AddWithValue("@Cantidad_Minima", parte.Cantidad_Minima);
            comando.Parameters.AddWithValue("@Precio", parte.Precio);
            comando.Parameters.AddWithValue("@Fecha_Entrada", parte.Fecha_Entrada);
            comando.Parameters.AddWithValue("@Numero_Factura", parte.Numero_Factura);
            comando.Parameters.AddWithValue("@Proveedor", parte.Proveedor);


            result = comando.ExecuteNonQuery();

            return result;

        }



        

        public Partes Filtrar(string ID)
        {
            Partes partes = new Partes();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Partes where Numero_Parte=@ID";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

            Partes detalle_parte =  new Partes(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetInt32(3),
                    list.GetInt32(4),
                    list.GetInt32(5),
                    list.GetDouble(6),
                    list.GetString(7),
                    list.GetString(8),
                    list.GetDateTime(9).ToString("yyyy/MM/dd")

                    );

                partes = detalle_parte;
            }

            list.Dispose();
            comando.Dispose();
            return partes;

        }



        public int Eliminar(Partes parte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Descripcion='@Descripcion' ,Ubicacion='@Descripcion' ,Cantidad_Inicial='@Cantidad_Inicial' ,Cantidad_Stock='@Cantidad_Stock',Cantidad_Minima='@Cantidad_Minima',Precio='@Precio',Proveedor='@Proveedor',Numero_Factura='@Numero_Factura'  where Numero_Parte='@Numero_Parte'";
            comando.Parameters.AddWithValue("@Descripcion", parte.Descripcion);
            comando.Parameters.AddWithValue("@Ubicacion", parte.Ubicacion);
            comando.Parameters.AddWithValue("@Cantidad_Inicial", parte.Cantidad_Inicial);
            comando.Parameters.AddWithValue("@Cantidad_Stock", parte.Cantidad_Stock);
            comando.Parameters.AddWithValue("@Cantidad_Minima", parte.Cantidad_Minima);
            comando.Parameters.AddWithValue("@Precio", parte.Precio);
            comando.Parameters.AddWithValue("@Proveedor", parte.Proveedor);
            comando.Parameters.AddWithValue("@Numero_Factura", parte.Numero_Factura);
            comando.Parameters.AddWithValue("@Numero_Parte", parte.Numero_Parte);
            result = comando.ExecuteNonQuery();

            return result;

        }



        public int UpdCantidadStock(int stock, string codigo)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Cantidad_Stock=@Cantidad_Stock where Numero_Parte=@Numero_Parte";
            comando.Parameters.AddWithValue("@Cantidad_Stock", stock);
            comando.Parameters.AddWithValue("@Numero_Parte", codigo);
            result = comando.ExecuteNonQuery();

            return result;

        }


        public int UpdCantidadInicial(int inicial, string codigo)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Cantidad_Inicial=@Cantidad_Inicial where Numero_Parte=@Numero_Parte";
            comando.Parameters.AddWithValue("@Cantidad_Inicial", inicial);
            comando.Parameters.AddWithValue("@Numero_Parte", codigo);
            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Validarparte(string ID)
        {
            int res = 0;

            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "if  Exists (select Descripcion from Partes where Numero_Parte = @ID) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {

                res = list.GetInt32(0);

            }
            list.Dispose();
            comando.Dispose();
            return res;

        }

        public int actualizar(string descripcion, string ubicacion, int cantidad_inicial, int cantidad_stock, int cantidad_minima, double precio, string proveedor, string numero_factura, string numero_parte)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Descripcion=@Descripcion ,Ubicacion=@Ubicacion ,Cantidad_Inicial=@Cantidad_Inicial ,Cantidad_Stock=@Cantidad_Stock,Cantidad_Minima=@Cantidad_Minima,Precio=@Precio,Proveedor=@Proveedor,Numero_Factura=@Numero_Factura,Numero_Parte=@Numero_Parte  where Numero_Parte=@Numero_Parte";
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Ubicacion", ubicacion);
            comando.Parameters.AddWithValue("@Cantidad_Inicial", cantidad_inicial);
            comando.Parameters.AddWithValue("@Cantidad_Stock", cantidad_stock);
            comando.Parameters.AddWithValue("@Cantidad_Minima", cantidad_minima);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Proveedor", proveedor);
            comando.Parameters.AddWithValue("@Numero_Factura", numero_factura);
            comando.Parameters.AddWithValue("@Numero_Parte", numero_parte);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Retirar_Parte(int cantidad, string numero_parte)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Cantidad_Stock=@Stock where Numero_Parte=@Numero_Parte";
            comando.Parameters.AddWithValue("@Stock", cantidad);
            comando.Parameters.AddWithValue("@Numero_Parte", numero_parte);
            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Retiro(int stock, string codigo)
        {
            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Partes set Cantidad_Stock=@Cantidad_Stock where Numero_Parte=@Numero_Parte";
            comando.Parameters.AddWithValue("@Cantidad_Stock", stock);
            comando.Parameters.AddWithValue("@Numero_Parte", codigo);
            result = comando.ExecuteNonQuery();

            return result;

        }
    }
}