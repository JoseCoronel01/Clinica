<%@ Page Title="Listado de Notas de Evolución" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RNotas.aspx.cs" Inherits="ClinicaApp.RNotas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="3">
                <h2><b><%= this.Page.Title %></b></h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPacientes" runat="server" Text="Seleccionar un Paciente:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlPacientes" runat="server" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button ID="btnPacientes" runat="server" Text="Preliminar" OnClick="btnPacientes_Click" CssClass="btn btn-primary" />
            </td>
        </tr>
    </table>

</asp:Content>
