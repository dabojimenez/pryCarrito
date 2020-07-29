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
    public partial class wfmCatalago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCatalogo();
            }
        }

        private void loadCatalogo()
        {
            //https://www.c-sharpcorner.com/article/how-to-convert-a-byte-array-to-a-string/
            //Link para convertir de bytes a string
            Task<List<TBL_PRODUCTO>> _taskProducto = Task.Run(() => logicaProducto.getAllProduct());
            _taskProducto.Wait();
            var _listaProducto = _taskProducto.Result;
            if (_listaProducto != null)
            {
                DataList1.DataSource = _listaProducto.Select(data => new
                {
                    ID = data.PRO_ID,
                    Nombre = data.PRO_NOMBRE,
                    Precio = data.PRO_PRECIOVENTA,
                    URL = Encoding.ASCII.GetString(data.PRO_IMAGEN, 0, data.PRO_IMAGEN.Length)
                }).ToList();
                DataList1.DataBind();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string codigo = e.CommandArgument.ToString();
            if (e.CommandName=="Comprar")
            {
                Response.Redirect("wfmCatalogoProducto.aspx?catCod=" + codigo,true);
            }
        }
    }
}