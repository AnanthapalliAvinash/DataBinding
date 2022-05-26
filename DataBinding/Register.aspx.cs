using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DataBinding
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.0.30; Initial Catalog = SqlPractice; User ID = User5; Password = CDev005#8;Integrated Security=False;Trusted_Connection=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Register(Username,Password,MobileNo,age,gender)values(@username,@password,@MobileNo,@age,@gender)", con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox4.Text);
            cmd.Parameters.AddWithValue("@MobileNo", TextBox2.Text);
            cmd.Parameters.AddWithValue("@age", TextBox3.Text);
            string gender = string.Empty;
            if (RadioButton1.Checked)
            {
                gender = "M";
            }
            else if (RadioButton2.Checked)
            {
                gender = "F";
            }
            cmd.Parameters.AddWithValue("@gender", gender);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("Login.aspx");
            }
            else {
                Label1.Text = "Register Failed";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}