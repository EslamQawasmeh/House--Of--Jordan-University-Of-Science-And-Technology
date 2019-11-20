using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminRoomRequest : System.Web.UI.Page
{
    RoomReservationRequest rrr = new  RoomReservationRequest();
    RoomReservation rr = new RoomReservation();
    Student std = new Student();
    void FillFullNames()
    {
        DropDownListStudentIDs.Items.Clear();
        DropDownListStudentIDs.Items.Add("--Select--");
        foreach (var item in rrr.GetStudentIDsRoomRequest())
	      {
		     DropDownListStudentIDs.Items.Add(item.ToString());
	      }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
           FillFullNames();
           GridViewStudentDetails.Visible = false;
       }

    }
  
    protected void DropDownListStudentIDs_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewStudentDetails.Visible = true;
        GridViewStudentDetails.DataSource = std.GetStudentDetails(DropDownListStudentIDs.SelectedItem.ToString()).Tables["Student"];
        GridViewStudentDetails.DataBind();
    }
   
    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        string Dicision = "";
        if (CheckBoxDicision.Checked)
        {
            Dicision = "Yes";
            if (rr.AddRoomReservation(DropDownListStudentIDs.SelectedItem.ToString(), rrr.GetRequestedRoomID(DropDownListStudentIDs.SelectedItem.ToString())) > 0)
            {
                if (rrr.UpdateRoomRequestState(DropDownListStudentIDs.SelectedItem.ToString(), Dicision) > 0)
                {
                    GridViewStudentDetails.Visible = false;
                    FillFullNames();
                    LabelMessage.Text = "Done";
                }
            }
            else
            {
                LabelMessage.Text = "Error";
            }
        }
    }


    protected void GridViewStudentDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBoxDicision_CheckedChanged(object sender, EventArgs e)
    {

    }
}
