using Montres.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Montres.DAO
{
    public class UsuarioDAO
    {
        public SqlConnection conexion;
        public SqlTransaction transaction;
        public string error;

        public UsuarioDAO()
        {
            this.conexion = Conexion.getConexion();
        }

        public int insertar(Usuario usuario)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Usuario(Cedula,Nombre,Correo,Telefono,Rol,Estado,Contrasena)values(@Cedula,@Nombre,@Correo,@Telefono,@Rol,@Estado,@Contrasena)";
            comando.Parameters.AddWithValue("@Cedula", usuario.Cedula); ;
            comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@Correo", usuario.Correo);
            comando.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            comando.Parameters.AddWithValue("@Rol", usuario.Rol);
            comando.Parameters.AddWithValue("@Estado", usuario.Estado);
            comando.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int actualizar(string nombre, string correo, string telefono, int rol, string estado, string cedula)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Usuario set Nombre=@Nombre ,Correo=@Correo ,Telefono=@Telefono ,Rol=@Rol,Estado=@Estado  where Cedula=@Cedula";
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Rol", rol);
            comando.Parameters.AddWithValue("@Estado", estado);
            comando.Parameters.AddWithValue("@Cedula", cedula);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public List<Usuario> MostrarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Usuario";


            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                usuarios.Add(new Usuario(
                    list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetString(3),
                    list.GetInt32(4),
                    list.GetString(5),
                    list.GetString(6)
                    ));
            }
            list.Dispose();
            comando.Dispose();
            return usuarios;

        }


        public string Nombre(string cedula)
        {
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select Nombre from Usuario where Cedula = @Cedula";
            comando.Parameters.AddWithValue("@Cedula", cedula);

            string res = null;

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                res = list.GetString(0);
            }
            list.Dispose();
            comando.Dispose();
            return res;
        }


        public Usuario listaUsuarios(string ID)
        {
            Usuario usuarios = new Usuario();
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "select * from Usuario where Cedula=@ID";
            comando.Parameters.AddWithValue("@ID", ID);

            SqlDataReader list = comando.ExecuteReader();
            while (list.Read())
            {
                Usuario detalle_usuario = new Usuario(
                   list.GetString(0),
                    list.GetString(1),
                    list.GetString(2),
                    list.GetString(3),
                    list.GetInt32(4),
                    list.GetString(5),
                    list.GetString(6)

                    );

                usuarios = detalle_usuario;
            }
            list.Dispose();
            comando.Dispose();
            return usuarios;

        }
        public int ValidarUser(string ID)
        {
            int res = 0;
          
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "if  Exists (select Nombre from Usuario where Cedula = @ID) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END";
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
        public int insertarSalida(string Cliente, string Descripcion, int Cantidad, string Encargado, string Despacho, DateTime Fecha, string Numero_Parte, string Numero_Factura)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "insert into Salida_Producto(Cliente,Descripcion,Cantidad,Encargado,Despacho,Fecha,Numero_Parte,Numero_Factura)values(@Cliente,@Descripcion,@Cantidad,@Encargado,@Despacho,@Fecha,@Numero_Parte,@Numero_Factura)";
            comando.Parameters.AddWithValue("@Cliente", Cliente); 
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Encargado", Encargado);
            comando.Parameters.AddWithValue("@Despacho", Despacho);
            comando.Parameters.AddWithValue("@Numero_Factura", Numero_Factura);
            comando.Parameters.AddWithValue("@Fecha", Fecha);
            comando.Parameters.AddWithValue("@Numero_Parte", Numero_Parte);
     
            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Desactivar(string codigo)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Usuario set Estado='Desactivo' where Cedula='@codigo'";
            comando.Parameters.AddWithValue("@codigo", codigo);

            result = comando.ExecuteNonQuery();

            return result;

        }

        public int Contrasena(string cedula, string contrasena)
        {

            int result = 0;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = "update Usuario set Contrasena=@Contrasena where Cedula=@codigo";
            comando.Parameters.AddWithValue("@Contrasena", contrasena);
            comando.Parameters.AddWithValue("@codigo", cedula);

            result = comando.ExecuteNonQuery();

            return result;

        }
    }
}