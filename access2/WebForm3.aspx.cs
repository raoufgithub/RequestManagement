using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{

        //}

        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");
        //}

















        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cbDate.Checked)
            {
                Label1.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                Label2.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            }
            else
            {
                Label1.Text = DateTime.Now.ToLongTimeString();
                Label2.Text = DateTime.Now.ToLongTimeString();
            }
            //Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (cbDate.Checked)
            {
                Label1.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            }
            else
            {
                Label1.Text = DateTime.Now.ToLongTimeString();
            }
            //Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
        }
        protected void cbDate_CheckedChanged(object sender, EventArgs e)
        {
            cbDate.Font.Bold = cbDate.Checked;
        }
        protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color c = Color.FromName(ddlColor.SelectedValue);
            Label2.ForeColor = c;
        }
    }
}