<%@ Page Title="Pago" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ClinicaApp.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="3">
                <h2><b><%= this.Page.Title %></b></h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbTratamiento" runat="server" Text="Tratamiento:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:DropDownList ID="ddlTratamiento" runat="server" CssClass="form-control" DataValueField="value" DataTextField="text"></asp:DropDownList>
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
                <asp:Label ID="lbFolio" runat="server" Text="Folio:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtFolio" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbImporte" runat="server" Text="Importe:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtImporte" runat="server" Width="200" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbConcepto" runat="server" Text="Concepto:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtConcepto" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
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
