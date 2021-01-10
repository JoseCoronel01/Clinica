<%@ Page Title="Tratamiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tratamiento.aspx.cs" Inherits="ClinicaApp.Tratamiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table>
        <tr>
            <td colspan="3">
                <h2><b><%= this.Page.Title %></b></h2>
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
                <asp:Label ID="lbFechaI" runat="server" Text="Fecha de Ingreso:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtFechaI" runat="server" Width="200" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbFechaS" runat="server" Text="Fecha de Salida:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtFechaS" runat="server" Width="200" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbCostoI" runat="server" Text="Costo de Ingreso:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtCostoI" runat="server" Width="200" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbPlanM" runat="server" Text="Plan Mensual:"></asp:Label>
            </td>
            <td style="margin-top: 8px;"></td>
            <td>
                <asp:TextBox ID="txtPlanM" runat="server" Width="200" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="chBoxTratamiento" runat="server" Text="Aplíca el Pago de Ingreso." />
            </td>
            <td>
            </td>
            <td>
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
