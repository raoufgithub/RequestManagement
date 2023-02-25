using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>alert('The following errors have occurred: Raouf');</script>");


            //IList<Claim> claimCollection = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, "Andras")
            //    , new Claim(ClaimTypes.Country, "Sweden")
            //    , new Claim(ClaimTypes.Gender, "M")
            //    , new Claim(ClaimTypes.Surname, "Nemes")
            //    , new Claim(ClaimTypes.Email, "hello@me.com")
            //    , new Claim(ClaimTypes.Role, "IT")
            //};

            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection);
            //Console.WriteLine(claimsIdentity.IsAuthenticated);
            Label1.Text = "555";
            

            UpdatePanel masterupdatepanel = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            masterupdatepanel.Update();
        }
    }
}