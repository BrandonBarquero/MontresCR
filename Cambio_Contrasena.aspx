<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cambio_Contrasena.aspx.cs" Inherits="Montres.Cambio_Contrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Contraseña actualizada');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al actualizar');
           };
           </script>

    <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5">Modificar contraseña</small></h1>
            </div>


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
                            Nueva contraseña 
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal"> 

                                <div class="form-group">
                                    <label for="nombre" class="col-sm-2 control-label">Nombre completo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="nombre" name="nombre" value="" type="text" class="form-control" required="" readonly/>
                                    </div>
                                    <label for="cedula" class="col-sm-2 control-label">Cédula</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" value="" id="cedula" name="cedula"  type="text" class="form-control" required="" readonly/>
                                    </div>
                                </div> 

                                <hr>

                                <div class="form-group">
                                    <label for="contra" class="col-sm-2 control-label">Contraseña</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" id="Contrasena1" name="contrasena1"  type="password" class="form-control" placeholder="Contraseña" maxlength="200" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="contra2" class="col-sm-2 control-label">Confirme Contraseña</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" id="contrasena" name="contrasena2" type="password" class="form-control" placeholder="Repite la contraseña" required="" maxlength="200"/>
                                    </div>
                                </div> 

                                <p class="text-center">
                                    <asp:Button ID="_guardar" Text="Modificar" runat="server" OnClick="Modificar_Contra" class="btn btn-outline-dark"  style="float: right;"/>
                                </p> 

                            </div> 
                        </div>
                    </div>

                </div>

            </div>

        </div>
</asp:Content>
