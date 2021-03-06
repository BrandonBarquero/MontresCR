<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="List_Partes_Ventas.aspx.cs" Inherits="Montres.List_Partes_Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">

            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Lista de Partes</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li class="Active">Lista de Partes</li>
                        <li><a class="link-dark" href="Numero_Alternativo_Ventas.aspx">Número de parte alternativo</a></li>
                    </ol>
                </div>
            </div> 
                                  
            <div class="table-responsive">

                       <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: white;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Número de Parte</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Número de Factura</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Ubicación</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cantidad en Stock</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Ver Detalles</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                    
                </asp:Table>

            </div>                       
        </div>

        <script>
            $(document).ready(function () {
                $('#<%=tableU.ClientID%>').DataTable({

              "ajax": {
                        "url": "default/listPartes",
                  "dataSrc": ""
              },

              pageLength: 100,
              "scrollY": "600px",
              "scrollCollapse": true,
              columns: [
                  { "data": "Numero_Parte" },
                  { "data": "Descripcion" },
                  { "data": "Numero_Factura" },
                  { "data": "Ubicacion" },
                  { "data": "Cantidad_Stock" }

              ],
                    "columnDefs": [

                        {
                            "targets": + 0,
                            "data": "Numero_Parte",
                            "render": function (data, type, row, meta) {

                                return '<span data-toggle="tooltip" data-placement="top" title="₡ ' + row["Precio"] +' + i.v.a">'+data+'</span>';

                            }
                        },

                        {
                  "targets": + 5,
                            "data": "Numero_Parte",
                            "render": function (data, type, row, meta) {
                                return '<a href="Detalle_Parte.aspx?ID=' + data + '"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-file-text"></i></a>';

                            }

                            }]
   
          });
      });

        </script>
</asp:Content>
