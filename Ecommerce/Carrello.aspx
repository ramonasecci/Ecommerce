<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="Ecommerce.Carrello" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-4">
        <div class="d-flex justify-content-between">
            <h2>Il tuo carrello</h2>

            <asp:Button ID="btnClearCart" runat="server" Text="Svuota Carrello" OnClick="btnClearCart_Click" CssClass="btn btn-outline-danger my-3" />
        </div>
        

        <div id="contentTot" runat="server" class="mb-3"></div>

        <ul id="htmlContent" runat="server" class="list-group w-75 mx-auto">
            <asp:Repeater ID="rptCartItems" runat="server" OnItemCommand="rptCartItems_ItemCommand">
                <ItemTemplate>
                    <li class="list-group-item d-flex justify-content-between align-items-center">
                        <div class="d-flex align-items-center">
                            <p class="mb-0"><%# Eval("Nome") %></p>
                        </div>
                        <div class="d-flex align-items-baseline">
                            <p class="mb-0 me-3"><%# Eval("Prezzo", "{0:C}") %></p>
                            <asp:Button runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'
                                CssClass="btn btn-outline-dark" Text="🗑" OnClientClick="return confirm('Sei sicuro di voler eliminare questo elemento?');" />
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>


