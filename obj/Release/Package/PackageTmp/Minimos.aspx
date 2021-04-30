<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Minimos.aspx.cs" Inherits="Montres.Minimos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5"> Mínimos</small></h1>
            </div>


            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li class="active">Mínimos</li>
                        <li><a class="link-dark" href="Partes_Vacias.aspx">Partes Vacías</a></li>
                    </ol>
                </div>
            </div>


       <asp:Panel  runat="server" id="div_table" class="table-responsive">

                     <asp:Table  runat="server"  id="tableU" class="table table-hover" style=" border: lightgray 2px solid; border-radius: 5px; background-color: #F8D7DA;">
                     <asp:TableHeaderRow  runat="server" class="table-light" TableSection="TableHeader">
                         <asp:TableHeaderCell>Número de parte</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Ubicación</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Descripción</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Cantidad en Stock</asp:TableHeaderCell>
                         <asp:TableHeaderCell>Mínimo</asp:TableHeaderCell>
                    </asp:TableHeaderRow>

                    
                </asp:Table>

            </asp:Panel>

            </div>


   <script>
       $(document).ready(function () {
           $('#<%=tableU.ClientID%>').DataTable({

              "ajax": {
                   "url": "default/listMinimos",
                  "dataSrc": ""
              },

              pageLength: 100,
              "scrollY": "600px",
              "scrollCollapse": true,
              columns: [
                  { "data": "Numero_Parte" },
                  { "data": "Ubicacion" },
                  { "data": "Descripcion" },
                  { "data": "Cantidad_Stock" },
                  { "data": "Cantidad_Minima" }

              ],

          });
      });

   </script>
</asp:Content>
