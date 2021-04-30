<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Montres.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       

        <title>Inicio</title>


       

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="page-header">
                <h1 class="all-tittles"><small style="color: #00adb5">Inicio</small></h1>
            </div>

         <%int partes = Contar_Parte(); int salidas = Contar_Salidas(); int devoluciones = Contar_Devoluciones(); int minimos = Contar_Minimos(); int cotizaciones = Contar_Cotizaciones(); int usuarios = Contar_Usuarios();%>

            <div class="row">
                <div class=" col-12">
                    <div class="panel panel-default bootcards-summary shadow">
                        <div class="panel-heading">
                            <h3 class="panel-title">Información actual</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">

                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="List_Partes.aspx" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-shape zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Partes <span style="background-color: #00adb5" class="label label-info"><%=partes%></span></h4>
                                    </a>
                                </div>
                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="Salidas.aspx" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-trending-down zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Salidas <span style="background-color: #00adb5"  class="label label-warning"><%=salidas%></span></h4>
                                    </a>
                                </div>
                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="Devoluciones.aspx" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-refresh-alt zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Devoluciones <span style="background-color: #00adb5" class="label label-info"><%=devoluciones%></span></h4>
                                    </a>
                                </div>
                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="Minimos.aspx" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-minus-circle-outline zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Minimos <span  style="background-color: #00adb5" class="label label-info"><%=minimos%></span></h4>
                                    </a>
                                </div>
                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="Realizar_Cotizacion.aspx" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-money zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Cotizaciones <span style="background-color: #00adb5"  class="label label-warning"><%=cotizaciones%></span></h4>
                                    </a>
                                </div>
                                <div class="col-xs-6 col-sm-4">
                                    <a class="bootcards-summary-item" href="List_Usuarios.aspx" class="link-dark" style="text-decoration:none">
                                        <i style="color:#222831" class="zmdi zmdi-face zmdi-hc-4x"></i>
                                        <h4 style="color: #00adb5">Usuarios <span style="background-color: #00adb5" class="label label-info"><%=usuarios%></span></h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
</asp:Content>
