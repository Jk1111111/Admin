using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;
using System.Collections.Specialized;

public partial class UserPages_bookApointment : System.Web.UI.Page
{
    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        BindDataList(id);


    }
    protected void BindDataList(string id)
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from DoctorsDetails where DocId='"+id+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            if(ds.Tables[0].Rows.Count > 0)
            {
                Label1.Text = ds.Tables[0].Rows[0][2].ToString();
                Label2.Text = ds.Tables[0].Rows[0][6].ToString();
                Label3.Text = ds.Tables[0].Rows[0][3].ToString();
                Label4.Text = ds.Tables[0].Rows[0][4].ToString();
                Label5.Text = ds.Tables[0].Rows[0][5].ToString();
            }
        }
    }
    public int generate_ID()
    {
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clientscript", "alert('Your inforamtion is recorded.Check your 'INBOX'')", true);
        int i;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("select count(*) from Appointment", con))
            {
                con.Open();
                i = (int)cmd.ExecuteScalar();
                i++;
                con.Close();
            }
            return i;
        }
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int booked_id = generate_ID();
        string doc_name = Label1.Text;
        string hos_name = Label2.Text;
        string specialist = Label3.Text;
        string doc_email = Label4.Text;
        string doc_mobile = Label5.Text;
        using (SqlConnection con = new SqlConnection(CS))
        {
            if (nmtxt.Text == "" || emailtxt.Text == "" || mobtxt.Text == "" || msgtxt.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Fill all the information....')", true);
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into Appointment values('" + booked_id + "','" + doc_name + "','" + hos_name + "','" + specialist + "','" + doc_email + "','" + doc_mobile + "','" + nmtxt.Text.ToString() + "','" + emailtxt.Text.ToString() + "','" + mobtxt.Text.ToString() + "','" + sujectlist.SelectedValue.ToString() + "','" + msgtxt.Text.ToString() + "')", con);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        User_msg();
                        Doctor_msg();
                        string msg = "Appointment Booked.";
                        Response.Redirect("index.aspx?msg=" + msg);
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
    protected void User_msg()
    {
        string countrycode = "91";
        string mnumber = mobtxt.Text;
        string destinationaddr = countrycode + mnumber;
        string m1 = "Hi,";
        string m2 = "yourappointmentwith Dr.";
        string m3 = "Contacthim+91-";
        string m4 = nmtxt.Text;
        string m5 = Label1.Text;
        string m6 = Label5.Text;
        string message = m1 + m4 + m2 + m5 + m3 + m6;
        String message1 = HttpUtility.UrlEncode(message);
        using (var wb = new WebClient())
        {
            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                                {"apikey" , "GKneR+wOOUU-19SI9S6TvYjNw76ZGY9v9psr9LTKG9"},
                                {"numbers" , destinationaddr},
                                {"message" , message1},
                                {"sender" , "TXTLCL"}
                            });

        }
    }
    protected void Doctor_msg()
    {
        string countrycode = "91";
        string mnumber = Label5.Text;
        string destinationaddr = countrycode + mnumber;
        string m1 = "Hi,";
        string m2 = "-yourpatientis";
        string m3 = "Contacthim+91-";
        string m4 = nmtxt.Text;
        string m5 = Label1.Text;
        string m6 = mobtxt.Text;
        string message = m1 + m5 + m2 + m4 + m3 + m6;
        String message1 = HttpUtility.UrlEncode(message);
        using (var wb = new WebClient())
        {
            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                                {"apikey" , "GKneR+wOOUU-19SI9S6TvYjNw76ZGY9v9psr9LTKG9"},
                                {"numbers" , destinationaddr},
                                {"message" , message1},
                                {"sender" , "TXTLCL"}
                            });

        }
    }
}