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
using System.IO;

using System.Data;
using System.Drawing;

namespace view.webforms
{
    public partial class ReceivedRequestTest : System.Web.UI.Page
    {
        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try
            {
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch(Exception e)
            {
                return false;
            }
            


        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
            
            

                if (!Context.User.Identity.IsAuthenticated)
                {

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
                        
                        try
                        {
                        
                        
                            Button Button_DisplayImg = (Button)FormView1.FindControl("Button_DisplayImg");
                            this.Master.RegisterTrigger(Button_DisplayImg);
                            
                            if (!IsPostBack)
                            {

                                /////////////////////////////////////////////////////////////////////////////////
                                DropDownList Wilaya = (DropDownList)FormView1.FindControl("DropDownList5");
                                //Label WilayaLabel = (Label)FormView1.FindControl("Label31");

                                OdsWilaya.SelectParameters[0].DefaultValue = Context.User.Identity.Name;
                                Wilaya.DataSourceID = null;
                                Wilaya.DataSource = OdsWilaya;
                                Wilaya.DataTextField = "wilaya";
                                Wilaya.DataValueField = "num";

                                Wilaya.DataBind();
                                Wilaya.SelectedValue = getAgentWilaya().ToString();
                                DropDownList DropDownListCommune = (DropDownList)FormView1.FindControl("DropDownListCommune");

                                ODSCommune.SelectParameters[0].DefaultValue = Wilaya.SelectedValue;
                                DropDownListCommune.DataSource = ODSCommune;
                                DropDownListCommune.DataTextField = "NomCommune";
                                DropDownListCommune.DataValueField = "CommuneId";
                                DropDownListCommune.DataBind();
                                /////////////////////////////////////////////////////////////////////////////////    



                                string Choice;
                                string session;
                                try
                                {
                                    Choice = Session["Request_Treating"].ToString().Substring(0, 1);
                                    session = Session["Request_Treating"].ToString().Substring(1, Session["Request_Treating"].ToString().Length - 1);
                                }
                                catch
                                {
                                    Choice = "";
                                    session = "";
                                }
                                string linq = "";
                                switch (Choice)
                                {
                                    case "1":
                                        if (isDGCell())
                                        {
                                            linq = "select *from Request ";
                                        }
                                        else
                                        {
                                            linq = "select *from Request where(num_wilaya=" + getIdAgentWilaya() + ")";

                                        }
                                        Session["Request_Treating"] = null;
                                        break;
                                    case "2":
                                        if (isDGCell())
                                        {
                                            linq = "select *from Request where(id_state=1)";
                                        }
                                        else
                                        {
                                            linq = "select *from Request where(num_wilaya=" + getIdAgentWilaya() + " and id_state=1)";

                                        }
                                        Session["Request_Treating"] = null;
                                        break;
                                    case "3":
                                        if (isDGCell())
                                        {
                                            linq = "select *from Request where(id_state=2)";
                                        }
                                        else
                                        {
                                            linq = "select *from Request where(num_wilaya=" + getIdAgentWilaya() + " and id_state=2)";

                                        }
                                        Session["Request_Treating"] = null;
                                        break;
                                    case "4":
                                        if (isDGCell())
                                        {
                                            linq = "select *from Request where(id_state=3)";
                                        }
                                        else
                                        {
                                            linq = "select *from Request where(num_wilaya=" + getIdAgentWilaya() + " and id_state=3)";

                                        }
                                        Session["Request_Treating"] = null;
                                        break;
                                    default:
                                        string[] RequestId = GetIdRequest(session);
                                        linq = "select *from Request where(num='" + RequestId[2] + "' and year=" + RequestId[1] + " and num_wilaya=" + RequestId[0] + ")";
                                        Session["Request_Treating"] = null;
                                        break;


                                }





                                //TextBox NumRequest = (TextBox)FormView1.FindControl("");
                                //DropDownList NumWilaya = (DropDownList)FormView1.FindControl("");
                                //TextBox year = (TextBox)FormView1.FindControl("");

                                datasource = requete_controller.getFilteredRequest(linq);
                                RqFound.Text = datasource.Count.ToString() + " Requêtes";
                                GridView1.DataSourceID = null;
                                GridView1.DataSource = datasource;
                                GridView1.DataBind();



                            
                        }
                        else
                            {

                                if (FormView1.CurrentMode == FormViewMode.Edit)
                                {
                                    //f
                                }
                                //this.Master.RegisterTrigger(Button_DisplayImg);
                                throw new Exception();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (!IsPostBack) filterRequest();
                            else
                            {
                                if (Photos_GridViewRow != -1)
                                {

                                    string NumWilaya_Selected = ((Label)GridView1.Rows[Photos_GridViewRow].FindControl("Label1")).Text;
                                    string Year_Selected = ((Label)GridView1.Rows[Photos_GridViewRow].FindControl("Label81")).Text;
                                    string num_Selected = ((Label)GridView1.Rows[Photos_GridViewRow].FindControl("Label82")).Text;


                                    Panel Panel1 = ((Panel)GridView1.Rows[Photos_GridViewRow].FindControl("Panel1"));

                                    List<Link> links = requete_controller.getRequestAttachments(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
                                    foreach (Link link in links)
                                    {
                                        ImageButton imageButton = new ImageButton();
                                        FileInfo fileInfo = new FileInfo(link.Link1);
                                        imageButton.ID = link.Link1;
                                        imageButton.ImageUrl = "~/RequestsFiles/" + link.Link1 + "_" + link.Guid + link.extension;
                                        imageButton.Width = Unit.Pixel(25);
                                        imageButton.Height = Unit.Pixel(25);
                                        imageButton.Style.Add("padding", "5px");
                                        imageButton.Click += new ImageClickEventHandler(Image_Click);
                                        string id = imageButton.ID;
                                        Panel1.Controls.Add(imageButton);

                                    }
                                }

                            }
                        }

                        

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
            DropDownList commune = (DropDownList)FormView1.FindControl("DropDownListCommune");
            TextBox requerant = (TextBox)FormView1.FindControl("TextBox11");
            DropDownList Mission = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList DropDownListPhase = (DropDownList)FormView1.FindControl("DropDownListPhase");
            DropDownList Object_dispo = (DropDownList)FormView1.FindControl("DropDownList9");
            DropDownList etat_requete = (DropDownList)FormView1.FindControl("DropDownList7");
            DropDownList mode_trans = (DropDownList)FormView1.FindControl("DropDownList6");
            TextBox objetTextBox = (TextBox)FormView1.FindControl("objetTextBox");
            DropDownList request_type = (DropDownList)FormView1.FindControl("DropDownList12");
            DropDownList request_voie = (DropDownList)FormView1.FindControl("DropDownList13");

            DropDownList DropDownListDispositionPrise = (DropDownList)FormView1.FindControl("DropDownListDispositionPrise");
            DropDownList DropDownListMotif = (DropDownList)FormView1.FindControl("DropDownListMotif");


            Label LabelWilaya = (Label)FormView1.FindControl("LabelWilaya");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from Request req.Request ";
            string linq = "select * from Request reclam join Motif mot on(mot.MotifId=reclam.MotifId) join Objet_Disp obj on obj.id_objet=mot.ObjectId join PhaseObject phase on phase.PhaseId=obj.PhaseId ";
            string where = " where(";
            string and = " and ";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from reclamation req.reclamation ";

            string whereLinq = "  ";

            //string linq = "select * from AspNetUsers users join AspNetUserClaims claims on(users.Id=claims.UserId)  ";

            string linq1 = "";

            if (!dateDu.Text.Equals(""))
            {
                linq1 = linq1 + " and reclam.date >= '" + dateDu.Text + "' ";
            }
            else linq1 = linq1 + "";
            if (!dateAu.Text.Equals(""))
            {
                linq1 = linq1 + " and reclam.date <= '" + dateAu.Text + "' ";
            }
            else linq1 = linq1 + "";
            if (!wilaya.SelectedValue.Equals("0"))
            {
                linq1 = linq1 + " and reclam.num_wilaya = '" + wilaya.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!commune.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and reclam.CommuneId = '" + commune.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!requerant.Text.Equals(""))
            {
                linq1 = linq1 + " and reclam.num_requerant = '" + requerant.Text + "' ";
            }
            else linq1 = linq1 + "";
            if (!Mission.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and phase.MissionId = '" + Mission.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!DropDownListPhase.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and phase.PhaseId = '" + DropDownListPhase.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!Object_dispo.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and mot.ObjectId = '" + Object_dispo.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!etat_requete.SelectedValue.Equals("0"))
            {
                linq1 = linq1 + " and reclam.id_state = '" + etat_requete.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!mode_trans.SelectedValue.Equals(" "))
            {
                linq1 = linq1 + " and reclam.id_trans = '" + mode_trans.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!request_type.SelectedValue.Equals(" "))
            {
                linq1 = linq1 + " and reclam.id_type = '" + request_type.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!request_voie.SelectedValue.Equals(" "))
            {
                linq1 = linq1 + " and reclam.id_Voie_Trans = '" + request_voie.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!DropDownListMotif.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and reclam.MotifId = '" + DropDownListMotif.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";
            if (!DropDownListDispositionPrise.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and reclam.DispositionPriseId = '" + DropDownListDispositionPrise.SelectedValue + "' ";
            }
            else linq1 = linq1 + "";

            if (!linq1.Equals(""))
            {
                //Delete the first and
                linq1 = linq1.Substring(4);
                whereLinq = " where(" + linq1 + ") ";
            }
            linq = linq+ whereLinq + " order by reclam.Date_Insertion DESC";

            //
            datasource = requete_controller.getFilteredRequest(linq);
            RqFound.Text=datasource.Count.ToString()+" Requêtes";
            GridView1.DataSourceID = null;
            GridView1.DataSource = datasource;
            GridView1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (GridView1.Rows.Count > 0)
            {
                GridView1.SelectedIndex = 0;
                GridViewRow g = GridView1.SelectedRow;
                g.ForeColor = Color.DarkBlue;
            }
            //GridViewRow gridViewRow = GridView1.SelectedRow;
            //if (gridViewRow != null)
            //{
            //    if (GridView1.Rows.Count > gridViewRow.RowIndex)
            //    {
            //        GridViewRow g = GridView1.SelectedRow;
            //        g.ForeColor = Color.DarkBlue;
            //    }
            //}
            
            
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
                if (b.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
                {
                    return "";
                }
                else
                {
                    linq1_updated = false;
                    return "reclam." + field + "= '" + b.Text + "'";
                }
            }

            else
            {
                if (b.SelectedValue.Equals(" "))
                {
                    return "";
                }
                else
                {
                    if (b.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
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
            }
            return "";
        }

        protected string getSubStringLinqDropDownList_Dispo(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals(" ")) && linq1_updated)
            {
                if (b.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
                {
                    return "";
                }
                else
                {
                    linq1_updated = false;
                    return "obj." + field + "= '" + b.Text + "'";
                }
            }

            else
            {
                if (b.SelectedValue.Equals(" "))
                {
                    return "";
                }
                else
                {
                    if (b.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
                    {
                        return "";
                    }
                    else
                    {
                        if (!linq1_updated)
                        {
                            return " and obj." + field + "= '" + b.Text + "'";
                        }
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
            DropDownList Phase = (DropDownList)FormView1.FindControl("DropDownListPhase");
            if (dispositif.Text.Equals(" "))
            {
                OdsPhaseMission.SelectParameters[0].DefaultValue = null;
            }
            else 
            {
                OdsPhaseMission.SelectParameters[0].DefaultValue = dispositif.SelectedValue;
            }

            
            Phase.DataSourceID = null;
            Phase.DataSource = OdsPhaseMission;
            Phase.DataTextField = "PhaseName";
            Phase.DataValueField = "PhaseId";

            Phase.DataBind();

            //Session["Numdispositif"] = ((DropDownList)FormView1.FindControl("DropDownList8")).SelectedValue;
            //DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            //motifDispositif.DataBind();
            DropDownListPhaseChanged();
            DropDownListObjectChanged();



            filterRequest();

            
        }
        protected void DropDownListMissionModifChanged()
        {
            DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList Phase = (DropDownList)FormView1.FindControl("DropDownListPhase");
            if (dispositif.Text.Equals(" "))
            {
                OdsPhaseMission.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsPhaseMission.SelectParameters[0].DefaultValue = dispositif.SelectedValue;
            }


            Phase.DataSourceID = null;
            Phase.DataSource = OdsPhaseMission;
            Phase.DataTextField = "PhaseName";
            Phase.DataValueField = "PhaseId";

            Phase.DataBind();
        }

        protected void DropDownList8Modif_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Mission_recl = (DropDownList)FormView1.FindControl("DropDownList8");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            Mission mission = dispositif_controller.getMissionOfMotif(r.MotifId.Value);
            if (!Mission_recl.SelectedValue.Equals(mission.num))
            {
                ModeTrans = "  ' La Mission de la Requête a été modifié Du " + r.MotifDispositifC + " Au " + Mission_recl.SelectedItem + " ' ";
            }

            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///

            DropDownListMissionModifChanged();
            DropDownListPhaseModifChanged();
            DropDownListObjectModifChanged();
            

        }
        protected void DropDownListPhaseModif_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Phase_recl = (DropDownList)FormView1.FindControl("DropDownListPhase");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            PhaseObject phase = PhaseObjetBLL.getPhaseOfMotif(r.MotifId.Value);
            if (!Phase_recl.SelectedValue.Equals(phase.PhaseId))
            {
                ModeTrans = "  ' La Phase de la Requête a été modifié Du " + phase.PhaseName + " Au " + Phase_recl.SelectedItem + " ' ";
            }

            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///

            DropDownListPhaseModifChanged();
            DropDownListObjectModifChanged();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormView1.ChangeMode(FormViewMode.ReadOnly);
            dialog.Visible = true;

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



        

        protected void LinkButtonUpdate_Click1(object sender, EventArgs e)
        {

            FileUpload FileUpload2 = (FileUpload)FormView1.FindControl("FileUpload1");

            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            UpdatePanel masterupdatepanel = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            masterupdatepanel.Update();
            ///////////////////////////////////////////////////
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            string LabelGridMotif = ((Label)GridView1.Rows[indexRowSelected].FindControl("LabelGridMotif")).Text;

            request.SelectParameters[0].DefaultValue = num_Selected;
            request.SelectParameters[1].DefaultValue = NumWilaya_Selected;
            request.SelectParameters[2].DefaultValue = Year_Selected;

            /////////////////////////////
            //OdsMotifDispositif.SelectParameters[0].DefaultValue = LabelGridMotif;
            //DropDownList state_Request = (DropDownList)FormView1.FindControl("DropDownList8");

            //OdsMotifDispositif.SelectParameters[0].DefaultValue = LabelGridMotif; 

            //////////////////////////////////////
            FormView1.DataBind();
            FormView1.ChangeMode(FormViewMode.Edit);
            dialog.Visible = false;
            FormView2.Visible = false;
            masterupdatepanel.Update();

            FormView1.DataBind();
            DropDownList DropDownListMission = ((DropDownList)FormView1.FindControl("DropDownList8"));
            DropDownList DropDownListObject = ((DropDownList)FormView1.FindControl("DropDownList9"));
            DropDownList DropDownListPhase = ((DropDownList)FormView1.FindControl("DropDownListPhase"));
            DropDownList DropDownListMotif = ((DropDownList)FormView1.FindControl("DropDownListMotif"));
            ///////////////////////////////////
            Request requete = requete_controller.getRequestByNum(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
            ///////////////////
            ///////////////////
            ///////////////////
            string id_Object_recl = requete_controller.getIDMotifOfRequest(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
            string valueMission = dispositif_controller.getIDMissionOfObject(id_Object_recl);
            Guid MotifId = requete.MotifId.Value;
            Guid PhaseId = PhaseObjetBLL.getPhaseOfObject(Guid.Parse(id_Object_recl));
            ///////////////////
            ///////////////////
            ///////////////////
            DropDownListMission.SelectedValue = valueMission;
            //////////////////////
            DropDownListPhase.DataSourceID = null;
            OdsPhaseMission.SelectParameters[0].DefaultValue = DropDownListMission.SelectedValue;
            DropDownListPhase.DataSource = OdsPhaseMission;
            DropDownListPhase.DataTextField = "PhaseName";
            DropDownListPhase.DataValueField = "PhaseId";
            DropDownListPhase.SelectedValue = PhaseId.ToString();
            DropDownListPhase.DataBind();
            ////////////////////
            DropDownListObject.DataSourceID = null;
            OdsMotifDispositif.SelectParameters[0].DefaultValue = DropDownListPhase.SelectedValue;
            DropDownListObject.DataSource = OdsMotifDispositif;
            DropDownListObject.DataTextField = "objet";
            DropDownListObject.DataValueField = "id_objet";
            DropDownListObject.SelectedValue = id_Object_recl.ToString();
            DropDownListObject.DataBind();
            ////////////////////
            DropDownListMotif.DataSourceID = null;
            OdsMotifOfObject.SelectParameters[0].DefaultValue = DropDownListObject.SelectedValue;
            DropDownListMotif.DataSource = OdsMotifOfObject;
            DropDownListMotif.DataTextField = "MotifName";
            DropDownListMotif.DataValueField = "MotifId";
            DropDownListMotif.SelectedValue = MotifId.ToString();
            DropDownListMotif.DataBind();
            /////////////////////
            /////////////////////
            /////////////////////
            FillPanelImagesModify(num_Selected, NumWilaya_Selected, Year_Selected);
            ///
            Button Button_DisplayImg = (Button)FormView1.FindControl("Button_DisplayImg");
            FileUpload FileUpload1 = (FileUpload)FormView1.FindControl("FileUpload1");
            Button_DisplayImg.Text = "ButtonChanged";
            
            this.Master.RegisterTrigger(Button_DisplayImg);
        }

        //
        private static bool UpdateAttachments = false;
        void FillPanelImagesModify(string num_Selected, string NumWilaya_Selected, string Year_Selected)
        {
            Panel Panel2 = (Panel)FormView1.FindControl("Panel2");
            List<Link> Attachments = requete_controller.getRequestAttachments(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
            foreach (Link l in Attachments)
            {
                ///////////////////////////////////////////////////////////////////////////////

                System.Web.UI.WebControls.Image imageButton = new System.Web.UI.WebControls.Image();
                string link = l.Link1;
                string tempath = "~/RequestsFiles/";
                FileInfo fileInfo = new FileInfo(link);
                imageButton.ID = link;
                //imageButton.ImageUrl = tempath + link;
                string path = tempath + link + "_" + l.Guid.ToString() + l.extension;
                imageButton.ImageUrl = path;

                imageButton.Width = Unit.Pixel(100);
                imageButton.Height = Unit.Pixel(100);
                imageButton.Style.Add("padding", "5px");

                string id = imageButton.ID;
                Panel2.Controls.Add(imageButton);

            }
            UpdateAttachments = false;
        }

        //to select the value of dropdownlist of motif
        //protected string ReturnValueMotif(int num_requete, int NumWilaya_Request, int Year_Request)
        //{
        //    Request recl = requete_controller.getRequestByNum(num_requete, NumWilaya_Request, Year_Request);
        //    if (recl != null)
        //    {
        //        return recl.id_objet.ToString();
        //    }
        //    else return " ";
        //}

        protected void LinkButton26_Click(object sender, EventArgs e)
        {



            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;


            UpdatePanel masterupdatepanel = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            masterupdatepanel.Update();
            ///////////////////////////////////////////////////

            
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            request.SelectParameters[0].DefaultValue = num_Selected;
            request.SelectParameters[1].DefaultValue = NumWilaya_Selected;
            request.SelectParameters[2].DefaultValue = Year_Selected;


            FormView1.ChangeMode(FormViewMode.Edit);

            dialog.Visible = false;
            FormView2.Visible = true;
            FormView1.Visible = false;
            FormView2.DataBind();
            Label NumWilaya_Request = (Label)FormView2.FindControl("Label85");
            Label Year_Request = (Label)FormView2.FindControl("Label86");
            NumWilaya_Request.Text = NumWilaya_Selected;
            Year_Request.Text = Year_Selected;

            ///////////////////////
            Request req = requete_controller.getRequestByNum(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
            Objet_Disp objet = MotifDispositif_Controller.getMotifDispositifByNum(req.MotifId.Value);
            DropDownList DropDownListDispositionPriseValidation = (DropDownList)FormView2.FindControl("DropDownListDispositionPriseValidation");

            if (objet.id_objet.ToString().Equals("00000000-0000-0000-0000-000000000000"))
            {

                OdsDispositionPrise.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsDispositionPrise.SelectParameters[0].DefaultValue = objet.id_objet.ToString();
            }
            DropDownListDispositionPriseValidation.DataSourceID = null;
            DropDownListDispositionPriseValidation.DataSource = OdsDispositionPrise;
            DropDownListDispositionPriseValidation.DataTextField = "DispositionName";
            DropDownListDispositionPriseValidation.DataValueField = "DispositionPriseId";

            DropDownListDispositionPriseValidation.DataBind();
            
            ////////////////////////

            masterupdatepanel.Update();

        }

        public object lnkBtnControl { get; set; }

        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nbrlignes =Convert.ToInt32(GridView1.Rows.Count / Convert.ToInt32(DropDownList10.SelectedValue.ToString())) + 1;
            //GridView1.PageSize = nbrlignes ;
            //GridView1.DataBind()            ;
            Photos_GridViewRow = -1;
            GridView1.PageSize = Convert.ToInt32(DropDownList10.SelectedValue);
            filterRequest();
            
        }




        /////////////////////////////////////////////////////////////////////////////////////
        ///to display the linkbutton Valider in the gridview only when the stat of request is (En cours de Traitement)
        ///

        protected Boolean IsEnCoursDeTraitement1(int id_state_request)
        {
            return id_state_request == 1;
        }

        

        protected void Button2_Click1(object sender, EventArgs e)
        {
            TextBox numero_Request = (TextBox)FormView1.FindControl("numTextBox");
            TextBox date = (TextBox)FormView1.FindControl("TextBox10");
            TextBox num_requerant = (TextBox)FormView1.FindControl("TextBox11");
            
            DropDownList Transmission_recl = (DropDownList)FormView1.FindControl("DropDownList6");
            DropDownList Mission_recl = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList Motif_recl = (DropDownList)FormView1.FindControl("DropDownListMotif");
            DropDownList wilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            Label Year_Request = (Label)FormView1.FindControl("Label84");
            TextBox corps_requete = (TextBox)FormView1.FindControl("corp_requeteTextBox");
            DropDownList type_rquest = (DropDownList)FormView1.FindControl("DropDownList14");
            DropDownList voie_trans_request = (DropDownList)FormView1.FindControl("DropDownList15");
            Request reclam = requete_controller.getRequestByNum(Convert.ToInt32(numero_Request.Text), Convert.ToInt32(wilaya_Request.SelectedValue), Convert.ToInt32(Year_Request.Text));
            reclam.id_trans = Transmission_recl.SelectedValue;
            //reclam.num_dispositif = Convert.ToInt32(dispo_recl.SelectedValue);
            reclam.num_wilaya = Convert.ToInt32(wilaya_Request.SelectedValue);
            reclam.date = DateTime.ParseExact(date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            reclam.Year=DateTime.ParseExact(date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;
            reclam.num_requerant = num_requerant.Text;
            reclam.id_Voie_Trans = voie_trans_request.SelectedValue;
            reclam.id_type = type_rquest.SelectedValue;
            reclam.corp_requete = corps_requete.Text;
            reclam.MotifId = Guid.Parse(Motif_recl.SelectedValue);
            historique = DateRequest + WilayaRequest + NumRequerant + DispositifRequest + ObjectDispostifRequest + ModeTrans
                    + VoieTrans + TypeRequest + MotifRequest + SummeryRequest;
            DateRequest = ""; WilayaRequest = ""; NumRequerant = ""; DispositifRequest = ""; ObjectDispostifRequest = "";
            ModeTrans = ""; VoieTrans = ""; TypeRequest = ""; MotifRequest = ""; SummeryRequest = "";
            if(!historique.Equals("")){


                /////////////////////////////////////////////
                //FileUpload FileUpload1 = (FileUpload)FormView1.FindControl("FileUpload1");
                Label FileUpload_ShowRslt = (Label)FormView1.FindControl("Label87");



                string Message_FileUpload = "";
                //use fileuploadstring_del to delete the images uploaded if the one file exists
                List<string[]> fileuploadString_del = new List<string[]>();
                bool Image_Exist = false;
                string Image_Existing = "";
                foreach (string[] img in FileUpload_String)
                {
                    //uploadedFile.SaveAs(Server.MapPath("~/RequestsFiles/" + uploadedFile.FileName));
                    //uploadedFile.SaveAs(tempath + uploadedFile.FileName);
                    // Use Path class to manipulate file and directory paths.
                    string sourcePath = Server.MapPath("~/temp/");
                    string targetPath = Server.MapPath("~/RequestsFiles/");
                    string sourceFile = System.IO.Path.Combine(sourcePath, img[1] + "_" + img[0] + img[2]);
                    string destFile = System.IO.Path.Combine(targetPath, img[1] + "_" + img[0] + img[2]);
                    if (!System.IO.File.Exists(destFile))
                    {
                        if (Image_Exist)
                        {
                            System.IO.File.Delete(sourceFile);
                        }
                        else
                        {
                            System.IO.File.Move(sourceFile, destFile);
                            fileuploadString_del.Add(img);
                        }

                    }
                    else
                    {
                        Image_Existing = Image_Existing + "  '" + img[1] + "'  ";
                        System.IO.File.Delete(sourceFile);
                        foreach (string[] SupImg in fileuploadString_del)
                        {
                            destFile = System.IO.Path.Combine(targetPath, SupImg[1] + "_" + SupImg[0] + SupImg[2]);

                            System.IO.File.Delete(destFile);

                        }
                        fileuploadString_del = new List<string[]>();
                        //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('le fichier "+img[1]+" existe déja');", true);
                        Image_Exist = true;


                    }



                }

                FileUpload_ShowRslt.Text = Message_FileUpload;

                /////////////////////////////////////////
                if (Image_Exist)
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert(' le(s) Image(s) ou l'Image suivantes existent déja" + Image_Existing + "' );", true);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('une ou plusieurs images existent déja');", true);
                }
                else
                {
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    if (requete_controller.updateRequest(reclam, "Modifiée   " + historique, manager.FindByName(Context.User.Identity.Name).Id, FileUpload_String, UpdateAttachments))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Request Modifiée avec succès');", true);
                        //////////////////////////////////////////////
                        FormView1.Visible = true;
                        FormView2.Visible = false;
                        FormView1.ChangeMode(FormViewMode.Insert);
                        FormView1.DataBind();
                        GridView1.EditIndex = -1;
                        dialog.Visible = true;
                        filterRequest();



                    }
                    else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('La modification de la Requête a échoué');", true);

                }
                
                FileUpload_String = new List<string[]>();


                    
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label num_request = (Label)FormView2.FindControl("Label10");
            TextBox resultat_traitement = (TextBox)FormView2.FindControl("resultat_traitement");
            TextBox date_envoi = (TextBox)FormView2.FindControl("TextBoxDateEnvoi");
            TextBox ref_validation = (TextBox)FormView2.FindControl("TextBoxRefEnvoi");
            DropDownList state_Request = (DropDownList)FormView2.FindControl("DropDownList7");
            DropDownList DropDownListDispositionPriseValidation = (DropDownList)FormView2.FindControl("DropDownListDispositionPriseValidation");
            Label NumWilaya_Request = (Label)FormView2.FindControl("Label85");
            Label Year_Request = (Label)FormView2.FindControl("Label86");

            Request reclam = requete_controller.getRequestByNum(Convert.ToInt32(num_request.Text), Convert.ToInt32(NumWilaya_Request.Text), Convert.ToInt32(Year_Request.Text));
            reclam.id_state = Convert.ToInt32(state_Request.SelectedValue);
            reclam.DispositionPriseId = Guid.Parse(DropDownListDispositionPriseValidation.SelectedValue);
            //reclam.date = date.Text;
            //reclam.num_requerant = num_requerant.Text;

            reclam.id_state = Convert.ToInt32(state_Request.SelectedValue);
            reclam.result_traitement = resultat_traitement.Text;
            reclam.Date_Envoi = DateTime.ParseExact(date_envoi.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            reclam.Ref_Validation = ref_validation.Text;


            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                if (requete_controller.updateRequest(reclam, "Validée ", manager.FindByName(Context.User.Identity.Name).Id, null, false))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Votre Request a été Validée avec succès');", true);
                    ///////////////////////////////////////////
                    FormView1.Visible = true;
                    FormView2.Visible = false;
                    FormView1.ChangeMode(FormViewMode.Insert);
                    FormView1.DataBind();
                    GridView1.EditIndex = -1;
                    dialog.Visible = true;
                    filterRequest();
                    ///////////////////////////////////////////
                }
                else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + requete_controller.message_exception + "');", true);
            }
        }

        protected string getObjetDispositifValue1(string MotifId)
        {
            Objet_Disp m = MotifDispositif_Controller.getMotifDispositifByNum(Guid.Parse(MotifId));
            return m.objet;
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
            TextBox DateDu = (TextBox)FormView1.FindControl("TextBox10");
            TextBox DateAu = (TextBox)FormView1.FindControl("TextBox12");
            if (DateDu.Text != "" && DateAu.Text != "")
            {
                DateTime DateTimeDu = DateTime.ParseExact(DateDu.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime DateTimeAu = DateTime.ParseExact(DateAu.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTimeDu > DateTimeAu)
                {
                    DateDu.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('La DateDu est supperieur de la DateAu');", true);
                }
                else
                {
                    filterRequest();
                }
            }
            else filterRequest();
            
            
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            TextBox DateDu = (TextBox)FormView1.FindControl("TextBox10");
            TextBox DateAu = (TextBox)FormView1.FindControl("TextBox12");
            if (DateDu.Text != "" && DateAu.Text != "")
            {
                DateTime DateTimeDu = DateTime.ParseExact(DateDu.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime DateTimeAu = DateTime.ParseExact(DateAu.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTimeDu > DateTimeAu)
                {
                    DateAu.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('La DateDu est supperieur de la DateAu');", true);
                }
                else
                {
                    filterRequest();
                }
            }
            else filterRequest();

            
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList Wilaya = (DropDownList)FormView1.FindControl("DropDownList5");
            //Label WilayaLabel = (Label)FormView1.FindControl("Label31");
            DropDownList DropDownListCommune = (DropDownList)FormView1.FindControl("DropDownListCommune");

            ODSCommune.SelectParameters[0].DefaultValue = Wilaya.SelectedValue;
            DropDownListCommune.DataSource = ODSCommune;
            DropDownListCommune.DataTextField = "NomCommune";
            DropDownListCommune.DataValueField = "CommuneId";
            DropDownListCommune.DataBind();
            filterRequest();
            
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListObjectChanged();
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

        protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }
        
        protected void DropDownList13_SelectedIndexChanged(object sender, EventArgs e)
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

        
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //grid1.EditIndex = e.NewEditIndex;
            fillGrid();
        }

        protected void LinkButton1_Click2(object sender, EventArgs e)
        {
            
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            Session["Id_Request_Relance"] = num_Selected;
            Session["NumWilaya_Request_Relance"] = NumWilaya_Selected;
            Session["Year_Request_Relance"] = Year_Selected;

            Response.Redirect("~/webforms/relance.aspx");
            
            
        }

        protected void Message_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            Session["Id_Request"] = num_Selected;
            Session["NumWilaya_Request"] = NumWilaya_Selected;
            Session["Year_Request"] = Year_Selected;

            Response.Redirect("~/Messaging/FindAgent.aspx");
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        protected int getIdAgentWilaya()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return -1;
                else return wilaya_controller.getWilayaByName(wilaya_claim.First().ClaimValue.ToString()).num;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return 0;
            }

        }

        protected int getAgentWilaya()
        {
            
            List<wilayas> WilayasOfThisStructure = wilaya_controller.GetWilayasOfStructure(Context.User.Identity.Name);
            if (WilayasOfThisStructure != null)
            {
                if (WilayasOfThisStructure.Count == 2) return WilayasOfThisStructure.LastOrDefault().num;
                else return 0;
            }
            else return 0;

            
            ////////////////////////////////////////
            //Structure structure = StructureBLL.getCurrentStructureByUserName(Context.User.Identity.Name);
            //wilayas wil = wilaya_controller.GetWilayaOfStructure(structure);
            //if (wil != null) return wil.num;
            //else return 0;

        }
        //protected Boolean IsWilayaDropDownListEnabled()
        protected Boolean isDGCell()
        {
            Structure structure = StructureBLL.getCurrentStructureByUserName(Context.User.Identity.Name);
            int CountWilayasOfThisStructure = wilaya_controller.GetCountWilayasOfStructure(structure);
            if (CountWilayasOfThisStructure != 0)
            {
                if (CountWilayasOfThisStructure == 1) return false;
                else return true;
            }
            else return false;


            //Structure structure = StructureBLL.getCurrentStructureByUserName(Context.User.Identity.Name);
            //if (structure.StructureParentId == null) return true;
            //else return false;

        }
        

        protected string getAgentStructure()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));


            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return "Cellule DG";
                else return "Agence de la wilaya de "+ wilaya_claim.First().ClaimValue.ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return "";
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
        static int RequestFountSearch = 0;
        protected static string GetRequestFountSearch()
        {
            return RequestFountSearch.ToString();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            FormView1.Visible = true;
            FormView2.Visible = false;
            FormView1.ChangeMode(FormViewMode.Insert);
            
            FormView1.DataBind();
            GridView1.EditIndex = -1;
            dialog.Visible = true;
            filterRequest();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            FormView1.Visible = true;
            FormView2.Visible = false;
            FormView1.ChangeMode(FormViewMode.Insert);
            FormView1.DataBind();
            GridView1.EditIndex = -1;
            dialog.Visible = true;
            filterRequest();
        }




        protected string historique="";
        protected static string DateRequest = "";
        protected static string WilayaRequest = "";
        protected static string NumRequerant = "";
        protected static string DispositifRequest = "";
        protected static string ObjectDispostifRequest = "";
        protected static string ModeTrans = "";
        protected static string VoieTrans = "";
        protected static string TypeRequest = "";
        protected static string MotifRequest = "";
        protected static string ImagesRequest = "";
        protected static string SummeryRequest = "";


        string GetHistorique(){
            this.historique = DateRequest + WilayaRequest + NumRequerant + DispositifRequest + ObjectDispostifRequest + ModeTrans
                + VoieTrans + TypeRequest + MotifRequest + ImagesRequest + SummeryRequest;
                return historique;
        }
        

        protected void TextBox10_TextChanged1(object sender, EventArgs e)
        {
            
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            
            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!DateReception.Text.Equals(r.date))
            {
                DateRequest = "   'la date a été modifiée Du " + r.date + " Au " + DateReception.Text+"' ";

            }

            
        }

        

        protected void NumRequerant_Changed(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            TextBox Num_Requerant = (TextBox)FormView1.FindControl("TextBox11");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!Num_Requerant.Text.Equals(r.num_requerant))
            {
                NumRequerant = "   'le numero du Requerant a été modifié Du " + r.num_requerant + " Au " + Num_Requerant.Text + "' ";
            }

            
        }
        
        

        protected void corp_requeteTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            TextBox body_request = (TextBox)FormView1.FindControl("corp_requeteTextBox");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!body_request.Text.Equals(r.corp_requete))
            {
                SummeryRequest = "   'La description de la Requête a été modifiée De " + r.corp_requete + " Au " + body_request.Text + "' ";
            }


        }

        protected void TransVoie_Changed(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList TransVoie = (DropDownList)FormView1.FindControl("DropDownList15");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!TransVoie.SelectedValue.Equals(r.id_Voie_Trans))
            {
                VoieTrans = "   'la voie de transmission de la Requête a été modifié De " + r.VoieTransC + " Au " + TransVoie.SelectedItem + "' ";
            }

            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///
            
        }

        protected void TypeRequest_Changed(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Type_Requete = (DropDownList)FormView1.FindControl("DropDownList14");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!Type_Requete.SelectedValue.Equals(r.id_type))
            {
                TypeRequest = "   'le type de la Requête a été modifié Du " + r.TypeRequestC + " Au " + Type_Requete.SelectedItem + "' ";
            }


            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///

            
        }

        protected void ModeTrans_Changed(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Mode_Transmission = (DropDownList)FormView1.FindControl("DropDownList6");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!Mode_Transmission.SelectedValue.Equals(r.id_trans))
            {
                ModeTrans = "   'le Mode de transmission de la Requête a été modifié Du " + r.ModeTransmissionC + " Au " + Mode_Transmission.SelectedItem + "' ";
            }


            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///

            
        }

        //protected void ObjetDispo_Changed(object sender, EventArgs e)
        //{
        //    TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
        //    DropDownList object_request = (DropDownList)FormView1.FindControl("DropDownList9");

        //    TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
        //    DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
        //    int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

        //    Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
        //    if (!object_request.SelectedValue.Equals(r.id_objet))
        //    {
        //        ObjectDispostifRequest = "   'l'Objet du Dispsitif a été modifié Du " + r.MotifDispositifC + " Au " + object_request.SelectedItem + "' ";
        //    }


        //    ///
        //    FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
        //    ///

        //}

        protected void Wilaya_Changed(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Wilaya_Requete = (DropDownList)FormView1.FindControl("DropDownList5");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            if (!Wilaya_Requete.SelectedValue.Equals(r.num_wilaya))
            {
                WilayaRequest = "   'la wilaya de la Requête a été modifié De " + r.WilayaC + " Au " + Wilaya_Requete.SelectedItem + "' ";
            }
            ///
            FillPanelImagesModify(num_requete.Text, Wilaya_Requete.SelectedValue.ToString(), Year_Request.ToString());
            ///

            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(Master.Page, Master.GetType(), "alert", "ShowPopup();", true);
        }

        protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Photos_GridViewRow = -1;
            filterRequest();
            
        }


        protected string GetNumRequest(int num, int Year, int NumWilaya)
        {
            return num + Year + NumWilaya.ToString();
        }
        
        static int Photos_GridViewRow = -1;
        protected void LinkButtonClick_ShowAttachments(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            if (Photos_GridViewRow!=-1)
            {
                Panel Panel_RowBefore_Empty = ((Panel)GridView1.Rows[Photos_GridViewRow].FindControl("Panel1"));
                Panel_RowBefore_Empty.Controls.Clear();
            }
            Photos_GridViewRow = indexRowSelected;
            Panel Panel1 = ((Panel)GridView1.Rows[indexRowSelected].FindControl("Panel1"));
            
            List<Link> links = requete_controller.getRequestAttachments(Convert.ToInt32(num_Selected), Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected));
            foreach (Link link in links)
            {
                ImageButton imageButton = new ImageButton();
                FileInfo fileInfo = new FileInfo(link.Guid);
                imageButton.ID = link.Link1;
                imageButton.ImageUrl = "~/RequestsFiles/" + link.Link1 + "_" +link.Guid + link.extension;
                imageButton.Width = Unit.Pixel(25);
                imageButton.Height = Unit.Pixel(25);
                imageButton.Style.Add("padding", "5px");
                imageButton.Click += new ImageClickEventHandler(Image_Click);
                string id=imageButton.ID;
                Panel1.Controls.Add(imageButton);
                
            }
        }
        protected void Image_Click(object sender, ImageClickEventArgs e)
        {
            
            Image1.ImageUrl = ((ImageButton)sender).ImageUrl;
            Image1.Width = Unit.Pixel(600);
            Image1.Height = Unit.Pixel(600);
            Image1.DataBind();
            Label17.Text = ((ImageButton)sender).ID.ToString();
            UpdatePanel2.Update();
            //myModal_Images.Attributes["style"] = "height:200px";
            
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "ShowImage();", true);
            //Response.Redirect(((ImageButton)sender).ImageUrl);
        }
        
        protected void LinkButtonAttachment_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            Session["Id_Request"] = num_Selected;
            Session["NumWilaya_Request"] = NumWilaya_Selected;
            Session["Year_Request"] = Year_Selected;

            Photos_GridViewRow = -1;

            Response.Redirect("~/webforms/TestAlbumPhotos.aspx");
            
        }




        protected string GetCountAttachment(int num_requete, int NumWilaya_Request, int Year_Request)
        {
            int count=requete_controller.GetCountAttachmentRequest(num_requete, NumWilaya_Request,Year_Request);
            
            //if (count == 1) return count + " Pièce jointe";
            //return count + " Pièces Jointes";
            if (count == 1) return count + "";
            return count + "";
        }

        protected string[] GetIdRequest(string IdRequest)
        {
            string [] RequestTab=new string[3];
            string id="";
            int i=0;
            foreach(char a in IdRequest)
            {
                if (a.Equals('-')) 
                {
                    RequestTab[i] = id;
                    i++;
                    id = "";
                }
                    
                else id = id + a;
            }
            RequestTab[2] = id;
            return RequestTab;
        }

        protected void Select_Detail(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            Session["Id_Request_Detail"] = num_Selected;
            Session["NumWilaya_Request_Detail"] = NumWilaya_Selected;
            Session["Year_Request_Detail"] = Year_Selected;
            LabelRefRequest_Details.Text = NumWilaya_Selected +"-" + Year_Selected +"-" + num_Selected;
            ////////////////////////////////
            gridViewRow.ForeColor = Color.DarkBlue;
            //gridViewRow.BackColor = Color.DimGray;
            /////////////////////////////////
            DetailsViewRequest.DataBind();
            UpdatePanelDetailRequest.Update();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "ShowDetails();", true);

        }




        protected string ReturnColorRowGridView()
        {

            return "";
        }


        

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            
            foreach (GridViewRow row in GridView1.Rows)
            {
                

                int indexRowSelected = row.RowIndex;

                string StateRequest = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label9")).Text;

                


                if (StateRequest.Equals("En Cours de Traitement"))
                {
                    row.BackColor = Color.White;
                }
                else
                {
                    if (StateRequest.Equals("Réglée"))
                    {
                        row.BackColor = Color.Khaki;
                    }
                    else
                    {
                        if (StateRequest.Equals("Non Fondée"))
                        {
                            row.BackColor = Color.DarkGray;
                        }
                    }
                }
            }

        }

        protected void DropDownList9_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Objet_recl = (DropDownList)FormView1.FindControl("DropDownList9");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            Objet_Disp objet = MotifDispositif_Controller.getObjectByMotif(r.MotifId.Value);
            if (!Objet_recl.SelectedValue.Equals(objet.id_objet))
            {
                ModeTrans = "  ' L'objet de la Requête a été modifié Du " + objet.objet+ " Au " + Objet_recl.SelectedItem + " ' ";
            }

            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///
            DropDownListObjectModifChanged();

        }

        protected Panel Panel_FileUpload ;
        protected static List<string[]> FileUpload_String = new List<string[]>();

        protected void Button_DisplayImg_Click(object sender, EventArgs e)
        {
            if (FileUpload_String != null)
            {
                foreach (string[] img in FileUpload_String)
                {
                    string sourcePath = Server.MapPath("~/temp/");
                    
                    string sourceFile = System.IO.Path.Combine(sourcePath, img[1] + "_" + img[0] + img[2]);
                    //if (!System.IO.File.Exists(sourceFile))
                    //{
                        System.IO.File.Delete(sourceFile);
                    //}
                }
            }
            FileUpload FileUpload1 = (FileUpload)FormView1.FindControl("FileUpload1");
            
            Label FileUpload_ShowRslt = (Label)FormView1.FindControl("Label87");

            Panel_FileUpload = (Panel)FormView1.FindControl("Panel2");
            if (FileUpload1.HasFiles)
            {
                string Message_FileUpload = "";
                FileUpload_String = new List<string[]>();
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                    string ext = System.IO.Path.GetExtension(uploadedFile.FileName);
                    if (ext.Equals(".png") || ext.Equals(".jpg"))
                    {
                        string tempath = "~/temp/";
                        //uploadedFile.SaveAs(Server.MapPath("~/RequestsFiles/" + uploadedFile.FileName));
                        Guid ImageGuid = Guid.NewGuid();
                        uploadedFile.SaveAs(Server.MapPath(tempath + uploadedFile.FileName + "_" + ImageGuid.ToString() + ext));

                        Message_FileUpload = Message_FileUpload + " '" + uploadedFile.FileName + " Chargé' ";

                        ///////////////////////////////////////////////////////////////////////////////

                        System.Web.UI.WebControls.Image imageButton = new System.Web.UI.WebControls.Image();
                        string link = uploadedFile.FileName;

                        FileInfo fileInfo = new FileInfo(link);
                        imageButton.ID = link;
                        //imageButton.ImageUrl = tempath + link;
                        string path = tempath + uploadedFile.FileName + "_" + ImageGuid.ToString() + ext;
                        imageButton.ImageUrl = path;

                        imageButton.Width = Unit.Pixel(100);
                        imageButton.Height = Unit.Pixel(100);
                        imageButton.Style.Add("padding", "5px");

                        string id = imageButton.ID;
                        Panel_FileUpload.Controls.Add(imageButton);

                        //////////////////////////////////////////////////////////////////////////////
                        string[] IdANDName = new string[3];
                        IdANDName[0] = ImageGuid.ToString();
                        IdANDName[1] = uploadedFile.FileName.ToString();
                        IdANDName[2] = ext;
                        FileUpload_String.Add(IdANDName);
                    }
                    else
                    {
                        Message_FileUpload = Message_FileUpload + " '" + uploadedFile.FileName + " n'a pas d'extension .PNG ou .JPG' ";
                    }

                }
                UpdateAttachments = true;
                FileUpload_ShowRslt.Text = Message_FileUpload;

                WilayaRequest = "   'Les Pièces Jointes de la Requête ont été modifiées' ";

            }
            else FileUpload_ShowRslt.Text = "there is no files";
        }

        protected bool IsDeletable(string NumWilaya, string Year, string IdRequest)
        {

            return requete_controller.IsDeletable(NumWilaya, Year, IdRequest, Context.User.Identity.Name + "/" + getAgentStructure());
        }
        protected bool IsUpdatable(string NumWilaya, string Year, string IdRequest)
        {

            //return requete_controller.IsUpdatable(NumWilaya, Year, IdRequest, Context.User.Identity.Name + "/" + getAgentStructure());
            return requete_controller.IsUpdatable(NumWilaya, Year, IdRequest);
        }
        protected void LinkButtonDel_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string NumWilaya_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string Year_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label81")).Text;
            string num_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label82")).Text;
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                if (requete_controller.deleteRequest(Convert.ToInt32(NumWilaya_Selected), Convert.ToInt32(Year_Selected), Convert.ToInt32(num_Selected)))
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Requête supprimée avec succès');", true);
                    filterRequest();
                    //////////////////////////////////////////////
                }
                else ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('La supression de la Requête a échoué');", true);
            }
        }

        protected void DropDownListCommune_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownListPhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownListPhaseChanged();
            DropDownListObjectChanged();
        }
        protected void DropDownListPhaseChanged()
        {
            DropDownList Phase = (DropDownList)FormView1.FindControl("DropDownListPhase");
            DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            if (Phase.Text.Equals(" "))
            {
                OdsMotifDispositif.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsMotifDispositif.SelectParameters[0].DefaultValue = Phase.SelectedValue;
            }


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
        protected void DropDownListPhaseModifChanged()
        {
            DropDownList Phase = (DropDownList)FormView1.FindControl("DropDownListPhase");
            DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            if (Phase.Text.Equals(" "))
            {
                OdsMotifDispositif.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsMotifDispositif.SelectParameters[0].DefaultValue = Phase.SelectedValue;
            }


            motifDispositif.DataSourceID = null;
            motifDispositif.DataSource = OdsMotifDispositif;
            motifDispositif.DataTextField = "objet";
            motifDispositif.DataValueField = "id_objet";

            motifDispositif.DataBind();

            //Session["Numdispositif"] = ((DropDownList)FormView1.FindControl("DropDownList8")).SelectedValue;
            //DropDownList motifDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            //motifDispositif.DataBind();

            

        }
        protected void DropDownListObjectChanged()
        {
            DropDownList DropDownListObjectDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            DropDownList DropDownListMotif = (DropDownList)FormView1.FindControl("DropDownListMotif");
            if (DropDownListObjectDispositif.Text.Equals("00000000-0000-0000-0000-000000000000"))
            {
                OdsMotifOfObject.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsMotifOfObject.SelectParameters[0].DefaultValue = DropDownListObjectDispositif.SelectedValue;
            }


            DropDownListMotif.DataSourceID = null;
            DropDownListMotif.DataSource = OdsMotifOfObject;
            DropDownListMotif.DataTextField = "MotifName";
            DropDownListMotif.DataValueField = "MotifId";

            DropDownListMotif.DataBind();



            ///////////////////////////////////////

            DropDownList DropDownListDispositionPrise = (DropDownList)FormView1.FindControl("DropDownListDispositionPrise");
            DropDownList DropDownListObjectDisp = (DropDownList)FormView1.FindControl("DropDownList9");
            if (DropDownListObjectDisp.Text.Equals("00000000-0000-0000-0000-000000000000"))
            {
                OdsDispositionPrise.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsDispositionPrise.SelectParameters[0].DefaultValue = DropDownListObjectDisp.SelectedValue;
            }


            DropDownListDispositionPrise.DataSourceID = null;
            DropDownListDispositionPrise.DataSource = OdsDispositionPrise;
            DropDownListDispositionPrise.DataTextField = "DispositionName";
            DropDownListDispositionPrise.DataValueField = "DispositionPriseId";

            DropDownListDispositionPrise.DataBind();
            ////////////////////////////////////////


            filterRequest();
        }
        protected void DropDownListObjectModifChanged()
        {
            DropDownList DropDownListObjectDispositif = (DropDownList)FormView1.FindControl("DropDownList9");
            DropDownList DropDownListMotif = (DropDownList)FormView1.FindControl("DropDownListMotif");
            if (DropDownListObjectDispositif.Text.Equals("00000000-0000-0000-0000-000000000000"))
            {
                OdsMotifOfObject.SelectParameters[0].DefaultValue = null;
            }
            else
            {
                OdsMotifOfObject.SelectParameters[0].DefaultValue = DropDownListObjectDispositif.SelectedValue;
            }


            DropDownListMotif.DataSourceID = null;
            DropDownListMotif.DataSource = OdsMotifOfObject;
            DropDownListMotif.DataTextField = "MotifName";
            DropDownListMotif.DataValueField = "MotifId";

            DropDownListMotif.DataBind();



            
        }

        protected void DropDownListMotif_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownListDispositionPrise_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void DropDownListMotif_SelectedIndexChanged1(object sender, EventArgs e)
        {
            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            DropDownList Motif_recl = (DropDownList)FormView1.FindControl("DropDownListMotif");

            TextBox DateReception = (TextBox)FormView1.FindControl("TextBox10");
            DropDownList NumWilaya_Request = (DropDownList)FormView1.FindControl("DropDownList5");
            int Year_Request = DateTime.ParseExact(DateReception.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;

            Request r = requete_controller.getRequestByNum(Convert.ToInt32(num_requete.Text), Convert.ToInt32(NumWilaya_Request.Text), Year_Request);
            
            if (!Motif_recl.SelectedValue.Equals(r.MotifId.Value))
            {
                ModeTrans = "  ' Le Motif de la Requête a été modifié Du " + r.MotifC + " Au " + Motif_recl.SelectedItem + " ' ";
            }

            ///
            FillPanelImagesModify(num_requete.Text, NumWilaya_Request.SelectedValue.ToString(), Year_Request.ToString());
            ///

        }


    }
}