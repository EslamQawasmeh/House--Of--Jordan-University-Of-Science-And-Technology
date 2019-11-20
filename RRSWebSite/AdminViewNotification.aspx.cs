using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminViewNotification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Notification not = new Notification();
        GridViewNotification.DataSource = not.GetNotifications(CalendarNotificationDate.SelectedDate.ToString("yyyy-MM-dd")).Tables["Notification"];
        GridViewNotification.DataBind();
     
    }
}