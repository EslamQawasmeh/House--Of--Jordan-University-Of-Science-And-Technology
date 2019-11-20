using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        User user = new User();
        string userfn = user.Login(TextBoxUserID.Text, DropDownListUserType.SelectedItem.ToString(), TextBoxPassword.Text);


        if (userfn != "")
        {

            if (Session["FullName"] == null)
            {
                Session.Add("FullName", userfn);
            }
            else
            {
                Session["FullName"] = userfn;
            }
            if (Session["UserID"] == null)
            {
                Session.Add("UserID", TextBoxUserID.Text);
            }
            else
            {
                Session["UserID"] = TextBoxUserID.Text;
            }

            if (DropDownListUserType.SelectedItem.ToString() == "Admin")
            {
                Response.Redirect("AdminMainPage.aspx");
            }

            if (DropDownListUserType.SelectedItem.ToString() == "User")
            {
                Response.Redirect("UserMainPage.aspx");
            }
          

            if(DropDownListUserType.SelectedItem.ToString()=="Social Advisor")
            {
                Response.Redirect("SocialAdviserMain.aspx");
            }
          
        }
        else
        {
            ErrorMessage.Text = "Invalid Username or password";
        }

    }

}