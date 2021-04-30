<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle_Parte.aspx.cs" Inherits="Montres.Detalle_Parte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">

            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Detalle de Parte</small></h1>
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
                                        <asp:TextBox ID="Numero_Parte" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                    <label for="descripcion" class="col-sm-2 control-label">Descripción</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Descripcion" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="ubicacion" class="col-sm-2 control-label">Ubicación</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Ubicacion" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                    <label for="cantidad" class="col-sm-2 control-label">Precio</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Precio" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                </div> 

                                <div class="form-group">
                                    <label for="cantidadInicial " class="col-sm-2 control-label">Cantidad Inicial</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Cantidad_Inicial" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                    <label for="cantidadStock" class="col-sm-2 control-label">Cantidad en Stock</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Cantidad_Stock" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label for="minimo" class="col-sm-2 control-label">Mínimo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Minimo" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                    <label for="fecha" class="col-sm-2 control-label">Fecha de Entrada</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Fecha_Entrada" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly="" />
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label for="factura" class="col-sm-2 control-label">Número de factura</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Numero_Factura" AutoPostBack = "true" runat="server"  value="" type="text" class="form-control" readonly="" />
                                    </div>
                                    <label for="proveedor" class="col-sm-2 control-label">Proveedor</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Proveedor" AutoPostBack = "true" runat="server" value="" type="text" class="form-control" readonly=""/>
                                    </div>
                                </div> 


                                <hr>

                                <asp:Panel ID="Panel_Insertar_Alterno" runat="server">

                                <div class="form-group">
                                    <label for="alterno" class="col-sm-2 control-label">Número de Parte Alternativo</label>
                                    <div class="col-sm-4">
                                        <asp:TextBox ID="Numero_Alternativo" runat="server" AutoPostBack = "true" type="text" class="form-control" placeholder="" required="" maxlength="70"/>
                                    </div>
                                 <div class="col-sm-4">
                                        <asp:Button ID="_guardar" Text="Agregar" runat="server"  OnClick="Insertar_Alterno"  class="btn btn-outline-dark"/>  
                                    </div>
                                </div> 
                                    </asp:Panel>

                                
                                <div class="form-group">

                                    <label for="alterno" class="col-sm-2 control-label">Número Alternativo:</label>


                                    <div class="col-sm-4"  runat="server" id="campo_alterno_div">

         
                                    </div>
                                    <asp:Panel ID="Panel_borrar_boton" runat="server">
                                    <div class="col-sm-4"  runat="server" id="campo_alterno_div2">     
                                    </div>
                                        </asp:Panel>

                                </div> 
                     </div>
             
                        </div>
                    </div>

                </div>

            </div>

        </div>
</asp:Content>
