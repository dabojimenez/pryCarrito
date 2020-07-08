using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pryCarrito.web.WebFormularios.Administracion.Producto
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtStockMaximo_TextChanged(object sender, EventArgs e)
        {

        }

        private void nuevoProducto()
        {
            lblId.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStockMaximo.Text = "";
            txtStockMinimo.Text = "";
            UC_CATEGORIA1.DropDownList.SelectedIndex = 0;
        }

        protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
        {
            nuevoProducto();
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            nuevoProducto();
        }
    }
}