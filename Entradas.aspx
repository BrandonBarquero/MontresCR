<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Entradas.aspx.cs" Inherits="Montres.Entradas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5">Bitácora de Entradas</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li  class="active">Entradas</li>
                        <li><a class="link-dark" href="Salidas.aspx">Salidas</a></li>
                        <li><a class="link-dark" href="Devoluciones.aspx">Devoluciones</a></li>
                    </ol>
                </div>
            </div>
            
            <asp:Panel  runat="server" id="div_table" class="table-responsive">

                
                        <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: white;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Responsable</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cantidad ingresada</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Precio</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Numero de Factura</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Proveedor</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                    
                </asp:Table>

             </asp:Panel>
        </div>

        <script>
            $(document).ready(function () {
                $('#<%=tableU.ClientID%>').DataTable({

              "ajax": {
                        "url": "default/listEntradas",
                  "dataSrc": ""
              },

              pageLength: 100,
              "scrollY": "600px",
              "scrollCollapse": true,
              columns: [
                  { "data": "Fecha" },
                  { "data": "Responsable" },
                  { "data": "Descripcion" },
                  { "data": "Cantidad_Ingresada" },
                  { "data": "Precio" },
                  { "data": "Numero_Factura" },
                  { "data": "Proveedor" }
              ],

          });
      });

        </script>

</asp:Content>
