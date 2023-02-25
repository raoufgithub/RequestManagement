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
namespace view.Messaging
{
    public partial class FindAgent : System.Web.UI.Page
    {

        static List<GetUsersStoredProcedure_Result> datasource;
        //static List<AspNetUsers> datasource;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList_Structure.DataBind();
                filterRequest();

            }
        }

        protected string getWilayaAgentClaim(string name)
        {

            

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));

            if (wilaya_claim.ToList().Count != 0) return wilaya_claim.First().ClaimValue.ToString();
            else return "Cellule DG";
            
        }

        protected void SendMessage_Onclick(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            string UserName_selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label2")).Text;
            Session["UserName_Agent"] = UserName_selected;
            if (Session["Id_Request"] == null || Session["NumWilaya_Request"] == null || Session["Year_Request"] == null)
              Response.Redirect("SendMessage.aspx");
            
            else Response.Redirect("MessageRequest.aspx");


        }



        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>
        
        public void filterRequest()
        {







            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from reclamation req.reclamation ";

            string whereLinq = "  ";

            //string linq = "select * from AspNetUsers users join AspNetUserClaims claims on(users.Id=claims.UserId)  ";
            
            string linq1="";

            if (!TextBox_UserName.Text.Equals(""))
            {
                linq1 = linq1 + " and a.[User Name] like '%" + TextBox_UserName.Text + "%' ";
            }
            else linq1 = linq1 + "";
            if (!TextBox_Name.Text.Equals(""))
            {
                linq1 = linq1 + " and a.[Nom] like '%" + TextBox_Name.Text + "%' ";
            }
            else linq1 = linq1 + "";
            if (!TextBox_FirstName.Text.Equals(""))
            {
                linq1 = linq1 + " and a.[Prenom] like '%" + TextBox_FirstName.Text + "%' ";
            }
            else linq1 = linq1 + "";
            if (!DropDownList_Structure.SelectedValue.Equals("00000000-0000-0000-0000-000000000000"))
            {
                linq1 = linq1 + " and struct.StructureId like '%" + DropDownList_Structure.SelectedValue + "%' ";
            }
            else linq1 = linq1 + "";

            if (!linq1.Equals(""))
            {
                //Delete the first and
                linq1 = linq1.Substring(4);
                whereLinq =" where(" + linq1+") ";
            }
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Built the request linq by adding the num_requete to the global request//
            string name_req_string = TextBox_UserName.Text;
            


            /////////////////////////////////////////////////////////////////////////////////////////////////////
            
            int RequestNum = Convert.ToInt32(Session["Id_Request"].ToString());
            int RequestWilNum = Convert.ToInt32(Session["NumWilaya_Request"].ToString());
            int YearRequest = Convert.ToInt32(Session["Year_Request"].ToString());
            string UserNameId = Users_Controller.getUserIDByUserName(Context.User.Identity.Name);

            //string whereLinq = " where a.[User Name] like '%ra%' ";
            
            string linq = "select Max(a.Id) 'Id', (a.[User Name]) 'username', max(a.Nom) 'Nom', max(a.Prenom) 'Prenom', max(struct.IntituleFr) 'structure',  sum(a.[nombremessages]) 'NombreSentMessages', sum(a.[nombremessages Dist]) 'NombreReceivedMessages', max(a.Email) 'Email', max(a.PhoneNumber) 'PhoneNumber', max(a.Hometown) 'HomeTown'"

                + " from"
                 +" (SELECT users.Id"
                        +", max(users.UserName) 'User Name'"
                        +", max(users.Nom) 'Nom'"
                        + ", max(users.Prenom) 'Prenom'"
                        + ", count(mess.id_user) 'nombremessages'"
                        + ", 0 'nombremessages Dist'"
                        + " ,max(users.Email) 'Email'"
                        + " ,max(users.PhoneNumber) 'PhoneNumber'"
                        + ", max(users.Hometown) 'HomeTown'"
                  + " FROM[requete].[dbo].[Message_Request] mess"
                  + " join AspNetUsers users on users.Id = mess.id_user"
                  + " join AspNetUsers users2 on users2.Id = mess.Id_User_Destination"
                  + " where mess.num_wilayaRequest = "+RequestWilNum+" and mess.NumRequest = "+RequestNum+" and mess.YearRequest = "+YearRequest+" and((mess.Id_User_Destination = '" + UserNameId + "')"
                  + " or(mess.id_user = '"+UserNameId+ "')) and users.Id <> '" + UserNameId + "'"
                  + " group by users.Id"

                  + " union all"
                  + " SELECT users2.Id"
                        + ", max(users2.UserName) 'User Name'"
                        + ", max(users2.Nom) 'Nom'"
                        + ", max(users2.Prenom) 'Prenom'"
                        + ", 0 'nombre de messages'"
                        + ", count(mess.id_user) 'nombre de messages Dist'"
                        + " ,max(users2.Email) 'Email'"
                        + " ,max(users2.PhoneNumber) 'PhoneNumber'"
                        + ", max(users2.Hometown) 'Home Town'"
                  + " FROM[requete].[dbo].[Message_Request] mess"
                  + " join AspNetUsers users on users.Id = mess.id_user"
                  + " join AspNetUsers users2 on users2.Id = mess.Id_User_Destination"
                  + " where mess.num_wilayaRequest = " + RequestWilNum + " and mess.NumRequest = " + RequestNum + " and mess.YearRequest = " + YearRequest + " and((mess.Id_User_Destination = '" + UserNameId + "')"
                  + " or(mess.id_user = '" + UserNameId + "')) and users2.Id <> '" + UserNameId + "'"
                  + " group by users2.Id"

                  + " union all"

                  + " SELECT users.Id"
                        + ", users.UserName 'User Name'"
                        + ", users.Nom 'Nom'"
                        + ", users.Prenom 'Prenom'"
                        + ", 0 'nombremessages'"
                        + ", 0 'nombremessages Dist'"
                        + " ,users.Email 'Email'"
                        + " ,users.PhoneNumber 'PhoneNumber'"
                        + ", users.Hometown 'HomeTown'"
                  + " FROM[requete].[dbo].AspNetUsers users"
                  + " where users.Id<> '" + UserNameId + "' and ( users.Id not in "
                  + " (select mess.id_user from[Message_Request] mess"


                  + " where(mess.num_wilayaRequest = " + RequestWilNum + " and mess.NumRequest = " + RequestNum + " and mess.YearRequest = " + YearRequest + "))"
                  + " or users.Id not in "
                  + " (select mess.Id_User_Destination from[Message_Request] mess"


                  + " where(mess.num_wilayaRequest = " + RequestWilNum + " and mess.NumRequest = " + RequestNum + " and mess.YearRequest = " + YearRequest + ")))"

                  + ") a"
                  + " join UserManageStructure manager on manager.UserId = a.Id"
                  + " join Structure struct on struct.StructureId=manager.StructureId"
                  + whereLinq+
                  " group by a.[User Name]"+
                  " order by sum(a.[nombremessages]) desc, sum(a.[nombremessages Dist]) desc";
            ///////////////////////////////////////////////////////////////////////////////////////////////////////


            //datasource = Users_Controller.getAllUsersOfUser();
            //datasource = Users_Controller.getFilteredUsers(linq);
            datasource = Users_Controller.getFilteredUsersBySQLRequest(linq);
            
            try
            {
                RqFound.Text = datasource.Count.ToString() + " Agents Acces";
            }
            catch
            {
                RqFound.Text = "0 Agent Acces";
            }
            GridView1.DataSourceID = null;
            GridView1.DataSource = datasource;
            GridView1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }


        protected string getSubStringLinqTextBox(TextBox a, string field)
        {
            if (!(a.Text.Equals("")))
            {
                
                return " users." + field + " like '" + a.Text + "%'";

            }
            
            return "";
        }

        

        protected string getSubStringLinqDropDownList(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("00000000-0000-0000-0000-000000000000")))
            {
                string aaa = b.SelectedValue;
                
                return " users.UserName!='" + Context.User.Identity.Name + "' and claims.ClaimType='" + field + "' and claims.ClaimValue  = '" + b.SelectedItem + "'";
            }
            
            return "";
        }

        protected void Username_Onclick(object sender, EventArgs e)
        {

            filterRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetNbreMessages(string id_Receiving)
        {
            
            if (Session["Id_Request"] == null || Session["NumWilaya_Request"] == null || Session["Year_Request"] == null)
            {
                return "";
            }
            else
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = manager.FindByName(Context.User.Identity.Name);
                int NbreMessages = MessageRequestBLL.getMessagesCountByUser(user.Id, id_Receiving, Convert.ToInt32(Session["Year_Request"].ToString()),
                    Convert.ToInt32(Session["NumWilaya_Request"].ToString()), Convert.ToInt32(Session["Id_Request"].ToString()));
                if (NbreMessages == 0) return "";
                return NbreMessages + " Messages";
            }
                
        }

        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nbrlignes =Convert.ToInt32(GridView1.Rows.Count / Convert.ToInt32(DropDownList10.SelectedValue.ToString())) + 1;
            //GridView1.PageSize = nbrlignes ;
            //GridView1.DataBind()            ;

            GridView1.PageSize = Convert.ToInt32(DropDownList10.SelectedValue);
            filterRequest();
            


        }

        protected void Wilaya_OnClick(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void TextBox_Name_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void TextBox_FirstName_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void TextBox_Birthday_TextChanged(object sender, EventArgs e)
        {
            filterRequest();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            filterRequest();
        }


        
        
        
    }
}