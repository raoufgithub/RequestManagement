using controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace view.Referentielles
{
    public partial class Wilayas : System.Web.UI.Page
    {
        static List<wilayas> datasource;


        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try { 
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
            wilayas w = new wilayas();
            w.num = Convert.ToInt16(TextBox1.Text);
            //m.num_dispositif = DropDownList1.DataTextField;
            
            w.wilaya = TextBox4.Text;
            bool confirm=wilaya_controller.insertWilaya(w);

            if (confirm) ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La Wilaya N° " + TextBox1.Text + " a été ajoutée avec succès\");", true);

            else
            {



                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'ajout de la wilaya N° " + TextBox1.Text + "  a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes \");", true);
            }

            GridView1.DataBind();

            SetSelectedGridView(GridView1, Convert.ToInt32(TextBox1.Text));
            TextBox1.Text = "";
            TextBox4.Text = "";
        }

        

        protected void fillGrid()
        {
            //GridView1.DataSourceID = null;
            //GridView1.DataSource = null;

            GridView1.DataSource = wilaya_controller.getAllWilaya();
            GridView1.DataBind();
            
        }

       
        public void SetSelectedGridView(GridView grid, int num)
        {
            int row_selected=0;
            foreach (GridViewRow gridRow in grid.Rows)
            {
                int num_selected = Convert.ToInt32(((Label)gridRow.FindControl("Label1")).Text);
                if (num == num_selected)
                {
                    row_selected = gridRow.RowIndex;
                    break;
                }
                    

            }
            grid.SelectRow(row_selected);
        }

        protected void LinkButton27_Delete(object sender, EventArgs e)
        {
            
            ////////////////////////////////////////////////////////////////////////////////////
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
                int indexRowSelected = gridViewRow.RowIndex;
                string ss = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;



                int num_selected = Convert.ToInt16(ss);
                bool confirm = wilaya_controller.deleteWilaya(num_selected);


                GridView1.DataBind();
                if (confirm) ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La Wilaya N° " + num_selected + " a été supprimé avec succès\");", true);

                else
                {



                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La supression de la wilaya N° " + num_selected + "  a échoué  probablement la cause dûe à l'utilisation de cette ressource par des Requêtes \");", true);
                }

            }
        }
    }
}