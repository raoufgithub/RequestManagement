using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

using System.Configuration;
using System.Security.Claims;

namespace view.Trace
{
    public partial class ListViewTrace : System.Web.UI.Page
    {


        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try { 
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Statistics"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch (Exception e)
            {
                return false;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                Response.Redirect("~/Account/loginPopup.aspx");
            }
            
            else
            {
                if (!IsAuthorized())
                {

                    //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                    Response.Redirect("~/UnauthorizedPage.aspx");

                }
                else
                {
                    LabelIdReclam.Text = Session["Id_Request_Trace"].ToString();
                    Label1.Text = Session["NumWilaya_Request_Trace"].ToString();
                    Label81.Text = Session["Year_Request_Trace"].ToString();


                    //OdsUserActionRequest.SelectParameters[0].DefaultValue = 4+"";
                    ListView1.DataSourceID = null;
                    ListView1.DataSource = controller.Action_User_Request.getRequestActionsByNum(Convert.ToInt32(Session["Id_Request_Trace"]), Convert.ToInt32(Session["NumWilaya_Request_Trace"]), Convert.ToInt32(Session["Year_Request_Trace"]));
                    ListView1.DataBind();
                }
            }
        }
        

        protected string getUserName(string UserId)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(UserId);

            return user.UserName ;
        }
    }
}