using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using view.Models;
using System.Security.Claims;

namespace view.Account
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PassUpdate_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {

                //Chek the old password if it is correct with the password stored in the Data Base
                bool ChekPass = manager.CheckPassword(user, TextBox_OldPass.Text);
                if (ChekPass)
                {
                    IdentityResult result =  manager.ChangePassword(user.Id, TextBox_OldPass.Text, TextBox_NewPass.Text);
                    if (result.Succeeded)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le Mot de Passe a été changé avec succès');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le changement du Mot de Passe a échoué');", true);
                }
            }
        }
    }
}