using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Montres.Models
{
    public class Usuario
    {
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private int v;
        private string selectedValue;

        public Usuario()
        {

        }

        public Usuario(string cedula, string contrasena)
        {
            Cedula = cedula;
            Contrasena = contrasena;
        }

        public Usuario(string cedula, string nombre, string correo, string telefono, int rol, string estado, string contrasena)
        {
            Cedula = cedula;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Rol = rol;
            Estado = estado;
            Contrasena = contrasena;
        }

      

        public Usuario(string text1, string text2, string text3, string text4, int v, string selectedValue)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.v = v;
            this.selectedValue = selectedValue;
        }

        public string Cedula { set; get; }
        public string Nombre { set; get; }
        public string Correo { set; get; }
        public string Telefono { set; get; }
        public int Rol { set; get; }
        public string Estado { set; get; }
        public string Contrasena { set; get; }
    }
}