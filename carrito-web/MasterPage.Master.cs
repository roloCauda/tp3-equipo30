using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using System.Web.SessionState;

namespace carrito_web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public Carrito carrito { get; set; }
        public List<ItemCarrito> ListaItems { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaItems"] != null)
                {
                    carrito = (Carrito)Session["ListaItems"];
                }
                else
                {
                    carrito = new Carrito();
                    Session["ListaItems"] = carrito;
                }

                repInfoCarrito.DataSource = carrito.ListaItems;
                repInfoCarrito.DataBind();
                //updatePanelCarrito.Update();
            }
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

            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();

            lblPrecio.Text = "$" + carrito.total.ToString();

            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();
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

                lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
                lblPrecio.Text = "$" + carrito.total.ToString();

                repInfoCarrito.DataSource = carrito.ListaItems;
                repInfoCarrito.DataBind();
                //updatePanelCarrito.Update();
            }
        }

        protected void btnBorrar_click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];

            /*  Me trae el ID del articulo en esa linea  */
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

            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            lblPrecio.Text = "$" + carrito.total.ToString();

            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();
        }

        protected void btnVaciarCarrito_click(object sender, EventArgs e)
        {
            Carrito carrito = (Carrito)Session["ListaItems"];

            carrito.ListaItems.Clear(); 

            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            lblPrecio.Text = "$" + carrito.total.ToString();

            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();
        }
    }
}