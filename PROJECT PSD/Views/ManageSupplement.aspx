<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="PROJECT_PSD.Views.ManageSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Views/Styles/GridStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Manage Supplement</h1>
    <div>
        <asp:GridView ID="ManageSupplementGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" DataKeyNames="SupplementID" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView">
            <Columns>
                <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
                <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                <asp:ButtonField CommandName="Edit" Text="Update" />
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="NoDataLabel" runat="server" Text="There is no data available." ForeColor="Red" Font-Bold="True" />
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert A New Supplement" OnClick="InsertBtn_Click" />
</asp:Content>
