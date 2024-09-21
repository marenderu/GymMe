<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="PROJECT_PSD.Views.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Views/Styles/GridStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TRANSACTION DETAIL PAGE</h1>
    <div>
        <asp:GridView ID="TransactionDetailGV" runat="server" AutoGenerateColumns="false" CssClass="GridView">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="TransactionID"></asp:BoundField>
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date"></asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                <asp:BoundField DataField="SupplementName" HeaderText="Name"></asp:BoundField>
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date"></asp:BoundField>
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price"></asp:BoundField>
                <asp:BoundField DataField="SupplementTypeName" HeaderText="Type"></asp:BoundField>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"></asp:BoundField>
            </Columns>
            <Columns>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
