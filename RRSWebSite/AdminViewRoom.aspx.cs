using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminAvailableRoom : System.Web.UI.Page
{

    Building building = new Building();
    User user = new User();
    Room room = new Room();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            DropDownListBuildingID.Items.Add("--Select--");
            foreach (var Item in building.GetBuildingIDs())
            {
                DropDownListBuildingID.Items.Add(Item.ToString());
            }
        }



    }


    protected void DropDownListBuildingID_SelectedIndexChanged(object sender, EventArgs e)
    {


        LabelUser.Text = user.GetUserFullName(building.GetUserID(DropDownListBuildingID.SelectedItem.ToString())).ToString();
        DropDownListRoomID.Items.Clear();
        DropDownListRoomID.Items.Add("--Select--");

        foreach (var item in room.GetRoomIDs(DropDownListBuildingID.SelectedItem.ToString()))
        {
            DropDownListRoomID.Items.Add(item.ToString());
        }
    }
   


    protected void DropDownListRoomID_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelCapacity.Text = room.GetRoomCapacity(DropDownListRoomID.SelectedItem.ToString());
    }
}
    
