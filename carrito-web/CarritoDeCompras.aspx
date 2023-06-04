<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CarritoDeCompras.aspx.cs" Inherits="carrito_web.CarritoDeCompras" EnableEventValidation="false" %>

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
                                                <asp:Label ID="lblNombreArticulo" runat="server" Text=""><%#Eval("Articulo.Nombre") %></asp:Label>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <div class="row">
                                                    <div class="col-lg-3 col-md-3">
                                                        <asp:Button ID="btnQuitar" runat="server" Text="-" type="button" Style="font-size: 14px;" OnClick="btnQuitar_click" CommandName="Quitar" CommandArgument='<%# Eval("Articulo.IdArticulo") %>'/>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3">
                                                        <button type="button" style="font-size: 14px;">
                                                            <asp:Label ID="lblCantArtEnCarrito" runat="server" Text=""><%#Eval("Cantidad") %></asp:Label>
                                                        </button>
                                                    </div>
                                                    <div class="col-lg-3 col-md-3">
                                                        <asp:Button ID="btnAgregar" runat="server" Text="+" type="button" Style="font-size: 14px;" OnClick="btnAgregar_click" CommandName="Agregar" CommandArgument='<%# Eval("Articulo.IdArticulo") %>' />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <asp:Label ID="lblPrcioArticulo" runat="server" Text=""><%#Convert.ToDecimal(Eval("Articulo.Precio")) * Convert.ToInt32(Eval("Cantidad")) %></asp:Label>
                                            </div>
                                            <div class="col-lg-2 col-md-2">
                                                <asp:Button ID="btnBorrar" runat="server" Text="Borrar" type="button" class="btn btn-primary" OnClick="btnBorrar_click" CommandName="Borrar" CommandArgument='<%# Eval("Articulo.IdArticulo") %>'/>

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
