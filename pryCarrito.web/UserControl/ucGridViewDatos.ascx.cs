using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pryCarrito.web.UserControl
{
    public partial class ucGridViewDatos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public GridView GridView
        {
            get
            {
                return GridView1;
            }
            set
            {
                GridView1 = value;
            }
        }

        public void loadData(dynamic _lista)
        {
            if (_lista != null)
            {
                GridView1.DataSource = _lista;
                GridView1.DataBind();
            }
        }
        //nos permite capturar un evento con RowCommand
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Modificar")
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}