<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="carrito_web.DetalleProducto" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row ">
            <div class="col-md-6">
                <div id="carouselExampleIndicators" class="carousel slide">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    </div>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="https://media.cnn.com/api/v1/images/stellar/prod/220920215114-iphone-14-lead.jpg?c=original" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="https://media.cnn.com/api/v1/images/stellar/prod/220920215114-iphone-14-lead.jpg?c=original" class="d-block w-100" alt="...">
                        </div>
                        <div class="carousel-item">
                            <img src="https://media.cnn.com/api/v1/images/stellar/prod/220920215114-iphone-14-lead.jpg?c=original" class="d-block w-100" alt="...">
                        </div>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>

            </div>
            <div class="col-md-6">
                <div>
                    <h2>Articulo</h2>
                    <ul>
                        <li>
                            <strong>Nombre:</strong> Articulo
                        </li>
                        <li>
                            <strong>Descripción:</strong> Descripción...
                        </li>
                        <li>
                            <strong>Marca:</strong> Marca del articulo...
                        </li>
                        <li>
                            <strong>Categoría:</strong> Categoría del articulo...
                        </li>
                        <li>
                            <strong>Precio:</strong> $20.000
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

