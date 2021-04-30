<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InsertarParte.aspx.cs" Inherits="Montres.InsertarParte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <script type="text/javascript">


           function Alert_True() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.success('Parte Agregada');
           };
           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Error al agregar');
           };
         </script>

     <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5">Insertar Parte</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li class="active">Insertar Parte</li>
                        <li><a  class="link-dark"  href="List_Partes.aspx">Lista de Partes</a></li>
                        <li><a class="link-dark" href="Numero_Alternativo.aspx">Número de parte alternativo</a></li>
                    </ol>
                </div>
            </div>

           <asp:Panel Visible="false" id="Panel_Error_Parte" runat="server" class="row">
                <div class="col-lg-12">
                    <div class="alert alert-warning" role="alert">
                        <strong>Advertencia!</strong> Verifique que los datos ingresados sean correctos y que el número de parte no exista ya en el programa.
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
                                        <div class="input-group mb-3">
                                        <asp:TextBox OnTextChanged="txtChanged" AutoPostBack = "true" runat="server" name="numero_parte" ID="numero_parte" maxlength="100" type="text" class="form-control" placeholder="" required=""/>
                                        <span visible="false"  runat="server"  style="background-color:white;" class="input-group-text" id="span_E"><i runat="server" id="span_error"  ></i></span> 
                                    </div>
                                        </div>



                                    <label for="descripcion" class="col-sm-2 control-label">Descripción</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="descripcion" ID="descripcion" type="text" maxlength="100" class="form-control" placeholder="" required=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="ubicacion" class="col-sm-2 control-label">Ubicación</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="ubicacion" ID="ubicacion" maxlength="100" type="text" class="form-control" placeholder="" required=""/>
                                    </div>
                                    <label for="cantidad" class="col-sm-2 control-label">Cantidad</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="cantidad" ID="cantidad" maxlength="100" type="text" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label for="minimo" class="col-sm-2 control-label">Mínimo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="minimo" ID="minimo" maxlength="100" type="text" class="form-control" placeholder="" required=""  pattern="[0-9]{1,20}"/>
                                    </div>
                                    <label for="precio" class="col-sm-2 control-label">Precio</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="precio" ID="precio" type="text" maxlength="100" class="form-control" placeholder="₡" pattern="[0-9]{1,20}" required=""/>
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label for="factura" class="col-sm-2 control-label">Número de factura</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" value="" name="Numero_Factura" ID="Numero_Factura" type="text" class="form-control" placeholder="" required="" maxlength="70"/>
                                    </div>
                                    <label for="proveedor" class="col-sm-2 control-label">Proveedor</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" value="" name="Proveedor" ID="Proveedor" type="text" class="form-control" placeholder="" required="" maxlength="70"/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="fecha" class="col-sm-2 control-label">Fecha de entrada</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox AutoPostBack = "true" runat="server" name="fecha" ID="fecha" type="date" class="form-control" placeholder="" required="" maxlength="70"/>
                                    </div>
                                </div> 


                                <div>
                                    <asp:Button ID="_guardar" Text="Agregar" runat="server" OnClick="Insertar_User"  class="btn btn-outline-dark"  style="float: right;"/>
                                </div> 

                            </div> 
                        </div>
                    </div>

                </div>

            </div>

        </div>
</asp:Content>
