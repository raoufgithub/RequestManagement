using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using Model;
using System.Globalization;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace view.webforms
{
    public partial class Relance : System.Web.UI.Page
    {
        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management"));
            return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());


        }

        static List<requerant> datasource = new List<requerant>();
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
                    Details.Visible = false;
                    Label8.Text = controller.Relance_Controller.getAllRelances(Convert.ToInt32(Session["Id_Request_Relance"]), Convert.ToInt32(Session["NumWilaya_Request_Relance"]), Convert.ToInt32(Session["Year_Request_Relance"])).Count.ToString();

                }
            }
        }



        protected string getNomRequerant()
        {
            return requete_controller.getRequestByNum(Convert.ToInt32(Session["Id_Request_Relance"]), Convert.ToInt32(Session["NumWilaya_Request_Relance"]), Convert.ToInt32(Session["Year_Request_Relance"])).NomRequerantC;
        }

        protected string getPrenomRequerant()
        {
            return requete_controller.getRequestByNum(Convert.ToInt32(Session["Id_Request_Relance"]), Convert.ToInt32(Session["NumWilaya_Request_Relance"]), Convert.ToInt32(Session["Year_Request_Relance"])).PrenomRequerantC;
        }
        

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string num_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            Session["id_relance"] = num_selected;
            //Label6.Text = num_selected;
            Details.Visible = true;
            DetailsView1.DataBind();
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            relance r = new relance();
            Guid GuidRelance = Guid.NewGuid();
            r.id_relances = GuidRelance.ToString();
            r.id_requete = Convert.ToInt32(((Label)FormView1.FindControl("LabelIdReclam")).Text);
            r.Year_Request = Convert.ToInt32(((Label)FormView1.FindControl("Label81")).Text);
            r.NumWilaya_Request = Convert.ToInt32(((Label)FormView1.FindControl("Label1")).Text);
            r.id_transmission = ((DropDownList)FormView1.FindControl("DropDownListIdTrans")).SelectedValue;
            r.date_relance = DateTime.ParseExact(((TextBox)FormView1.FindControl("date_relanceTextBox")).Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            r.Description_relance = ((TextBox)FormView1.FindControl("Description_relanceTextBox")).Text;

            string session = Session["Id_Request_Relance"].ToString();

            bool confirm=Relance_Controller.insertRelance(r);

            if (confirm)
            {
                
                
                (GridView1).DataSourceID = null;
                (GridView1).DataSource = controller.Relance_Controller.getAllRelances(Convert.ToInt32(Session["Id_Request_Relance"]), Convert.ToInt32(Session["NumWilaya_Request_Relance"]), Convert.ToInt32(Session["Year_Request_Relance"]));
                Label8.Text = controller.Relance_Controller.getAllRelances(Convert.ToInt32(Session["Id_Request_Relance"]), Convert.ToInt32(Session["NumWilaya_Request_Relance"]), Convert.ToInt32(Session["Year_Request_Relance"])).Count.ToString();
                GridView1.DataBind();
                //UpdatePanel1.Update();
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"Votre Relance a été ajoutée avec succès\");", true);
            }
                
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(\"L'ajout de la Relance a échoué \");", true);
            }

            
        }












        //grid1

        


        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    //datasource = null;
        //    //datasource = requerant_controller.getAllRequerant();
        //    //grid1.DataBind();
        //    grid1.PageIndex = e.NewPageIndex;
        //}
        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    grid1.EditIndex = -1;
        //    fillGrid();
        //}

        //protected void fillGrid()
        //{
        //    grid1.DataSourceID = null;
        //    grid1.DataSource = null;
        //    grid1.DataSource = datasource;
        //    grid1.DataBind();
        //}

        //protected void GridView1_RowDeleted1(object sender, GridViewDeletedEventArgs e)
        //{
        //    grid1.DataBind();
        //}
        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //    requerant_controller r = new requerant_controller();
        //    int aa = e.RowIndex;
        //    string ss = ((Label)grid1.Rows[e.RowIndex].FindControl("Label1")).Text;
        //    int num_selected = Convert.ToInt16(ss);
        //    r.deleteRequerant(num_selected);
        //    grid1.DataSourceID = null;
        //    datasource = requerant_controller.getAllRequerant();
        //    //UpdatePanel3.Update();
        //    fillGrid();

        //}
        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    grid1.EditIndex = e.NewEditIndex;
        //    fillGrid();
        //}
        //protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        //{
        //    grid1.DataBind();
        //}
        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    ///updated
        //    string num = ((Label)grid1.Rows[e.RowIndex].FindControl("Label30")).Text;
        //    string nom_requerant = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        //    string prenom_requerant = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            
            
        //    string WILAYA = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox8")).Text;
        //    string SEXE = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox13")).Text;
        //    string Date_Naissance = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox15")).Text;
            

        //    string adresse = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox4")).Text;
            

        //    requerant_controller r_controller = new requerant_controller();
        //    requerant r1 = requerant_controller.getRequerantByNum(Convert.ToInt16(num));
        //    r1.nom_requerant = nom_requerant;
        //    r1.prenom_requerant = prenom_requerant;
        //    r1.Date_Naissance = DateTime.ParseExact(Date_Naissance, "dd/MM/yyyy", CultureInfo.InvariantCulture); 
        //    r1.WILAYA = WILAYA;
        //    r1.SEXE = SEXE;
        //    r1.Adresse = adresse;
        //    r_controller.updateRequerant(r1);
        //    List<requerant> rrrr = datasource;
        //    datasource = requerant_controller.getAllRequerant();
        //    int nm = rrrr.Count;
        //    grid1.EditIndex = -1;
        //    fillGrid();
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //protected void LinkButton225_Click11(object sender, EventArgs e)
        //{
        //    //updated
        //    TextBox TextBox30 = (TextBox)grid1.FooterRow.FindControl("TextBox30");
        //    TextBox TextBox31 = (TextBox)grid1.FooterRow.FindControl("TextBox31");
        //    TextBox TextBox34 = (TextBox)grid1.FooterRow.FindControl("TextBox34");
        //    TextBox TextBox35 = (TextBox)grid1.FooterRow.FindControl("TextBox35");
        //    TextBox TextBox36 = (TextBox)grid1.FooterRow.FindControl("TextBox36");
        //    TextBox TextBox41 = (TextBox)grid1.FooterRow.FindControl("TextBox41");
        //    TextBox TextBox43 = (TextBox)grid1.FooterRow.FindControl("TextBox43");
        //    TextBox TextBox47 = (TextBox)grid1.FooterRow.FindControl("TextBox47");
        //    TextBox TextBox48 = (TextBox)grid1.FooterRow.FindControl("TextBox48");
        //    TextBox TextBox49 = (TextBox)grid1.FooterRow.FindControl("TextBox49");
        //    requerant r1 = new requerant();

        //    r1.nom_requerant = TextBox30.Text;
        //    r1.prenom_requerant = TextBox31.Text;
            
            
        //    r1.WILAYA = TextBox36.Text;
        //    r1.SEXE = TextBox41.Text;
        //    r1.Date_Naissance = DateTime.ParseExact((TextBox43.Text), "dd/MM/yyyy", CultureInfo.InvariantCulture); 
            
        //    r1.Adresse = TextBox49.Text;
        //    requerant_controller r = new requerant_controller();
        //    r.insertRequerant(r1);
        //    grid1.DataSourceID = null;
        //    //datasource = requerant_controller.getRequerantDataSource(Convert.ToInt16(TextBox31.Text));
        //    datasource = requerant_controller.getAllRequerant();
        //    fillGrid();

        //}
        //protected void LinkButton111_Click111(object sender, EventArgs e)
        //{
        //    //retrieve it from the  the valider button in the receivedRequestTest or ReceivedRequest
        //    GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
        //    int indexRowSelected = gridViewRow.RowIndex;

        //    string num_selected = ((Label)grid1.Rows[indexRowSelected].FindControl("Label1")).Text;


        //    requerant_controller r = new requerant_controller();
        //    int num = Convert.ToInt16(num_selected);
        //    r.deleteRequerant(num);
        //    grid1.DataSourceID = null;
        //    datasource = requerant_controller.getAllRequerant();
        //    fillGrid();
        //    //UpdatePanel promoteur = (UpdatePanel)FormView1.FindControl("ModalPanel1");
        //    //promoteur.Update();
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        //}



        //protected void Grid1_Edit_Button(object sender, EventArgs e)
        //{
        //    //updated
        //    //retrieve it from the  the valider button in the receivedRequestTest or ReceivedRequest
        //    GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
        //    int indexRowSelected = gridViewRow.RowIndex;


        //    string num = ((Label)grid1.Rows[indexRowSelected].FindControl("Label30")).Text;
        //    string nom_requerant = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox2")).Text;
        //    string prenom_requerant = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox3")).Text;

        //    string WILAYA = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox8")).Text;
        //    string SEXE = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox13")).Text;
        //    string Date_Naissance = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox15")).Text;



        //    string adresse = ((TextBox)grid1.Rows[indexRowSelected].FindControl("TextBox4")).Text;
        //    requerant_controller r_controller = new requerant_controller();
        //    requerant r1 = requerant_controller.getRequerantByNum(Convert.ToInt16(num));
        //    r1.nom_requerant = nom_requerant;
        //    r1.prenom_requerant = prenom_requerant;
            
        //    r1.WILAYA = WILAYA;


        //    r1.SEXE = SEXE;

        //    r1.Date_Naissance = DateTime.ParseExact(Date_Naissance, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //    r1.Adresse = adresse;

        //    r_controller.updateRequerant(r1);
        //    List<requerant> rrrr = datasource;

        //    datasource = requerant_controller.getAllRequerant();
        //    int nm = rrrr.Count;
        //    grid1.EditIndex = -1;
        //    fillGrid();
        //}
        //protected void LinkButton222_Click(object sender, EventArgs e)
        //{
        //    //grid1.EditIndex = e.NewEditIndex;
        //    fillGrid();
        //}



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


       
    }
}