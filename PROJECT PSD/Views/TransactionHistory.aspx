<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="PROJECT_PSD.Views.TransactionHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Views/Styles/GridStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TRANSACTION HISTORY PAGE</h1>
    <div>
        <asp:GridView ID="TransactionHistoryGV" runat="server" AutoGenerateColumns="false" CssClass="GridView">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id"></asp:BoundField>
                <asp:BoundField DataField="TransactionDate" HeaderText="Date"></asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Detail_btn" runat="server" Text="Details" OnClick="Detail_btn_Click" CommandArgument='<%# Eval("TransactionId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
