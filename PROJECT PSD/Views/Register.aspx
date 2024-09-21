<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PROJECT_PSD.Views.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Views/Styles/RegisterStyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <div>
                <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </div>
            <div>

                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div>

                <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem Value="" Text="Select Gender"></asp:ListItem>
                    <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>

                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>

                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>

                <asp:Label ID="lblDOB" Text="Date of Birth" runat="server" />
                <asp:Calendar ID="calDOB" runat="server" OnSelectionChanged="calDOB_SelectionChanged"></asp:Calendar>
                <asp:TextBox ID="txtDOB" runat="server" ReadOnly="true" />
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        <br />
            <br />
            <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Views/Home.aspx">Already have an account? Login here</asp:HyperLink>
        </div>
    </form>
</body>
</html>
