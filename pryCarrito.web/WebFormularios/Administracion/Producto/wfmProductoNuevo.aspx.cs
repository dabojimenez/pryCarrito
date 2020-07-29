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
using System.IO;

namespace pryCarrito.web.WebFormularios.Administracion.Producto
{
    public partial class wfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    string codigo = Request["cod"].ToString();
                    //DESEMCRIPTAR
                    string desencriptarCodigo = Security.Encriptacion.desencriptarCodigo(codigo);
                    loadProducto(desencriptarCodigo);
                }

            }
        }

        private void loadProducto(string codigo)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var taskProducto = Task.Run(() => logicaProducto.getProductXid(int.Parse(codigo)));
            taskProducto.Wait();
            _infoProducto = taskProducto.Result;
            if (_infoProducto != null)
            {
                lblId.Text = _infoProducto.PRO_ID.ToString();
                txtCodigo.Text = _infoProducto.PRO_CODIGO.ToString();
                UC_CATEGORIA1.DropDownList.SelectedValue = _infoProducto.CAT_ID.ToString();
                txtNombre.Text = _infoProducto.PRO_NOMBRE;//21:55
                txtDescripcion.Text = _infoProducto.PRO_DESCRIPCION.ToString();
                txtPrecioCompra.Text = _infoProducto.PRO_PRECIOCOMPRA.ToString();
                txtPrecioVenta.Text = _infoProducto.PRO_PRECIOVENTA.ToString();
                txtStockMaximo.Text = _infoProducto.PRO_STOCKMAXIMO.ToString();
                txtStockMinimo.Text = _infoProducto.PRO_STOCKMINIMO.ToString();
                imgpreview2.ImageUrl = Encoding.ASCII.GetString(_infoProducto.PRO_IMAGEN, 0, _infoProducto.PRO_IMAGEN.Length);
                //imgpreview
            }
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

        private void guardarProducto()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                _infoProducto.PRO_CODIGO = txtCodigo.Text;
                _infoProducto.PRO_DESCRIPCION = txtDescripcion.Text.TrimStart().TrimEnd().ToUpper();
                //IMAGEN

                string ruta=null;
                if (fuimage.HasFile)
                {
                    if (!string.IsNullOrEmpty(txtCodigo.Text))
                    {
                        try
                        {
                            if (fuimage.PostedFile.ContentType=="image/png" || fuimage.PostedFile.ContentType == "image/jpg"
                                || fuimage.PostedFile.ContentType == "image/PNG" || fuimage.PostedFile.ContentType == "image/JPG")
                            {
                                if (fuimage.PostedFile.ContentLength < 100000)
                                {
                                    string nombreArchivo = txtCodigo.Text + ".jpg";
                                    //carga del archivo
                                    ruta = "~/imagenes/productos/" + nombreArchivo;
                                    fuimage.SaveAs(Server.MapPath(ruta));
                                }
                                else
                                {
                                    lblMensaje.Text = "El tamaño máximo de la imagen es de 100 Kb";
                                }
                            }
                            else
                            {
                                lblMensaje.Text = "Solo imagenes de tipo JPG y PNG";
                            }
                        }
                        catch (Exception)
                        {

                            throw new ArgumentException("Error al cargar la imagen del producto");
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "El codigo del producto es obligatorio.";
                    }
                }

                //if (fuimage.HasFile)
                //{
                //    string nombreArchivo = fuimage.FileName;
                //    ruta = "~/imagenes/productos/" + nombreArchivo;
                //    fuimage.SaveAs(Server.MapPath(ruta));
                //}
                byte[] array = Encoding.ASCII.GetBytes(ruta);
                _infoProducto.PRO_IMAGEN = array;

                _infoProducto.PRO_NOMBRE = txtNombre.Text.TrimStart().TrimEnd().ToUpper();
                _infoProducto.PRO_PRECIOCOMPRA = txtPrecioCompra.Text;
                _infoProducto.PRO_PRECIOVENTA = txtPrecioVenta.Text;
                _infoProducto.PRO_STOCKMAXIMO = txtStockMaximo.Text;
                _infoProducto.PRO_STOCKMINIMO = txtStockMinimo.Text;
                _infoProducto.CAT_ID = Convert.ToInt32( UC_CATEGORIA1.DropDownList.SelectedValue);
                var _taskSaveProducto = Task.Run(() => logicaProducto.saveProducto(_infoProducto));
                _taskSaveProducto.Wait();
                var resultado = _taskSaveProducto.Result;
                if (resultado)
                {
                    lblMensaje.Text = "Producto Guardado Correctamente";
                }
            }
            catch (Exception ex)
            {

                lblMensaje.Text = ex.Message;
            }
        }

        private void modificarProducto()
        {
            try
            {
                TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
                var taskProducto = Task.Run(() => logicaProducto.getProductXid(int.Parse(lblId.Text)));
                taskProducto.Wait();
                _infoProducto = taskProducto.Result;


                if (_infoProducto != null)
                {
                    _infoProducto.PRO_ID = int.Parse(lblId.Text);
                    _infoProducto.PRO_CODIGO = txtCodigo.Text;
                    _infoProducto.PRO_DESCRIPCION = txtDescripcion.Text.TrimStart().TrimEnd().ToUpper();
                    //IMAGEN

                    string ruta = null;
                    if (fuimage.HasFile)
                    {
                        if (!string.IsNullOrEmpty(txtCodigo.Text))
                        {
                            try
                            {
                                if (fuimage.PostedFile.ContentType == "image/png" || fuimage.PostedFile.ContentType == "image/jpg"
                                    || fuimage.PostedFile.ContentType == "image/PNG" || fuimage.PostedFile.ContentType == "image/JPG"
                                    || fuimage.PostedFile.ContentType == "image/jpeg" || fuimage.PostedFile.ContentType == "image/JPEG")
                                {
                                    if (fuimage.PostedFile.ContentLength < 100000)
                                    {
                                        string nombreArchivo = txtCodigo.Text + ".jpg";
                                        //carga del archivo
                                        ruta = "~/imagenes/productos/" + nombreArchivo;
                                        fuimage.SaveAs(Server.MapPath(ruta));
                                    }
                                    else
                                    {
                                        lblMensaje.Text = "El tamaño máximo de la imagen es de 100 Kb";
                                    }
                                }
                                else
                                {
                                    lblMensaje.Text = "Solo imagenes de tipo JPG y PNG";
                                }
                            }
                            catch (Exception)
                            {

                                throw new ArgumentException("Error al cargar la imagen del producto");
                            }
                        }
                        else
                        {
                            lblMensaje.Text = "El codigo del producto es obligatorio.";
                        }
                    }

                    //string ruta = null;
                    //if (fuimage.HasFile)
                    //{
                    //    string nombreArchivo = fuimage.FileName;
                    //    ruta = "~/imagenes/productos/" + nombreArchivo;
                    //    fuimage.SaveAs(Server.MapPath(ruta));
                    //}
                    byte[] array = Encoding.ASCII.GetBytes(ruta);
                    _infoProducto.PRO_IMAGEN = array;

                    _infoProducto.PRO_NOMBRE = txtNombre.Text.TrimStart().TrimEnd().ToUpper();
                    _infoProducto.PRO_PRECIOCOMPRA = txtPrecioCompra.Text;
                    _infoProducto.PRO_PRECIOVENTA = txtPrecioVenta.Text;
                    _infoProducto.PRO_STOCKMAXIMO = txtStockMaximo.Text;
                    _infoProducto.PRO_STOCKMINIMO = txtStockMinimo.Text;
                    _infoProducto.CAT_ID = Convert.ToInt32(UC_CATEGORIA1.DropDownList.SelectedValue);
                    var _taskSaveProducto = Task.Run(() => logicaProducto.updateProducto(_infoProducto));
                    _taskSaveProducto.Wait();
                    var resultado = _taskSaveProducto.Result;
                    if (resultado)
                    {
                        lblMensaje.Text = "Producto Modificado Correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }

        protected void lnkGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                guardarProducto();
                
            }
            else
            {
                modificarProducto();
            }
        }

        protected void imgGuardar_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(lblId.Text))
            {
                guardarProducto();

            }
            else
            {
                modificarProducto();
            }
        }

        private void regresar()
        {
            Response.Redirect("wfmProductoLista.aspx", true);
        }

        protected void imgRegresar_Click(object sender, ImageClickEventArgs e)
        {
            regresar();
        }

        protected void lnkRegresar_Click(object sender, EventArgs e)
        {
            regresar();
        }
    }
}