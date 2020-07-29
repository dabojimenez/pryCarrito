<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmCatalago.aspx.cs" Inherits="pryCarrito.web.WebFormularios.Public.wfmCatalago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h4>Catalogo de Productos</h4>
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" Width="80%" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
                <tr>
                    <td aligen="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" Width="100px" ImageUrl='<%#Eval("URL")%>'/>
                    </td>
                </tr>
                <tr>
                    <td aligen="center">
                        <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre")%>'></asp:Label><br />
                        <asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("Precio")%>'></asp:Label><br />
                    </td>
                </tr>
                <tr>
                    <td aligen="center">
                        <asp:ImageButton ID="imgComprar" runat="server" Height="100px" Width="100px" ImageUrl="~/imagenes/comprar.png" CommandName="Comprar" CommandArgument='<%#Eval("ID") %>'/>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>



</asp:Content>
