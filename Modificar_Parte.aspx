<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Modificar_Parte.aspx.cs" Inherits="Montres.Modificar_Parte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Parte Modificada');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al modificar');
           };
         </script>

    <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Modificar Parte</small></h1>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div id="info"></div>
                </div>
                <div class="col-lg-12">
                    <div class="panel panel-default shadow">
                        <div class="panel-heading">
                            Datos
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal"> 

                                <div class="form-group">
                                    <label for="numeroparte" class="col-sm-2 control-label">Número de parte</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="numero_parte" name="numero_parte" value="" type="text" class="form-control" required="" readonly=""/>
                                    </div>

                                    <label for="descripcion" class="col-sm-2 control-label">Descripción</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="descripcion" name="descripcion" value="" type="text" class="form-control" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="ubicacion" class="col-sm-2 control-label">Ubicación</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="ubicacion" name="ubicacion" value="" type="text" class="form-control" required=""/>
                                    </div>
                                    <label for="precio" class="col-sm-2 control-label">Precio</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="precio" name="precio" value="" class="form-control" placeholder="" type="number" step="0.01" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="cantidadInicial " class="col-sm-2 control-label">Cantidad Ingresada</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="inicial" name="inicial" value="" type="text" class="form-control" required="" readonly=""/>
                                    </div>

                                    <label for="cantidadStock" class="col-sm-2 control-label">Cantidad en Stock</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack="true" runat="server" maxlength="100" id="stock" name="stock" value="" type="text" class="form-control" required="" readonly=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="factura" class="col-sm-2 control-label">Número de factura</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="numero_factura" name="Numero_Factura" value="" type="text" class="form-control" required=""/>
                                    </div>

                                    <label for="proveedor" class="col-sm-2 control-label">Proveedor</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="proveedor" name="Proveedor" value="" type="text" class="form-control" required=""/>
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label for="minimo" class="col-sm-2 control-label">Mínimo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" maxlength="100" id="minimo" name="minimo" value="" type="text" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                    </div>
                                </div> 

                                <hr>

                                <div class="form-group">
                                    <label for="nueva_cantidad" class="col-sm-2 control-label">Ingresar nueva cantidad</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" id="cantidad_nueva" name="cantidad_nueva" value="0" type="text" class="form-control"  pattern="[0-9]{1,20}" required="" maxlength="20"/>
                                    </div>

                                </div>
                                <div>
                                    <asp:Button ID="_guardar" Text="Modificar" runat="server" OnClick="Modificar_datos_parte" class="btn btn-outline-dark"  style="float: right;"/>
                                </div> 

                            </div> 
                        </div>
                    </div>

                </div>

            </div>

        </div>
</asp:Content>
