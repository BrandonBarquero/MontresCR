<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Historial_Cotizaciones.aspx.cs" Inherits="Montres.Historial_Cotizaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small>Historial de Cotizaciones</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li><a class="link-dark" href="Realizar_Cotizacion.aspx">Realizar Cotización</a></li>
                        <li class="Active">Historial de Cotizaciones</li>
                        <li><a class="link-dark" href="Cotizaciones_Aprobadas.aspx">Cotizaciones Aprobadas</a></li>
                    </ol>
                </div>
            </div> 

            <div class="table-responsive">

                <asp:Table ID="Table1" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: white;" runat="server">
                    <asp:TableHeaderRow  runat="server"  class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell CssClass="text-center">Fecha</asp:TableHeaderCell>
                         <asp:TableHeaderCell CssClass="text-center">Cliente</asp:TableHeaderCell>
                         <asp:TableHeaderCell CssClass="text-center">Número de orden</asp:TableHeaderCell>
                         <asp:TableHeaderCell CssClass="text-center">Ver detalles</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                </asp:Table>



              
                       
            </div>
             <script>
          $(document).ready(function () {
              $('#<%=Table1.ClientID%>').DataTable({

                    "ajax": {
                      "url": "default/ListaCotizaciones",
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
                                return '<a href="Detalle_Cotizacion.aspx?Detallado='+data +'"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-file-text"></i></a>';

                            }
                        }]


                });
            });

             </script>
        </div>
</asp:Content>
