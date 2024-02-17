<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Dettaglio.aspx.cs" Inherits="Ecommerce.Dettaglio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg my-4">
        <div class="row">
            <div class="col-lg-6">
                <h2 ID="ttlProduct" runat="server" class="mb-3"></h2>
                <img ID="img" alt="" class="w-50 mb-3" runat="server"/>
            </div>
            <div class="col-lg-6">
                <h5>Descrizione</h5>
                <p ID="txtDescription" runat="server" class="lead mb-4"></p>
                <p ID="txtPrice" runat="server" class="h4 mb-4"></p>
                <asp:Button ID="btnAddCart" runat="server" Text="Add to Cart" CssClass="btn btn-dark rounded-pill" OnClick="btnAddCart_Click"/>
                <p id="txtConfirm" runat="server" class="mt-3 text-success"></p>
            </div>
        </div>
    </div>
</asp:Content>
