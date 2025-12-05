<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Web_comercio.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-6">
                <div class="card" style="border: none; padding: 20px; border-radius: 10px; background-color: transparent;"">
                    <div class="card-body">
                        <h3 class="mb-3" style="color: white; border-bottom: 2px solid #00c6ff; padding-bottom: 8px;">Creá tu perfil</h3>
                        
                        <div class="mb-3">
                            <asp:Label Text="Correo electrónico" runat="server" CssClass="text-white" Font-Size="Larger" Font-Bold="true" />
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                            <asp:RequiredFieldValidator ErrorMessage="El mail es requerido." CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
                            <asp:RegularExpressionValidator ErrorMessage="Formato de email incorrecto." CssClass="validacion" ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ControlToValidate="txtEmail" runat="server" />
                            <asp:Label ID="lbError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                       
                        <div class="mb-3">
                            <asp:Label Text="Contraseña" runat="server" CssClass="text-white" Font-Size="Larger" Font-Bold="true" />
                            <asp:TextBox runat="server" ID="txtPass" CssClass="form-control textbox-custom" />
                            <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida" CssClass="validacion" ControlToValidate="txtPass" runat="server" />
                        </div>

                        <div class="mb-2">
                            <asp:Button ID="btnRegistrarse" runat="server"  Text="Registrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                            <a href="Default.aspx" class="ml-3">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
