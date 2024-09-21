<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="PROJECT_PSD.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Views/Styles/ProfileStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="profile-section">
     <h2>Update Profile</h2>
     <asp:Label ID="lblProfileMessage" runat="server" ForeColor="Red"></asp:Label>
     <br />
     <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
     <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
     <br />
     <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
     <br />

     <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
     <asp:DropDownList ID="ddlGender" runat="server">
         <asp:ListItem Value="" Text="Select Gender"></asp:ListItem>
         <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
         <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
     </asp:DropDownList>
     <br />
     <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:"></asp:Label>
     <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
     <br />
     <asp:Button ID="btnUpdateProfile" runat="server" Text="Update Profile" OnClick="btnUpdateProfile_Click" />
 </div>
 <br />
 <div class="password-section">
     <h2>Change Password</h2>
     <asp:Label ID="lblPasswordMessage" runat="server" ForeColor="Red"></asp:Label>
     <br />
     <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
     <asp:TextBox ID="txtOldPassword" runat="server"></asp:TextBox>
     <br />
     <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
     <asp:TextBox ID="txtNewPassword" runat="server"></asp:TextBox>
     <br />
     <asp:Button ID="btnUpdatePassword" runat="server" Text="Update Password" OnClick="btnUpdatePassword_Click" />
 </div>
</asp:Content>
