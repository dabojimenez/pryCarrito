using pryCarrito.web.Logica;
using pryCarrito.web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pryCarrito.web.WebFormularios.Administracion.Producto
{
    public partial class wfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var taskProducto = Task.Run(() => logicaProducto.getAllProduct());
                taskProducto.Wait();
                var listaProdutco = taskProducto.Result;
                loadProductos(listaProdutco);
            }

            UC_EventosGRDProductos();

        }

        private void UC_EventosGRDProductos()
        {
            GridView gridview = (GridView)this.UC_Datos1.FindControl("GridView1");
            gridview.RowCommand += new GridViewCommandEventHandler(Uc_GrdProducto_RowCommand);
            gridview.PageIndexChanging += new GridViewPageEventHandler(GridView1_PageIndexChanging);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gridview = (GridView)this.UC_Datos1.FindControl("GridView1");
            gridview.PageIndex = e.NewPageIndex;
            var taskProducto = Task.Run(() => logicaProducto.getAllProduct());
            taskProducto.Wait();
            var listaProducto = taskProducto.Result;
            loadProductos(listaProducto);
        }

        private void Uc_GrdProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //minuto 13:45
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                //METODO DE ENCRIPTACION
                string codigoEncriptado = Security.Encriptacion.encriptarCodigo(codigo);
                Response.Redirect("wfmProductoNuevo.aspx?cod="+ codigoEncriptado, true);
            }
            if (e.CommandName == "Eliminar")
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => logicaProducto.getProductXid(int.Parse(codigo)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;
                if (_infoProducto != null)
                {
                    var _taskSaveProducto = Task.Run(() => logicaProducto.deleteProducto(_infoProducto));
                    _taskSaveProducto.Wait();
                    var resultado = _taskSaveProducto.Result;
                    if (resultado)
                    {
                        var taskProducto2 = Task.Run(() => logicaProducto.getAllProduct());
                        taskProducto.Wait();
                        var listaProdutco = taskProducto2.Result;
                        loadProductos(listaProdutco);
                        Response.Write("<script>alert('Registro Eliminidado Correctamente')</script>");
                    }
                }
            }
        }

        private void loadProductos(List<TBL_PRODUCTO> _lista)
        {
            if (_lista.Count > 0 && _lista != null)
            {
                UC_Datos1.loadData(_lista.Select(data => new
                {
                    ID = data.PRO_ID,
                    CODIGO = data.PRO_CODIGO,
                    NOMBRE = data.PRO_NOMBRE,
                    PRECIO_C = data.PRO_PRECIOCOMPRA,
                    PRECIO_V = data.PRO_PRECIOVENTA,
                    STOCK_MIN = data.PRO_STOCKMINIMO,
                    STOCK_MAX = data.PRO_STOCKMAXIMO,
                    CATEGORIA = data.TBL_CATEGORIA.CAT_NOMBRE,
                    ESTADO = data.PRO_STATUS
                }).ToList());
            }
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            search(ddlBuscar.SelectedValue);
        }

        private void search(string opcion)
        {
            string dato = txtBuscar.Text.TrimEnd().TrimStart();
            switch (opcion)
            {
                case "T":
                    var taskProducto = Task.Run(() => logicaProducto.getAllProduct());
                    taskProducto.Wait();
                    var listaProdutco = taskProducto.Result;
                    loadProductos(listaProdutco);
                    break;

                case "C":
                    var taskProducto2 = Task.Run(() => logicaProducto.getProductxCodigo(dato));
                    taskProducto2.Wait();
                    var listaProdutco2 = taskProducto2.Result;
                    loadProductos(listaProdutco2);
                    break;

                case "N":
                    var taskProducto3 = Task.Run(() => logicaProducto.getProductxNombre(dato));
                    taskProducto3.Wait();
                    var listaProdutco3 = taskProducto3.Result;
                    loadProductos(listaProdutco3);
                    break;

                case "CA":
                    var taskProducto4 = Task.Run(() => logicaProducto.getProductxCategoria(dato));
                    taskProducto4.Wait();
                    var listaProdutco4 = taskProducto4.Result;
                    loadProductos(listaProdutco4);
                    break;

                default:
                    break;

            }
        }

        private void nuevoProducto()
        {
            Response.Redirect("wfmProductoNuevo.aspx", true);
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