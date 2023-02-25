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

namespace view.Account
{
    public partial class AgentSetting : System.Web.UI.Page
    {
        static List<AspNetUsers> datasource;
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("SendMessage.aspx");
        }



        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////
        /// </summary>
        bool linq1_updated = true;
        public void filterRequest()
        {







            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from reclamation req.reclamation ";
            string linq = "select * from AspNetUsers users join AspNetUserClaims claims on(users.Id=claims.UserId)  ";
            string where = " where(";
            string and = " and ";
            string linq1;

            linq1 =
                  getSubStringLinqDropDownList(DropDownList_Structure, "wilaya") + getSubStringLinqTextBoxClaims(TextBox_Name, "Name")
                  + getSubStringLinqTextBoxClaims(TextBox_FirstName, "FirstName")
                + getSubStringLinqTextBoxClaims(TextBox_Birthday, "Birthday") + ")";

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Built the request linq by adding the num_requete to the global request//
            string name_req_string = TextBox_UserName.Text;
            if (!(TextBox_UserName.Text.Equals("")))
            {
                if (linq1.Equals(")")) linq = linq + where + " users.UserName like '%" + name_req_string + "%'" + " and claims.ClaimType='wilaya' " + linq1;
                else linq = linq + where + " users.UserName like '%" + TextBox_UserName.Text + "%'" + " and claims.ClaimType='wilaya' " + and + linq1;
            }
            else
            {
                if (!linq1.Equals(")")) linq = linq + where + linq1;
                else
                {
                    linq1 = " claims.ClaimType='wilaya' )";
                    linq = linq + where + linq1;
                }
            }




            datasource = Users_Controller.getFilteredUsers(linq);
            try
            {
                RqFound.Text = datasource.Count.ToString() + " Utilisateurs";
            }
            catch
            {
                RqFound.Text = "0 Utilisateur";
            }
            GridView1.DataSourceID = null;
            GridView1.DataSource = datasource;
            GridView1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }


        protected string getSubStringLinqTextBox(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                return "users." + field + " like '" + a.Text + "%'";

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
                        return " and users." + field + " like '" + a.Text + "%'";
                    }


                }
            }
            return "";
        }
        

        protected string getSubStringLinqTextBoxClaims(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linq1_updated)
            {
                linq1_updated = false;
                return "claims.ClaimType='" + field + "' and claims.ClaimValue  like '%" + a.Text + "%'";

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
                        return " and claims.ClaimType='" + field + "' and claims.ClaimValue  like '%" + a.Text + "%'";
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
                return "claims.ClaimType='" + field + "' and claims.ClaimValue  = '" + b.SelectedItem + "'";
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
                        return " and claims.ClaimType='" + field + "' and claims.ClaimValue  = '" + b.SelectedItem + "'";
                    }

                }
            }
            return "";
        }

        protected void Username_Onclick(object sender, EventArgs e)
        {

            filterRequest();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



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

        protected void UpdateAgent_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            
            
            string UserName_Selected = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label2")).Text;

            Session["User"] = UserName_Selected;
            Response.Redirect("~/Account/ProfileAgent.aspx");
        }

 
    }
}