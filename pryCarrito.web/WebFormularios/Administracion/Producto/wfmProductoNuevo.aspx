<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="pryCarrito.web.WebFormularios.Administracion.Producto.wfmProductoNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td colspan="2">
                <h2><strong>Producto</strong></h2>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
               <table width="75%">
                   <tr>
                       <td>
                           <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/imagenes/archivo-nuevo.png" Width="30px" Height="30px" />
                           <asp:LinkButton ID="lnkNuevo" runat="server">Nuevo</asp:LinkButton>
                       </td>
                       <td>
                           <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/imagenes/disco-flexible.png" Width="30px" Height="30px"  />
                           <asp:LinkButton ID="lnkGuardar" runat="server">Guardar</asp:LinkButton>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>
            </td>
        </tr>
        <tr>
            <td>ID</td>
            <td>
                <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Categoria</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Codigo</td>
            <td>
                <asp:TextBox ID="txtCodifo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Precio de Compra</td>
            <td>
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Precio de Venta</td>
            <td>
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Imagen</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Stock Minimo</td>
            <td>
                <asp:TextBox ID="txtStockMinimo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Stock Maximo</td>
            <td>
                <asp:TextBox ID="txtStockMaximo" runat="server" OnTextChanged="txtStockMaximo_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Mensaje</td>
            <td>
                <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>


</asp:Content>
