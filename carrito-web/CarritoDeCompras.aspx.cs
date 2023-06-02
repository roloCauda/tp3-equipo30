using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace carrito_web
{
    public partial class CarritoDeCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cantArticulos;

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "CARRITO DE COMPRAS";
            }

            cantArticulos = (int)Session["CantCarrito"];

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = cantArticulos.ToString();
        }
    }
}