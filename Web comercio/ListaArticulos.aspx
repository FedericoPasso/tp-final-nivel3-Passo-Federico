<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Web_comercio.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h1>Administrar productos</h1>
            <hr />
            <asp:GridView id="dgvArticulos" datakeynames="Id" CssClass="table table-bordered" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" 
                OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                AllowPaging="true" PageSize="5" PageIndex="0" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Codigo de Artículo" DataField="CodArticulo"/> 
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre"/> 
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion"/> 
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion"/> 
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" HtmlEncode="false"/> 
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/> 
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />

                </Columns>    

            </asp:GridView>
            <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
