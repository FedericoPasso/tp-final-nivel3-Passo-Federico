<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Estilos.css" rel="stylesheet" type="text/css">
    <script>
        function ImagenDefecto() {
            this.onerror = null;
            this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <h1>Productos</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-3">
                <asp:Repeater ID="repRepetidor" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card h-100">   <%-- #Eval inyecta las propiedades del objeto que trae el repeater en el code behind --%>
                                <img src="<%#Eval("UrlImagen") %>" onerror="this.onerror=null; this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740'" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text">Marca: <%#Eval("Marca") %></p>
                                    <p class="card-text">Categoría: <%#Eval("Categoria") %></p>
                                    <p class="precio">Precio: $<%#Eval("Precio")%></p>

                                    <a href="DetalleArticulo.aspx?id= <%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>

                                    <%if (Negocio.Seguridad.SesionActiva(Session["usuario"]))
                                        {%>
                                             <asp:Button Text="Agregar a favoritos ❤️" CssClass="btn btn-primary" runat="server" ID="btnFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnFavoritos_Click1" />
                                            <div id="alerta" class="alerta" style="display: none;">Este producto ya está en tu lista de favoritos.</div>

                                    <% } %>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
