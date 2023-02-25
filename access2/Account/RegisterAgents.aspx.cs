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

using System.IO;
using Model;
using controller;
namespace view.Account
{
    public partial class RegisterAgents : System.Web.UI.Page
    {

        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);


            var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("referentials"));
            return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //AddListOfAgents();
            if (!IsAuthorized())
            {
                //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                Response.Redirect("~/UnauthorizedPage.aspx");
            }
            
        }
        protected void AddListOfAgents()
        {

            List<ACCESAgentList_> agents = requete_controller.GetAllAgentACCES();
            foreach (ACCESAgentList_ agent in agents)
            {
                
                    string username = agent.username;
                if (Users_Controller.getUserByUserName(username) == null)
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                //username is family name + . + first name
                var user = new ApplicationUser() { UserName = username, Email = username + "@cnac.dz" };
                IdentityResult result = manager.Create(user, "123456789");

                
                    if (result.Succeeded)
                    {
                        user = manager.FindByName(username);


                        manager.AddToRole(user.Id, "Utilisateurs");

                       
                        var permissions = role_controller.getPermissions("f6ae2e00-dc87-4974-b8f0-28ae15d41a8a");
                        foreach (var perm in permissions)
                        {
                            manager.AddClaim(user.Id, new Claim(perm.Permission_Type.ToString(), perm.Permission_Value.ToString()));
                        }
                        //Add Matricule and structures
                        ////////////////////////////////////////////////////////////////////////
                        //manager.AddClaim(user.Id, new Claim("wilaya", agent.Agences_de__Wilaya));

                        UserManageStructure userManageStructure = new UserManageStructure();

                        Structure s = StructureBLL.getStructureByIntituleFr(agent.Agences_de__Wilaya);
                        userManageStructure.userManagerStructureId = Guid.NewGuid();
                        userManageStructure.StructureId = s.StructureId;
                        userManageStructure.UserId = user.Id;
                        userManageStructure.DateBegin = agent.DATE_RECRUTEMENT;
                        userManageStructure.DateEnd = null;
                        userManageStructure.PosteOccupe = agent.POSTE_OCCUPE;


                        ///////////////////////////////////////////////////////////////////////////
                        AspNetUsers us = Users_Controller.getUserByID(user.Id);
                        us.Matricule = agent.MATRICULE;
                        us.Nom = agent.NOMS;
                        us.Prenom = agent.PRENOMS;
                        us.Diplome = agent.DIPLOME_ ;
                        us.Date_Recrutement = agent.DATE_RECRUTEMENT;
                        Users_Controller.UpdateUserD(us, userManageStructure);

                        //create a new directory for the agent to store files received from messaging
                        Directory.CreateDirectory(Server.MapPath("~/Files/" + username));

                        Directory.CreateDirectory(Server.MapPath("~/Files/" + username + "/profile"));


                        

                        
                        ////////////////////////////////////////////////////////////////////////////
                    }
                }
            }
        }
        protected void Register_Onclick(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = UserName.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                user = manager.FindByName(UserName.Text);
                manager.AddToRole(user.Id, DropDownList_role.SelectedItem.ToString());
                UserManageStructure userManageStructure = new UserManageStructure();
                if (!DropDownListWilaya.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
                {
                    userManageStructure.userManagerStructureId = Guid.NewGuid();
                    userManageStructure.StructureId = Guid.Parse(DropDownListWilaya.SelectedValue);
                    userManageStructure.UserId = user.Id;
                    userManageStructure.DateBegin = DateTime.Now;
                    userManageStructure.DateEnd = DateTime.Now;
                    
                }
                else return;
                var permissions = role_controller.getPermissions(DropDownList_role.SelectedValue.ToString());
                foreach (var perm in permissions)
                {
                    manager.AddClaim(user.Id, new Claim(perm.Permission_Type.ToString(), perm.Permission_Value.ToString()));
                }
                //Add Matricule
                AspNetUsers us = Users_Controller.getUserByID(user.Id);
                us.Matricule = MatriculeAgent.Text;
                //us.Nom = agent.NOMS;
                //us.Prenom = agent.PRENOMS;
                //us.Diplome = agent.DIPLOME_;
                Users_Controller.UpdateUserD(us, userManageStructure);

                //create a new directory for the agent to store files received from messaging
                Directory.CreateDirectory(Server.MapPath("~/Files/" + UserName.Text));

                Directory.CreateDirectory(Server.MapPath("~/Files/" + UserName.Text+"/profile"));

                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'utilisateur a été ajoutée avec succès\");", true);

                Response.Redirect("RegisterAgents.aspx");
                
                
                //// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                ////string code = manager.GenerateEmailConfirmationToken(user.Id);
                ////string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                ////manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'ajout de l'utilisateur  a échoué \");", true);
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }




        
    }
}