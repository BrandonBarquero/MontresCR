<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Realizar_Cotizacion.aspx.cs" Inherits="Montres.Realizar_Cotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div class="container">
        
            <style>
      .select2 {
      width:100%!important;
                }
    </style>
            <div class="page-header">
                <h1 class="all-tittles"><small>Realizar Cotización</small></h1>
            </div>

            <div class="row">
                <div class="col-xs-12 lead">
                    <ol class="breadcrumb">
                        <li class="Active">Realizar Cotización</li>
                        <li><a class="link-dark" href="Historial_Cotizaciones.aspx">Historial de Cotizaciones</a></li>
                        <li><a class="link-dark" href="Cotizaciones_Aprobadas.aspx">Cotizaciones Aprobadas</a></li>
                    </ol>
                </div>
            </div> 

            <div class="panel panel-default shadow">
                <div class="panel-heading">
                    Datos de la Cotización
                </div>
                <div class="panel-body">

                    <div class="row g-5">
                        <div class="col-md-5 col-lg-4 order-md-last">
                            <h4 class="d-flex justify-content-between align-items-center mb-3">

                                <% List<Montres.Models.Partes> questions = (List<Montres.Models.Partes>)HttpContext.Current.Session["allList"];%>

                                <span class="text-primary">Cotización</span>
                                <span class="badge bg-primary rounded-pill"><%=questions.Count%>  </span>
                            </h4>
        

                           <ul class="list-group mb-3">

                               <% 

                                   foreach (var dato in questions)
                                       
                                   {%> 
                                <li class="list-group-item d-flex justify-content-between lh-sm">
                                    <div>
                                        <small class="text-muted"><strong>Descripción: </strong><% =dato.Descripcion %></small><br/>
                                        <small class="text-muted"><strong>Número de parte: </strong><% =dato.Numero_Parte %></small><br/>
                                        <small class="text-muted"><strong>Ubicación: </strong><% =dato.Ubicacion %></small><br/>
                                        <small class="text-muted"><strong>Cantidad: </strong><% =dato.Cantidad_Stock %></small><br/>
                                        <small class="text-muted"><strong>Precio Unitario: </strong><% =aux.transformar(dato.Precio)%></small><br/>
                                        <small class="text-muted"><strong>Precio total: </strong><% =aux.transformar(dato.Precio*dato.Cantidad_Stock)%></small>

                                    </div>

                                      <div style="float: right">
                                           <a class="link-dark" href="Realizar_Cotizacion.aspx?Parte=<%=dato.Numero_Parte%>">Modificar</a>
                                        </div>

                                
                            
                                </li>
                               <hr />
                             <%
                                        cont = (dato.Precio* dato.Cantidad_Stock) + cont;
                                 } %>


   

                                <li class="list-group-item d-flex justify-content-between">
                                    <span>Total</span>
                                    <asp:Label ID="Label1" runat="server" Text="Label"><%=aux.transformar(cont)+ " + IVA"%></asp:Label>
                                </li>
                            </ul>

                            <div style="display: flex; float: right;">
                            <center><asp:Button onClick="Finalizar" id="Finalizar_B"  runat="server" class="btn btn-success" Text="Finalizar"></asp:Button></center> 
                                &nbsp
                            <center><asp:Button onClick="Cancelar" id="Cancelar_B" runat="server" class="btn btn-danger" Text="Cancelar"></asp:Button></center> 
                                 </div>
                        </div>


                        <div class="col-md-7 col-lg-8">
                            <h4 class="mb-3">Datos del cliente</h4>
                            
                                <div class="row g-3">
                                    <div class="col-sm-6">
                                        <label for="firstName" class="form-label">Cliente</label>
                                        
                                        <asp:TextBox OnTextChanged="txtChanged" AutoPostBack = 'True' runat="server" type="text" class="form-control" id="Cliente" placeholder="" value="" required="required" />
                                        <div class="invalid-feedback">
                                            Valid first name is required.
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <label for="lastName" class="form-label">Número de orden</label>

                                        <asp:TextBox Readonly="true"  runat="server"  type="text" class="form-control" id="orden"   />
                                    </div>

                                    <hr>

                                  


                                    <h4 class="mb-3">Buscar parte</h4>

                                    <div class="col-sm-12">
                                        <label for="numero_parte"  class="form-label">Número de parte</label>
                    <asp:DropDownList ID="ddlPerfiles"    AutoPostBack="true"
                       CssClass=" form-control" runat="server"   OnSelectedIndexChanged="ddlPerfiles_SelectedIndexChanged">
                      </asp:DropDownList>
                                                <div class="invalid-feedback">
                                            Valid last name is required.
                                        </div>
                                    </div>

                                    <div class="col-6">
                                        <label  for="descripcion" class="form-label">Descripción</label>
                                        <asp:TextBox  ReadOnly="true" runat="server" type="text" class="form-control" id="descripcion"/>
                                    </div>

                                    <div class="col-6">
                                        <label for="ubicacion" class="form-label">Ubicación</label>
                                        <asp:TextBox  ReadOnly="true" runat="server" type="text" class="form-control" id="ubicacion"/>
                                    </div>

                                    <div class="col-6">
                                        <label for="precio" class="form-label">Precio</label>
                                        <asp:TextBox  ReadOnly="true" runat="server" type="text" class="form-control" id="precio" name="precio"/>
                                    </div>

                                    <div class="col-6">
                                        <label for="cantidad" class="form-label">Cantidad</label>
                                        <asp:TextBox value="0"  runat="server" type="number" class="form-control" id="cantidad" name="cantidad"/>
                                    </div>

                                    <hr class="my-4"/>

                                    <center>

                                    <asp:Button onClick="Agregar_Parte"  ID="Button1" data-placement="bottom" class="btn btn-outline-dark col-4" runat="server" Text="Agregar" />
                                    
                                    <center>

                                        <asp:Button onClick="Eliminar_Parte" data-placement="bottom" class="btn btn-outline-danger col-2" runat="server" id="Eliminar" Text="Eliminar"></asp:Button>
                                        <asp:Button onClick="Modificar_Parte" data-placement="bottom" class="btn btn-outline-success col-2" runat="server" id="Actualizar" Text="Actualizar"></asp:Button>
                                         <asp:Button onClick="Redirect" data-placement="bottom" class="btn btn-outline-secondary col-2" runat="server" id="Cancelar_Buton" Text="Cancelar"></asp:Button>

                                        
                                    </center>



                          
                                </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            initdropdown();
        })
        function initdropdown() {
            $("#<%=ddlPerfiles.ClientID%>").select2({
                placeholder: "Buscar..."

            });
        }
    </script>
                <script type="text/javascript">
                    function pageLoad(sender, args) {
                        initdropdown();
                    }
                </script>

   

</asp:Content>
