<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Web_comercio.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <h1>Lista de articulos</h1>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                </div>
            </div>


            <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
                <div class="mb-3">
                    <asp:CheckBox Text="Filtro Avanzado" CssClass="" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
                </div>
            </div>

            <div class="col-6">
                <asp:Button Text="Limpiar" ID="btnLimpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" runat="server" />
            </div>
            <br />

            <asp:Panel runat="server" ID="pnlFiltroAvanzado" Visible="false">

                <div class="row">

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Campo" ID="lbCampo" runat="server" />
                            <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                <asp:ListItem Text="-- Seleccione una opción --" Value="" />
                                <asp:ListItem Text="Precio" />
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Marca" />
                                <asp:ListItem Text="Categoria" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Debe seleccionar una opción" ControlToValidate="ddlCampo" runat="server"
                                ID="validaCampo" InitialValue="" ForeColor="DarkRed" />
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Criterio" runat="server" />
                            <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCriterio_SelectedIndexChanged">
                                <asp:ListItem Text="-- Seleccione una opción --" Value="" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Debe seleccionar una opción" ID="validaCriterio" ControlToValidate="ddlCriterio" runat="server"
                                InitialValue="" ForeColor="DarkRed" />
                        </div>
                    </div>

                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Label Text="Filtro" runat="server" />
                            <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />

                        </div>
                    </div>

                </div>

                <%----Otra Fila----%>

                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" ID="btnBuscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>

                <br />

            </asp:Panel>


            <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging"
                AllowPaging="true" PageSize="5" PageIndex="0">
                <Columns>
                    <asp:BoundField HeaderText="Codigo de Articulo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}" HtmlEncode="False" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />

                </Columns>

            </asp:GridView>
            <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
        </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>
