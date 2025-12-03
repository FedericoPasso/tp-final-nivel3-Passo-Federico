<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Web_comercio.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

    </div>
    <div class="row row-cols-2">
        <div class="col-5">
            <asp:Image id="imgFoto" CssClass="imagen" runat="server" />
        </div>
        <div class="col-7">
            <div>
                    <asp:Label id="LblTitulo" CssClass="tituloDetalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblCodigo" CssClass="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="LblDescripcion" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblMarca" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblCategoria" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Label id="lblPrecio" class="detalle" runat="server" Text=""></asp:Label>  
                </div>
                <div>
                    <asp:Button ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-primary btn-sm botones" runat="server" Text="Volver" />
                </div>
            </div>
    </div>

</asp:Content>
