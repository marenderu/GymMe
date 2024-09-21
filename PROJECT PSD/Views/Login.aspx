<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROJECT_PSD.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Views/Styles/LoginStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>LOGIN PAGE</h1>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <div>
            <asp:Label ID="lblUsername" Text="Username" runat="server" />
            <asp:TextBox ID="txtUsername" runat="server" />
        </div>
        <div>
            <asp:Label ID="lblPassword" Text="Password" runat="server" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/>
        </div>
        <div class="checkbox-container">
            <asp:CheckBox ID="chkRememberMe" Text="Remember Me" runat="server" />
        </div>
        <br />
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
        <br />
        <br />
        <asp:HyperLink ID="hlRegister" NavigateUrl="~/Views/Register.aspx" runat="server"> Don't have an account yet? Register here</asp:HyperLink>
    </form>
</body>
</html>
