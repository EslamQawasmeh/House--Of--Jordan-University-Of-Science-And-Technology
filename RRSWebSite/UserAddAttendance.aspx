<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserAddAttendance.aspx.cs" Inherits="UserAddAttendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 119px;
        }
        .style3
        {
            width: 165px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label2" runat="server" Text="Building ID"></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListBuildingID" runat="server" Height="18px" 
                    Width="126px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Room ID "></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListRoomID" runat="server" Width="124px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                <asp:Label ID="Label3" runat="server" Text="Student ID"></asp:Label>
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListStudentID" runat="server" Width="124px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="LabelStudentName"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:CheckBox ID="CheckBoxIsAttend" runat="server" Text="Is Attend ?" 
                     />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="Button1" runat="server" Text="Save" />
            </td>
            <td>
                <asp:Label ID="LabelMessage" runat="server" Text="LabelMessage"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

