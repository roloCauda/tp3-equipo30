<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="carrito_web.DetalleProducto" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <div class="col-md-6">

                <!--Inicio Carousel-->
                <div id="carouselExample" class="carousel slide">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptItems" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item<%# Container.ItemIndex == 0 ? " active" : "" %>">
                                    <img src='<%# Eval("ImagenURL") %>' class="d-block w-100" alt="...">
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
        <div class="col-md-6">
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
        </div>
    </div>
    </div>

</asp:Content>



