using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAddNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        Notification not = new Notification();
        int notid = not.GetNotificationCount();
        int newnotid = 0 ;
        if(notid == 0)
        {
            newnotid = 1;
        }
        else
        {
            newnotid = notid +1 ;
        }
        if(not.AddNotification(newnotid.ToString(),TextBoxTitle.Text,TextBoxText.Text,CalendarNotificationDate.SelectedDate.Date.ToString("yyyy-MM-dd"),Session["UserID"].ToString()) > 0 )
        {
            LabelMessage.Text ="Notification Added";
        }
        else
        {
            LabelMessage.Text = "Error";
        }
    }
}

        











    