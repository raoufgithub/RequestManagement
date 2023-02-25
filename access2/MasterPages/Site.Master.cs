using controller;
using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;




using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

using System.Configuration;
using System.Security.Claims;
using System.Web.UI.HtmlControls;
using System.IO;


namespace view.MasterPages
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public void RegisterTrigger(Control ct)
        {
            ScriptManager1.RegisterPostBackControl(ct);
        }


        static List<requerant> datasource = new List<requerant>();
        static List<Request> datasource1 = new List<Request>();
        static int menu_show = 0;


        protected void Page_Load(object sender, EventArgs e)
        {



            //////////////////////////////////

            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/loginPopup.aspx");
            }
            GetNewRequests();
            GetNewMessages();
            GetNewRequestMessages();
            GetUrlImageProfil();

            //if(!isDGCell())
            //{
            //    datasource = requerant_controller.getFilteredRequerant(linq);
            //    //RqFound.Text = datasource.Count.ToString() + " Requerants";
            //    grid1.DataSourceID = null;
            //    grid1.DataSource = datasource;
            //    grid1.DataBind();
                
            //}
            
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);




            //Session["claims"] = manager.FindByName(Context.User.Identity.Name);

            //manager.GetClaims(user.Id);
            string dashboard_var = user.Claims.Where(cl => cl.ClaimType.Equals("Dashboard")).First().ClaimValue;
            string referentials_var = user.Claims.Where(cl => cl.ClaimType.Equals("referentials")).First().ClaimValue;
            string Role_Management_var = user.Claims.Where(cl => cl.ClaimType.Equals("Role_Management")).First().ClaimValue;
            string Request_Management_var = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management")).First().ClaimValue;
            string Statistics_var = user.Claims.Where(cl => cl.ClaimType.Equals("Statistics")).First().ClaimValue;



            Dashboard.Visible = Convert.ToBoolean(dashboard_var);
            referentials.Visible = Convert.ToBoolean(referentials_var);
            Role_Management.Visible = Convert.ToBoolean(Role_Management_var);
            Request_Management.Visible = Convert.ToBoolean(Request_Management_var);
            Statistics.Visible = Convert.ToBoolean(Statistics_var);
            //}
            //else
            //{
            //    Response.Redirect("~/Account/loginPopupSite.aspx");
            //}

            /////////////////////////////////////



            //ScriptManager.RegisterStartupScript(this,this.GetType(), "alert", "ShowPopup();", true);


            //if (Panel_Base.Visible && Div1.Visible && Panel_Gestion.Visible && Panel_TableauBord.Visible)
            //{
            //    Panel_Base.Visible = false;
            //    Div1.Visible = false;
            //    Panel_Gestion.Visible = false;
            //    Panel_TableauBord.Visible = false;

            //}
            if (menu_show == 0)
            {
                Panel_Base.Visible = false;
                Div1.Visible = false;
                Panel_Gestion.Visible = false;
                Panel_TableauBord.Visible = false;
                Panel_Messaging.Visible = false;

            }
            else
            {
                if (menu_show == 1)
                {
                    Panel_Base.Visible = true;
                    Div1.Visible = false;
                    Panel_Gestion.Visible = false;
                    Panel_TableauBord.Visible = false;
                    Panel_Messaging.Visible = false;
                }
                else
                {
                    if (menu_show == 2)
                    {
                        Panel_Base.Visible = false;
                        Div1.Visible = true;
                        Panel_Gestion.Visible = false;
                        Panel_TableauBord.Visible = false;
                        Panel_Messaging.Visible = false;
                    }
                    else
                    {
                        if (menu_show == 3)
                        {
                            Panel_Base.Visible = false;
                            Div1.Visible = false;
                            Panel_Gestion.Visible = true;
                            Panel_TableauBord.Visible = false;
                            Panel_Messaging.Visible = false;
                        }
                        else
                        {
                            if (menu_show == 4)
                            {
                                Panel_Base.Visible = false;
                                Div1.Visible = false;
                                Panel_Gestion.Visible = false;
                                Panel_TableauBord.Visible = true;
                                Panel_Messaging.Visible = false;
                            }
                            else
                            {
                                Panel_Base.Visible = false;
                                Div1.Visible = false;
                                Panel_Gestion.Visible = false;
                                Panel_TableauBord.Visible = false;
                                Panel_Messaging.Visible = true;
                            }
                        }

                    }

                }

            }
            if (Div1.Visible) Div1.Visible = true;


            if (!Context.User.Identity.IsAuthenticated)
            {
                //Decon.Visible = false;
                //changeuser.Visible = false;
                //utilisateur.Visible = false;
                ////Response.Redirect("~/Account/login.aspx");
            }
            else
            {
                //Decon.Visible = true;
                //changeuser.Visible = true;
                //utilisateur.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!Panel_Base.Visible)
            {
                menu_show = 1;
                Panel_Base.Visible = true;
                Div1.Visible = false;
                Panel_Gestion.Visible = false;
                Panel_TableauBord.Visible = false;
                Panel_Messaging.Visible = false;
            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel_Base.Visible = false;
            Div1.Visible = true;
            Panel_Gestion.Visible = false;
            Panel_TableauBord.Visible = false;
            Panel_Messaging.Visible = false;
            menu_show = 2;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Panel_Base.Visible = false;
            Div1.Visible = false;
            Panel_Gestion.Visible = true;
            Panel_TableauBord.Visible = false;
            Panel_Messaging.Visible = false;
            menu_show = 3;

        }

        protected void Décon_Click(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            Context.GetOwinContext().Authentication.SignOut();
            if (Context.GetOwinContext().Authentication.User.Identity.IsAuthenticated)
            //if (Context.User.Identity.IsAuthenticated)
            {
                //Decon.Visible = false;
                Response.Redirect("~/Account/loginPopup.aspx");
            }

        }
        protected void LinkButtonProfile_Click(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            Session["User"] = Context.User.Identity.Name;
            Response.Redirect("~/Account/ProfileAgent.aspx");


        }

        protected void LinkButtonPassword_Click(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            Session["User"] = Context.User.Identity.Name;
            Response.Redirect("~/Account/PasswordChange.aspx");
        }


        protected void Décon0_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ChangePassword.aspx");
        }

        protected void LinkButton35_Click(object sender, EventArgs e)
        {
            Panel_Base.Visible = false;
            Div1.Visible = false;
            Panel_Gestion.Visible = false;
            Panel_TableauBord.Visible = true;
            Panel_Messaging.Visible = false;
            menu_show = 4;
        }

        protected void LinkButtonMessaging_Click(object sender, EventArgs e)
        {
            Panel_Base.Visible = false;
            Div1.Visible = false;
            Panel_Gestion.Visible = false;
            Panel_TableauBord.Visible = false;
            Panel_Messaging.Visible = true;
            menu_show = 5;
        }

        protected void LinkButtonPaie_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click1(object sender, EventArgs e)
        {

        }


        public void menuManager()
        {

            Panel_Base.Visible = false;
            Div1.Visible = true;
            Panel_Gestion.Visible = false;
            Panel_TableauBord.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Session["variable"] = Context.User.Identity.Name;
            Response.Redirect("~/Authentication/Test.aspx");
        }




        protected void LinkButton25_Click11(object sender, EventArgs e)
        {
            ContentPlaceHolder mpContentPlaceHolder = new ContentPlaceHolder();
            FormView formm1;
            TextBox mpTextBox;
            TextBox mpTextBoxNamePrenom;
            Label request_number;
            mpContentPlaceHolder =
              (ContentPlaceHolder)Page.Master.FindControl("MainContent");

            if (mpContentPlaceHolder != null)
            {
                request_number = (Label)mpContentPlaceHolder.FindControl("RqFound");
                formm1 =
                    (FormView)mpContentPlaceHolder.FindControl("FormView1");
                GridView GridView1 = (GridView)mpContentPlaceHolder.FindControl("GridView1");
                if (formm1 != null)
                {
                    if (grid1.SelectedValue != null)
                    {
                        
                        mpTextBox = (TextBox)formm1.FindControl("TextBox11");
                        
                        mpTextBox.Text = grid1.SelectedValue.ToString();
                        
                        mpTextBoxNamePrenom = (TextBox)formm1.FindControl("TextBox59");
                        requerant req = requerant_controller.getRequerantByNum(mpTextBox.Text);
                        mpTextBoxNamePrenom.Text = req.nom_requerant +"  " + req.prenom_requerant;
                        
                        if (GridView1 != null && formm1.CurrentMode== FormViewMode.Insert)
                        {

                            filterRequest(formm1, GridView1);
                            request_number.Text = datasource1.Count.ToString() + " Requêtes";
                            if (GridView1.Rows.Count > 0)
                            {
                                GridView1.SelectedIndex = 0;
                                GridViewRow g = GridView1.SelectedRow;
                                g.ForeColor = System.Drawing.Color.DarkBlue;
                            }
                        }
                        

                    }
                }
            }
            //datasource = requerant_controller.getAllRequerant();
            ////RqFound.Text = datasource.Count.ToString() + " Requerants";
            //grid1.DataSourceID = null;
            //grid1.DataSource = datasource;
            //grid1.DataBind();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///// <summary>
        ///// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// </Request with where et and>
        protected void LinkButton222_Click(object sender, EventArgs e)
        {
            //grid1.EditIndex = e.NewEditIndex;
            fillGrid();
        }

        bool linq1_updated = true;

        public void filterRequest(FormView FormView1, GridView GridView1)
        {

            TextBox num_requete = (TextBox)FormView1.FindControl("numTextBox");
            TextBox dateDu = (TextBox)FormView1.FindControl("TextBox10");
            TextBox dateAu = (TextBox)FormView1.FindControl("TextBox12");
            DropDownList wilaya = (DropDownList)FormView1.FindControl("DropDownList5");
            DropDownList commune = (DropDownList)FormView1.FindControl("DropDownListCommune");

            TextBox requerant = (TextBox)FormView1.FindControl("TextBox11");
            DropDownList dispositif = (DropDownList)FormView1.FindControl("DropDownList8");
            DropDownList motif_dispo = (DropDownList)FormView1.FindControl("DropDownList9");
            DropDownList etat_requete = (DropDownList)FormView1.FindControl("DropDownList7");
            DropDownList mode_trans = (DropDownList)FormView1.FindControl("DropDownList6");

            DropDownList request_type = (DropDownList)FormView1.FindControl("DropDownList12");
            DropDownList request_voie = (DropDownList)FormView1.FindControl("DropDownList13");


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from Request req.Request ";
            string linq = "select * from Request reclam join Objet_Disp mot on(mot.id_objet=reclam.id_objet) ";
            string where = " where(";
            string and = " and ";
            string linq1 =
                 getDateDu(dateDu, "date") + getDateAu(dateAu, "date")
                + getSubStringLinqDropDownList0(wilaya, "num_wilaya") + getSubStringLinqDropDownList0(commune, "CommuneId") + getSubStringLinqTextBox(requerant, "num_requerant") + getSubStringLinqDropDownList_Dispo(dispositif, "num_mission")
                + getSubStringLinqDropDownList(motif_dispo, "id_objet") + getSubStringLinqDropDownList0(etat_requete, "id_state") + getSubStringLinqDropDownList(mode_trans, "id_trans")
                + getSubStringLinqDropDownList(request_type, "id_type") + getSubStringLinqDropDownList(request_voie, "id_Voie_Trans") + ")";

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
            datasource1 = controller.requete_controller.getFilteredRequest(linq);
            GridView1.DataSourceID = null;
            GridView1.DataSource = datasource1;
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
            string aaa = a.ID.ToString();
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                return "reclam." + field + " = '" + a.Text+"'";

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
                        return " and reclam." + field + " = '" + a.Text+"'";
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
        protected string getSubStringLinqDropDownList0(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linq1_updated)
            {
                linq1_updated = false;
                return "reclam." + field + "= '" + b.Text + "'";
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
                        return " and reclam." + field + "= '" + b.Text + "'";
                    }

                }
            }
            return "";
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //if (IsValid)
            //{
            TextBox login = (TextBox)Login1.FindControl("userName");
            TextBox Password = (TextBox)Login1.FindControl("Password");
            CheckBox RememberMe = (CheckBox)Login1.FindControl("RememberMe");
            Literal FailureText = (Literal)Login1.FindControl("FailureText");



            // Validate the user password
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // This doen't count login failures towards account lockout
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = signinManager.PasswordSignIn(login.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    break;
                case SignInStatus.LockedOut:
                    Response.Redirect("/Account/Lockout");
                    break;
                case SignInStatus.RequiresVerification:
                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                    Request.QueryString["ReturnUrl"],
                                                    RememberMe.Checked),
                                      true);
                    break;
                case SignInStatus.Failure:
                default:
                    FailureText.Text = "Invalid login attempt";
                    //ErrorMessage.Visible = true;
                    break;

            }




            //}
        }

        protected void GetNewRequests()
        {
            int RequestNumber;
            List<Request> Requests;
            if (GetIDWilayaAgent() == -1)
            {
                RequestNumber = requete_controller.getCountRequestTraiting();
                Requests = requete_controller.getAllTreatingRequest();
            }
            else
            {
                RequestNumber = requete_controller.getCountRequestTraitingWilaya(GetIDWilayaAgent());
                Requests = requete_controller.getAllTreatingRequestByIDWilaya(GetIDWilayaAgent());
            }
            Button Button_NewRequest = (Button)LoginView1.FindControl("Button_NewRequest");
            Button_NewRequest.Text = RequestNumber + " Requêtes";
            HtmlGenericControl Ul_NewRequest = (HtmlGenericControl)LoginView1.FindControl("Ul_NewRequest");

            try
            {


                foreach (Request r in Requests)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    //HtmlGenericControl anchor = new HtmlGenericControl("a");
                    //anchor.Attributes.Add("href", "page.htm");
                    //string substr_Corp;
                    //if (r.corp_requete.ToString().Length > 100) substr_Corp = r.corp_requete.ToString().Substring(0,100);
                    //else substr_Corp = r.corp_requete.ToString();
                    //anchor.InnerText = "Requête " + substr_Corp + " du promoteur '" + r.NomRequerantC + "  " + r.PrenomRequerantC+"'";
                    //li.Controls.Add(anchor);


                    LinkButton buttonlink = new LinkButton();
                    string substr_Corp;
                    if (r.corp_requete.ToString().Length > 50) substr_Corp = r.corp_requete.ToString().Substring(0, 50) + " ...";
                    else substr_Corp = r.corp_requete.ToString();
                    buttonlink.Text = "Requête " + substr_Corp + " du promoteur '" + r.NomRequerantC + "  " + r.PrenomRequerantC + "'";
                    buttonlink.ID = r.num_wilaya + "-" + r.Year + "-" + r.num;
                    buttonlink.Click += new EventHandler(LinkButtonRequests_Event);

                    li.Controls.Add(buttonlink);
                    Ul_NewRequest.Controls.Add(li);
                }

            }
            catch
            {

            }
        }


        protected void GetNewMessages()
        {

            int MessageNumber;

            MessageNumber = Messaging_Controller.getMessages_NotYetReadCount(GetIdUser());

            Button Button_NewMessage = (Button)LoginView1.FindControl("Button_NewMessage");



            Button_NewMessage.Text = MessageNumber + " Messages";
            HtmlGenericControl Ul_NewMessage = (HtmlGenericControl)LoginView1.FindControl("Ul_NewMessage");

            List<BAL_User> Messages = Messaging_Controller.getMessages_NotYetRead(GetIdUser());
            try
            {

                foreach (BAL_User m in Messages)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    //HtmlGenericControl anchor = new HtmlGenericControl("a");
                    //anchor.Attributes.Add("href", "page.htm");
                    //string substr_Message;
                    //if (m.Message.ToString().Length > 50) substr_Message = m.Message.ToString().Substring(0, 50);
                    //else substr_Message = m.Message.ToString();
                    //anchor.InnerText = "Message " + substr_Message + " reçu du '" + m.UserNameSendingC + "'";
                    //li.Controls.Add(anchor);

                    LinkButton buttonlink = new LinkButton();
                    buttonlink.ID = m.Id_Message;
                    buttonlink.Click += new EventHandler(LinkButtonMessages_Event);
                    string substr_Message;
                    if (m.Message.ToString().Length > 50) substr_Message = m.Message.ToString().Substring(0, 50) + " ...";
                    else substr_Message = m.Message.ToString();
                    buttonlink.Text = "Message " + substr_Message + " reçu du '" + m.UserNameSendingC + "'";
                    li.Controls.Add(buttonlink);
                    Ul_NewMessage.Controls.Add(li);
                }
            }
            catch
            {

            }
        }
        protected void GetNewRequestMessages()
        {

            int MessageNumber;

            MessageNumber = MessageRequestBLL.getMessages_NotYetReadCount(GetIdUser());

            Button Button_NewRequestMessage = (Button)LoginView1.FindControl("Button_RequestMessage");



            Button_NewRequestMessage.Text = MessageNumber + " Messages";
            HtmlGenericControl Ul_NewMessage = (HtmlGenericControl)LoginView1.FindControl("Ul_RequestMessage");

            List<Message_Request> Messages = MessageRequestBLL.getMessages_NotYetRead(GetIdUser());
            try
            {

                foreach (Message_Request m in Messages)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    //HtmlGenericControl anchor = new HtmlGenericControl("a");
                    //anchor.Attributes.Add("href", "page.htm");
                    //string substr_Message;
                    //if (m.Message.ToString().Length > 50) substr_Message = m.Message.ToString().Substring(0, 50);
                    //else substr_Message = m.Message.ToString();
                    //anchor.InnerText = "Message " + substr_Message + " reçu du '" + m.UserNameSendingC + "'";
                    //li.Controls.Add(anchor);

                    LinkButton buttonlink = new LinkButton();
                    buttonlink.ID = m.MessageId;
                    buttonlink.Click += new EventHandler(LinkButtonRequestMessages_Event);
                    string substr_Message;
                    if (m.Message.ToString().Length > 50) substr_Message = m.Message.ToString().Substring(0, 50) + " ...";
                    else substr_Message = m.Message.ToString();
                    buttonlink.Text = "Message " + substr_Message + " reçu du '" + m.UserNameSendingC + "'";
                    li.Controls.Add(buttonlink);


                    Ul_NewMessage.Controls.Add(li);
                }
            }
            catch
            {

            }
        }




        //public GridView GridViewRelance
        //{
        //    get
        //    {
        //        return this.GridRelance;
        //    }
        //}

        //public ObjectDataSource Ods_Relance
        //{
        //    get
        //    {
        //        return this.OdsRelance;
        //    }
        //}

        //public UpdatePanel UpdatePanelGridRelance
        //{
        //    get
        //    {
        //        return this.UpdatePanelGrid;
        //    }
        //}
        ////public Label LabelTest
        ////{
        ////    get
        ////    {
        ////        return this.Label4;
        ////    }
        ////}
        protected void LinkButton17_Click(object sender, EventArgs e)
        {
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "ShowPopup();", true);
            //GridRelance.DataBind();

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }


        //protected string GetStructure()
        //{
        //    AspNetUsers user = Users_Controller.getUserByUserName(Context.User.Identity.Name);
        //    try
        //    {
        //        if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return "La Cellule Centrale    ";
        //        else return "Agence de la Wilaya : " + wilaya_claim.First().ClaimValue.ToString() + "    ";
        //    }
        //    catch
        //    {

        //        return "";
        //    }
        //}



        protected string GetStructure()
        {
            
            

            return StructureBLL.getCurrentStructureByUserName(Context.User.Identity.Name).IntituleFr;
        
        }
        int id_wilaya = 0;
        protected int GetIDWilayaAgent()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));

            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG"))
                {
                    id_wilaya = -1;
                    return -1;
                }
                else
                {
                    id_wilaya = wilaya_controller.getWilayaByName(wilaya_claim.First().ClaimValue.ToString()).num;
                    return wilaya_controller.getWilayaByName(wilaya_claim.First().ClaimValue.ToString()).num;
                }
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return 0;
            }
        }

        protected void MessagesNotRead_Changed(object sender, EventArgs e)
        {


        }


        protected string GetIdUser()
        {
            return Context.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByName(Context.User.Identity.Name).Id;


        }

        protected void LinkButtonMessages_Event(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).ID.ToString();
            BAL_User message = Messaging_Controller.GetMessageByIDMessage(id);

            string UserName_selected = message.UserNameSendingC;
            Session["UserName_Agent"] = UserName_selected;
            message.State_Message = "Lu";
            Messaging_Controller.updateMessage(message);
            Response.Redirect("~/Messaging/SendMessage.aspx");


        }

        protected void LinkButtonRequestMessages_Event(object sender, EventArgs e)
        {
            string id = ((LinkButton)sender).ID.ToString();
            Message_Request MessageRequest = MessageRequestBLL.GetMessageByIDMessage(id);
            Session["Id_Request"] = MessageRequest.NumRequest;
            Session["NumWilaya_Request"] = MessageRequest.num_wilayaRequest;
            Session["Year_Request"] = MessageRequest.YearRequest;
            AspNetUsers us = Users_Controller.getUserByID(MessageRequest.id_user);
            string UserName_selected = us.UserName;
            Session["UserName_Agent"] = UserName_selected;
            MessageRequest.State_Message = "Lu";
            MessageRequestBLL.updateMessage(MessageRequest);
            Response.Redirect("~/Messaging/MessageRequest.aspx");
        }
        protected void LinkButtonRequests_Event(object sender, EventArgs e)
        {
            string IdRequest = ((LinkButton)sender).ID.ToString();
            Session["Request_Treating"] = "0" + IdRequest;
            Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
        }

        protected void GetUrlImageProfil()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //ImageButton Image_Profile = (ImageButton)LoginView1.FindControl("Image_Profile");
            Image Image_Profile = (Image)LoginView1.FindControl("Image_Profile");
            var User = manager.FindByName(Context.User.Identity.Name);
            var ProfilePhoto_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Profile_Photo"));
            if (ProfilePhoto_claim.Count() == 0)
            {
                FileInfo fileInfo = new FileInfo("Profil-Photo.jpg");
                Image_Profile.ImageUrl = "~/Profil-Photo.jpg";
            }
            else
            {
                FileInfo fileInfo = new FileInfo(ProfilePhoto_claim.First().ClaimValue.ToString());
                Image_Profile.ImageUrl = "~/Files/" + User.UserName + "/profile/" + ProfilePhoto_claim.First().ClaimValue.ToString();
            }
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ///Filter of the requerant
        ///


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //datasource = null;
            //datasource = requerant_controller.getAllRequerant();
            //grid1.DataBind();
            grid1.PageIndex = e.NewPageIndex;
            grid1.DataBind();
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

            string num_selected = ((Label)grid1.Rows[e.RowIndex].FindControl("Label1")).Text;

            r.deleteRequerant(num_selected);
            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();
            //UpdatePanel3.Update();
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
            TextBox NomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox PrenomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            
            requerant r1 = new requerant();
            Guid num = Guid.NewGuid();
            r1.num = num.ToString();
            r1.nom_requerant = TextBox30.Text;
            r1.prenom_requerant = TextBox31.Text;

            /////////////////////////////////////////////////////////////////////////////

            Label LabelWilayaPro=(Label)grid1.FooterRow.FindControl("LabelWilayaPro");
            int id_wilayaInt = Convert.ToInt32(wilaya.SelectedValue);
            if (id_wilayaInt != 0) r1.id_wilaya = id_wilayaInt;
            else
            {
                r1.id_wilaya = wilaya_controller.getWilayaByName(LabelWilayaPro.Text).num;
            }
            ///////////////////////////////////////////////
            r1.SEXE = sexe_DropDownList.Text;
            r1.Nom_CAnimateur = NomAgentAssocie.Text;
            r1.Prenom_CAnimateur = PrenomAgentAssocie.Text;

            try
            {
                r1.Date_Naissance = DateTime.ParseExact((TextBox43.Text), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                r1.Date_Naissance = null;
            }

            r1.Adresse = TextBox49.Text;
            r1.Email = email.Text;

            requerant_controller r = new requerant_controller();
            r.insertRequerant(r1);

            grid1.DataSourceID = null;
            datasource = requerant_controller.getRequerantDataSource(r1.num);
            //datasource = requerant_controller.getAllRequerant();
            fillGrid();


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
            //UpdatePanel Requerant = (UpdatePanel)FormView1.FindControl("ModalPanel1");
            //Requerant.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void NomRequerant_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            PrenomRequerant.Focus();
        }

        protected void PrenomRequerant_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            wilaya.Focus();
        }

        protected void Wilaya_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            sexe.Focus();
        }

        protected void Sexe_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            DateBirthday.Focus();
        }

        protected void Birthday_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
        }

        protected void TextBox_NomCAnim_TextChanged(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            Prenom_CAnimateur.Focus();
        }

        protected void TextBox_PrenomCAnim_TextChanged(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            Prenom_CAnimateur.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        bool linqRequerant1_updated = true;
        private static string NomRequerant_str = "";
        private static string PrenomRequerant_str = "";
        private static string wilaya_str = "";
        private static string sexe_str = "";
        private static string DateBirthday_str = "";
        private static string Nom_CAnimateur_str = "";
        private static string Prenom_CAnimateur_str = "";
        public void filterRequerant()
        {

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox NomCAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox PrenomCAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");

            Label LabelWilayaPro = (Label)grid1.FooterRow.FindControl("LabelWilayaPro");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from Request req.Request ";
            string linq = "select * from Requerant pro ";
            string where = " where(";
            string and = " and ";
            string linq1;
            if (isDGCell())
            {
                linq1 =
                 getSubStringLinqTextBoxRequerant(PrenomRequerant, "prenom_requerant")
                + getSubStringLinqDropDownListRequerant(wilaya, "id_wilaya")
                + getDateBirthRequerant(DateBirthday, "Date_Naissance")
                + getSubStringLinqDropDownListSexeRequerant(sexe, "SEXE")
                + getSubStringLinqTextBoxRequerant(NomCAnimateur, "Nom_CAnimateur")
                + getSubStringLinqTextBoxRequerant(PrenomCAnimateur, "Prenom_CAnimateur")
                + ")";
            }
            else
            {
                linq1 =
                 getSubStringLinqTextBoxRequerant(PrenomRequerant, "prenom_requerant")
                + getSubStringLinqLabelWilayaRequerant(LabelWilayaPro, "id_wilaya")
                + getDateBirthRequerant(DateBirthday, "Date_Naissance")
                + getSubStringLinqDropDownListSexeRequerant(sexe, "SEXE")
                + getSubStringLinqTextBoxRequerant(NomCAnimateur, "Nom_CAnimateur")
                + getSubStringLinqTextBoxRequerant(PrenomCAnimateur, "Prenom_CAnimateur")
                + ")";
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Built the request linq by adding the num_requete to the global request//
            string num_req_string = NomRequerant.Text;
            if (!(NomRequerant.Text.Equals("")))
            {
                if (linq1.Equals(")")) linq = linq + where + "pro.nom_requerant like '" + num_req_string + "%'" + linq1;
                else linq = linq + where + "pro.nom_requerant like '" + NomRequerant.Text + "%'" + and + linq1;
            }
            else
            {
                if (!linq1.Equals(")")) linq = linq + where + linq1;
            }

            NomRequerant_str = NomRequerant.Text;
            PrenomRequerant_str = PrenomRequerant.Text;
            wilaya_str = wilaya.Text;
            sexe_str = sexe.Text;
            DateBirthday_str = DateBirthday.Text;
            Prenom_CAnimateur_str = PrenomCAnimateur.Text;
            Nom_CAnimateur_str = NomCAnimateur.Text;

            datasource = requerant_controller.getFilteredRequerant(linq);
            //RqFound.Text = datasource.Count.ToString() + " Requerants";
            grid1.DataSourceID = null;
            grid1.DataSource = datasource;
            grid1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string getSubStringLinqTextBoxRequerant(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + " like '" + a.Text + "%'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + " like '" + a.Text + "%'";
                    }


                }
            }
            return "";
        }
        protected string getSubStringLinqDropDownListRequerant(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + "=" + b.Text;
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + "=" + b.Text;
                    }

                }
            }
            return "";
        }
        protected string getSubStringLinqDropDownListSexeRequerant(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + "='" + b.SelectedItem + "'";
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + "='" + b.SelectedItem + "'";
                    }

                }
            }
            return "";
        }
        protected string getDateBirthRequerant(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //return "reclam." + field + " >= '" + a.Text + "'";

                DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                return "pro." + field + " = '" + ff.ToString("MM/dd/yyyy") + "'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //return " and " + "reclam." + field + " >=  '" + a.Text + "'";

                        DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "pro." + field + " =  '" + ff.ToString("MM/dd/yyyy") + "'";
                    }


                }
            }
            return "";
        }
        protected string getSubStringLinqLabelWilayaRequerant(Label a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;

                return "pro." + field + " = " + wilaya_controller.getWilayaByName(a.Text).num;

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + " =" + wilaya_controller.getWilayaByName(a.Text).num;
                    }


                }
            }
            return "";
        }


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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        //protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    grid1.PageSize = Convert.ToInt32(DropDownList10.SelectedValue);
        //    filterRequerant();

        //}




        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        
       




    }
}