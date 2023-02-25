using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using controller;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace view.Referentielles
{
    public partial class RequestTypes : System.Web.UI.Page
    {
        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try
            {
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("referentials"));
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
            types t=new types();
            t.type = TextBox1.Text;
            Guid id_types = Guid.NewGuid();
            t.id_types = id_types.ToString();
            bool confirm = Type_Controller.insertType(t);
            


            if (confirm) ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"Le Type de Requête '" + TextBox1.Text + "' a été ajoutée avec succès\");", true);

            else
            {



                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'ajout du Type de Requête '" + TextBox1.Text + "' a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes  \");", true);
            }
            GridView1.DataBind();

            SetSelectedGridView(GridView1, TextBox1.Text);
            TextBox1.Text = "";
        }

        protected void Delete_LinkButton(object sender, EventArgs e)
        {


            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                int a = 0;
                GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
                int indexRowSelected = gridViewRow.RowIndex;
                string num_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;

                string nom_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label2")).Text;

                bool confirm = Type_Controller.deleteType(num_selected);

                if (confirm) ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La voie de transmission '" + nom_selected + "' a été supprimée avec succès\");", true);

                else
                {



                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La suppression de la voie de transmission '" + nom_selected + "'  a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes \");", true);
                }

                GridView1.DataBind();
            }
        }

        public void SetSelectedGridView(GridView grid, string mode_trans)
        {
            int row_selected = 0;
            foreach (GridViewRow gridRow in grid.Rows)
            {
                string mode_selected = ((Label)gridRow.FindControl("Label2")).Text;
                if (mode_trans.Equals(mode_selected))
                {
                    row_selected = gridRow.RowIndex;
                    break;
                }


            }
            grid.SelectRow(row_selected);
        }
    }
}