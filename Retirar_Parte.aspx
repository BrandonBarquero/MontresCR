<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Retirar_Parte.aspx.cs" Inherits="Montres.Retirar_Parte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <script>
               function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Salida Realizada');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error en la salida');
           };
         </script>

      <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Retirar Parte</small></h1>
            </div>



                    <asp:Panel Visible="false" id="Panel_Error" runat="server" class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning" role="alert">
                        <strong>Advertencia!</strong> No puede retirar más partes de las existentes.
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
                            Datos
                        </div>
                        <div class="panel-body">
                            <div class="form-horizontal"> 
                                <div class="form-group">
                                    <label for="numeroparte" class="col-sm-2 control-label">Número de parte</label>
                                    <div class="col-sm-4">
                                           <asp:DropDownList Required="true" ID="ddlPerfiles"    AutoPostBack="true"
                       CssClass=" form-control" runat="server"   OnSelectedIndexChanged="consultar_detalle_Parte">
                      </asp:DropDownList>
                                    </div>
                                    <label for="factura" class="col-sm-2 control-label">Número de Factura</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server"  id="numero_factura" name="Numero_Factura" value="" type="text" class="form-control" required="" readonly=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="desc" class="col-sm-2 control-label">Descripción</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server"  id="descripcion" name="descripcion"  type="text" class="form-control" required="" readonly=""/>
                                    </div>
                                    <label for="cantidadstock" class="col-sm-2 control-label">Cantidad en Stock</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server"  id="stock" name="stock" type="text" class="form-control" required="" readonly=""/>
                                    </div>
                                </div> 

                                <hr>

                                <div class="form-group">
                                    <label for="cliente " class="col-sm-2 control-label">Cliente</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="cliente" name="cliente" type="text" class="form-control" required=""/>
                                    </div>

                                    <label for="cantidadRetirar" class="col-sm-2 control-label">Cantidad a Retirar</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" id="cantidad_retirar" name="cantidad_retirar" type="number" class="form-control" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="encargado" class="col-sm-2 control-label">Encargado</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="encargado" name="encargado" type="text" class="form-control" required=""/>
                                    </div>

                                      <label for="despachador" class="col-sm-2 control-label">Despachador</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server"  ID="despachador" name="despachador" type="text" class="form-control" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="fecha_salida" class="col-sm-2 control-label">Fecha de salida</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox runat="server" ID="fecha_salida" name="fecha" type="date" class="form-control" required=""/>
                                    </div>
                                </div> 
                                <div>
                                     <asp:Button ID="_guardar" Text="Retirar parte" runat="server" OnClick="Retirar_Parte_Automatico" class="btn btn-outline-dark"  style="float: right;"/>
                                </div> 
                            </div> 
                        </div>
                    </div>

                </div>

            </div>

        </div>

     <script type="text/javascript">
         $(function () {
             initdropdown();
         })
         function initdropdown() {
             $("#<%=ddlPerfiles.ClientID%>").select2({
                 placeholder: "Buscar..."

             });
        }
     </script>
                <script type="text/javascript">
                    function pageLoad(sender, args) {
                        initdropdown();
                    }
                </script>

</asp:Content>
