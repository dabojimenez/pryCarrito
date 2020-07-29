<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoLista.aspx.cs" Inherits="pryCarrito.web.WebFormularios.Administracion.Producto.wfmProductoLista" %>
<%@ Register Src="~/UserControl/ucGridViewDatos.ascx" TagName="UC_Datos" TagPrefix="UC1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div align="center" width="95%">
        <table width="92%">
            <tr>
                <td><h3>Lista de Producto</h3></td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
               <td align="left">
                   <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/imagenes/archivo-nuevo.png" Width="30px" Height="30px" OnClick="imgNuevo_Click" />
                   <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="false" OnClick="lnkNuevo_Click" >Nuevo</asp:LinkButton>
               </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="40%">
                        <tr>
                            <td>Buscar por</td>
                            <td>
                                <asp:DropDownList ID="ddlBuscar" runat="server">
                                    <asp:ListItem Value="T">Todos</asp:ListItem>
                                    <asp:ListItem Value="C">Codigo</asp:ListItem>
                                    <asp:ListItem Value="N">Nombre</asp:ListItem>
                                    <asp:ListItem Value="CA">Categoria</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/imagenes/buscar.png" Width="32px" Height="32px" OnClick="imgBuscar_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        </table>
                </td>
            </tr>
            <UC1:UC_Datos ID="UC_Datos1" runat="server">

                            </UC1:UC_Datos>
        </table>
    </div>
</asp:Content>
