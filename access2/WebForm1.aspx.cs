using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal;", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Member Registered Sucessfully');", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "openModal()", true);
        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected bool test()
        {
            return true;
            
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Validation Errors List for HP7 Citation";
            lblModalBody.Text = "This is modal body";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            //upModal.Update();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "openModal();", true);
            ////ScriptManager.RegisterStartupScript(this, this.GetType(), "modal", "$(function() { openModal(); });", true);
            IList<Claim> claimCollection = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Andras")
                , new Claim(ClaimTypes.Country, "Sweden")
                , new Claim(ClaimTypes.Gender, "M")
                , new Claim(ClaimTypes.Surname, "Nemes")
                , new Claim(ClaimTypes.Email, "hello@me.com")
                , new Claim(ClaimTypes.Role, "IT")
            };

            //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claimCollection, "My e-commerce website");
            Console.WriteLine(claimsIdentity.IsAuthenticated);


            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);
            Thread.CurrentPrincipal = principal;

            TextBox3.Text = "555";
           

        }





        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                
                string Message_FileUpload = "";
                foreach (HttpPostedFile uploadedFile in FileUpload1.PostedFiles)
                {
                   //uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"),
                   //uploadedFile.FileName)); listofuploadedfiles.Text += String.Format("{0}<br />", uploadedFile.FileName);

                    uploadedFile.SaveAs(Server.MapPath("~/Files/" + uploadedFile.FileName));

                    Message_FileUpload = Message_FileUpload + " '"+uploadedFile.FileName+" Uploaded' ";
                    
                }
                Label31.Text = Message_FileUpload;
            }
            else Label31.Text = "there is no files";
        }
    }
}