using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace view.webforms
{
    public partial class Report : System.Web.UI.Page
    {

        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management"));
            return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsAuthorized())
            {

                //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                Response.Redirect("~/UnauthorizedPage.aspx");

            }
        }
    }
}