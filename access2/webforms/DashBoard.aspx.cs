using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;


using System.Configuration;
using System.Security.Claims;
using controller;
using Model;
using System.Globalization;
namespace view.webforms
{
    public partial class DashBoard : System.Web.UI.Page
    {

        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try { 
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Dashboard"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch (Exception e)
            {
                return false;
            }

        }
        
        



        protected void Page_Load(object sender, EventArgs e)
        {


            
            

            
                //if (Context.User.Identity.IsAuthenticated)
                //{

                //    if (!IsAuthorized())
                //    {

                //        //ScriptManager.RegisterStartupScript(this, Master.GetType(), "alert", "ShowPopup();", true);
                //        Response.Redirect("~/UnauthorizedPage.aspx");

                //    }
                //    else
                //    {
                        if (isDGCell())
                        {
                            LinkButton1.Text = requete_controller.getCountRequestIntroduite().ToString();
                            LinkButton2.Text = requete_controller.getCountRequest(1).ToString();
                            LinkButton3.Text = requete_controller.getCountRequest(2).ToString();
                            LinkButton4.Text = requete_controller.getCountRequest(3).ToString();
                        }
                        else
                        {
                            LinkButton1.Text = requete_controller.getCountRequestIntroduiteWilaya(getAgentWilaya()).ToString();
                            LinkButton2.Text = requete_controller.getCountRequestWilaya(getAgentWilaya(), 1).ToString();
                            LinkButton3.Text = requete_controller.getCountRequestWilaya(getAgentWilaya(), 2).ToString();
                            LinkButton4.Text = requete_controller.getCountRequestWilaya(getAgentWilaya(), 3).ToString();

                        }

                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        List<action_User_Request> actions_List = new List<action_User_Request>();
                        if (isDGCell())
                        {
                            actions_List = requete_controller.GetUsersLate();
                            
                            
                        }
                        else
                        {
                            actions_List = requete_controller.GetUsersLateWilayaID(getAgentWilaya());

                        }
                        GridView1.DataSourceID = null;
                        GridView1.DataSource = actions_List;
                        GridView1.DataBind();

                        int ww= getAgentWilaya();
                        Session["Wilaya_Agent"] = getAgentWilaya();
                        //}
                    //}
                //}
                //else
                //{
                //    Response.Redirect("~/Account/loginPopup.aspx");
                //}
                
                


            
        }

        



        protected int getAgentWilaya()
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var user = manager.FindByName(Context.User.Identity.Name);
            //var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            //try
            //{
            //    if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return -1;
            //    else return wilaya_controller.getWilayaByName(wilaya_claim.First().ClaimValue.ToString()).num;
            //}

            string id = Users_Controller.getUserIDByUserName(Context.User.Identity.Name);
            string wilayaa = Users_Controller.getClaimValueUserByID(id);
            //string wilayaa = Users_Controller.getClaimValueUserByID(Session["ID_CurrentUser"].ToString());

            try
            {
                if (wilayaa.Equals("Cellule DG")) return -1;
                else return wilaya_controller.getWilayaByName(wilayaa).num;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return 0;
            }

        }
        protected string getAgentStructure(string AgentID)
        {
            
            
            string wilayaa = Users_Controller.getClaimValueUserByID(AgentID);
            try
            {
                return wilayaa;
                
            }
            catch
            {
                
                return null;
            }

        }
        protected Boolean isDGCell()
        {
            
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            
            //var user = manager.FindByName(Context.User.Identity.Name);
            //string wilaya_claimtest;
            //if (Context.User.Identity.Name == null) wilaya_claimtest = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya")).FirstOrDefault().ClaimValue.ToString();
            //var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));


            //try
            //{
            //    if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return true;
            //    else return false;
            //}
            bool auth = Context.User.Identity.IsAuthenticated;
            string id = Users_Controller.getUserIDByUserName(Context.User.Identity.Name);
            string wilayaa = Users_Controller.getClaimValueUserByID(id);
            
            //string wilayaa = Users_Controller.getClaimValueUserByID(Session["ID_CurrentUser"].ToString());

            try
            {
                if (wilayaa.Equals("Cellule DG")) return true;
                else return false;
            }

            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return false;
            }

        }

        protected void IntrodReq_Click(object sender, EventArgs e)
        {
            Session["Request_Treating"] = "1";
            Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
        }

        protected void Treating_Click(object sender, EventArgs e)
        {
            Session["Request_Treating"] = "2";
            Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
        }

        protected void Treated_Click(object sender, EventArgs e)
        {
            Session["Request_Treating"] = "3";
            Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
        }

        protected void NonFond_Click(object sender, EventArgs e)
        {
            Session["Request_Treating"] = "4";
            Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
        }
        protected string GetIdRequest( string num_wilaya, string year,string id_request)
        {
            return num_wilaya + "-" + year + "-" + id_request;
        }

        protected string GetUserName(string id)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return manager.FindById(id).UserName.ToString();
        }

        protected string DurationTreating(string Date)
        {
            DateTime dt = Convert.ToDateTime(Date);
            //DateTime dt = DateTime.ParseExact(Date,  "YYYY-MM-dd h:mm tt", CultureInfo.InvariantCulture);
            TimeSpan duration5 = (TimeSpan)(DateTime.Now - dt);
            //LabelDuration5.Text = "  (" + duration5.Days + " Jours / " + duration5.Hours + " Heures / " + duration5.Minutes + " Minutes)";
            return "  " + duration5.Days + " Jours / " + duration5.Hours + " Heures";
        }
    }
}