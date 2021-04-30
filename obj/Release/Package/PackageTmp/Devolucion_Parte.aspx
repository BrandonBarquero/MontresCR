<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Devolucion_Parte.aspx.cs" Inherits="Montres.Devolucion_Parte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
       <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Devolución realizada');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al devolver');
           };
       </script>

    <div class="container">
        <div class="page-header">
            <h1 class="all-tittles"><small style="color: #00adb5">Realizar Devolución</small></h1>
        </div>

            <asp:Panel Visible="false" id="Panel_Error" runat="server" class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning" role="alert">
                        <strong>Advertencia!</strong> La cantidad a devolver no puede ser mayor a la cantidad de salida.
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
                                    <asp:TextBox runat="server" maxlength="100" id="numero_parte" name="numero_parte" value="" type="text" class="form-control" required="" readonly=""/>
                                </div>
                                <label for="descripcion" class="col-sm-2 control-label">Motivo de devolución</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="motivo" name="descripcion" type="text" maxlength="200" class="form-control" placeholder="" required=""/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label for="responsable" class="col-sm-2 control-label">Responsable</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" maxlength="100" id="responsable" name="Responsable" value="" type="text" class="form-control" required="" readonly=""/>
                                </div>
                                <label for="fecha" class="col-sm-2 control-label">Fecha</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="fecha" name="Fecha" maxlength="100" type="date" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                </div>
                            </div> 

                            <div class="form-group">
                                <label for="cantidadDevolucion" class="col-sm-2 control-label">Cantidad de salida</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" maxlength="100" id="cantidad_salida" name="Cantidad" value="" type="text" class="form-control" required="" readonly=""/>
                                </div>
                                <label for="nuevaCantidad" class="col-sm-2 control-label">Cantidad de Devolución</label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" id="cantidad_devuelta" name="Nueva" maxlength="100" type="text" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                </div>
                            </div> 

                            <div>
                                  <asp:Button ID="_guardar" Text="Devolver" runat="server" OnClick="Realizar_Devolucion" class="btn btn-outline-dark"  style="float: right;"/>
                            </div> 
                        </div> 
                    </div>
                </div>

            </div>

        </div>

    </div>
</asp:Content>
