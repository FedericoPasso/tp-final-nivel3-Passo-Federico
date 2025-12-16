<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Web_comercio.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img-thumbnail {
            width: 250px;
            height: 250px;
            object-fit: contain;
            transition: width 0.5s ease, height 0.5s ease;
        }

            .img-thumbnail:hover {
                width: 500px;
                height: 500px;
                object-fit: contain;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalles</h1>
    <hr />
    <div class="row">
        <%-- --columna izq----%>
        <div class="col-6">

            <div class="mb-3">
                <label for="lbCodigo" class="col-sm-2 col-form-label fw-bold">Código:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbNombre" class="col-sm-2 col-form-label fw-bold">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbDescripcion" class="col-sm-2 col-form-label fw-bold">Descripción:</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbMarca" class="col-sm-2 col-form-label fw-bold">Marca:</label>
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <asp:Button ID="btnAtras" runat="server" Text="Volver" CssClass="btn btn-danger" OnClick="btnAtras_Click" />

        </div>

        <%-- --columna der----%>
        <div class="col-6">

            <div class="mb-3">
                <label for="lbCategoria" class="col-sm-2 col-form-label fw-bold">Categoría:</label>
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="lbPrecio" class="col-sm-2 col-form-label fw-bold">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>

            <div class="rmb-5">
                <asp:Image ID="txtImagen" runat="server" CssClass="img-thumbnail" />
            </div>

        </div>


    </div>

</asp:Content>
