using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using controller;
using Model;
using System.Globalization;

namespace view.webforms
{
    public partial class test1 : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Context.User.Identity.IsAuthenticated) Response.Redirect("~/Account/login.aspx");
        }
            static List<Request> datasource;
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            
            string num_selected = ((Label)row.FindControl("Label1")).Text;
            //string num_selected = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label1")).Text;
            request.SelectParameters[0].DefaultValue = "3";
            //OdsRequest.SelectParameters[0].DefaultValue = GridView1.SelectedValue.ToString(); 
            //TextBox numTextBox=(TextBox)FormView1.FindControl("numTextBox");
            //numTextBox.Text = "1";
            
            FormView1.ChangeMode(FormViewMode.Edit);

            dialog.Visible = false;

            
        }
        ///// <summary>
        ///// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// </Request with where et and>
        bool linq1_updated = true;
        protected void filterRequest()
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            TextBox dateDu = (TextBox)FormView1.FindControl("TextBox10");
            TextBox dateAu = (TextBox)FormView1.FindControl("TextBox12");
            DropDownList wilaya = (DropDownList)FormView1.FindControl("DropDownList5");
            TextBox requerant = (TextBox)FormView1.FindControl("TextBox11");
            DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList motif_dispo = (DropDownList)FormView1.FindControl("DropDownList9");
            DropDownList etat_requete = (DropDownList)FormView1.FindControl("DropDownList7");
            DropDownList mode_trans = (DropDownList)FormView1.FindControl("DropDownList6");
            TextBox objetTextBox = (TextBox)FormView1.FindControl("objetTextBox");
            string aaaa = mode_trans.Text;
            string aaaaaaaaaa = mode_trans.SelectedItem.ToString();
            string aaaaaaaaa = mode_trans.SelectedValue;


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from reclamation req.reclamation ";
            string linq = "select * from reclamation reclam join motif mot on(mot.id_motif=reclam.id_motif) ";
            string where = " where(";
            string and = " and ";
            string linq1 =
                 getDateDu(dateDu, "date") + getDateAu(dateAu, "date")
                + getSubStringLinqDropDownList(wilaya, "num_wilaya") + getSubStringLinqTextBox(requerant, "num_requerant") + getSubStringLinqDropDownList_Dispo(dispositif, "num_dispositif")
                + getSubStringLinqDropDownList(motif_dispo, "id_motif") + getSubStringLinqDropDownList(etat_requete, "id_state") + getSubStringLinqDropDownList(mode_trans, "id_trans")
                + getSubStringLinqTextBox(objetTextBox, "objet") + ")";

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Built the request linq by adding the num_requete to the global request//
            string num_req_string = num_requete.Text;
            if (!(num_requete.Text.Equals("")))
            {
                if (linq1.Equals(")")) linq = linq + where + "reclam.num like '" + num_req_string + "%'" + linq1;
                else linq = linq + where + "reclam.num like '" + num_requete.Text + "%'" + and + linq1;
            }
            else
            {
                if (!linq1.Equals(")")) linq = linq + where + linq1;
            }
            datasource = requete_controller.getFilteredRequest(linq);
            GridView1.DataSourceID = null;
            GridView1.DataSource = datasource;
            GridView1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string getDateDu(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                return "reclam." + field + " >= '" + a.Text + "'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "reclam." + field + " >=  '" + a.Text + "'";
                    }


                }
            }
            return "";
        }
        protected string getDateAu(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                //requete_controller.dateAu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return "reclam." + field + " <=  '" + a.Text + "'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        //requete_controller.dateAu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "reclam." + field + " <=  '" + a.Text + "'";
                    }


                }
            }
            return "";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string getSubStringLinqTextBox(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                return "reclam." + field + " like '" + a.Text+"%'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        return " and reclam." + field + " like '" + a.Text + "%'";
                    }


                }
            }
            return "";
        }
        protected string getSubStringLinqDropDownList(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linq1_updated)
            {
                linq1_updated = false;
                return "reclam." + field + "=" + b.Text;
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        return " and reclam." + field + "=" + b.Text;
                    }

                }
            }
            return "";
        }

        protected string getSubStringLinqDropDownList_Dispo(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linq1_updated)
            {
                linq1_updated = false;
                return "mot." + field + "=" + b.Text;
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        return " and mot." + field + "=" + b.Text;
                    }

                }
            }
            return "";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </Request with where et and>
        //bool linq1_updated = true;
        //protected void filterRequest()
        //{
        //    TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
        //    TextBox dateDu = (TextBox)FormView1.FindControl("TextBox10");
        //    TextBox dateAu = (TextBox)FormView1.FindControl("TextBox12");
        //    DropDownList wilaya = (DropDownList)FormView1.FindControl("DropDownList5");
        //    TextBox requerant = (TextBox)FormView1.FindControl("TextBox11");
        //    DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList8");
        //    DropDownList motif_dispo = (DropDownList)FormView1.FindControl("DropDownList9");
        //    DropDownList etat_requete = (DropDownList)FormView1.FindControl("DropDownList7");
        //    DropDownList mode_trans = (DropDownList)FormView1.FindControl("DropDownList6");
        //    TextBox objetTextBox = (TextBox)FormView1.FindControl("objetTextBox");

        //    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //    //Build a request linq without the num_requete because it start sure without AND//
        //    //string linq = "from reclamation req.reclamation ";
        //    string linq = "";
        //    //string where = " where(";
        //    string and = " and ";
        //    string linq1 =
        //         getDateDu(dateDu, "date") + getDateAu(dateAu, "date")
        //        + getSubStringLinqDropDownList(wilaya, "num_wilaya") + getSubStringLinqTextBox(requerant, "num_requerant") + getSubStringLinqDropDownList(dispositif, "num_dispositif")
        //        + getSubStringLinqDropDownList(motif_dispo, "id_motif") + getSubStringLinqDropDownList(etat_requete, "id_state") + getSubStringLinqDropDownList(mode_trans, "id_trans")
        //        + getSubStringLinqTextBox(objetTextBox, "objet") + "";
        //    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //    //Built the request linq by adding the num_requete to the global request//
        //    string num_req_string = num_requete.Text;
        //    if (!(num_requete.Text.Equals("")))
        //    {
        //        if (linq1.Equals("")) linq = linq + "num = " + num_req_string + "" + linq1;
        //        else linq = linq + "num = " + num_requete.Text + "" + and + linq1;
        //    }
        //    else
        //    {
        //        if (!linq1.Equals("")) linq = linq + linq1;
        //    }
        //    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //    datasource = requete_controller.getFilteredReclamation(linq);
        //    GridView1.DataSourceID = null;
        //    GridView1.DataSource = datasource;
        //    GridView1.DataBind();
        //}
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //protected string getDateDu(TextBox a, string field)
        //{
        //    if (!(a.Text.Equals("")) && linq1_updated)
        //    {
        //        linq1_updated = false;
        //        requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //        return field + " >= @0 ";

        //    }
        //    else
        //    {
        //        if (a.Text.Equals(""))
        //        {

        //            return "";
        //        }
        //        else
        //        {
        //            if (!linq1_updated)
        //            {
        //                requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //                return " and " + field + " >=  @0 ";
        //            }


        //        }
        //    }
        //    return "";
        //}
        //protected string getDateAu(TextBox a, string field)
        //{
        //    if (!(a.Text.Equals("")) && linq1_updated)
        //    {
        //        linq1_updated = false;
        //        requete_controller.dateAu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        return field + " <=  @1 ";

        //    }
        //    else
        //    {
        //        if (a.Text.Equals(""))
        //        {

        //            return "";
        //        }
        //        else
        //        {
        //            if (!linq1_updated)
        //            {
        //                requete_controller.dateAu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //                return " and " + field + " <=  @1 ";
        //            }


        //        }
        //    }
        //    return "";
        //}
        //protected string getSubStringLinqTextBox(TextBox a, string field)
        //{
        //    if (!(a.Text.Equals("")) && linq1_updated)
        //    {
        //        linq1_updated = false;
        //        return field + " = " + a.Text + "";

        //    }
        //    else
        //    {
        //        if (a.Text.Equals(""))
        //        {

        //            return "";
        //        }
        //        else
        //        {
        //            if (!linq1_updated)
        //            {
        //                return " and " + field + " = " + a.Text + "";
        //            }


        //        }
        //    }
        //    return "";
        //}
        //protected string getSubStringLinqDropDownList(DropDownList b, string field)
        //{
        //    if (!(b.SelectedValue.Equals("0")) && linq1_updated)
        //    {
        //        linq1_updated = false;
        //        return field + " = " + b.Text + "";
        //    }

        //    else
        //    {
        //        if (b.SelectedValue.Equals("0"))
        //        {
        //            return "";
        //        }
        //        else
        //        {
        //            if (!linq1_updated)
        //            {
        //                return " and " + field + " = " + b.Text + "";
        //            }

        //        }
        //    }
        //    return "";
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            
            //lbl_num.Text = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label1")).Text;
            //lbl_nom.Text = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label2")).Text;
            //lbl_prenom.Text = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label3")).Text;
            //lbl_addres.Text = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label4")).Text;



            dialog.Visible = false;
            //OdsDispositif.SelectParameters[0].DefaultValue = ((Label)GridView1.Rows[row.RowIndex].FindControl("Label1")).Text;
            FormView1.ChangeMode(FormViewMode.Edit);
            DropDownList wilayasEdit = (DropDownList)FormView1.FindControl("DropDownList5");
            wilayasEdit.ClearSelection();
            wilayasEdit.Items.FindByValue(((Label)GridView1.Rows[row.RowIndex].FindControl("Label6")).Text).Selected = true;
            
        }

        protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            OdsMotifDispositif.SelectParameters[0].DefaultValue = dispositif.SelectedValue;


            motifDispositif.DataSourceID = null;
            motifDispositif.DataSource = OdsMotifDispositif;
            motifDispositif.DataTextField = "motif1";
            motifDispositif.DataValueField = "id_motif";





            motifDispositif.DataBind();





            //Session["Numdispositif"] = ((DropDownList)FormView1.FindControl("DropDownList8")).SelectedValue;
            //DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            //motifDispositif.DataBind();


            filterRequest();
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            dialog.Visible = true;

        }

        

        protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            
                
        }

        protected void LinkButton25_Click(object sender, EventArgs e)
        {
            Label test=(Label)FormView1.FindControl("Label21");
            test.Text = "eeeeeeeeeeeeeeeee";
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.Insert);
            
            dialog.Visible = false;
        }

        

        protected void FormView2_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            
            
            
        }

        protected void LinkButton25_Click1(object sender, EventArgs e)
        {
            //GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            //int indexRowSelected = gridViewRow.RowIndex;
            //UpdatePanel masterupdatepanel = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            //masterupdatepanel.Update();
            /////////////////////////////////////////////////////
            //string num_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;

            //string LabelGridMotif = ((Label)GridView1.Rows[indexRowSelected].FindControl("LabelGridMotif")).Text;
            
            //request.SelectParameters[0].DefaultValue = num_selected;

            ///////////////////////////////
            ////OdsMotifDispositif.SelectParameters[0].DefaultValue = LabelGridMotif;
            ////DropDownList state_reclamation = (DropDownList)FormView1.FindControl("DropDownList8");
             
            ////OdsMotifDispositif.SelectParameters[0].DefaultValue = LabelGridMotif; 


            ////////////////////////////////////////
            //FormView1.DataBind();
            //FormView1.ChangeMode(FormViewMode.Edit);
            //dialog.Visible = false;
            //FormView2.Visible = false;
            //masterupdatepanel.Update();

            //FormView1.DataBind();
            //DropDownList DropDownListDispoSelected = ((DropDownList)FormView1.FindControl("DropDownList8"));
            //DropDownList DropDownListMotif = ((DropDownList)FormView1.FindControl("DropDownList9"));


            /////////////////////////////////////
            //int id_motif_recl = requete_controller.getIDMotifOfRequest(Convert.ToInt32(num_selected));
            //int valueDispositif = MotifDispositif_Controller.getIdDispositifOfMotifByNum(id_motif_recl);
            //DropDownListDispoSelected.SelectedValue = valueDispositif.ToString();

            //DropDownListDispoSelected.SelectedValue = valueDispositif.ToString();





            //DropDownListMotif.DataSourceID = null;

            //OdsMotifDispositif.SelectParameters[0].DefaultValue = valueDispositif.ToString();
            //DropDownListMotif.DataSource = OdsMotifDispositif;
            //DropDownListMotif.DataTextField = "motif1";
            //DropDownListMotif.DataValueField = "id_motif";
            //DropDownListMotif.SelectedValue = id_motif_recl.ToString();
            //DropDownListMotif.DataBind();




            ////DropDownListMotif.SelectedValue = id_motif_recl.ToString();


            /////////////////////////////////////

            //////foreach (ListItem cf in DropDownListDispoSelected.Items)
            //////{
            //////    string aaaa = cf.Text;
            //////}
            ////string sss=DropDownListDispoSelected.SelectedItem.Text.ToString();
            ////DropDownListMotif.DataSourceID = null;

            ////OdsMotifDispositif.SelectParameters[0].DefaultValue = DropDownListDispoSelected.SelectedValue.ToString();
            ////DropDownListMotif.DataSource = OdsMotifDispositif;
            ////DropDownListMotif.DataTextField = "motif1";
            ////DropDownListMotif.DataValueField = "id_motif";
            ////DropDownListMotif.DataBind();
            //////////////////////////////////////////////////
            ////string aaa = DropDownListMotif.Items.ToString();
            ////int i = 0;
            ////foreach (ListItem cf in DropDownListMotif.Items){
            ////    string aaaa = cf.Text;
            ////    i++;
            ////}
            //////////////////////////////////////////////////
            //////DropDownListMotif.SelectedItem.Text = LabelGridMotif;

            //////DropDownListMotif.SelectedValue = "2";
            
            
        }


        //to select the value of dropdownlist of motif
        protected string ReturnValueMotif(int num_requete)
        {
            //Request recl = requete_controller.getRequestByNum(num_requete);
            //if(recl!=null)
            //{
            //    return recl.id_motif.ToString();
            //}
            //else return "0";
            return "";
        }

        protected void LinkButton26_Click(object sender, EventArgs e)
        {



            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;


            UpdatePanel masterupdatepanel = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            masterupdatepanel.Update();
            ///////////////////////////////////////////////////

            string num_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            request.SelectParameters[0].DefaultValue = num_selected;



            FormView1.ChangeMode(FormViewMode.Edit);

            dialog.Visible = false;
            FormView2.Visible = true;
            FormView1.Visible = false;
            masterupdatepanel.Update();




            //FormView2.Visible = true;
            //FormView1.Visible = false;
            //dialog.Visible = false;


            
        }









        public object lnkBtnControl { get; set; }

        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nbrlignes =Convert.ToInt32(GridView1.Rows.Count / Convert.ToInt32(DropDownList10.SelectedValue.ToString())) + 1;
            //GridView1.PageSize = nbrlignes ;
            //GridView1.DataBind()            ;

            GridView1.PageSize = Convert.ToInt32(DropDownList10.SelectedValue);
            GridView1.DataBind();
        }




        /////////////////////////////////////////////////////////////////////////////////////
        ///to display the linkbutton Valider in the gridview only when the stat of request is (En cours de Traitement)
        ///
        
        public Boolean IsEnCoursDeTraitement(int id_state_request)
        {
            return id_state_request==1;
        }

        public bool raouf()
        {
            return true;
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            //TextBox numero_reclamation = (TextBox)FormView1.FindControl("numTextBox");
            //TextBox date = (TextBox)FormView1.FindControl("TextBox10");
            //TextBox num_requerant = (TextBox)FormView1.FindControl("TextBox11");
            //DropDownList state_reclamation = (DropDownList)FormView1.FindControl("DropDownList7");
            //DropDownList Transmission_recl = (DropDownList)FormView1.FindControl("DropDownList6");
            //DropDownList dispo_recl = (DropDownList)FormView1.FindControl("DropDownList8");
            //DropDownList wilaya_reclamation = (DropDownList)FormView1.FindControl("DropDownList5");
            
            //TextBox corps_requete = (TextBox)FormView1.FindControl("corp_requeteTextBox");

            //Request reclam = requete_controller.getRequestByNum(Convert.ToInt32(numero_reclamation.Text));
            //reclam.id_state = Convert.ToInt32(state_reclamation.SelectedValue);
            //reclam.id_trans = Convert.ToInt32(Transmission_recl.SelectedValue);
            ////reclam.num_dispositif = Convert.ToInt32(dispo_recl.SelectedValue);
            //reclam.num_wilaya = Convert.ToInt32(wilaya_reclamation.SelectedValue);
            

            
            //reclam.date = DateTime.ParseExact(date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);




            //if (requete_controller.updateRequest(reclam))
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Reclamation Modifiée avec succès');", true);
            
            //    FormView1.ChangeMode(FormViewMode.ReadOnly);
            //    GridView1.EditIndex = -1;
            //    dialog.Visible = true;
                
            //}
            //else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + requete_controller.message_exception + "');", true);
                        
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Label num_request = (Label)FormView2.FindControl("Label10");
            //TextBox resultat_traitement = (TextBox)FormView2.FindControl("resultat_traitement");
            //DropDownList state_reclamation = (DropDownList)FormView2.FindControl("DropDownList7");
            //Request reclam = requete_controller.getRequestByNum(Convert.ToInt32(num_request.Text));
            //reclam.id_state = Convert.ToInt32(state_reclamation.SelectedValue);

            ////reclam.date = date.Text;
            ////reclam.num_requerant = num_requerant.Text;

            //reclam.id_state = Convert.ToInt32(state_reclamation.SelectedValue);
            //reclam.result_traitement = resultat_traitement.Text;


            //if (requete_controller.updateRequest(reclam))
            //{

                
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Votre Reclamation a été Validée avec succès');", true);

            //    FormView1.Visible = false;
            //    FormView2.ChangeMode(FormViewMode.Edit);
            //    FormView2.Visible = true;
            //    GridView1.EditIndex = -1;
            //    dialog.Visible = true;

            //}
            //else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + requete_controller.message_exception + "');", true);

        }

        protected string getPhaseValue(string id_Object)
        {
            Objet_Disp m = MotifDispositif_Controller.getMotifDispositifByNum(Guid.Parse(id_Object));
            
            
            string dispo = m.PhaseC;
            return dispo;
        }

        protected void numTextBox_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }
        protected void fillGrid()
        {


            GridView1.DataSourceID = null;
            GridView1.DataSource = null;
            GridView1.DataSource = datasource;
            GridView1.DataBind();
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void objetTextBox_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }
        
    }
}