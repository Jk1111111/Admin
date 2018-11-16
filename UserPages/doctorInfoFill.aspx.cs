using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UserPages_doctorInfoFill : System.Web.UI.Page
{
    string Image;
    static int n = 100;
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
        updEmail.Enabled = false;
        updDes.Enabled = false;
        updMob.Enabled = false;
        updCategory.Enabled = false;
        updHosId.Enabled = false;
        updTime.Enabled = false;
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
    string GenerateID()
    {
        int i;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand ("select count(*) from DoctorsDetails",con))
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();
            }
        }
        i++;
        n += i;
        return addName.Text.Substring(0, 3).ToUpper() + n.ToString();
    }

    protected string getName()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from HospitalsDetails where HosID = '"+addHosId.Text+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "dt");
            if(ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0][1].ToString();
            }
            return "Not Available";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (addName.Text == "" || addDes.Text == "" || addEmail.Text == "" || addMob.Text == "" || addHosId.Text == "" || addTime.Text =="")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Fill all the information....')", true);
        }
        else
        {
            string id = GenerateID();
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    string hosname=getName();
                    SqlCommand cmd = new SqlCommand("insert into DoctorsDetails values('"+addHosId.Text+"','" + id + "','" + "Dr."+ addName.Text + "','" + addCategoryList.SelectedValue.ToString() + "','" + addEmail.Text + "'" +
                        ",'" +addMob.Text+ "','" + hosname + "','" + addTime.Text + "','" + addDes.Text + "'" +
                        ",'" + Image1.ImageUrl+ "')", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clientscript", "alert('Record inserted succesfully!')", true);
                        addName.Text = addDes.Text = addEmail.Text = addMob.Text = addTime.Text = addHosId.Text = string.Empty;
                        addCategoryList.SelectedIndex  = 0;
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
    protected void BindDataList()
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DoctorsDetails", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Hospital ID";
            GridView1.HeaderRow.Cells[1].Text = "ID";
            GridView1.HeaderRow.Cells[2].Text = "Name";
            GridView1.HeaderRow.Cells[3].Text = "Specialist";
            GridView1.HeaderRow.Cells[4].Text = "Email";
            GridView1.HeaderRow.Cells[5].Text = "MObile";
            GridView1.HeaderRow.Cells[6].Text = "Hospitals Name";
            GridView1.HeaderRow.Cells[7].Text = "Work TIme";
            GridView1.HeaderRow.Cells[8].Text = "Description";
            GridView1.HeaderRow.Cells[9].Text = "Image url";
            con.Close();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        BindDataList();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (delId.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter id of doctor')", true);
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from DoctorsDetails where DocId='" + delId.Text + "'", con);
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            try
            {
                if (updId.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select * from DoctorsDetails where DocId ='" + updId.Text + "'", con);
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
                        updEmail.Enabled = true;
                        updDes.Enabled = true;
                        updMob.Enabled = true;
                        updCategory.Enabled = true;
                        updHosId.Enabled = true;
                        updTime.Enabled = true;
                        Button5.Enabled = true;
                        FileUpload2.Enabled = true;
                        Button4.Enabled = true;
                        updName.Text = ds.Tables[0].Rows[0][2].ToString();
                        updCategory.SelectedValue = ds.Tables[0].Rows[0][3].ToString();
                        updEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                        updMob.Text = ds.Tables[0].Rows[0][5].ToString();
                        updHosId.Text = ds.Tables[0].Rows[0][6].ToString();
                        updTime.Text = ds.Tables[0].Rows[0][7].ToString();
                        updDes.Text = ds.Tables[0].Rows[0][8].ToString();
                        Image2.ImageUrl = ds.Tables[0].Rows[0][9].ToString();
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
            updEmail.Enabled = true;
            updDes.Enabled = true;
            updMob.Enabled = true;
            updCategory.Enabled = true;
            updHosId.Enabled = true;
            updTime.Enabled = true;
            Button5.Enabled = true;
            FileUpload2.Enabled = true;
            Button4.Enabled = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Select an image...')", true);
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update DoctorsDetails set Name='" + updName.Text + "',Specialist='" + updCategory.SelectedValue.ToString() + "',Email='" + updEmail.Text + "',Mobile='" + updMob.Text + "',HosName='" + updHosId.Text + "',WorkTime='" + updTime.Text + "',Description='" + updDes.Text + "',Image='"+Image2.ImageUrl+"' where DocId = '" + updId.Text + "'", con);
                int i = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (i > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clientscript", "alert('Record Updated succesfully!')", true);
                    updId.Text = updName.Text = updDes.Text = updEmail.Text = updMob.Text = updHosId.Text = updTime.Text = string.Empty;
                    updCategory.SelectedIndex =  0;
                    Image2.ImageUrl = "g.jpg";
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