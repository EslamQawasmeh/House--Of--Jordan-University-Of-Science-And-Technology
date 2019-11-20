<%@ Page Title="" Language="C#" MasterPageFile="~/SocialAdviserMasterPage.master" AutoEventWireup="true" CodeFile="SocialAdviserViewInbox.aspx.cs" Inherits="SocialAdviserViewInbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 165px;
            height: 148px;
        }
        .style3
        {
            width: 165px;
            height: 52px;
        }
        .style4
        {
            height: 52px;
        }
        .style5
        {
            height: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Student Name"></asp:Label>
            </td>
            <td class="style4">
                <asp:DropDownList ID="DropDownListStudentName" runat="server" Height="25px" 
                    onselectedindexchanged="DropDownListStudentName_SelectedIndexChanged" 
                    Width="181px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
            </td>
            <td class="style5">
                <asp:GridView ID="GridViewInbox" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Height="16px" Width="499px">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

