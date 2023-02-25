using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace view
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }






        string a;
        protected void Upload_Click(object sender, EventArgs e)
        {
            if (this.FileUpload1.HasFile)
            {
                

                this.FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));


                Label31.Text = "file uploaded";
            }
            else Label31.Text = "there is no file";
        }
    }
}