using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Model;
using controller;
using System.Globalization;
namespace view.MasterPages
{
    public partial class TestRequerantPopup : System.Web.UI.Page
    {


        static List<requerant> datasource = new List<requerant>();
        static List<Request> datasource1 = new List<Request>();
        static int menu_show = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void LinkButton225_Click11(object sender, EventArgs e)
        {
            //updated
            TextBox TextBox30 = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox TextBox31 = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            TextBox TextBox34 = (TextBox)grid1.FooterRow.FindControl("TextBox34");
            TextBox TextBox35 = (TextBox)grid1.FooterRow.FindControl("TextBox35");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe_DropDownList = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox TextBox43 = (TextBox)grid1.FooterRow.FindControl("TextBox43");
            TextBox TextBox47 = (TextBox)grid1.FooterRow.FindControl("TextBox47");
            TextBox TextBox48 = (TextBox)grid1.FooterRow.FindControl("TextBox48");
            TextBox TextBox49 = (TextBox)grid1.FooterRow.FindControl("TextBox49");
            TextBox email = (TextBox)grid1.FooterRow.FindControl("TextBox50");
            requerant r1 = new requerant();

            r1.nom_requerant = TextBox30.Text;
            r1.prenom_requerant = TextBox31.Text;

            int id_wilayaInt = Convert.ToInt32(wilaya.SelectedValue);
            r1.id_wilaya = id_wilayaInt;
            r1.SEXE = sexe_DropDownList.Text;
            r1.Date_Naissance = DateTime.ParseExact((TextBox43.Text), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            r1.Adresse = TextBox49.Text;
            r1.Email = email.Text;
            requerant_controller r = new requerant_controller();
            r.insertRequerant(r1);
            grid1.DataSourceID = null;
            //datasource = requerant_controller.getRequerantDataSource(Convert.ToInt16(TextBox31.Text));
            datasource = requerant_controller.getAllRequerant();
            fillGrid();


        }




        //////////////////////////////////////////////////////////////////////

        protected void LinkButton222_Click(object sender, EventArgs e)
        {
            //grid1.EditIndex = e.NewEditIndex;
            fillGrid();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //datasource = null;
            //datasource = requerant_controller.getAllRequerant();
            //grid1.DataBind();
            grid1.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid1.EditIndex = -1;
            fillGrid();
        }

        protected void fillGrid()
        {
            //grid1.DataSourceID = null;
            //grid1.DataSource = null;
            grid1.DataSource = datasource;
            grid1.DataBind();
        }

        protected void GridView1_RowDeleted1(object sender, GridViewDeletedEventArgs e)
        {
            grid1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            requerant_controller r = new requerant_controller();
            int aa = e.RowIndex;
            string num_selected = ((Label)grid1.Rows[e.RowIndex].FindControl("Label1")).Text;
            
            r.deleteRequerant(num_selected);
            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();
            UpdatePanel3.Update();
            fillGrid();

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid1.EditIndex = e.NewEditIndex;
            fillGrid();
        }
        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grid1.DataBind();
        }
        

        
        protected void LinkButton111_Click111(object sender, EventArgs e)
        {
            //retrieve it from the  the valider button in the receivedRequestTest or ReceivedRequest
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;

            string num_selected = ((Label)grid1.Rows[indexRowSelected].FindControl("Label1")).Text;


            requerant_controller r = new requerant_controller();
            
            r.deleteRequerant(num_selected);
            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();
            fillGrid();
            //UpdatePanel promoteur = (UpdatePanel)FormView1.FindControl("ModalPanel1");
            //promoteur.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }



        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}