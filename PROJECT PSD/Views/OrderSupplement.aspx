<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="PROJECT_PSD.Views.OrderSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>All Supplement Lists</h2>
        <asp:Label ID="lblMessage" Text="" runat="server" ForeColor="Red" />
        <asp:GridView ID="OrderSupplementGV" runat="server" AutoGenerateColumns="false" OnRowCommand="OrderSupplementGV_RowCommand">
            <Columns>
                <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name"></asp:BoundField>
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date"></asp:BoundField>
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price"></asp:BoundField>
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Type"></asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="quanlbl" runat="server" Text="Quantity"></asp:Label>
                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="hfSupplementID" Value='<%# Eval("SupplementID") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAddToCart" runat="server" Text="add to cart" CommandName ="AddToCart" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <%-- Add to cart View --%>
    <div>
        <h2>Your cart</h2>
        <asp:GridView ID="cartGV" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="CartID" HeaderText="Cart ID" SortExpression="CartID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" />
                <asp:BoundField DataField="SupplementID" HeaderText="Supplement ID" SortExpression="SupplementID" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />

                <asp:TemplateField HeaderText="SubTotal">
                    <ItemTemplate>
                        <asp:Label ID="subTotal" Text="" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <%-- total --%>
    <div>
        Total Price =  <asp:Label ID="lblTotalPrice" Text="" runat="server" />
    </div>

    <%-- checkout and clear --%>
    <asp:Button ID="btnCheckout" Text="Checkout" runat="server" OnClick="btnCheckout_Click" />
    <asp:Button ID="btnClearCart" Text="Clear Cart" runat="server" OnClick="btnClearCart_Click" />

</asp:Content>
