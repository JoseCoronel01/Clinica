<%@ Page Title="Nota de Evolución" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotasEvolucion.aspx.cs" Inherits="ClinicaApp.NotasEvolucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="3">
                <h2><b><%= this.Page.Title %></b></h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbTitulo" runat="server" Text="Título:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbDescipcion" runat="server" Text="Descripción:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Width="200" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbFecha" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtFecha" runat="server" Width="200" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPaciente" runat="server" Text="Paciente:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlPaciente" runat="server" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbEstado" runat="server" Text="Estado:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" DataValueField="Id" DataTextField="Nombre"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <table style="margin-top: 8px;">
                    <tr>
                        <td>
                            <asp:Button ID="btnPrimero" runat="server" Text="Primero" CssClass="btn btn-danger" OnClick="btnPrimero_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnAnterior" runat="server" Text="Anterior" CssClass="btn btn-danger" OnClick="btnAnterior_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-secondary" OnClick="btnNuevo_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" CssClass="btn btn-success" OnClick="btnSiguiente_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnUltimo" runat="server" Text="Ultimo" CssClass="btn btn-success" OnClick="btnUltimo_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
