using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view.webforms
{
    public partial class TestPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            //this.lblMessage.Text = "Your Registration is done successfully. Our team will contact you shotly";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
            this.lblMessage.Text = "Your Registration is done successfully. Our team will contact you shotly";
        }

        protected void relance_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopupRelance();", true);
            //this.lblMessage.Text = "Your Registration is done successfully. Our team will contact you shotly";
        }
    }
}