using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace view.Authentication
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            Login1.FailureText = "ggggggggggggggg";
            

            
        }

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            //FormsAuthentication.Authenticate();
        }
    }
}