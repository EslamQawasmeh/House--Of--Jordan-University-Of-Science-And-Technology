using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserAddAttendance : System.Web.UI.Page
{
    Building building = new Building();
    Room room = new Room();
    Student student = new Student();
    RoomReservation roomres = new RoomReservation();
    StudentAttendance stdattendance = new StudentAttendance();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            DropDownListBuildingID.Items.Add("-- Select --");

            foreach (var item in building.GetBuildingIDsforUser(Session["UserID"].ToString()))
            {
                DropDownListBuildingID.Items.Add(item.ToString());
            }

    }
}

    protected void DropDownListBuildingID_SelectedIndexChanged(object sender , EventArgs e)
    {
        DropDownListRoomID.Items.Clear();
        DropDownListRoomID.Items.Add("-- Select --");
        foreach (var item in room.GetRoomIDs(DropDownListBuildingID.SelectedItem.ToString()))
        {
            DropDownListRoomID.Items.Add(item.ToString());
        }
    }
    protected void DropDownListStudentID_SelectedIndexChanged( object sender , EventArgs e)
    {
        Label4.Text = student.GetStudentFullName(DropDownListStudentID.SelectedItem.ToString());
    }
    protected void DropDownListRoomID_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownListStudentID.Items.Add("-- Select --");
        foreach (var item in roomres.GetStudentIDs(DropDownListRoomID.SelectedItem.ToString()))
        {
            DropDownListStudentID.Items.Add(item.ToString());
        }
    }

        protected void ButtonSave_Click( object sender , EventArgs e )
        {
            string IsAttend = "NO" ;
            if(CheckBoxIsAttend.Checked)
            {
                IsAttend ="Yes";
            }
            else
            {
                IsAttend = "No";
            }
            if(stdattendance.AddAttendance(DropDownListStudentID.SelectedItem.ToString(),Label4.Text , DateTime.Now.Date.ToString("yyyy-DD-MM"),IsAttend , Session["UserID"].ToString())> 0)

            {
                LabelMessage.Text = "Done";
            }
            else
            {
                LabelMessage.Text="Error";
            }
       
        }
}


