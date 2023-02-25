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
namespace view.User
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected string[] profileUser()
        {
            string[] Profile= new string[5];

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            Profile[0] = user.UserName;
            Profile[1] = user.Email;
            
            
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));



            if (wilaya_claim.ToList().Count != 0)
            {
                wilaya_claim.First().ClaimValue.ToString();
            }
                
            return Profile;
        }
    }
}