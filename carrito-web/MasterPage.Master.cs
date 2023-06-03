using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace carrito_web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public Carrito carrito { get; set; }
        public List<ItemCarrito> ListaItems { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            carrito = (Carrito)Session["ListaItems"];

            // ListaItems = carrito.listar(); //deberia ser carrito.ListaArticulos ahora???
            repInfoCarrito.DataSource = carrito.ListaItems;//deberia ser carrito.ListaArticulos ahora???
            repInfoCarrito.DataBind();


        }
    }
}