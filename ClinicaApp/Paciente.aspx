<%@ Page Title="Paciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paciente.aspx.cs" Inherits="ClinicaApp.Paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="3">
                <h2><b><%= this.Page.Title %></b></h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbApePat" runat="server" Text="Apellido Paterno:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApePat" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbApeMat" runat="server" Text="Apellido Materno:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtApeMat" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbNombre" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbTelContacto" runat="server" Text="Teléfono de Contacto:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtTelContacto" runat="server" Width="200" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbResponsable" runat="server" Text="Responsable:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtResponsable" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbLugarResi" runat="server" Text="Lugar de Residencia:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtLugarResi" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbEstatus" runat="server" Text="Estatus:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbTipo" runat="server" Text="Tipo:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
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
