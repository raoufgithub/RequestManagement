using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using view.Models;
using System.Web.Security;
using Model;
using controller;
using System.Configuration;
namespace view.Account
{
    public partial class loginPopup : System.Web.UI.Page
    {
        static int error = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    
                    Response.Redirect("../webforms/Dashboard");
                }
                if (error==1)
                {
                    Literal FailureText = (Literal)Login1.FindControl("FailureText");
                    FailureText.Text = "Nom d'utilisateur ou mot de passe non valide";

                    //ErrorMessage.Visible = true;
                    error = 0;
                }
                if(error==2)
                {
                    Literal FailureText = (Literal)Login1.FindControl("FailureText");
                    FailureText.Text = "Nom d'utilisateur ou mot de passe non valide";

                    //ErrorMessage.Visible = true;
                    error = 0;
                }
                if (error == 3)
                {
                    Literal FailureText = (Literal)Login1.FindControl("FailureText");
                    FailureText.Text = "Nom d'utilisateur ou mot de passe non valide";

                    //ErrorMessage.Visible = true;
                    error = 0;
                }
                if (error == 4)
                {
                    Literal FailureText = (Literal)Login1.FindControl("FailureText");
                    FailureText.Text = "Nom d'utilisateur ou mot de passe non valide";

                    //ErrorMessage.Visible = true;
                    error = 0;
                }
            }
            
        }


        
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                TextBox login = (TextBox)Login1.FindControl("userName");
                TextBox Password = (TextBox)Login1.FindControl("Password");
                CheckBox RememberMe = (CheckBox)Login1.FindControl("RememberMe");
                Literal FailureText = (Literal)Login1.FindControl("FailureText");
                // Validate the user password
                //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(login.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();


                        var user = manager.FindByName(Context.User.Identity.Name);
                        bool auth = Context.User.Identity.IsAuthenticated;
                        
                        Session["ID_CurrentUser"] = Users_Controller.getUserIDByUserName(Context.User.Identity.Name.ToString());
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["../webforms/Dashboard"], Response);
                        
                        
                        //Response.Redirect("../webforms/Dashboard");
                        break;
                    case SignInStatus.LockedOut:
                        //Response.Redirect("/Account/Lockout");
                        error = 3;
                        Response.Redirect("../Account/loginPopup.aspx");
                        break;
                    case SignInStatus.RequiresVerification:
                        //Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                        //                                Request.QueryString["ReturnUrl"],
                        //                                RememberMe.Checked),
                        //                  true);
                        error = 4;
                        Response.Redirect("../Account/loginPopup.aspx");
                        break;
                    case SignInStatus.Failure:
                        error = 2;
                        Response.Redirect("../Account/loginPopup.aspx");
                        break;

                    default:
                        //FailureText.Text = "Invalid login attempt";
                        
                        //ErrorMessage.Visible = true;
                        error = 1;
                        Response.Redirect("../Account/loginPopup.aspx");
                        break;
                }




            }
        }
    }
}