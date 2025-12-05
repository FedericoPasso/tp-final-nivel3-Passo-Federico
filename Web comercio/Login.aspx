<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_comercio.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-6">
                <div class="card" style="border: none; padding: 20px; border-radius: 10px; background-color: transparent;">
                    <div class="card-body">
                        <div class="row" style="display: flex; justify-content: center;">
                            <h3 class="text-white" style="text-align: center;">Iniciar sesión</h3>
                        </div>
                        <br />
                        <div class="row" style="display: flex;">
                            <div class="col-12">
                                <div class="input-group mb-3">
                                    <span class="input-group-text" id="user-label" style="font-size: larger; font-weight: bold;">👤</span>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Correo electrónico" />
                                </div>

                                <div class="input-group mb-3">
                                    <span class="input-group-text" id="pass-label" style="font-size: larger; font-weight: bold;">🔒</span>
                                    <asp:TextBox runat="server" ID="txtPass" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
                                </div>

                                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-success" OnClick="btnIngresar_Click" />
                            </div>
                        </div>

                        <br />

                        <div class="row" style="display: flex; text-align: center;">
                            <div class="col-12">
                                <p class="d-inline" style="color: white;">¿No tienes una cuenta?</p>
                                <a href="Registro.aspx" class="d-inline">Registrate</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
