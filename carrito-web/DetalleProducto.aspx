<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="carrito_web.DetalleProducto" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="../Estilos/EstilosDetalleProducto.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-detalle">
        <div class="row">
            <!--Columna 1-->
            <div class="col-md-6 carousel-estilo" style="background-color:white;">

                <!--Inicio Carousel-->
                <div id="carouselExample" class="carousel slide carousel-dark">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptItems" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                                    <div class="d-flex justify-content-center align-items-center">
                                        <img src='<%# Eval("ImagenURL") %>' class="img-fluid" alt="...">
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
                <!--Fin Carousel-->


            </div>
            <!--Columna 2-->
            <div class="col-md-6 d-flex flex-column align-items-center justify-content-center">
                <div>
                    <h2>Articulo</h2>
                    <ul>
                        <li>
                            <asp:Label ID="lblNombre" runat="server" Text="Label"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="lblPrecio" runat="server" Text=""></asp:Label>
                        </li>
                    </ul>
                </div>

                <div class="btn-group" role="group" aria-label="Basic example">


                    <asp:Button ID="btnQuitarAlCarrito" runat="server" Text="-" type="button" class="btn btn-primary" OnClick="btnQuitar_click"/>
                    <button type="button" class="btn btn-primary custom-button">
                        <asp:Label ID="lblCantCarrito" runat="server" Text="Agregar Al Carrito"></asp:Label>
                    </button>
                    <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="+" type="button" class="btn btn-primary" OnClick="btnAgregar_click" />
                </div>


            </div>
        </div>
    </div>

</asp:Content>



