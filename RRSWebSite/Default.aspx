<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 140px;
        }
        .style3
        {
            width: 310px;
        }
        .style4
        {
            width: 140px;
            height: 21px;
        }
        .style5
        {
            width: 310px;
            height: 21px;
        }
        .style6
        {
            height: 21px;
        }
        .style7
        {
            width: 140px;
            height: 35px;
        }
        .style8
        {
            width: 310px;
            height: 35px;
        }
        .style9
        {
            height: 35px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxUserID" runat="server" 
                    ></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td class="style6">
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label3" runat="server" Text="User Type"></asp:Label>
            </td>
            <td class="style8">
                <asp:DropDownList ID="DropDownListUserType" runat="server" Width="126px">
                    <asp:ListItem>Admin</asp:ListItem>
                    <asp:ListItem>User</asp:ListItem>
                    <asp:ListItem>Social Advisor</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="ButtonLogin" runat="server" onclick="ButtonLogin_Click" 
                    Text="Login" />
            </td>
            <td>
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
