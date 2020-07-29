<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmCatalogoProducto.aspx.cs" Inherits="pryCarrito.web.WebFormularios.Public.wfmCatalogoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    Producto Seleccionado
    <table width="95%">
        <tr>
            <td align="center" width="40%">
                <asp:Image ID="imgCatalogoProducto" runat="server" Width="215px" Height="315px"/>
            </td>
            <td width="*" align="center" style="vertical-align:top">
                <table width="100%">
                     <tr>
                        <td>
                            <asp:Label ID="lblIdProducto" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h4><asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label></h4>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h5><asp:Label ID="lblDescripcion" runat="server" Text="Label"></asp:Label></h5>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <h5>Precio: USD$ <asp:Label ID="lblPrecio" runat="server" Text="Label"></asp:Label></h5>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            Cantidad: &nbsp;
                            <asp:TextBox ID="txtCantidad" runat="server" TextMode="Number" min="1" max="20" step="1" Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                    <br />
                    <tr>
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td Align="center">
                            <asp:ImageButton ID="imgComprarCarrito" runat="server" ImageUrl="~/imagenes/comprarCarrito.png" Height="50px" Width="50px" OnClick="imgComprarCarrito_Click"/>
                        </td>
                    </tr>
                </table>
            </td>

        </tr>
    </table>


</asp:Content>
