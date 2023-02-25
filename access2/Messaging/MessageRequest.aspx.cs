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

namespace view.Messaging
{
    public partial class MessageRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Id_Request"]==null || Session["NumWilaya_Request"]==null || Session["Year_Request"] == null)
            {
                Response.Redirect("~/webforms/ReceivedRequestTest.aspx");
            }

            ///The title
            LabelTitle.Text = "Renseignement sur la Requête : " + GetRequestCodification();

            this.Master.RegisterTrigger(Button_SendMessage);



            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var User_Sending = manager.FindByName(Context.User.Identity.Name);

            var User_Receiving = manager.FindByName(Session["UserName_Agent"].ToString());
            var wilaya_claim = User_Receiving.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            var name_claim = User_Receiving.Claims.Where(cl => cl.ClaimType.Equals("Name"));
            var firstName_claim = User_Receiving.Claims.Where(cl => cl.ClaimType.Equals("FirstName"));
            Label_UserName.Text = Session["UserName_Agent"].ToString();
            try
            {
                Label_AgentName.Text = name_claim.First().ClaimValue.ToString();

            }
            catch
            {
                Label_AgentName.Text = "";

            }
            try
            {
                Label_AgentFirstName.Text = firstName_claim.First().ClaimValue.ToString();
            }
            catch
            {
                Label_AgentFirstName.Text = "";

            }
            try
            {
                Label_Structure.Text = wilaya_claim.First().ClaimValue.ToString();
            }
            catch
            {
                Label_Structure.Text = "";

            }


            OdsMessages.SelectParameters[0].DefaultValue = User_Sending.Id;
            OdsMessages.SelectParameters[1].DefaultValue = User_Receiving.Id;
            
            OdsMessages.SelectParameters[2].DefaultValue = Session["Year_Request"].ToString();
            OdsMessages.SelectParameters[3].DefaultValue = Session["NumWilaya_Request"].ToString();
            OdsMessages.SelectParameters[4].DefaultValue = Session["Id_Request"].ToString();

            GridView1.DataBind();
            ListView1.DataBind();
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

        public string GetRequestCodification()
        {
            if (Session["Id_Request"] != null && Session["NumWilaya_Request"] != null && Session["Year_Request"] != null)
            {
                return Session["NumWilaya_Request"].ToString() + "-" + Session["Year_Request"].ToString() + "-"
                    + Session["Id_Request"].ToString();
            }
            else return null;
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

        protected void SendButton_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var User_Sending = manager.FindByName(Context.User.Identity.Name);
            var User_Receiving = manager.FindByName(Label_UserName.Text);
            string IdUser_Sending = User_Sending.Id;
            string IdUser_Receiving = User_Receiving.Id;

            string filename = null;
            string link;
            if (FileUpload1.HasFile)
            {
                string a = FileUpload1.FileContent.ToString();
                link = Server.MapPath("~/Files/" + Label_UserName.Text + "/" + FileUpload1.FileName);
                FileUpload1.SaveAs(link);

                filename = FileUpload1.FileName;
                Label31.Text = "file uploaded";

            }
            else
            {
                filename = null;
                Label31.Text = "there is no file";

            }

            
            
            if (MessageRequestBLL.InsertMessages(IdUser_Sending, IdUser_Receiving, filename, TextBox_Message.Text, 
                Convert.ToInt32(Session["Year_Request"].ToString()), Convert.ToInt32(Session["NumWilaya_Request"].ToString())
                , Convert.ToInt32(Session["Id_Request"].ToString())))
            {
                ListView1.DataBind();
                GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le Message n'a pas été envoyé');", true);
            }

        }

        protected void TextBox_Message_TextChanged(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.Equals("1"))
            {
                DIV_ListView_Message.Visible = true;
                DIV_Grid_Messages.Visible = false;

            }
            else
            {
                DIV_ListView_Message.Visible = false;
                DIV_Grid_Messages.Visible = true;
            }
        }

        protected void Download_PieceJoint(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;
            LinkButton LinkButton_PieceJointe = (LinkButton)GridView1.Rows[indexRowSelected].FindControl("LinkButton_PieceJointe");
            Label LabelUsername_Receiving = (Label)GridView1.Rows[indexRowSelected].FindControl("Label2");

            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var User_Sending = manager.FindByName(Context.User.Identity.Name);
            var User_Receiving = manager.FindByName(Label_UserName.Text);
            string IdUser_Sending = User_Sending.Id;
            string IdUser_Receiving = User_Receiving.Id;


            Response.Redirect("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text);


            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //Response.AppendHeader("Content-Disposition", "filename=" + LinkButton_PieceJointe.Text);
            //string path = Server.MapPath("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text);
            //Response.TransmitFile(Server.MapPath("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text));
            //Response.End();


            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + LinkButton_PieceJointe.Text);
            //Response.TransmitFile(Server.MapPath("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text));
            //Response.End();





        }

        protected void LinkButton26_Click(object sender, EventArgs e)
        {

            var btn = (LinkButton)sender;
            var item = (ListViewItem)btn.NamingContainer;
            // find other controls:
            LinkButton LinkButton_PieceJointe = (LinkButton)item.FindControl("LinkButton26");
            Label LabelUsername_Receiving = (Label)item.FindControl("User_DestinationLabel");



            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var User_Sending = manager.FindByName(Context.User.Identity.Name);
            var User_Receiving = manager.FindByName(Label_UserName.Text);
            string IdUser_Sending = User_Sending.Id;
            string IdUser_Receiving = User_Receiving.Id;


            Response.Redirect("~/Files/" + LabelUsername_Receiving.Text + "/" + LinkButton_PieceJointe.Text);
        }

        protected void Grid_MessageDetail(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;

            string UserNameSending = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label1")).Text;
            string UserNameReceiving = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label2")).Text;
            string DateTimeMessage = ((Label)GridView1.Rows[indexRowSelected].FindControl("Label5")).Text;


            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var User_Sending = manager.FindByName(UserNameSending);
            var User_Receiving = manager.FindByName(UserNameReceiving);
            string IdUser_Sending = User_Sending.Id;
            string IdUser_Receiving = User_Receiving.Id;


            //string DateTimeMessage_Converted = DateTime.ParseExact(DateTimeMessage.ToString(), "yy/MM/dd HH:mm:ss",
            //                CultureInfo.InvariantCulture
            //                ).ToString("yy-mm-dd HH:mm:ss");


            //DateTime test = DateTime.ParseExact(DateTimeMessage.ToString(), "YYYY-MM-dd h:mm tt", CultureInfo.InvariantCulture);

            //DateTime DateMessageConverted = Convert.ToDateTime(DateTimeMessage);
            //string DateMessageConvertedFormat = "" + DateMessageConverted.Year + "-" + DateMessageConverted.Month + "-"
            //    + DateMessageConverted.Day + " " + DateMessageConverted.Hour + ":" + DateMessageConverted.Minute + ":"
            //    + DateMessageConverted.Second + "." + DateMessageConverted.Millisecond;


            OdsMessageDetails.SelectParameters[0].DefaultValue = IdUser_Sending;
            OdsMessageDetails.SelectParameters[1].DefaultValue = IdUser_Receiving;
            OdsMessageDetails.SelectParameters[2].DefaultValue = DateTimeMessage;

            OdsMessageDetails.SelectParameters[3].DefaultValue = Session["Year_Request"].ToString();
            OdsMessageDetails.SelectParameters[4].DefaultValue = Session["NumWilaya_Request"].ToString();
            OdsMessageDetails.SelectParameters[5].DefaultValue = Session["Id_Request"].ToString();

            DetailsView1.Visible = true;
            DetailsView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

    }
}