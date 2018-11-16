using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
public partial class UserPages_hosInfoFill : System.Web.UI.Page
{
    static int n = 100;
    string date;
    string Image;
    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Tab1.CssClass = "Clicked";
            MainView.ActiveViewIndex = 0;
        }
        BindDataList();
        updId.Enabled = true;
        updName.Enabled = false;
        updStreet.Enabled = false;
        updDes.Enabled = false;
        updMob.Enabled = false;
        updCategory.Enabled = false;
        updNoOfDoctor.Enabled = false;
        updStateList.Enabled = false;
        FileUpload2.Enabled = false;
        Button4.Enabled = false;
        Button5.Enabled = false;
        Button3.Enabled = true;
    }

    protected void Tab1_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Clicked";
        Tab2.CssClass = "Initial";
        Tab3.CssClass = "Initial";
        Tab4.CssClass = "Initial";
        MainView.ActiveViewIndex = 0;
    }

    protected void Tab2_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        Tab2.CssClass = "Clicked";
        Tab3.CssClass = "Initial";
        Tab4.CssClass = "Initial";
        MainView.ActiveViewIndex = 1;
    }

    protected void Tab3_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        Tab2.CssClass = "Initial";
        Tab3.CssClass = "Clicked";
        Tab4.CssClass = "Initial";
        MainView.ActiveViewIndex = 2;
    }

    protected void Tab4_Click(object sender, EventArgs e)
    {
        Tab1.CssClass = "Initial";
        Tab2.CssClass = "Initial";
        Tab3.CssClass = "Initial";
        Tab4.CssClass = "Clicked";
        MainView.ActiveViewIndex = 3;
    }

    string GenerateID()
    {
        int i;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select count(*) from HospitalsDetails", con))
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();
            }
        }
        i++;
        n += i;
        return addName.Text.Substring(0,3).ToUpper() + n.ToString();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (addName.Text == "" ||  addDes.Text == "" || addStreet.Text == ""  || addMob.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Fill all the information....')", true);
        }
        else
        {
            date = DateTime.Today.ToString("dd-MM-yyyy");
            string id = GenerateID();
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into HospitalsDetails values('" + id + "','" + addName.Text + "','" + addCategoryList.SelectedValue.ToString() + "','" + date + "'" +
                        ",'" + Image1.ImageUrl + "','" + addStreet.Text + "','" + addStateList.SelectedValue.ToString() + "','" + addNumberList.SelectedValue.ToString() + "'" +
                        ",'" + addMob.Text + "','" + addDes.Text + "')"
                        , con);
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clientscript", "alert('Record inserted succesfully!')", true);
                        addName.Text = addDes.Text = addStreet.Text = addMob.Text = string.Empty;
                        addCategoryList.SelectedIndex = addStateList.SelectedIndex = addNumberList.SelectedIndex =  0;
                        Image1.ImageUrl = "g.jpg";
                    }
                }
                catch (SqlException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex.Message + "')", true);

                }
                finally
                {
                    con.Close();
                }
            }
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string fileName = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + fileName));
            Image = "~/Upload/" + fileName;
            Image1.ImageUrl = Image;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Select an image...')", true);
        }
       
        
    }
    protected void BindDataList()
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from HospitalsDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "ID";
            GridView1.HeaderRow.Cells[1].Text = "Name";
            GridView1.HeaderRow.Cells[2].Text = "Category";
            GridView1.HeaderRow.Cells[3].Text = "Date";
            GridView1.HeaderRow.Cells[4].Text = "Image Url";
            GridView1.HeaderRow.Cells[5].Text = "Street";
            GridView1.HeaderRow.Cells[6].Text = "State";
            GridView1.HeaderRow.Cells[7].Text = "No. Of Doctor";
            GridView1.HeaderRow.Cells[8].Text = "Mobile No.";
            GridView1.HeaderRow.Cells[9].Text = "Description";
            con.Close();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        BindDataList();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            try
            {
                if(updId.Text!="")
                {
                    SqlCommand cmd = new SqlCommand("select * from HospitalsDetails where HosID ='"+updId.Text+"'", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "dt");
                    con.Open();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Button3.Enabled = false;
                        updId.Enabled = false;
                        updName.Enabled = true;
                        updStreet.Enabled = true;
                        updDes.Enabled = true;
                        updMob.Enabled = true;
                        updCategory.Enabled = true;
                        updNoOfDoctor.Enabled = true;
                        updStateList.Enabled = true;
                        Button5.Enabled = true;
                        FileUpload2.Enabled = true;
                        Button4.Enabled = true;
                        updName.Text = ds.Tables[0].Rows[0][1].ToString();
                        updCategory.SelectedValue = ds.Tables[0].Rows[0][2].ToString();
                        Image2.ImageUrl =  ds.Tables[0].Rows[0][4].ToString();
                        updStreet.Text = ds.Tables[0].Rows[0][5].ToString();
                        updStateList.SelectedValue = ds.Tables[0].Rows[0][6].ToString();
                        updNoOfDoctor.SelectedValue = ds.Tables[0].Rows[0][7].ToString();
                        updMob.Text = ds.Tables[0].Rows[0][8].ToString();
                        updDes.Text = ds.Tables[0].Rows[0][9].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('ID is invalid')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Insert ID')", true);
                }
            }
            catch(SqlException ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('"+ex.Message+"')", true);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update HospitalsDetails set HosName='" + updName.Text + "',HosCategory='" + updCategory.SelectedValue.ToString() + "',HosImage='"+Image2.ImageUrl+"',Street='"+updStreet.Text+"',State='"+updStateList.SelectedValue.ToString()+"',noOfDoctor='"+updNoOfDoctor.SelectedValue.ToString()+"',HosMobNo='"+updMob.Text+"',HosDecription='"+updDes.Text+"' where HosID = '"+updId.Text+"'", con);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clientscript", "alert('Record Updated succesfully!')", true);
                    updId.Text = updName.Text = updDes.Text = updStreet.Text = updMob.Text = string.Empty;
                    updCategory.SelectedIndex = updStateList.SelectedIndex = updNoOfDoctor.SelectedIndex = 0;
                    Image2.ImageUrl = "g.jpg";
                }
            }
            catch(SqlException ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex.Message + "')", true);
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        string img;
        if (FileUpload2.HasFile)
        {
            string fileName = FileUpload2.FileName;
            FileUpload2.PostedFile.SaveAs(Server.MapPath("~/Upload/" + fileName));
            img = "~/Upload/" + fileName;
            Image2.ImageUrl = img;
            Button3.Enabled = false;
            updId.Enabled = false;
            updName.Enabled = true;
            updStreet.Enabled = true;
            updDes.Enabled = true;
            updMob.Enabled = true;
            updCategory.Enabled = true;
            updNoOfDoctor.Enabled = true;
            updStateList.Enabled = true;
            Button5.Enabled = true;
            FileUpload2.Enabled = true;
            Button4.Enabled = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Select an image...')", true);
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if(delId.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter Hospital ID')", true);
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from HospitalsDetails where HosID='" + delId.Text + "'", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Record Deleted')", true);
                        delId.Text = string.Empty;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Id not valid')", true);
                    }
                }
                catch (SqlException ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex.Message + "')", true);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        
    }
}