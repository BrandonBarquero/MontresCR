<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertarUsuario.aspx.cs" Inherits="Montres.InsertarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Usuario agregado');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al agregar');
           };
           function Contrasenna_Error() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Cedulas ');
           };
</script>
   <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Insertar Usuarios</small></h1>
            </div>

         

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li class="active">Nuevo usuario</li>
                        <li><a class="link-dark" href="List_Usuarios.aspx">Lista de usuarios</a></li>
                    </ol>
                </div>
            </div>
            
            <asp:Panel Visible="false" id="Panel_Error_Cedula" runat="server" class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning" role="alert">
                        <strong>Advertencia!</strong> El número de cédula ya existe en el sistema.
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel Visible="false" id="Panel_Error_Contrasena" runat="server" class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning" role="alert">
                        <strong>Advertencia!</strong> Las contrasenas no coinciden.
                    </div>
                </div>
            </asp:Panel>

            <div class="row">
                <div class="col-lg-12">
                    <div id="info"></div>
                </div>
                <div class="col-lg-12">
                    <div class="panel panel-default shadow">
                        <div class="panel-heading">
                            Datos del Usuario
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal"  > 

                               

                                <div class="form-group">
                                    <label for="cedula" class="col-sm-2 control-label">Cédula</label>
                                    <div class="col-sm-4">
                                        <div class="input-group mb-3">
                                        <asp:TextBox  OnTextChanged="txtChanged"  AutoPostBack = True runat="server" maxlength="100" id="cedula" name="cedula" type="text" class="form-control" placeholder="Cédula" required=""  pattern="[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ]{1,20}"/>
                                                                                <span visible="false"  runat="server"  style="background-color:white;" class="input-group-text" id="span_E"><i runat="server" id="span_error"  ></i></span> 

                                     </div>
                                    </div>

                                    <label for="nombreCompleto" class="col-sm-2 control-label">Nombre Completo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="nombre" name="nombre" type="text" class="form-control"  placeholder="Nombre completo" required=""  pattern="[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{1,70}"/>
                                      
                                    </div>
                                </div> 
                               

                                <div class="form-group">
                                    <label for="telefono" class="col-sm-2 control-label">Teléfono</label>
                                    <div class="col-sm-4">
                                        <div class="input-group">
                                            <asp:TextBox  runat="server"  maxlength="100" id="telefono" name="telefono" type="text" class="form-control" pattern="[0-9]{1,20}" required="" placeholder="Teléfono"/>
                                        </div>
                                    </div>

                                    <label for="email" class="col-sm-2 control-label">Email</label>
                                    <div class="col-sm-4">
                                        <div class="input-group">
                                            <asp:TextBox runat="server" maxlength="100" id="correo" name="correo" type="email" placeholder="E-mail" class="form-control"/>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <label for="auto" class="col-sm-2 control-label">Rol</label>
                                    <div class="col-sm-4">

                                        <asp:DropDownList runat="server" id="rol" required="" name="rol" class="form-control" data-toggle="tooltip" data-placement="top" title="Elige el rol">
                                            <asp:ListItem  value="" disabled="" selected="">Seleccione un rol</asp:ListItem>
                                            <asp:ListItem  value="1">Administrador</asp:ListItem>
                                            <asp:ListItem  value="2">Bodeguero</asp:ListItem>
                                            <asp:ListItem  value="3">Ventas</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                
                                <hr>

                                <div class="form-group">
                                    <label for="contra" class="col-sm-2 control-label">Contraseña</label>
                                    <div class="col-sm-4"><asp:TextBox runat="server" maxlength="100" id="Contrasena" name="contrasena" type="password" class="form-control" placeholder="Contraseña" required=""/></div>
                                </div> 

                                <div class="form-group">
                                    <label for="contra2" class="col-sm-2 control-label">Repetir contraseña</label>
                                    <div class="col-sm-4"><asp:TextBox runat="server" maxlength="100" id="Contrasena2" type="password" class="form-control" placeholder="Repite la contraseña" required=""/></div>
                                </div> 

                                <p class="text-center">
                                    <asp:Button ID="_guardar" Text="Agregar" runat="server" OnClick="Insertar_User"  class="btn btn-outline-dark"  style="float: right;"/>
                                    
                                  
                                </p> 

                            </div> 
                        </div>
                    </div>

                </div>

            </div>
           
        </div>
</asp:Content>
