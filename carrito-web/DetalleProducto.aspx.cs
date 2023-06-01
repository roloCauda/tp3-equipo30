using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrito_web
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                if (lblSeccion != null)
                {
                    lblSeccion.Text = "DETALLE PRODUCTO";
                }
            }

            try
            {
                string idArticulo = Request.QueryString["id"].ToString();

                if (!string.IsNullOrEmpty(idArticulo))
                {
                    int id = int.Parse(idArticulo);
                    art = negocio.cargarArticulo(id);
                    lblNombre.Text = art.Nombre;
                    lblDescripcion.Text = art.Descripcion;
                    lblMarca.Text = art.IdMarca.Descripcion;
                    lblCategoria.Text = art.IdCategoria.Descripcion;
                    lblPrecio.Text = art.Precio.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            rptItems.DataSource = art.ListaImagenes;
            rptItems.DataBind();
        }
    }
}
