using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataBinding
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Password"] != null && Session["Username"]!=null)
            {
                // Displaying stored email  
                //Label1.Text = "This password is stored to the session.";
                Label2.Text = Session["Password"].ToString();
                Label1.Text = Session["Username"].ToString();

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}