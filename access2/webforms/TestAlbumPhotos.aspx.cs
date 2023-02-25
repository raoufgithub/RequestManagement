using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using controller;
using System.IO;
using Model;
namespace view.webforms
{
    public partial class TestAlbumPhotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                LabelIdReclam.Text = Session["Id_Request"].ToString();
                Label2.Text=Session["NumWilaya_Request"].ToString();
                Label81.Text = Session["Year_Request"].ToString();
                //List<string> links = requete_controller.getRequestAttachments(38, 16, 2016);
                List<Link> links = requete_controller.getRequestAttachments(Convert.ToInt32(LabelIdReclam.Text), Convert.ToInt32(Label2.Text), Convert.ToInt32(Label81.Text));
                foreach (Link link in links)
                {
                    ImageButton imageButton = new ImageButton();
                    FileInfo fileInfo = new FileInfo(link.Guid);
                    imageButton.ImageUrl = "~/RequestsFiles/" + link.Guid;
                    imageButton.Width = Unit.Pixel(200);
                    imageButton.Height = Unit.Pixel(200);
                    imageButton.Style.Add("padding", "5px");
                    imageButton.Click += new ImageClickEventHandler(Image_Click);

                    Panel1.Controls.Add(imageButton);
                }
            
            
        }

        protected void Image_Click(object sender, ImageClickEventArgs e)
        {
            Image1.ImageUrl =  ((ImageButton)sender).ImageUrl;
            Image1.Width = Unit.Pixel(800);
            Image1.Height = Unit.Pixel(400);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "ShowImage();", true);
            //Response.Redirect(((ImageButton)sender).ImageUrl);
        }
    }
}