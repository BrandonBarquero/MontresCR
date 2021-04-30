<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cotizaciones_Aprobadas.aspx.cs" Inherits="Montres.Cotizaciones_Aprobadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">

            <div class="page-header">
                <h1 class="all-tittles"><small>Cotizaciones Aprobadas</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li><a class="link-dark" href="Realizar_Cotizacion.aspx">Realizar Cotización</a></li>
                        <li class="Active"><a class="link-dark" href="Historial_Cotizaciones.aspx">Historial de Cotizaciones</a></li>
                        <li class="Active">Cotizaciones Aprobadas</li>
                    </ol>
                </div>
            </div> 

            <div class="table-responsive">

                       <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: white;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cliente</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Número de orden</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Ver detalles</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                    
                </asp:Table>
            </div>
            
        </div>
      <script>
          $(document).ready(function () {
              $('#<%=tableU.ClientID%>').DataTable({

                    "ajax": {
                      "url": "default/ListaCotizacionesAPROBADAS",
                        "dataSrc": ""
                    },

                    pageLength: 100,
                    "scrollY": "600px",
                    "scrollCollapse": true,
                    columns: [
                        { "data": "Fecha" },
                        { "data": "Cliente" },
                        { "data": "ID_Cotizacion" },
                        { "data": "ID_Cotizacion" }

                    ],
                    "columnDefs": [

                        {
                            "targets": + 3,
                            "data": "ID_Cotizacion",
                            "render": function (data, type, row, meta) {
                                return '<a href="Detalle_Cotizacion_Aprobada.aspx?ID='+data +'"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-file-text"></i></a>';

                            }
                        }]


                });
            });

      </script>
</asp:Content>
