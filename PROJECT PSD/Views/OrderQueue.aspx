<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="PROJECT_PSD.Views.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div>
        <asp:GridView ID="TransactionQueueGV" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TransactionId" HeaderText="Transaction Id"></asp:BoundField>
                <asp:BoundField DataField="TransactionDate" HeaderText="Date"></asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="handle_btn" runat="server" Text="Handle Transaction" OnClick="handle_btn_Click" CommandArgument='<%# Eval("TransactionId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
