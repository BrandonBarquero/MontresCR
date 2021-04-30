<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modificar_Usuario.aspx.cs" Inherits="Montres.Modificar_Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Usuario modificado');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al modificar');
           };
    </script>

      <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Modificar Usuario</small></h1>
            </div>


            <div class="row">
                <div class="col-lg-12">
                    <div id="info"></div>
                </div>
                <div class="col-lg-12">
                    <div class="panel panel-default shadow">
                        <div class="panel-heading">
                            Datos del usuario 
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal" name="modificarr" action="ModificaUsuario" method="post" autocomplete="off" onsubmit="return confirmar()"> 

                                <div class="form-group">
                                    <label for="nombre" class="col-sm-2 control-label">Nombre completo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox  runat="server" AutoPostBack="false"  id="nombre" name="nombre" value="" type="text" class="form-control" required=""/>
                                    </div>

                                    <label for="cedula" class="col-sm-2 control-label">Cédula</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox  runat="server" AutoPostBack="false" value="" id="cedula" name="cedula"  type="text" class="form-control" required=""  readonly=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="email" class="col-sm-2 control-label">Email</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox  runat="server" AutoPostBack="false"  id="correo" name="correo" value="" type="email" class="form-control" required=""/>
                                    </div>
                                    <label for="telefono" class="col-sm-2 control-label">Télefono</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox  runat="server" AutoPostBack="false" id="telefono" name="telefono" value="" type="text" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="rol" class="col-sm-2 control-label">Rol</label>
                                    <div class="col-sm-4">
                                       <asp:DropDownList runat="server" AutoPostBack="false" id="rol" required="" name="rol" class="form-control" data-toggle="tooltip" data-placement="top" title="Elige el rol">
                                            <asp:ListItem  value="" disabled="" selected="">Seleccione un rol</asp:ListItem>
                                            <asp:ListItem  value="1">Administrador</asp:ListItem>
                                            <asp:ListItem  value="2">Bodeguero</asp:ListItem>
                                            <asp:ListItem  value="3">Ventas</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <label for="estado" class="col-sm-2 control-label">Estado</label>
                                    <div class="col-sm-4">
                                         <asp:DropDownList runat="server" AutoPostBack="false" id="estado" name="estado" value="" class="form-control"  required="" title="Elige un estado">
                                            <asp:ListItem  value="" disabled="" selected="">Seleccione un estado</asp:ListItem>
                                            <asp:ListItem  value="Activo">Activo</asp:ListItem>
                                            <asp:ListItem  value="Desactivo">Desactivo</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div> 
                                <p class="text-center">
                                         <asp:Button ID="_guardar" Text="Modificar" runat="server" OnClick="Modificar_User" class="btn btn-outline-dark"  style="float: right;"/>
                                </p> 

                            </div> 
                        </div>
                    </div>

                </div>

            </div>


        </div>
</asp:Content>
