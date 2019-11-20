using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SocialAdviserViewInbox : System.Web.UI.Page
{
    SocialAdviserInbox SocialAdviserInbox = new SocialAdviserInbox();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownListStudentName.Items.Add("- - Select - -");
            foreach (var item in SocialAdviserInbox.GetStudentFullNames())
            {
                DropDownListStudentName.Items.Add(item.ToString());
            }
        }
    }
    protected void DropDownListStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewInbox.DataSource = SocialAdviserInbox.GetInbox(DropDownListStudentName.SelectedItem.ToString()).Tables["SocialAdviserInbox"];
        GridViewInbox.DataBind();
    }
}