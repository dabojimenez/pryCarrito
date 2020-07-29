<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoNuevo.aspx.cs" Inherits="pryCarrito.web.WebFormularios.Administracion.Producto.wfmProductoNuevo" %>
<%--                                            IMPORTANTE
Se debe colocar siempre nuestro <%@ Register %> para hacer uso de nuestro user control, y este es
individual dependiendo del numero de user control que se tenga y que obviamente use este formulario--%>
<%@ Register Src="~/UserControl/UCCategoria.ascx" TagName="UC_CATEGORIA" TagPrefix="UC1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../js/previewImagen.js"></script>
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
                           <asp:ImageButton ID="imgRegresar" runat="server" ImageUrl="~/imagenes/hacia-atras.png" Width="30px" Height="30px" OnClick="imgRegresar_Click" />
                           <asp:LinkButton ID="lnkRegresar" runat="server" OnClick="lnkRegresar_Click" >Regresar</asp:LinkButton>
                       </td>
                       <td>
                           <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/imagenes/archivo-nuevo.png" Width="30px" Height="30px" OnClick="imgNuevo_Click" CausesValidation="false" />
                           <asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="false" OnClick="lnkNuevo_Click">Nuevo</asp:LinkButton>
                       </td>
                       <td>
                           <asp:ImageButton ID="imgGuardar" runat="server" ImageUrl="~/imagenes/disco-flexible.png" Width="30px" Height="30px" CausesValidation="false" OnClick="imgGuardar_Click" />
                           <asp:LinkButton ID="lnkGuardar" runat="server" CausesValidation="false" OnClick="lnkGuardar_Click">Guardar</asp:LinkButton>
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
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Categoria</td>
            <td>
                <%--<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>
                <UC1:UC_CATEGORIA ID="UC_CATEGORIA1" runat="server"></UC1:UC_CATEGORIA>
            </td>
        </tr>
        <tr>
            <td>Codigo</td>
            <td>
                <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Codigo Campo Obligatorio" ControlToValidate="txtCodigo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Nombre</td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nombre Campo Obligatorio" ControlToValidate="txtNombre" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Precio de Compra</td>
            <td>
                <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precio de compra Obligatorio" ControlToValidate="txtPrecioCompra" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Precio de Venta</td>
            <td>
                <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Precio de Venta Obligatorio" ControlToValidate="txtPrecioVenta" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Imagen</td>
            <td>
                <%--https://forums.asp.net/t/2056960.aspx?how+to+show+image+before+upload+using+asp+net+c+--%>
                <asp:FileUpload ID="fuimage" runat="server" onchange="showpreview(this);" />
                <asp:Image ID="imgpreview2" runat="server" height="200" width="200" src="" style="width:180px; visibility: hidden;"/>
                <img id="imgpreview" height="200" width="200" src="" style="width:180px; visibility: hidden;" />
            </td>
        </tr>
        <tr>
            <td>Descripcion</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Descripcion Campo Obligatorio" ControlToValidate="txtDescripcion" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Stock Minimo</td>
            <td>
                <asp:TextBox ID="txtStockMinimo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Stock Minimo Campo Obligatorio" ControlToValidate="txtStockMinimo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Stock Maximo</td>
            <td>
                <asp:TextBox ID="txtStockMaximo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Stock Maximo Campo Obligatorio" ControlToValidate="txtStockMaximo" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ShowMessageBox="True" />
            </td>
        </tr>
    </table>


</asp:Content>
