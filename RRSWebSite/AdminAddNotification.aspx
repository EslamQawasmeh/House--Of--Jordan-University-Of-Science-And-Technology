<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminAddNotification.aspx.cs" Inherits="AdminAddNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 88px;
        }
        .style3
        {
            width: 88px;
            height: 156px;
        }
        .style4
        {
            height: 156px;
        }
        .style5
        {
            width: 217px;
        }
        .style6
        {
            height: 156px;
            width: 217px;
        }
        .style7
        {
            width: 156px;
            height: 50px;
        }
        .style8
        {
            width: 217px;
            height: 50px;
        }
        .style9
        {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBoxTitle" runat="server" Width="220px" 
                    ></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label3" runat="server" Text="Text"></asp:Label>
            </td>
            <td class="style8">
                <asp:TextBox ID="TextBoxText" runat="server" Height="39px" 
                   style="margin-top: 0px" Width="230px"></asp:TextBox>
            </td>
            <td class="style9">
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
            </td>
            <td class="style6">
                <asp:Calendar ID="CalendarNotificationDate" runat="server" BackColor="#FFFFCC" 
                    BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" 
                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" 
                   
                    ShowGridLines="True" Width="220px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                        ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                </asp:Calendar>
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="ButtonAdd" runat="server"  Text="Add"
                    />
            </td>
            <td>
                <asp:Label ID="LabelMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

