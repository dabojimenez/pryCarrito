using pryCarrito.web.Logica;
using pryCarrito.web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pryCarrito.web.UserControl
{
    public partial class UCCategoria : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcCargar();
            }
        }

        public DropDownList DropDownList
        {
            get
            {
                return DropDownList1;
            }
            set
            {
                DropDownList1 = value;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return DropDownList1.SelectedIndex;
            }
            set
            {
                DropDownList1.SelectedIndex = value;
            }
        }

        public void UcCargar()
        {
            Task<List<TBL_CATEGORIA>> _taskCategoria = Task.Run(() => logicaCategoria.GetAllCategorias());
            _taskCategoria.Wait();
            var _listaCategoria = _taskCategoria.Result;
            if (_listaCategoria!= null && _listaCategoria.Count>0)
            {
                var data = _listaCategoria.OrderBy(lista => lista.CAT_NOMBRE).ToList();
                data.Insert(0, new TBL_CATEGORIA { CAT_NOMBRE = "Seleccione Categoria", CAT_ID = 0 });
                DropDownList1.DataSource = data;
                DropDownList1.DataTextField = "CAT_NOMBRE";
                DropDownList1.DataValueField = "CAT_ID";
                DropDownList.DataBind();
            }
        }

    }
}