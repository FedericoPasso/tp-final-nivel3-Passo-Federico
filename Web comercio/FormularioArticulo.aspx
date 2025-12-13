<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Web_comercio.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">

            <div class="mb-3">
                <label for="txtId" class="form-label">Id: </label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodArticulo" class="form-label">* Codigo de Articulo: </label>
                <asp:TextBox runat="server" ID="txtCodArticulo" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El Codigo es requerido." ControlToValidate="txtCodArticulo" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">* Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido." ControlToValidate="txtNombre" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">* Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El Precio es requerido." ControlToValidate="txtPrecio" ForeColor="DarkRed" runat="server" />
                <%--<asp:RangeValidator ErrorMessage="Ingresar un formato precio, use coma (,) como separador decimal" ControlToValidate="txtPrecio" Type="Double" MinimumValue="0" MaximumValue="70000000" runat="server" />--%>
            </div>


            <div class="mb-3">
                <label for="ddlMarca" class="form-label">* Marca: </label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La Marca es requerida." ControlToValidate="ddlMarca" ForeColor="DarkRed" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">* Categoria: </label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="La Categoria es requerido." ControlToValidate="ddlCategoria" ForeColor="DarkRed" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" runat="server" />
                <a href="ListaArticulos.aspx">Cancelar</a>
            </div>
        </div>

        <%-- --------------otra columna-------------------%>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <%-- --------------otra Fila-------------------%>
    <div class="row">
        <div class="col-6">

            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                    </div>

                    <%if (ConfirmarEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminacion" ID="chkConfirmaEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                    </div>

                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>


        </div>
    </div>
</asp:Content>
