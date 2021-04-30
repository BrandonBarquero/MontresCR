<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Salidas.aspx.cs" Inherits="Montres.Salidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css%22%3E />
        <script src="js/cdn.datatables.js"></script>
        <script src="js/cdn.datatables.net.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Bitácora de Salidas</small></h1>
            </div>

          
                  <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">

                            <li><a class="link-dark" href="Entradas.aspx">Entradas</a></li>
                            <li class="Active">Salidas</li>
                            <li><a class="link-dark" href="Devoluciones.aspx">Devolución</a></li>
                    </ol>
                </div>
            </div>
            
               
         <asp:Panel  runat="server" id="div_table" class="table-responsive">
                <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color:#fff">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Número de parte</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Encargado</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Despachador</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cliente</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Cantidad retirada</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Fecha</asp:TableHeaderCell>
                          <asp:TableHeaderCell>Devolución</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow  ID="TableRow1" runat="server" TableSection="TableBody" BackColor="White">
               
            </asp:TableRow>
                    
                </asp:Table>
            </asp:Panel>

        </div>
  <script>
      $(document).ready(function () {
          $('#<%=tableU.ClientID%>').DataTable({

              "ajax": {
                  "url": "default/listSalidas",
                  "dataSrc": ""
              },

              pageLength: 100,
              "scrollY": "600px",
              "scrollCollapse": true,
              columns: [
                  { "data": "Numero_Parte" },
                  { "data": "Encargado" },
                  { "data": "Despacho" },
                  { "data": "Descripcion" },
                  { "data": "Cliente" },
                  { "data": "Cantidad" },
                  { "data": "Fecha" }

              ],
              "columnDefs": [{
                  "targets": + 7,
                  "data": "Numero_Parte",
                  "render": function (data, type, row, meta) {
                      return '<a href="Devolucion_Parte.aspx?ID=' + row["Numero_Parte"] + '&Cantidad=' + row["Cantidad"] + '&ID_Salida=' + row["ID_Salida"] + '" class="btn btn-light tooltips-general" data-toggle="tooltip" data-placement="top" ><i class="zmdi zmdi-swap"></i></a>';
                  }
              }]

          });
      });

  </script>
</asp:Content>