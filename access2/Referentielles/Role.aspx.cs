using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using controller;
using Model;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace view.Referentielles
{
    public partial class Role : System.Web.UI.Page
    {
        static List<AspNetRoles> datasource;
        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try { 
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Role_Management"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch (Exception e)
            {
                return false;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsAuthorized())
            {

                //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                Response.Redirect("~/UnauthorizedPage.aspx");

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AspNetRoles w = new AspNetRoles();
            Guid guid_role = Guid.NewGuid();
            w.Id = guid_role.ToString();
            w.Name = TextBox4.Text;


            //get the permissions
            List<Permissions_Role> permissions = new List<Permissions_Role>();
            foreach (ListItem chekbox in RoleCheckBoxs.Items)
            {
                Guid guid_permission = Guid.NewGuid();
                Permissions_Role permission = new Permissions_Role();
                permission.Id_Permission = guid_permission.ToString();
                permission.Id_Role = guid_role.ToString();
                permission.Permission_Type = chekbox.Text;
                permission.Permission_Value = chekbox.Selected.ToString();


                permissions.Add(permission);


                //role_controller.AddPermission(permission);

            }




            
            bool confirm=role_controller.insertRole(w, permissions);




            if (confirm) 
            {
                GridView1.DataBind();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"Le rôle  " + TextBox4.Text + " a été ajoutée avec succès\");", true);
            }
                
                

            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'ajout du rôle  " + TextBox4.Text + "  a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes \");", true);
            }

        }

        protected void fillGrid()
        {
            GridView1.DataSourceID = null;
            GridView1.DataSource = null;

            GridView1.DataSource = role_controller.getAllRole();
            GridView1.DataBind();
        }

        protected void LinkButton_Delete(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////////////////
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
                int indexRowSelected = gridViewRow.RowIndex;
                string guid_role = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
                string role = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label2")).Text;



                bool confirm = role_controller.deleteRole(guid_role);


                GridView1.DataBind();
                if (confirm) ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"Le rôle N° " + role + " a été supprimé avec succès\");", true);

                else
                {



                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La supression du rôle N° " + role + "  a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes \");", true);
                }

            }

        }
    }
}