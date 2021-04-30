<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Numero_Alternativo.aspx.cs" Inherits="Montres.Numero_Alternativo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Lista de Números Alternativos</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">

                        <li><a class="link-dark" href="InsertarParte.aspx">Insertar Parte</a></li>
                        <li><a  class="link-dark"href="List_Partes.aspx">Lista de Partes</a></li>
                        <li class="Active">Número de parte alternativo</li>
                    </ol>
                </div>
            </div>



                <asp:Panel  runat="server" id="div_table" class="table-responsive">

                    <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color:white;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Número de Parte</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Número de Parte Alternativo</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Ver detalles</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                                
                </asp:Table>

             </asp:Panel>

        </div>

       <script>
           $(document).ready(function () {
               $('#<%=tableU.ClientID%>').DataTable({

                    "ajax": {
                       "url": "default/listNumeroAlterno",
                        "dataSrc": ""
                    },

                    pageLength: 100,
                    "scrollY": "600px",
                    "scrollCollapse": true,
                    columns: [
                        { "data": "Numero_Parte" },
                        { "data": "Partes_Numeros" },
                        { "data": "Numero_Parte" }
                   ],

                   "columnDefs": [{
                       "targets": + 2,
                       "data": "Numero_Parte",
                       "render": function (data, type, row, meta) {
                           return '<a href="Detalle_Parte.aspx?ID=' + data + '"  class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-file-text"></i></a>';
                       }
                   }]

                });
            });

       </script>

</asp:Content>
