using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using controller;
using Model;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Globalization;
using System.IO;
using System.Security.Claims;

namespace view.Account
{
    public partial class ProfileAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.RegisterTrigger(Button_AddPhotoProfile);
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            
            var User = manager.FindByName(Session["User"].ToString());
            var ProfilePhoto_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Profile_Photo"));

            ImageButton imageButton = new ImageButton();
            if (ProfilePhoto_claim.Count() == 0)
            {
                FileInfo fileInfo = new FileInfo("Profil-Photo.jpg");
                imageButton.ImageUrl = "~/Profil-Photo.jpg";
            }
            else
            {
                 FileInfo fileInfo = new FileInfo(ProfilePhoto_claim.First().ClaimValue.ToString());
                imageButton.ImageUrl = "~/Files/" + User.UserName + "/profile/" + ProfilePhoto_claim.First().ClaimValue.ToString();
            }
            
            imageButton.Width = Unit.Pixel(200);
            imageButton.Height = Unit.Pixel(200);
            imageButton.Style.Add("padding", "5px");
            imageButton.Click += new ImageClickEventHandler(Image_Click);

            Panel1.Controls.Add(imageButton);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            

            if(!IsPostBack)
            {
                var User_Updating = manager.FindByName(Context.User.Identity.Name);

                //var User_Receiving = manager.FindByName(Session["UserName_Agent"].ToString());
                
                string EmailAddress = User.Email;
                var wilaya_claim = User.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
                var name_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Name"));
                var firstName_claim = User.Claims.Where(cl => cl.ClaimType.Equals("FirstName"));
                //Label_UserName.Text = Session["UserName_Agent"].ToString();
                TextBox_UserName.Text = Session["User"].ToString();
                try
                {
                    TextBox_AgentName.Text = name_claim.First().ClaimValue.ToString();

                }
                catch
                {
                    TextBox_AgentName.Text = "";

                }
                try
                {
                    TextBox_AgentFirstName.Text = firstName_claim.First().ClaimValue.ToString();
                }
                catch
                {
                    TextBox_AgentFirstName.Text = "";

                }
                try
                {
                    if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG"))
                    {
                        DropDownList_Structure.SelectedValue = "-1";
                    }
                    else
                    {
                        DropDownList_Structure.SelectedValue = wilaya_controller.getWilayaByName(wilaya_claim.First().ClaimValue.ToString()).num.ToString();

                    }
                }
                catch
                {
                    DropDownList_Structure.SelectedValue = "";

                }
                try
                {
                    TextBox_Email.Text = EmailAddress;
                }
                catch
                {
                    TextBox_AgentFirstName.Text = "";

                }

                TextBox_AgentMatricule.Text = Users_Controller.getUserByUserName(Session["User"].ToString()).Matricule;

                TextBox_UserName.ReadOnly = VisibilityUserNameMatricule();
                TextBox_AgentMatricule.ReadOnly = VisibilityUserNameMatricule();

                OdsMessages.SelectParameters[0].DefaultValue = User_Updating.Id;
                OdsMessages.SelectParameters[1].DefaultValue = User_Updating.Id;

            }
            
            
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string a = FileUpload1.FileContent.ToString();

                FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));


                Label31.Text = "file uploaded";
            }
            else Label31.Text = "there is no file";
        }



        protected Boolean IsAuthorized()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            try
            {
                var permission_claim = user.Claims.Where(cl => cl.ClaimType.Equals("Request_Management"));
                return Convert.ToBoolean(permission_claim.First().ClaimValue.ToString());
            }
            catch (Exception e)
            {
                return false;
            }



        }

        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

                
                var User = manager.FindByName(Session["User"].ToString());
                User.UserName = TextBox_UserName.Text;
                User.Email = TextBox_Email.Text;
                string Name = TextBox_AgentName.Text;
                string FirstName = TextBox_AgentFirstName.Text;
                try
                {
                    var wilaya_claim = User.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
                    manager.RemoveClaim(User.Id, new Claim(wilaya_claim.First().ClaimType, wilaya_claim.First().ClaimValue));


                    manager.AddClaim(User.Id, new Claim("wilaya", DropDownList_Structure.SelectedItem.ToString()));
                }
                catch
                {
                    manager.AddClaim(User.Id, new Claim("wilaya", DropDownList_Structure.SelectedItem.ToString()));
                }
                try
                {
                    var name_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Name"));
                    manager.RemoveClaim(User.Id, new Claim(name_claim.First().ClaimType, name_claim.First().ClaimValue));

                    manager.AddClaim(User.Id, new Claim("Name", TextBox_AgentName.Text));
                }
                catch
                {
                    manager.AddClaim(User.Id, new Claim("Name", TextBox_AgentName.Text));
                }
                try
                {
                    var firstName_claim = User.Claims.Where(cl => cl.ClaimType.Equals("FirstName"));
                    manager.RemoveClaim(User.Id, new Claim(firstName_claim.First().ClaimType, firstName_claim.First().ClaimValue));

                    manager.AddClaim(User.Id, new Claim("FirstName", TextBox_AgentFirstName.Text));
                }
                catch
                {
                    manager.AddClaim(User.Id, new Claim("FirstName", TextBox_AgentFirstName.Text));
                }

                Users_Controller.UpdateUserByUserName(TextBox_UserName.Text, TextBox_AgentMatricule.Text);
                
                
                Response.Redirect("~/Account/AgentSetting.aspx");
            }
            


        }

        
        

        protected void Download_PieceJoint(object sender, EventArgs e)
        {
            //GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            //int indexRowSelected = gridViewRow.RowIndex;
            //LinkButton LinkButton_PieceJointe = (LinkButton)GridView1.Rows[indexRowSelected].FindControl("LinkButton_PieceJointe");
            //Label LabelUsername_Receiving = (Label)GridView1.Rows[indexRowSelected].FindControl("Label2");

            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            //var User_Sending = manager.FindByName(Context.User.Identity.Name);
            //var User_Receiving = manager.FindByName(Label_UserName.Text);
            //string IdUser_Sending = User_Sending.Id;
            //string IdUser_Receiving = User_Receiving.Id;


            //Response.Redirect("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text);


            





        }

        

        protected void ButtonPhotoProfile_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string UserName = "" ;
            try
            {
                UserName = Session["User"].ToString();
            }
            catch
            {
                Response.Redirect("~/Account/AgentSetting.aspx");
            }

            var User = manager.FindByName(UserName);

            string IdUser = User.Id;
            string filename;
            if (FileUpload1.HasFile)
            {
                var ProfilePhoto_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Profile_Photo"));
                
                if (ProfilePhoto_claim.Count() != 0)
                {
                    string ClaimPhoto = ProfilePhoto_claim.First().ClaimValue.ToString();
                    manager.RemoveClaim(User.Id, new Claim("Profile_Photo", ProfilePhoto_claim.First().ClaimValue.ToString()));

                    File.Delete(Server.MapPath("~/Files/" + UserName + "/profile/" + ClaimPhoto));
                }


                string a = FileUpload1.FileContent.ToString();
                string link = Server.MapPath("~/Files/" + UserName + "/profile/" + FileUpload1.FileName);
                FileUpload1.SaveAs(link);

                filename = FileUpload1.FileName;
                Label31.Text = "file uploaded";

                ImageButton imageButton = new ImageButton();
                FileInfo fileInfo = new FileInfo(link);
                imageButton.ImageUrl = "~/Files/" + UserName + "/profile/" + FileUpload1.FileName;
                imageButton.Width = Unit.Pixel(200);
                imageButton.Height = Unit.Pixel(200);
                imageButton.Style.Add("padding", "5px");
                imageButton.Click += new ImageClickEventHandler(Image_Click);

                Panel1.Controls.Clear();
                Panel1.Controls.Add(imageButton);

                manager.AddClaim(User.Id, new Claim("Profile_Photo", FileUpload1.FileName));

                
            }
            else
            {
                filename = null;
                Label31.Text = "there is no file";

            }

            
        }



        protected void Image_Click(object sender, ImageClickEventArgs e)
        {
            Image1.ImageUrl = ((ImageButton)sender).ImageUrl;
            Image1.Width = Unit.Pixel(600);
            Image1.Height = Unit.Pixel(600);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "ShowImageProfile();", true);
            //Response.Redirect(((ImageButton)sender).ImageUrl);
        }

        protected void CancalButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/AgentSetting.aspx");
        }

        protected bool VisibilityUserNameMatricule()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var User = manager.FindByName(Session["User"].ToString());
            var RoleManagement_claim = User.Claims.Where(cl => cl.ClaimType.Equals("Role_Management"));
            try
            {
                return !Convert.ToBoolean(RoleManagement_claim.FirstOrDefault().ClaimValue.ToString());
                
            }
            catch
            {
                return true;
            }
            
        }

        
    }
}