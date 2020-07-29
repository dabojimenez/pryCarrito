using pryCarrito.web.Logica;
using pryCarrito.web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pryCarrito.web.WebFormularios.Public
{
    public partial class wfmCatalogoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["catCod"] != null)
                {
                    int codigoProducto = Convert.ToInt32(Request["catCod"].ToString());
                    loadProductoCatalogo(codigoProducto);
                }
            }
        }

        private void loadProductoCatalogo(int codigoProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => logicaProducto.getProductXid(codigoProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                lblIdProducto.Text = Convert.ToString(_infoProducto.PRO_ID);
                imgCatalogoProducto.ImageUrl = Encoding.ASCII.GetString(_infoProducto.PRO_IMAGEN, 0, _infoProducto.PRO_IMAGEN.Length);
                lblNombre.Text = _infoProducto.PRO_NOMBRE;
                lblDescripcion.Text = _infoProducto.PRO_DESCRIPCION;
                lblPrecio.Text = _infoProducto.PRO_PRECIOVENTA;
            }
        }

        protected void imgComprarCarrito_Click(object sender, ImageClickEventArgs e)
        {
            List<clsCarrito> _listaCarrito = new List<clsCarrito>();
            _listaCarrito = (List<clsCarrito>)Session["Carrito"];
            clsCarrito _infoProducto = new clsCarrito();
            _infoProducto.idProducto = int.Parse( lblIdProducto.Text);
            _infoProducto.cantidadProducto = int.Parse(txtCantidad.Text);
            _infoProducto.precioProducto = lblPrecio.Text;
            _infoProducto.nombreProducto = lblNombre.Text;
            _listaCarrito.Add(_infoProducto);
            Session["Carrito"] = _listaCarrito;
            Response.Redirect("wfmCatalago.aspx", true);
        }
    }
}