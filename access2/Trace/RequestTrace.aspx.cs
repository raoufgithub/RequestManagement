using System;
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


namespace view.Trace
{
    public partial class RequestTrace : System.Web.UI.Page
    {

        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try { 
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Statistics"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch (Exception e)
            {
                return false;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Context.User.Identity.IsAuthenticated)
            {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    Response.Redirect("~/Account/loginPopup.aspx");
            }
            
            else
            {
                //ClientScript.RegisterStartupScript(Master.GetType(), "alert", "ShowPopup();", true);

                if (!IsAuthorized())
                {

                    //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                    Response.Redirect("~/UnauthorizedPage.aspx");

                }
                else
                {
                    if (!IsPostBack) filterRequest();
                }
            }
        }

        
        static List<requerant> datasource1;
        static List<Request> datasource;
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {



        }
        ///// <summary>
        ///// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// </Request with where et and>


        bool linq1_updated = true;

        public void filterRequest()
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
            DropDownList request_type = (DropDownList)FormView1.FindControl("DropDownList12");
            DropDownList request_voie = (DropDownList)FormView1.FindControl("DropDownList13");

            Label LabelWilaya = (Label)FormView1.FindControl("LabelWilaya");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from Request req.Request ";
            string linq = "select * from Request reclam join Objet_Disp mot on(mot.id_objet=reclam.id_objet) ";
            string where = " where(";
            string and = " and ";
            string linq1;
            if (isDGCell())
            {
                linq1 =
                 getDateDu(dateDu, "date") + getDateAu(dateAu, "date")
                + getSubStringLinqDropDownList0(wilaya, "num_wilaya") + getSubStringLinqTextBox(requerant, "num_requerant") + getSubStringLinqDropDownList_Dispo(dispositif, "num_mission")
                + getSubStringLinqDropDownList(motif_dispo, "id_objet") + getSubStringLinqDropDownList0(etat_requete, "id_state") + getSubStringLinqDropDownList(mode_trans, "id_trans")
                + getSubStringLinqDropDownList(request_type, "id_type") + getSubStringLinqDropDownList(request_voie, "id_Voie_Trans") + ")";
            }
            else
            {
                linq1 =
                 getDateDu(dateDu, "date") + getDateAu(dateAu, "date")
                + getSubStringLinqLabelWilaya(LabelWilaya, "num_wilaya") + getSubStringLinqTextBox(requerant, "num_requerant") + getSubStringLinqDropDownList_Dispo(dispositif, "num_mission")
                + getSubStringLinqDropDownList(motif_dispo, "id_objet") + getSubStringLinqDropDownList0(etat_requete, "id_state") + getSubStringLinqDropDownList(mode_trans, "id_trans")
                + getSubStringLinqDropDownList(request_type, "id_type") + getSubStringLinqDropDownList(request_voie, "id_Voie_Trans") + ")";
            }
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


            linq = linq + " order by reclam.Date_Insertion DESC";

            datasource = requete_controller.getFilteredRequest(linq);
            RqFound.Text=datasource.Count.ToString()+" Requêtes";
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
                //return "reclam." + field + " >= '" + a.Text + "'";

                DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                return "reclam." + field + " >= '" + ff.ToString("MM/dd/yyyy") + "'";

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
                        //return " and " + "reclam." + field + " >=  '" + a.Text + "'";

                        DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "reclam." + field + " >=  '" + ff.ToString("MM/dd/yyyy") + "'";
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
                //return "reclam." + field + " <=  '" + a.Text + "'";

                DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                return "reclam." + field + " <=  '" + ff.ToString("MM/dd/yyyy") + "'";
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
                        //return " and " + "reclam." + field + " <=  '" + a.Text + "'";

                        DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "reclam." + field + " <=  '" + ff.ToString("MM/dd/yyyy") + "'";
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
                return "reclam." + field + " like '" + a.Text + "%'";

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
        protected string getSubStringLinqLabelWilaya(Label a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;

                return "reclam." + field + " = " + wilaya_controller.getWilayaByName(a.Text).num;

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
                        return " and reclam." + field + " =" + wilaya_controller.getWilayaByName(a.Text).num;
                    }


                }
            }
            return "";
        }

        protected string getSubStringLinqDropDownList0(DropDownList b, string field)
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
        protected string getSubStringLinqDropDownList(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals(" ")) && linq1_updated)
            {
                linq1_updated = false;
                return "reclam." + field + "= '" + b.Text + "'";
            }

            else
            {
                if (b.SelectedValue.Equals(" "))
                {
                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        return " and reclam." + field + "= '" + b.Text + "'";
                    }

                }
            }
            return "";
        }

        protected string getSubStringLinqDropDownList_Dispo(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals(" ")) && linq1_updated)
            {
                linq1_updated = false;
                return "mot." + field + "= '" + b.Text + "'";
            }

            else
            {
                if (b.SelectedValue.Equals(" "))
                {
                    return "";
                }
                else
                {
                    if (!linq1_updated)
                    {
                        return " and mot." + field + "= '" + b.Text + "'";
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
        //    //string linq = "from Request req.Request ";
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
        //    datasource = requete_controller.getFilteredRequest(linq);
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
            motifDispositif.DataTextField = "objet";
            motifDispositif.DataValueField = "id_objet";

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
            Label test = (Label)FormView1.FindControl("Label21");
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




        //to select the value of dropdownlist of motif
        protected string ReturnValueMotif(int num_requete)
        {
            //Request recl = requete_controller.getRequestByNum(num_requete);
            //if (recl != null)
            //{
            //    return recl.id_motif.ToString();
            //}
            //else return "0";
            return "";
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

        protected Boolean IsEnCoursDeTraitement1(int id_state_request)
        {
            return id_state_request == 1;
        }

        public bool raouf()
        {
            return true;
        }

        

        protected string getPhaseValue1(string id_objet)
        {
            Objet_Disp m = MotifDispositif_Controller.getMotifDispositifByNum(Guid.Parse(id_objet));


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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            TextBox numrequerant = (TextBox)FormView1.FindControl("TextBox11");
            numrequerant.Text = "1";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "closeModal();", true);
        }


        protected void GridView2_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
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

        
        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






        protected string getAgentWilaya()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));


            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return "";
                else return wilaya_claim.First().ClaimValue.ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return "";
            }

        }
        protected Boolean isDGCell()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return true;
                else return false;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return false;
            }

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

        protected void LinkButton27_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            Session["Id_Request_Trace"] = num_Selected;
            Session["NumWilaya_Request_Trace"] = NumWilaya_Selected;
            Session["Year_Request_Trace"] = Year_Selected;
            Response.Redirect("~/Trace/ListViewTrace.aspx");
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////

        protected void Button5_Click(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(Master.Page, Master.GetType(), "alert", "ShowPopup();", true);
        }

        protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }
        protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            
            filterRequest();
        }
    }
}