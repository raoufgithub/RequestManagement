using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Security.Claims;
namespace view.webforms
{
    public partial class test : System.Web.UI.Page
    {
        protected void InitDialog()
        {
            
            editCustomerID.Text = lblCustomerID.Text;
            editTxtCompanyName.Text = lblCompanyName.Text;
            editTxtContactName.Text = lblContactName.Text;
            editTxtCountry.Text = lblCountry.Text;
            try
            {
                SetFocus("editTxtCompanyName");

            }
            catch (InvalidOperationException ex)
            {
                
                throw ex;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDialog();
                
            }
            
            
            
            
            
            //////////////////////////////////////////////////////////////
        }
        protected void editBox_OK_Click(object sender, EventArgs e)
        {
            // Save to the database
            // Refresh the UI
            lblCompanyName.Text = editTxtCompanyName.Text;
            lblContactName.Text = editTxtContactName.Text;
            lblCountry.Text = editTxtCountry.Text;
            
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            if (editTxtCountry.Text == "Germany")
                editTxtCountry.Text = "Cuba";
            else
                editTxtCountry.Text = "USA";
        }
    }
}