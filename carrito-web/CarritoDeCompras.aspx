<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="carrito_web.CarritoDeCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding:25px; justify-content:center;">
        <div class="row" style="display:flex; justify-content:center;">

            <div class="col-md-7" style="border: 3px solid #3b71ca; border-radius: 15px; height: 100vh; margin-right: 25px;">
                <asp:Repeater ID="repCarrito" runat="server">
                    <ItemTemplate>
                        <div class="row" style="justify-content: space-around; align-items: center; text-align: center;">
                                            <div class="col-lg-2 col-md-2 custom-img">
                                                <img src="<%#Eval("Articulo.ListaImagenes[0].ImagenURL") %>" class="card-img-top" alt="...">
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <asp:Label ID="Label2" runat="server" Text=""><%#Eval("Articulo.Nombre") %></asp:Label>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3">
                                                        <asp:Button ID="btnQuitarAlCarrito" runat="server" Text="-" type="button" Style="font-size: 14px;" />
                                                    </div>
                                                    <div class="col-lg-3 col-md-3">
                                                        <button type="button" style="font-size: 14px;">
                                                            <asp:Label ID="Label1" runat="server" Text="1"></asp:Label>
                                                        </button>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3">
                                                        <asp:Button ID="btnAgregarAlCarrito" runat="server" Text="+" type="button" Style="font-size: 14px;" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <asp:Label ID="Label3" runat="server" Text=""><%#Eval("Articulo.Precio") %></asp:Label>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <asp:Button ID="Button1" runat="server" Text="Borrar" type="button" class="btn btn-primary" />

                                            </div>
                                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <div class="col-md-4" style="border: 3px solid #3b71ca; border-radius:15px; height: 100vh; text-align:center;">
                <div>
                    <h2>Resumen de la Compra</h2>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
