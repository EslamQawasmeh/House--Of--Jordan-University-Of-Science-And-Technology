<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminViewRoom.aspx.cs" Inherits="AdminAvailableRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 200px;
        }
        .style6
        {
            width: 200px;
            height: 26px;
        }
        .style7
        {
            height: 26px;
        }
        .style8
        {
            width: 200px;
            height: 21px;
        }
        .style9
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
                <asp:Label ID="Label1" runat="server" Text="Building ID "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListBuildingID" runat="server" 
                    onselectedindexchanged="DropDownListBuildingID_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <asp:Label ID="Label2" runat="server" Text="User"></asp:Label>
            </td>
            <td class="style9">
                <asp:Label ID="LabelUser" runat="server" Text="User"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <asp:Label ID="Label3" runat="server" Text="Room ID"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="DropDownListRoomID" runat="server" 
                    onselectedindexchanged="DropDownListRoomID_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label4" runat="server" Text="Capacity"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelCapacity" runat="server" Text="Capacity"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="Label5" runat="server" Text="Students"></asp:Label>
            </td>
            <td>
                <asp:GridView ID="GridViewStudentDetails" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
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

