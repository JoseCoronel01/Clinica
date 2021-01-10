<%@ Page Title="Log In" Language="C#" MasterPageFile="~/SiteLogIn.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="ClinicaApp.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>
                <asp:Label ID="lbUsuario" runat="server" Text="Nombre de Usuario:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td style="width: 8px;"></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="200" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table style="margin-top: 8px;">
                    <tr>
                        <td>
                            <asp:Button ID="btnEntrar" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnEntrar_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
