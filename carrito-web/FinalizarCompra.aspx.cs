using dominio;
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
            Carrito carrito = (Carrito)Session["ListaItems"];

            TextBox txtFiltro = Master.FindControl("txtFiltro") as TextBox;

            if (txtFiltro != null && !string.IsNullOrEmpty(txtFiltro.Text))
            {
                Response.Redirect("Default.aspx?txtFiltro=" + Server.UrlEncode(txtFiltro.Text));
            }

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "FINALIZAR COMPRA";
            }
            lblPrecio.Text = "$" + carrito.total.ToString();

            repFinalizar.DataSource = carrito.ListaItems;
            repFinalizar.DataBind();
        }

        protected void Comprar_Click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];

            carrito.ListaItems.Clear();

            carrito.total = 0;
            Session["ListaItems"] = carrito;

            Response.Redirect("Default.aspx");

        }
    }
}