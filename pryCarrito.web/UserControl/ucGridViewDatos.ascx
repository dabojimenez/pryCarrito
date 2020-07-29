<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGridViewDatos.ascx.cs" Inherits="pryCarrito.web.UserControl.ucGridViewDatos" %>
<asp:GridView ID="GridView1" runat="server" align="center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="95%" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
    <Columns >
        <asp:TemplateField>
            <ItemTemplate>
                <%--Con CommandName, me permite pasar la variable indicando o hacienod referncia a que realizara esa variable.
                CommandArgument, permite enviar le argumento que sera usado en la programación, con los comandos Eval()
                Con OnClientClick, podemos incluir lo que es programación javascript, para enviar un mensaje o realizar una confirmación. --%>
                <asp:ImageButton ID="ibmModificar" runat="server" ImageUrl="~/imagenes/editar.png" Width="32px" Height="32px" CommandName="Modificar" CommandArgument='<%#Eval("ID")%>'/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="ibmEliminar" runat="server" ImageUrl="~/imagenes/eliminar.png" Width="32px" Height="32px" CommandName="Eliminar" CommandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('Desea eliminar el registro')"/>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="White" ForeColor="#000066" />
    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
    <RowStyle ForeColor="#000066" />
    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F1F1F1" />
    <SortedAscendingHeaderStyle BackColor="#007DBB" />
    <SortedDescendingCellStyle BackColor="#CAC9C9" />
    <SortedDescendingHeaderStyle BackColor="#00547E" />
</asp:GridView>