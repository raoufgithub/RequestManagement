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
    public partial class MotifDispositif : System.Web.UI.Page
    {

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
            Objet_Disp m = new Objet_Disp();
            Guid id_objet = Guid.NewGuid();
            m.id_objet = id_objet.ToString();
            m.objet = TextBox1.Text;

            m.PhaseId = Guid.Parse(DropDownList6.SelectedValue);

            //m.id_motif = 37;
            //m.motif1 = "test";

            //m.num_dispositif = 1;
            
            MotifDispositif_Controller.insertMotifDispositif(m);
            GridView1.DataBind();

            SetSelectedGridView(GridView1, id_objet.ToString());
            TextBox1.Text = "";
            
        }

        protected void LinkButton27_Delete(object sender, EventArgs e)
        {

            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "confirm", "return confirm('Voulez vous vraiment supprimer cet Objet');", true);

            
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
                int indexRowSelected = gridViewRow.RowIndex;
                string num_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;

                bool confirm=MotifDispositif_Controller.deleteMotifDispositif(num_selected);


                GridView1.DataBind();
                if(confirm)ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'Objet de Dispositif a été supprimé avec succès\");", true);

                else
                {



                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"La supression de l'Objet de Dispositif a échoué, probablement la cause dûe à l'utilisation de cette ressource par des Requêtes  \");", true);
                } 
                 
            }

            
                
           


            
                
            
        }
        public void SetSelectedGridView(GridView grid, string id_motif)
        {
            int row_selected = 0;
            foreach (GridViewRow gridRow in grid.Rows)
            {
                string num_selected = ((Label)gridRow.FindControl("Label1")).Text;
                if (id_motif==num_selected)
                {
                    row_selected = gridRow.RowIndex;
                    break;
                }


            }
            grid.SelectRow(row_selected);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DropDownList6.DataSourceID = null;
            OdsPhaseMission.SelectParameters[0].DefaultValue = DropDownList1.SelectedValue;
            DropDownList6.DataSource = OdsPhaseMission;
            DropDownList6.DataTextField = "PhaseName";
            DropDownList6.DataValueField = "PhaseId";
            
            DropDownList6.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            
            Label LabelPhaseId = (Label)GridView1.Rows[indexRowSelected].FindControl("LabelPhaseId");
            string MissionId = dispositif_controller.getIDMissionOfPhase(LabelPhaseId.Text);

            OdsPhaseMission.SelectParameters[0].DefaultValue = MissionId;
            Session["PhaseIdEdit"] = LabelPhaseId.Text;
            Session["MissionIdEdit"] = MissionId;
        }


        protected void DropDownListMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            DropDownList DropDownListMission = (DropDownList)GridView1.Rows[indexRowSelected].FindControl("DropDownListMission");
            DropDownList DropDownListPhase = (DropDownList)GridView1.Rows[indexRowSelected].FindControl("DropDownListPhase");
            Session["PhaseIdEdit"] = DropDownListPhase.SelectedValue;
            Session["MissionIdEdit"] = DropDownListMission.SelectedValue;
            DropDownListPhase.DataSourceID = null;
            OdsPhaseMission.SelectParameters[0].DefaultValue = DropDownListMission.SelectedValue;
            DropDownListPhase.DataSource = OdsPhaseMission;
            DropDownListPhase.DataTextField = "PhaseName";
            DropDownListPhase.DataValueField = "PhaseId";
            DropDownListPhase.DataBind();

        }
        public string GetBindPhaseId()
        {
            
            string MissionIdEdit = Session["MissionIdEdit"].ToString();
            string PhaseIdEdit = Session["PhaseIdEdit"].ToString();
            //if(bind.Equals(Guid.Empty.ToString()))retu
            bool h = PhaseObjetBLL.IsPhaseInMission(Guid.Parse(MissionIdEdit), Guid.Parse(PhaseIdEdit));
            
            if (h) return PhaseIdEdit;
            else return Guid.Empty.ToString();

            
        }

        public string GetBindMissionId()
        {

            return Session["MissionIdEdit"].ToString();
            

        }

        protected void DropDownListPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            DropDownList DropDownListPhase = (DropDownList)GridView1.Rows[indexRowSelected].FindControl("DropDownListPhase");
            Label LabelPhaseIdEdit = (Label)GridView1.Rows[indexRowSelected].FindControl("LabelPhaseIdEdit");

            LabelPhaseIdEdit.Text = DropDownListPhase.SelectedValue;
        }

        //protected void LinkButtonOK_Click(object sender, EventArgs e)
        //{
        //    GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
        //    int indexRowSelected = gridViewRow.RowIndex;
        //    TextBox TextBoxObject = (TextBox)GridView1.Rows[indexRowSelected].FindControl("TextBox2");
        //    DropDownList DropDownListPhase = (DropDownList)GridView1.Rows[indexRowSelected].FindControl("DropDownListPhase");
        //    Label LabelObjectId = (Label)GridView1.Rows[indexRowSelected].FindControl("Label1");
        //    Guid PhaseId = Guid.Parse(DropDownListPhase.SelectedValue);
        //    Objet_Disp obj = MotifDispositif_Controller.GetObjectById(LabelObjectId.Text);
        //    obj.objet = TextBoxObject.Text;
        //    obj.PhaseId = Guid.Parse(DropDownListPhase.SelectedValue);
        //    MotifDispositif_Controller.updateMotifDispositif(obj);

        //}
    }
}