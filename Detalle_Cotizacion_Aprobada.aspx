<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle_Cotizacion_Aprobada.aspx.cs" Inherits="Montres.Detalle_Cotizacion_Aprobada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container">

            <div class="page-header">
                <h1 class="all-tittles"><small>Detalles de la Cotización</small></h1>
            </div>
            <div class="panel panel-default shadow">
                <div class="panel-heading">
                    Datos de la Cotización
                </div>
                <div class="panel-body">
                    <%  Montres.DAO.CotizacionDAO dao2 = new Montres.DAO.CotizacionDAO();
                                      string parametro2 = Request.QueryString["ID"];
                                     Montres.Models.Cotizaciones coti =dao2.MostrarCotizacion(parametro2);%>
                    <div class="col-12">
                        <h4 class="mb-3">Datos del cliente</h4>
                        <form class="needs-validation" novalidate>
                            <div class="row g-3">
                                <div class="col-sm-6">
                                    <label for="firstName" class="form-label">Cliente</label>
                                    <asp:Label class="form-control" ID="Label1"  Text="Label"><%= coti.Cliente %></asp:Label>
                                </div>

                                <div class="col-sm-6">
                                    <label for="lastName" class="form-label">Número de orden</label>
                                    <asp:Label class="form-control" ID="Label1"  Text="Label"><%= coti.ID_Cotizacion %></asp:Label>
                                </div>

                            </div>
                    </div>
                    <hr>
                    <br><br>
                        <%Montres.DAO.Partes_CotizacionDAO dao = new Montres.DAO.Partes_CotizacionDAO();
                                      string parametro = Request.QueryString["ID"];
                                     List<Montres.Models.Partes> questions =dao.MostrarCotizacion(parametro);
                             %>
                    <div class="row g-5">
                        <div class="col-md-12">
                            <h4 class="d-flex justify-content-between align-items-center mb-3">
                                <span class="text-primary">Cotización</span>
                                <span class="badge bg-primary rounded-pill"><%= questions.Count %></span>
                            </h4>
                            <ul class="list-group mb-3">


                                 <% 
                                     
                                     foreach (var dato in questions)

                                     {%> 
                                <li class="list-group-item d-flex justify-content-between lh-sm">
                                    <div>
                                        <h6 class="my-0">Descripción</h6>
                                        <small class="text-muted"><%= dato.Descripcion %></small><br>
                                        <h6 class="my-0">Número de parte</h6>
                                        <small class="text-muted"><%= dato.Numero_Parte %></small><br>
                                        <h6 class="my-0">Ubicación</h6>
                                        <small class="text-muted"><%= dato.Ubicacion %></small><br>
                                        <h6 class="my-0">Cantidad</h6>
                                        <small class="text-muted"><%= dato.Cantidad_Stock %></small>
                                    </div>
                                    <span class="text-muted">  <h6 class="my-0">Precio Unitario: </h6><%=aux.transformar( dato.Precio) %></span></br>
                                    <span class="text-muted">  <h6 class="my-0">Precio: </h6><%= aux.transformar(dato.Precio* dato.Cantidad_Stock)%></span>
                                </li>

                                <%} %>

                                <li class="list-group-item d-flex justify-content-between">
                                    <span>Total</span>
                                    <strong><%= aux.transformar(coti.Total)+" + IVA"%></strong>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>

            </div>
        </div>
</asp:Content>
