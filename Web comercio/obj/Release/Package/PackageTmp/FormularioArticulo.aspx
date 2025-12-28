<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Web_comercio.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ImagenDefecto() {
            this.onerror = null;
            this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>cosas</h1>
    <hr />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id:</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodArticulo" class="form-label">Cdogido de articulo:</label>
                <asp:TextBox runat="server" ID="txtCodArticulo" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El código es requerido." ControlToValidate="txtCodArticulo" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." ControlToValidate="txtNombre" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio:</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El precio es requerido" ControlToValidate="txtPrecio" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca:</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="La marca es requerida." ControlToValidate="ddlMarca" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" calss="form-label">Categoría:</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="La categoria es requerida" ControlToValidate="ddlCategoria" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn fw-bold" Style="background-color: #00784B" data-bs-theme="dark" runat="server" OnClick="btnGuardar_Click" />
                <a href="ListaArticulos.aspx">Cancelar</a>
            </div>


        </div>
        <%-- otra columna --%>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <label for="txtImagenurl" class="form-label">Url imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image onerror="this.onerror=null; this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740'" class="logos" runat="server" ID="imgArticulo" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <%-- otra fila --%>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>
                    <%if (ConfirmaEliminacion)
                        {%>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar eliminación" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>
                    <% } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
