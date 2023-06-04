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
            Carrito carrito = (Carrito)Session["ListaItems"];

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "CARRITO DE COMPRAS";
            }

            repCarrito.DataSource = carrito.ListaItems;
            repCarrito.DataBind();

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            Label lblPrecio = Master.FindControl("lblPrecio") as Label;
            lblPrecio.Text = "$" + carrito.total.ToString();
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            int idArticulo = Convert.ToInt32(btnAgregar.CommandArgument);
            Carrito carrito = (Carrito)Session["ListaItems"];
            Articulo artSeleccionado = (Articulo)Session["ArticuloSeleccionado"];

            bool articuloYaExiste = false;

            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == idArticulo)
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

            repCarrito.DataSource = carrito.ListaItems;
            repCarrito.DataBind();
        }

        protected void btnQuitar_click(object sender, EventArgs e)
        {
            Button btnQuitar = (Button)sender;
            int idArticulo = Convert.ToInt32(btnQuitar.CommandArgument);
            Carrito carrito = (Carrito)Session["ListaItems"];
            Articulo artSeleccionado = (Articulo)Session["ArticuloSeleccionado"];

            ItemCarrito itemExistente = null;

            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == idArticulo)
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
                Label lblPrecio = Master.FindControl("lblPrecio") as Label;
                lblPrecio.Text = "$" + carrito.total.ToString();

                repCarrito.DataSource = carrito.ListaItems;
                repCarrito.DataBind();
            }
        }


        protected void btnBorrar_click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];


            Button btnBorrar = (Button)sender;
            int idArticulo = Convert.ToInt32(btnBorrar.CommandArgument);

            for (int x = carrito.ListaItems.Count - 1; x >= 0; x--)
            {
                ItemCarrito item = carrito.ListaItems[x];
                if (item.Articulo.IdArticulo == idArticulo)
                {
                    carrito.total -= (item.Articulo.Precio * item.Cantidad);
                    carrito.ListaItems.RemoveAt(x);
                    break;
                }
            }

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();

            repCarrito.DataSource = carrito.ListaItems;
            repCarrito.DataBind();
            Response.Redirect("CarritoDeCompras.aspx");
        }
    }

}