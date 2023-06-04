﻿using System;
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
                    Articulo artSeleccionado = (Articulo)Session["ArticuloSeleccionado"];

                }
                else
                {
                    carrito = new Carrito();
                    Session["ListaItems"] = carrito;
                }

                repInfoCarrito.DataSource = carrito.ListaItems;
                repInfoCarrito.DataBind();
            }
        }

        protected void btnAgregar_click(object sender, EventArgs e)
        {
            /* Le asigno al botonbtnAgregar lo que me trae el boton agregar del front(id), lo casteo y lo guardo en un int */
            Button btnAgregar = (Button)sender;
            int idArticulo = Convert.ToInt32(btnAgregar.CommandArgument);

            /* Le asigna a carrito lo que esta guardado en Session*/
            Carrito carrito = (Carrito)Session["ListaItems"];

            /*  Busca el art en la lista y le suma una unidad */
            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == idArticulo)
                {
                    item.Cantidad += 1;
                    carrito.total += item.Articulo.Precio;
                    break;
                }
            }

            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();

            lblPrecio.Text = "$" + carrito.total.ToString();

            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();

            Session["ListaItems"] = carrito;
        }

        protected void btnQuitar_click(object sender, EventArgs e)
        {
            /* Le asigno al botonbtnAgregar lo que me trae el boton agregar del front(id), lo casteo y lo guardo en un int */
            Button btnQuitar = (Button)sender;
            int idArticulo = Convert.ToInt32(btnQuitar.CommandArgument);

            /* Le asigna a carrito lo que esta guardado en Session["ListaItems"] */
            Carrito carrito = (Carrito)Session["ListaItems"];


            foreach (ItemCarrito item in carrito.ListaItems)
            {
                if (item.Articulo.IdArticulo == idArticulo)
                {
                    if (item.Cantidad > 1)
                    {
                        item.Cantidad -= 1;
                        carrito.total -= item.Articulo.Precio;
                    }
                    else
                    {
                        carrito.total -= item.Articulo.Precio;
                        carrito.ListaItems.Remove(item);
                    }

                    /*  Actualiza las Label de la Master */

                    lblCantCarrito.Text = carrito.ListaItems.Count.ToString();

                    lblPrecio.Text = "$" + carrito.total.ToString();

                    break;
                }
            }

            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();

            Session["ListaItems"] = carrito;
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

            carrito.total = 0;
            Session["ListaItems"] = carrito;

            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            lblPrecio.Text = "$" + carrito.total.ToString();


            repInfoCarrito.DataSource = carrito.ListaItems;
            repInfoCarrito.DataBind();
        }
    }
}