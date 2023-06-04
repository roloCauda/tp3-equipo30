using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace carrito_web
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();

            Carrito carrito = (Carrito)Session["ListaItems"];

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "DETALLE DEL PRODUCTO";
            }

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            Label lblPrecio = Master.FindControl("lblPrecio") as Label;
            lblPrecio.Text = "$" + carrito.total.ToString();

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
                    lblPrecioArt.Text = art.Precio.ToString();
                    Session["ArticuloSeleccionado"] = art;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            rptItems.DataSource = art.ListaImagenes;
            rptItems.DataBind();
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];
            Articulo artSeleccionado = (Articulo)Session["ArticuloSeleccionado"];

            bool articuloYaExiste = false;

            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == artSeleccionado.IdArticulo)
                {
                    item.Cantidad += 1;
                    articuloYaExiste = true;
                    break;
                }
            }

            if (!articuloYaExiste)
            {
                ItemCarrito nuevoItem = new ItemCarrito
                {
                    Articulo = artSeleccionado,
                    Cantidad = 1
                };

                carrito.ListaItems.Add(nuevoItem);
            }

            carrito.total += artSeleccionado.Precio;

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            Label lblPrecio = Master.FindControl("lblPrecio") as Label;
            lblPrecio.Text = "$" + carrito.total.ToString();
            Response.Redirect("DetalleProducto.aspx?id=" + artSeleccionado.IdArticulo);
        }

        protected void btnQuitar_click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];
            Articulo artSeleccionado = (Articulo)Session["ArticuloSeleccionado"];

            ItemCarrito itemExistente = null;

            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == artSeleccionado.IdArticulo)
                {
                    itemExistente = item;
                    break;
                }
            }

            if (itemExistente != null)
            {
                if (itemExistente.Cantidad > 1)
                {
                    itemExistente.Cantidad -= 1;
                }
                else
                {
                    carrito.ListaItems.Remove(itemExistente);
                }

                carrito.total -= artSeleccionado.Precio;

                Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
                lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
                Response.Redirect("DetalleProducto.aspx?id=" + artSeleccionado.IdArticulo);
            }
        }
    }
}
