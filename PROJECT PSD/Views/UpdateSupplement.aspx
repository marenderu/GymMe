<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="PROJECT_PSD.Views.UpdateSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Views/Styles/InsertUpdateStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="insertupdate">
        <h1>Update Supplement</h1>
    <div>
        <asp:Label ID="NameLbl" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Label ID="ExpDateLbl" runat="server" Text="Expiry Date: "></asp:Label>
        <asp:TextBox ID="ExpDateTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="PriceLbl" runat="server" Text="Price: "></asp:Label>
        <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="TypeIDLbl" runat="server" Text="Type ID: "></asp:Label>
        <asp:TextBox ID="TypeIDTB" runat="server"></asp:TextBox>
    </div>
    <br />
    <asp:Button ID="UpdateBtn" runat="server" Text="Update Supplement" OnClick="UpdateBtn_Click" />
    <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" />
    <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red"></asp:Label>
        </div>
</asp:Content>
