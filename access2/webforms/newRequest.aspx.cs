﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using controller;
using System.Web.UI.WebControls;
using System.Globalization;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace view.webforms
{
    public partial class newRequest : System.Web.UI.Page
    {
        static List<requerant> datasource;
        GridView grid1;



        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management"));
            return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());


        }
        
       
            

        protected void Page_Load(object sender, EventArgs e)
        {
            


            if (!IsAuthorized())
            {

                //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                Response.Redirect("~/UnauthorizedPage.aspx");

            }

            else
            {

                if (!Context.User.Identity.IsAuthenticated) Response.Redirect("~/Account/loginPopup.aspx");
                grid1 = (GridView)FormView1.FindControl("GridView1");
                //ça concerne le updatepanel
                //if (!IsPostBack)
                //{
                //    InitDialog();
                //}
                if (!IsPostBack)
                {
                    if (!Context.User.Identity.IsAuthenticated) Response.Redirect("~/Account/login.aspx");

                    else
                    datasource = requerant_controller.getAllRequerant();
                
                }


                TextBox date = (TextBox)FormView1.FindControl("TextBox58");
            
            }
        }

        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //UpdatePanel promoteur = (UpdatePanel)FormView1.FindControl("UpdatePanel1");
            //Calendar c = (Calendar)FormView1.FindControl("Calendar1");
            //TextBox t = (TextBox)FormView1.FindControl("dateTextBox");
            //t.Visible = false;
            //c.Visible = true;
        }

        protected void FormView1_PageIndexChanging1(object sender, FormViewPageEventArgs e)
        {

        }



        protected void dateTextBox_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void dateTextBox_Disposed(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
            
        //    Panel Panel1=(Panel)FormView1.FindControl("Panel1");
        //    Button Button1 = (Button)FormView1.FindControl("Button1");
        //    Label lbl_num = (Label)FormView1.FindControl("num_requerant");
        //    Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
        //    Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
        //    Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
        //    Label lb_num_req = (Label)FormView1.FindControl("lb_num_req");
        //    Label lb_nom_req = (Label)FormView1.FindControl("lb_nom_req");
        //    Label lb_prenom_req = (Label)FormView1.FindControl("lb_prenom_req");
        //    Label lb_address_req = (Label)FormView1.FindControl("lb_address_req");
        //    //recuper div


        //    if (Button1.Text.Equals("..."))
        //    {
        //        grid1.DataSourceID = null;
        //        datasource = requerant_controller.getAllRequerant();

        //        grid1.DataSource = datasource;
        //        grid1.DataBind();

        //        Button1.Text = "+";

        //        TextBox numTextBox = (TextBox)FormView1.FindControl("numTextBox");
        //        Panel1.Visible = true;
        //    }
        //    else
        //    {

        //        TextBox objetTextBox = (TextBox)FormView1.FindControl("objetTextBox");

        //        grid1.DataSourceID = null;
        //        datasource = requerant_controller.getAllRequerant();

        //        grid1.DataSource = datasource;
        //        grid1.DataBind();

        //        Panel1.Visible = false;
        //        Button1.Text = "...";

        //        GridViewRow row = grid1.SelectedRow;
        //        lb_num_req.Text = "Numero Requerant : ";
        //        lb_nom_req.Text = "Nom Requerant : ";
        //        lb_prenom_req.Text = "Prenom Requerant : ";
        //        lb_address_req.Text = "adresse Requerant : ";
        //        lbl_num.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label1")).Text;
        //        lbl_nom.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label2")).Text;
        //        lbl_prenom.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label3")).Text;

        //    }

            
        //}

        protected void OdsRequete_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            
            
        }



        //ça concerne le updatepanel pour le requerant

        protected void InitDialog()
        {
            //Label editCustomerID = (Label)FormView1.FindControl("editCustomerID");
            //Label lblCustomerID = (Label)FormView1.FindControl("lblCustomerID");
            //TextBox editTxtCompanyName = (TextBox)FormView1.FindControl("editTxtCompanyName");
            //Label lblCompanyName = (Label)FormView1.FindControl("lblCompanyName");
            //TextBox editTxtContactName = (TextBox)FormView1.FindControl("editTxtContactName");
            //Label lblContactName = (Label)FormView1.FindControl("lblContactName");
            //TextBox editTxtCountry = (TextBox)FormView1.FindControl("editTxtCountry");
            //Label lblCountry = (Label)FormView1.FindControl("lblCountry");
            //editCustomerID.Text = lblCustomerID.Text;
            //editTxtCompanyName.Text = lblCompanyName.Text;
            //editTxtContactName.Text = lblContactName.Text;
            //editTxtCountry.Text = lblCountry.Text;
            //SetFocus("editTxtCompanyName");
        }

        protected void editBox_OK_Click(object sender, EventArgs e)
        {
            // Save to the database
            // Refresh the UI

            Label lblCustomerID = (Label)FormView1.FindControl("lblCustomerID");
            TextBox editTxtCompanyName = (TextBox)FormView1.FindControl("editTxtCompanyName");
            Label lblCompanyName = (Label)FormView1.FindControl("lblCompanyName");
            TextBox editTxtContactName = (TextBox)FormView1.FindControl("editTxtContactName");
            Label lblContactName = (Label)FormView1.FindControl("lblContactName");
            TextBox editTxtCountry = (TextBox)FormView1.FindControl("editTxtCountry");
            Label lblCountry = (Label)FormView1.FindControl("lblCountry");
            lblCompanyName.Text = editTxtCompanyName.Text;
            lblContactName.Text = editTxtContactName.Text;
            lblCountry.Text = editTxtCountry.Text;
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {

            TextBox editTxtCompanyName = (TextBox)FormView1.FindControl("editTxtCompanyName");


            TextBox editTxtContactName = (TextBox)FormView1.FindControl("editTxtContactName");

            TextBox editTxtCountry = (TextBox)FormView1.FindControl("editTxtCountry");

            if (editTxtCountry.Text == "Germany")
                editTxtCountry.Text = "Cuba";
            else
                editTxtCountry.Text = "USA";
        }

        protected void btnEditText_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Int16 numm = Convert.ToInt16(e.CommandArgument);
                
                Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
                Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
                Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
                //lbl_nom.Text = grid1.Rows[numm].Cells[1].Text;
                //lbl_prenom.Text = grid1.Rows[numm].Cells[2].Text;
                lbl_nom.Text = "dddddddddddddddd";
                lbl_prenom.Text = "rrrrrrrrrrrrrrrrrrrrrrrrrrr";


        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    GridView GridView1 = (GridView)FormView1.FindControl("GridView1");
            //    e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            //    e.Row.ToolTip = "Click to select this row.";
            //}

        }
        
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void LinkButton25_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void LinkButton25_Command(object sender, CommandEventArgs e)
        {
            
        }

        

        protected void Button2_Click1(object sender, EventArgs e)
        {
            TextBox TextBox30 = (TextBox)FormView1.FindControl("TextBox30");
            Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            lbl_nom.Text = "eeeeeeeeeeeeeeeeeeeeeeee";
            lbl_prenom.Text = "ggggggggggggggggggggggg";
            TextBox30.Text = "gggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
            
            //requerant r1 = new requerant();
            //r1.agencebancaire = TextBox30.Text; ;
            //r1.annéeAccord = TextBox31.Text; ;
            //r1.anneePrime = "ffffff ";
            //r1.CMT = "ffffffff ";
            //r1.Date_Accord_PBancaire = "gggggggggggg";
            //r1.DATE_DEPOT = "ggggggggggggg";
            //r1.Date_Naissance = "gggggggggggg";
            //r1.date_Prime = "gggggggggggg";
            //r1.Des_Act = "gggggggggggg";
            //r1.DES_SEC_ACT = "ggggggggggg";
            //r1.DES_SEC_ACT2 = "gggggggggggggg";
            //r1.HANDICAPE = "gggggggggggg";
            //r1.JourAccordBancaire = "gggggggggg";
            //r1.JourPrime = "gggggggggggggggg";
            //r1.LIB_DR = "ggggggggggggggggggggg";
            //r1.LIB_SEXE = "hhhhhhhhhh";
            //r1.Lib_Sit_Fam = "hhhhhhhhhhhhh";
            //r1.moisAccordBancaire = "hhhhhhhhhhhh";
            //r1.moisPrime = "hhhhhhhhh";
            //r1.Montant_Prime = "hhhhhhhhhh";
            //r1.NBRE_ASSOCIES = 0;
            //r1.NIVEAU = "hhhhhhhhhh";
            //r1.NOM_AGENCE_CNAC = "hhhhhhhhhhhh";
            //r1.Nom_Banque = "hhhhhhhhhh";
            //r1.NOM_COMMUNE = "hhhhhhhhhhhhh";
            //r1.nom_requerant = "hhhhhhhhhhhhhhhh";
            //r1.num = 1;
            //r1.NUM_CPT_BANC = "fffffffff";
            //r1.prenom_requerant = "fffffffffffff";
            //r1.prime = "ffffffffffffffff";

            //r1.REGION = "ggggggggg";
            //r1.WILAYA = "gggggggggggg";
            //r1.nom_requerant = "ggggggggggggg";
        }

        protected void LinkButton25_Command1(object sender, CommandEventArgs e)
        {
            TextBox TextBox30 = (TextBox)FormView1.FindControl("TextBox30");
            Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            lbl_nom.Text = "eeeeeeeeeeeeeeeeeeeeeeee";
            lbl_prenom.Text = "ggggggggggggggggggggggg";
            TextBox30.Text = "gggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
        }

        protected void LinkButton25_Command2(object sender, CommandEventArgs e)
        {
            //TextBox TextBox30 = (TextBox)FormView1.FindControl("TextBox30");
            //Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            //Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            //Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            //lbl_nom.Text = "eeeeeeeeeeeeeeeeeeeeeeee";
            //lbl_prenom.Text = "ggggggggggggggggggggggg";
            //TextBox30.Text = "gggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
        }

        protected void LinkButton25_Click1(object sender, EventArgs e)
        {
            //TextBox TextBox30 = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            //TextBox TextBox31 = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            
            //TextBox TextBox34 = (TextBox)grid1.FooterRow.FindControl("TextBox34");
            //TextBox TextBox35 = (TextBox)grid1.FooterRow.FindControl("TextBox35");
            //TextBox TextBox36 = (TextBox)grid1.FooterRow.FindControl("TextBox36");
            
            //TextBox TextBox41 = (TextBox)grid1.FooterRow.FindControl("TextBox41");
            
            //TextBox TextBox43 = (TextBox)grid1.FooterRow.FindControl("TextBox43");
            
            //TextBox TextBox47 = (TextBox)grid1.FooterRow.FindControl("TextBox47");
            //TextBox TextBox48 = (TextBox)grid1.FooterRow.FindControl("TextBox48");
            

            //requerant r1 = new requerant();
            ////r1.num = 1;
            ////r1.nom_requerant = TextBox30.Text;
            ////r1.prenom_requerant = TextBox31.Text;
            ////r1.NBRE_ASSOCIES = 0;
            ////r1.LIB_DR = TextBox33.Text;
            ////r1.NOM_AGENCE_CNAC = TextBox34.Text;
            ////r1.NOM_COMMUNE = TextBox35.Text;
            ////r1.WILAYA = TextBox36.Text;
            ////r1.Des_Act = TextBox37.Text;
            ////r1.DES_SEC_ACT = TextBox38.Text;
            ////r1.DES_SEC_ACT2 = TextBox39.Text;
            ////r1.NIVEAU = TextBox40.Text;
            ////r1.LIB_SEXE = TextBox41.Text;
            ////r1.DATE_DEPOT = TextBox42.Text;
            ////r1.Date_Naissance = TextBox43.Text;
            ////r1.HANDICAPE = TextBox44.Text;
            ////r1.Lib_Sit_Fam = TextBox45.Text;
            ////r1.Nom_Banque = TextBox46.Text;
            ////r1.agencebancaire = TextBox47.Text;
            ////r1.NUM_CPT_BANC = TextBox48.Text;
            ////r1.CMT = TextBox49.Text;
            ////r1.Date_Accord_PBancaire = TextBox50.Text;
            ////r1.annéeAccord = TextBox51.Text; ;
            ////r1.moisAccordBancaire = TextBox52.Text;
            ////r1.JourAccordBancaire = TextBox53.Text;
            ////r1.prime = TextBox54.Text;
            ////r1.date_Prime = TextBox55.Text;
            ////r1.Montant_Prime = TextBox56.Text;
            ////r1.REGION = TextBox57.Text;

            
            //r1.nom_requerant = TextBox30.Text;
            //r1.prenom_requerant = TextBox31.Text;
            
            //r1.NOM_AGENCE_CNAC = TextBox34.Text;
            //r1.NOM_COMMUNE = TextBox35.Text;
            //r1.WILAYA = TextBox36.Text;
            
            //r1.LIB_SEXE = TextBox41.Text;
            
            //r1.Date_Naissance = TextBox43.Text;
            
            //r1.agencebancaire = TextBox47.Text;
            //r1.NUM_CPT_BANC = TextBox48.Text;
            


            //requerant_controller r = new requerant_controller();
            //r.insertRequerant(r1);


            //Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            //Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            //Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            //lbl_nom.Text = "eeeeeeeeeeeeeeeeeeeeeeee";
            //grid1.DataSourceID = null;

            ////datasource = requerant_controller.getRequerantDataSource(Convert.ToInt16(TextBox31.Text));
            //datasource = requerant_controller.getAllRequerant();
            //fillGrid();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //TextBox TextBox30 = (TextBox)FormView1.FindControl("TextBox30");
            //Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            //Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            //Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            //lbl_nom.Text = "eeeeeeeeeeeeeeeeeeeeeeee";
            //lbl_prenom.Text = "ggggggggggggggggggggggg";
            //TextBox30.Text = "gggggggggggggggggggggggggggggggggggggggggggggggggggggggg";
            grid1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            GridViewRow row = grid1.SelectedRow;
            lbl_nom.Text = row.Cells[1].Text;
            lbl_prenom.Text =row.Cells[2].Text;
            //requerant selectedReq = requerant_controller.getRequerantByNum((int)grid1.SelectedValue);
            //lbl_nom.Text = selectedReq.num.ToString();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            requerant_controller r = new requerant_controller();

            
            int aa = e.RowIndex;
            string num_selected = ((Label)grid1.Rows[e.RowIndex].FindControl("Label1")).Text;

            Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
           
            r.deleteRequerant(num_selected);
            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();
            fillGrid();
            //UpdatePanel promoteur = (UpdatePanel)FormView1.FindControl("ModalPanel1");
            //promoteur.Update();
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
            
        }



        protected void fillGrid()
        {

            
            grid1.DataSourceID = null;
            grid1.DataSource = null;
            grid1.DataSource = datasource;
            grid1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string num=((Label)grid1.Rows[e.RowIndex].FindControl("Label30")).Text;
            //string nom_requerant = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            //string prenom_requerant = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            //string NOM_AGENCE_CNAC = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox6")).Text;
            //string NOM_COMMUNE = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox7")).Text;
            //string WILAYA = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox8")).Text;
            // string LIB_SEXE = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox13")).Text;
            //string Date_Naissance = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox15")).Text;
            //string agencebancaire = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox19")).Text;
            //string NUM_CPT_BANC = ((TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox20")).Text;
            
            //UpdatePanel promoteur = (UpdatePanel)FormView1.FindControl("ModalPanel1");
            
            //requerant_controller r_controller = new requerant_controller();
            //requerant r1 = requerant_controller.getRequerantByNum(Convert.ToInt16(num));

            //r1.nom_requerant = nom_requerant;
            //r1.prenom_requerant = prenom_requerant;
            
            //r1.NOM_AGENCE_CNAC = NOM_AGENCE_CNAC;
            //r1.NOM_COMMUNE = NOM_COMMUNE;
            //r1.WILAYA = WILAYA;
            
            
            //r1.LIB_SEXE = LIB_SEXE;
            
            //r1.Date_Naissance = Date_Naissance;
            
            //r1.agencebancaire = agencebancaire;
            //r1.NUM_CPT_BANC = NUM_CPT_BANC;
            
            

            //r_controller.updateRequerant(r1);
            //List<requerant> rrrr = datasource;

            //datasource = requerant_controller.getAllRequerant();
            //int nm = rrrr.Count;
            //grid1.EditIndex = -1;
            //fillGrid();
            
            
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grid1.DataBind();
        }

        protected void GridView1_RowDeleted1(object sender, GridViewDeletedEventArgs e)
        {
            grid1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid1.EditIndex = e.NewEditIndex;
            fillGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid1.EditIndex = -1;
            fillGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //datasource = null;
            //datasource = requerant_controller.getAllRequerant();
            //grid1.DataBind();
            grid1.PageIndex = e.NewPageIndex;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            Label lbl_num = (Label)FormView1.FindControl("num_requerant");
            Label lbl_nom = (Label)FormView1.FindControl("nom_requerant");
            Label lbl_prenom = (Label)FormView1.FindControl("prenom_requerant");
            Label lbl_addres = (Label)FormView1.FindControl("address_requerant");
            Label lb_num_req = (Label)FormView1.FindControl("lb_num_req");
            Label lb_nom_req = (Label)FormView1.FindControl("lb_nom_req");
            Label lb_prenom_req = (Label)FormView1.FindControl("lb_prenom_req");
            Label lb_address_req = (Label)FormView1.FindControl("lb_address_req");


            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();

            grid1.DataSource = datasource;
            grid1.DataBind();

            grid1.Visible = true;
            //promoteur_panel.Visible = false;

            

            GridViewRow row = grid1.SelectedRow;
            lb_num_req.Text = "Numero Requerant : ";
            lb_nom_req.Text = "Nom Requerant : ";
            lb_prenom_req.Text = "Prenom Requerant : ";
            lb_address_req.Text = "adresse Requerant : ";
            lbl_num.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label1")).Text;
            lbl_nom.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label2")).Text;
            lbl_prenom.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label3")).Text;
            lbl_addres.Text = ((Label)grid1.Rows[row.RowIndex].FindControl("Label4")).Text;
        }

        
        
        //Function to add a new request (Request)
        protected void Button2_Click3(object sender, EventArgs e)
        {
            //recuper the component that exist in the formview
            TextBox numTextBox = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList DropDownList1 = (DropDownList)FormView1.FindControl("DropDownList1");
            DropDownList DropDownList3 = (DropDownList)FormView1.FindControl("DropDownList3");
            DropDownList DropDownListMotif = (DropDownList)FormView1.FindControl("DropDownList4");
            DropDownList DropDownList2 = (DropDownList)FormView1.FindControl("DropDownList2");
            DropDownList ModeTransmission = (DropDownList)FormView1.FindControl("DropDownList1");
            DropDownList DispositifRequete = (DropDownList)FormView1.FindControl("DropDownList3");
            DropDownList MotifDispositif = (DropDownList)FormView1.FindControl("DropDownList4");
            DropDownList Type = (DropDownList)FormView1.FindControl("DropDownList5");
            DropDownList VoieTransmission = (DropDownList)FormView1.FindControl("DropDownList6");
            //DropDownList Wilayas = (DropDownList)FormView1.FindControl("DropDownList2");
            TextBox txt_num = (TextBox)FormView1.FindControl("TextBox11");
            
            TextBox corp_requeteTextBox = (TextBox)FormView1.FindControl("corp_requeteTextBox");
            TextBox date_requete = (TextBox)FormView1.FindControl("TextBox58");
            Request recl = new Request();
            //recl.num = Convert.ToInt32(numTextBox.Text);
            recl.id_trans = ModeTransmission.SelectedValue.ToString();
            recl.num_requerant =txt_num.Text;
            ///////////////////
            recl.num_wilaya = getRequestWilaya();
            //////////////////
            recl.id_type = Type.SelectedValue.ToString();
            
            recl.corp_requete = corp_requeteTextBox.Text;
            recl.id_state = 1;
            string textdate = date_requete.Text;
            recl.date = DateTime.ParseExact(textdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //recl.id_objet = DropDownListMotif.SelectedValue;
            recl.id_Voie_Trans = VoieTransmission.SelectedValue;

            //if the request (Request) is added correctly a dialog box will appear to inform that this request is added , if no inform that is not added and give the error code

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            List<string[]> ssss = new List<string[]>();
            if (requete_controller.insertRequest(recl, manager.FindByName(Context.User.Identity.Name).Id, Context.User.Identity.Name, ssss))
            {
                
                
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Request ajoutée avec succès');", true);
                FormView1.DataBind();
            }
            else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + requete_controller.message_exception + "');", true);

            
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList3");
            DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList4");
            OdsMotifDispositif.SelectParameters[0].DefaultValue = dispositif.SelectedValue;
            motifDispositif.DataSource = OdsMotifDispositif;
            motifDispositif.DataTextField = "motif1";
            motifDispositif.DataValueField = "id_motif";
            motifDispositif.DataBind();

        }
        protected string getAgentWilaya()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));

            if (wilaya_claim.ToList().Count != 0) return wilaya_claim.First().ClaimValue.ToString();
            else return "";
            
        }
        protected Boolean isDGCell()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            if (wilaya_claim.ToList().Count != 0) return false;
            else return true;
            
        }
        protected int getRequestWilaya()
        {
            DropDownList Wilayas = (DropDownList)FormView1.FindControl("DropDownList2");
            Label Wilaya_lab = (Label)FormView1.FindControl("Label31");
            if (!Wilayas.Visible)
            {
                int id = wilaya_controller.getWilayaByName(Wilaya_lab.Text).num;
                return id;
            }

            else
            {
                
                return Convert.ToInt32(Wilayas.SelectedValue.ToString());
            }
                
        }
    }
}