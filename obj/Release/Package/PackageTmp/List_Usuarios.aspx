<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="List_Usuarios.aspx.cs" Inherits="Montres.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css%22%3E
        <script src="js/cdn.datatables.js"></script>
        <script src="js/cdn.datatables.net.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Lista de Usuarios</small></h1>
            </div>

          

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li><a class="link-dark" href="InsertarUsuario.aspx">Nuevo usuario</a></li>
                        <li class="active">listado de usuarios</li>
                    </ol>
                </div>
            </div>


         


            <div class="table-responsive">
                <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: white;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Nombre</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cédula</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Estado</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Rol</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Modificar Usuario</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cambio de Contrasena</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                    
                </asp:Table>
            </div>

        </div>

   <script>
       $(document).ready(function () {
           $('#<%=tableU.ClientID%>').DataTable({

               "ajax": {
                   "url": "default/listUsuarios",
                   "dataSrc": ""
               },

               pageLength: 100,
               "scrollY": "600px",
               "scrollCollapse": true,
               columns: [
                   { "data": "Nombre" },
                   { "data": "Cedula" },
                   { "data": "Correo" },
                   { "data": "Estado" },
                   { "data": "Rol" }

               ],

               "columnDefs": [

                   {
                       "targets": + 5,
                       "data": "Cedula",
                       "render": function (data, type, row, meta) {
                           return '<a href="Modificar_Usuario.aspx?ID=' + data + '"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-refresh"></i></a>';

                       }
                   },

                   {

                       "targets": + 6,
                       "data": "Cedula",
                       "render": function (data, type, row, meta) {
                           return '<a href="Cambio_Contrasena.aspx?ID=' + data + '"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-lock"></i></a>';
                       }
                   

                   }]

           });
       });

   </script>
</asp:Content>

