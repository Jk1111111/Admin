using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class UserPages_hospitalDetails : System.Web.UI.Page
{
    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = getdata();
        Repeater1.DataSource = ds;
        Repeater1.DataBind();
    }
    private DataSet getdata()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from HospitalsDetails", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}