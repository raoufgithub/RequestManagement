using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view.webforms
{
    public partial class tableauBord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Context.User.Identity.IsAuthenticated) Response.Redirect("~/Account/login.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //UpdatePanel updatepanel = (UpdatePanel)Master.FindControl("UpdatePanel1");
            


            //Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");
            //updatepanel.Update();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
        }

        protected void btn_click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
        }

        
    }
}