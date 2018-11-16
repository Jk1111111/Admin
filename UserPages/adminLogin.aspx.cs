using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPages_adminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(admId.Text == "" || admPass.Text == "" || RadioButtonList1.SelectedIndex < 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please fill the inforamtion')", true);
        }
        else if(admId.Text == "admin11" && admPass.Text == "hello" && RadioButtonList1.SelectedItem.Value == "Hospital")
        {
            Response.Redirect("hosInfoFill.aspx");
        }
        else if (admId.Text == "admin11" && admPass.Text == "hello" && RadioButtonList1.SelectedItem.Value == "Doctor")
        {
            Response.Redirect("doctorInfoFill.aspx");
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Invalid Password')", true);
        }
    }
}