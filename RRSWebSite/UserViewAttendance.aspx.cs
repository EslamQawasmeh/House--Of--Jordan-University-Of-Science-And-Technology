using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserViewAttendance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        StudentAttendance stdattend = new StudentAttendance();
        GridViewAttendance.DataSource = stdattend.GetAttendance(CalendarAttendanceDate.SelectedDate.Date.ToString("yyyy-MM-dd"), Session["UserID"].ToString());
        GridViewAttendance.DataBind();
    }
}