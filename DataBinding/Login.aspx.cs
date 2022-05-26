using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBinding
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = 192.168.0.30; Initial Catalog = SqlPractice; User ID = User5; Password = CDev005#8;Integrated Security=False;Trusted_Connection=False");
            con.Open();
            string s = "select * from Register where Username=@Username and Password=@Password";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //   if (password.Text=="qwe123")  
            //{  
            //    // Storing email to Session variable  
            //    Session["email"] = email.Text;  
            //}  
            // Checking Session variable is not empty  
           
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Username"] = TextBox1.Text;
                Session["Password"] = TextBox2.Text;
                
                Label1.Text = "Login Successfully";
                Response.Redirect("Home.aspx");

                
            }
            else
            {
                Label1.Text = "Login Failed";
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}