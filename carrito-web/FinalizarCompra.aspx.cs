using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrito_web
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cantArticulos;

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "FINALIZAR COMPRA";
            }

            cantArticulos = (int)Session["CantCarrito"];

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = cantArticulos.ToString();
        }
    }
}