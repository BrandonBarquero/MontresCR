using Montres.DAO;
using Montres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Montres
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string Rol = (string)(Session["Rol"]);

            if (Rol == "2" || Rol == "3")
            {
                Response.Redirect("Error_403.aspx");
                return;
            }

            UsuarioDAO dao = new UsuarioDAO();

            List<Usuario> list = dao.MostrarUsuarios();

            foreach (Usuario element in list)
            {
                TableRow row = new TableRow();
                row.Attributes.Add("Style", "background-color: #fff;");
                row.Attributes.Add("TableSection", "TableBody");
                TableCell cell = new TableCell();
                TableCell cel2 = new TableCell();
                TableCell cel3 = new TableCell();
                TableCell cel4 = new TableCell();
                TableCell cel5 = new TableCell();
                TableCell cel6 = new TableCell();
                TableCell cel7 = new TableCell();
               

                cell.Text = element.Nombre;
                cel2.Text = element.Cedula;
                cel3.Text = element.Correo;
                cel4.Text = element.Estado;
                cel5.Text = element.Rol.ToString();
                cel6.Controls.Add(new LiteralControl("<a href=''/><button class='btn btn-light'><i class='zmdi zmdi-refresh'></i></button>"));
                cel7.Controls.Add(new LiteralControl("<a href='' /><button class='btn btn-light'><i class='zmdi zmdi-lock'></i></button>"));
                cel6.HorizontalAlign = HorizontalAlign.Center;
                cel7.HorizontalAlign = HorizontalAlign.Center;



                row.Cells.Add(cell);
                row.Cells.Add(cel2);
                row.Cells.Add(cel3);
                row.Cells.Add(cel4);
                row.Cells.Add(cel5);
                row.Cells.Add(cel6);
                row.Cells.Add(cel7);

                tableU.Rows.Add(row);
            }

            






        }
    }
}