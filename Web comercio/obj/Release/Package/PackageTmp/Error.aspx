<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web_comercio.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- Columna izquierda con el mensaje de error -->
        <div class="col-6 d-flex flex-column justify-content-center text-center">
            <h1 style="color: #ff004d; font-family: 'Orbitron', sans-serif; font-weight: bold;">Hubo un problema </h1>
            <asp:Label ID="lblMensaje" runat="server" Text="Comuniquese con ayuda@soporte.com" CssClass="error-message"></asp:Label>
        </div>
           
    </div>
</asp:Content>
