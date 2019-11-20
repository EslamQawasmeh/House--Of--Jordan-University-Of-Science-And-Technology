<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminRoomRequest.aspx.cs" Inherits="AdminRoomRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style5
        {
            width: 128px;
        }
        .style6
        {
            width: 128px;
            height: 21px;
        }
        .style7
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style5">
                <asp:Label ID="Label1" runat="server" Text="Student IDs"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListStudentIDs" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="DropDownListStudentIDs_SelectedIndexChanged" 
                    Width="129px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridViewStudentDetails" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    onselectedindexchanged="GridViewStudentDetails_SelectedIndexChanged" 
                    Width="801px">
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
        <tr>
            <td class="style5">
                <asp:Label ID="Label2" runat="server" Text="Dicision"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="CheckBoxDicision" runat="server" 
                    oncheckedchanged="CheckBoxDicision_CheckedChanged" Text="Yes" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                <asp:Button ID="ButtonSave" runat="server" onclick="ButtonSave_Click" 
                    Text="Save" />
            </td>
        </tr>
        <tr>
            <td class="style6">
            </td>
            <td class="style7">
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

