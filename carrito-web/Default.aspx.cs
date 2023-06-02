﻿using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace carrito_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        public Carrito carrito { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            carrito = (Carrito)Session["ListaItems"];

            if (carrito == null)
            {
                carrito = new Carrito();
                Session["ListaItems"] = carrito;
            }

            ListaArticulo = negocio.listarConSP(); //deberia ser carrito.ListaArticulos ahora???
            repRepetidor.DataSource = ListaArticulo;//deberia ser carrito.ListaArticulos ahora???
            repRepetidor.DataBind();

            /*Primera vez que carga la pagina*/
            if (!IsPostBack)
            {
                Label lblSeccion = Master.FindControl("lblSeccion") as Label;
                lblSeccion.Text = "NUESTROS PRODUCTOS";

                if (Session["TotalCarrito"] == null)
                {
                    Session["TotalCarrito"] = 0;
                }
            }

            Label lblCantCarrito = Master.FindControl("lblCantCarrito") as Label;
            lblCantCarrito.Text = carrito.ListaItems.Count.ToString();
            Label lblCantCarritoBoton = Master.FindControl("lblCantCarritoBoton") as Label;
            lblCantCarritoBoton.Text = lblCantCarrito.Text;
        }
    }
}