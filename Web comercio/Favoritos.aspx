<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Web_comercio.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function ImagenDefecto() {
        this.onerror = null;
        this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favoritos</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repFavoritos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" onerror="this.onerror=null; this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740'" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <h5 class="card-title"><%# Eval("Precio", "{0:C}") %></h5>
                            <a href="DetalleArticulo.aspx?id=<%# Eval("Id") %>" class="btn btn-outline-secondary">Ver detalles</a>
                            <asp:Button Text="Eliminar Favorito" CommandArgument='<%# Eval("Id") %>' ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
