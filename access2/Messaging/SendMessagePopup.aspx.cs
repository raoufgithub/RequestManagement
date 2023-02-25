using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view.Messaging
{
    public partial class SendMessagePopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}