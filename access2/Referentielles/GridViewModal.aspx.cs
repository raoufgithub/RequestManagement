using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using controller;
using System.Globalization;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.IO;

namespace view
{
    public partial class GridViewModal : System.Web.UI.Page
    {
        static List<requerant> datasource = new List<requerant>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                filterRequerant();


            }




        }



        protected void Grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //datasource = null;
            //datasource = requerant_controller.getAllRequerant();
            //grid1.DataBind();
            grid1.PageIndex = e.NewPageIndex;
            filterRequerant();
        }
        protected void Grid1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grid1.EditIndex = -1;

            
            filterRequerant();
            GetFooterValues();
            
        }

        protected void fillGrid()
        {
            //grid1.DataSourceID = null;
            //grid1.DataSource = null;
            grid1.DataSource = datasource;
            grid1.DataBind();
        }

        protected void Grid1_RowDeleted1(object sender, GridViewDeletedEventArgs e)
        {
            grid1.DataBind();
        }
        protected void Grid1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            requerant_controller r = new requerant_controller();
            
            string num_selected = ((Label)grid1.Rows[e.RowIndex].FindControl("Label1")).Text;
            string confirmValue = Request.Form["confirm_value"].Last().ToString();
            if (confirmValue.Equals("s"))
            {
                if (r.deleteRequerant(num_selected))
                {
                    grid1.DataSourceID = null;
                    datasource = requerant_controller.getAllRequerant();
                    //UpdatePanel3.Update();
                    fillGrid();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le Requerant a été supprimé avec succès');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('La suppression du Requerant a échouée');", true);
                }
            }
        }
        protected void Grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            grid1.EditIndex = e.NewEditIndex;

            
            filterRequerant();
            GetFooterValues();
            
        }
        protected void Grid1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            grid1.DataBind();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void LinkButton225_Click11(object sender, EventArgs e)
        {
            //updated
            TextBox TextBox30 = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox TextBox31 = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            TextBox TextBox34 = (TextBox)grid1.FooterRow.FindControl("TextBox34");
            TextBox TextBox35 = (TextBox)grid1.FooterRow.FindControl("TextBox35");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe_DropDownList = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox TextBox43 = (TextBox)grid1.FooterRow.FindControl("TextBox43");
            TextBox TextBox47 = (TextBox)grid1.FooterRow.FindControl("TextBox47");
            TextBox TextBox48 = (TextBox)grid1.FooterRow.FindControl("TextBox48");
            TextBox TextBox49 = (TextBox)grid1.FooterRow.FindControl("TextBox49");
            TextBox email = (TextBox)grid1.FooterRow.FindControl("TextBox50");
            TextBox NomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox PrenomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Label LabelWilayaPro = (Label)grid1.FooterRow.FindControl("LabelWilayaPro");

            requerant r1 = new requerant();
            
            Guid num = Guid.NewGuid();
            r1.num = num.ToString();
            r1.nom_requerant = TextBox30.Text;
            r1.prenom_requerant = TextBox31.Text;

            int id_wilayaInt = Convert.ToInt32(wilaya.SelectedValue);
            if (id_wilayaInt != 0) r1.id_wilaya = id_wilayaInt;
            else
            {
                r1.id_wilaya = wilaya_controller.getWilayaByName(LabelWilayaPro.Text).num;
            }
            r1.SEXE = sexe_DropDownList.Text;
            r1.Nom_CAnimateur = NomAgentAssocie.Text;
            r1.Prenom_CAnimateur = PrenomAgentAssocie.Text;

            try
            {
                r1.Date_Naissance = DateTime.ParseExact((TextBox43.Text), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                r1.Date_Naissance = null;
            }

            r1.Adresse = TextBox49.Text;
            r1.Email = email.Text;
            //r1.num = requerant_controller.getLastRequerant().ToString();
            
            
            requerant_controller r = new requerant_controller();
            r.insertRequerant(r1);

            grid1.DataSourceID = null;
            datasource = requerant_controller.getRequerantDataSource(r1.num);
            fillGrid();


        }
        protected void LinkButton111_Click111(object sender, EventArgs e)
        {
            //retrieve it from the  the valider button in the receivedRequestTest or ReceivedRequest
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int indexRowSelected = gridViewRow.RowIndex;

            string num_selected = ((Label)grid1.Rows[indexRowSelected].FindControl("Label1")).Text;


            requerant_controller r = new requerant_controller();

            r.deleteRequerant(num_selected);
            grid1.DataSourceID = null;
            datasource = requerant_controller.getAllRequerant();
            fillGrid();
            //UpdatePanel Requerant = (UpdatePanel)FormView1.FindControl("ModalPanel1");
            //Requerant.Update();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

        protected void NomRequerant_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;



            PrenomRequerant.Focus();
        }

        protected void PrenomRequerant_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            wilaya.Focus();
        }

        protected void Wilaya_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            sexe.Focus();
        }

        protected void Sexe_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            DateBirthday.Focus();
        }

        protected void Birthday_Click(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
        }

        protected void TextBox_NomCAnim_TextChanged(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            Prenom_CAnimateur.Focus();
        }

        protected void TextBox_PrenomCAnim_TextChanged(object sender, EventArgs e)
        {
            filterRequerant();

            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur.Text = Prenom_CAnimateur_str;

            NomRequerant.Text = NomRequerant_str;
            PrenomRequerant.Text = PrenomRequerant_str;
            wilaya.SelectedValue = wilaya_str;
            sexe.SelectedValue = sexe_str;
            DateBirthday.Text = DateBirthday_str;
            Prenom_CAnimateur.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////
        bool linqRequerant1_updated = true;
        private static string NomRequerant_str = "";
        private static string PrenomRequerant_str = "";
        private static string wilaya_str = "";
        private static string sexe_str = "";
        private static string DateBirthday_str = "";
        private static string Nom_CAnimateur_str = "";
        private static string Prenom_CAnimateur_str = "";
        public void filterRequerant()
        {
            TextBox NomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox NomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox PrenomAgentAssocie = (TextBox)grid1.FooterRow.FindControl("TextBox53");

            Label LabelWilayaPro = (Label)grid1.FooterRow.FindControl("LabelWilayaPro");
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Build a request linq without the num_requete because it start sure without AND//
            //string linq = "from Request req.Request ";
            string linq = "select * from Requerant pro ";
            string where = " where(";
            string and = " and ";
            string linq1;
            if (isDGCell())
            {
                linq1 =
                 getSubStringLinqTextBoxRequerant(PrenomRequerant, "prenom_requerant")
                + getSubStringLinqDropDownListRequerant(wilaya, "id_wilaya")
                + getDateBirthRequerant(DateBirthday, "Date_Naissance")
                + getSubStringLinqDropDownListSexeRequerant(sexe, "SEXE")
                + getSubStringLinqTextBoxRequerant(NomAgentAssocie, "Nom_CAnimateur")
                + getSubStringLinqTextBoxRequerant(PrenomAgentAssocie, "Prenom_CAnimateur")
                + ")";
            }
            else
            {
                linq1 =
                 getSubStringLinqTextBoxRequerant(PrenomRequerant, "prenom_requerant")
                + getSubStringLinqLabelWilayaRequerant(LabelWilayaPro, "id_wilaya")
                + getDateBirthRequerant(DateBirthday, "Date_Naissance")
                + getSubStringLinqDropDownListSexeRequerant(sexe, "SEXE")
                + getSubStringLinqTextBoxRequerant(NomAgentAssocie, "Nom_CAnimateur")
                + getSubStringLinqTextBoxRequerant(PrenomAgentAssocie, "Prenom_CAnimateur")
                + ")";
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Built the request linq by adding the num_requete to the global request//
            string num_req_string = NomRequerant.Text;
            if (!(NomRequerant.Text.Equals("")))
            {
                if (linq1.Equals(")")) linq = linq + where + "pro.nom_requerant like '" + num_req_string + "%'" + linq1;
                else linq = linq + where + "pro.nom_requerant like '" + NomRequerant.Text + "%'" + and + linq1;
            }
            else
            {
                if (!linq1.Equals(")")) linq = linq + where + linq1;
            }

            NomRequerant_str = NomRequerant.Text;
            PrenomRequerant_str = PrenomRequerant.Text;
            wilaya_str = wilaya.Text;
            sexe_str = sexe.Text;
            DateBirthday_str = DateBirthday.Text;


            datasource = requerant_controller.getFilteredRequerant(linq);
            RqFound.Text = datasource.Count.ToString() + " Requerants";
            grid1.DataSourceID = null;
            grid1.DataSource = datasource;
            grid1.DataBind();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected string getSubStringLinqTextBoxRequerant(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + " like '" + a.Text + "%'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + " like '" + a.Text + "%'";
                    }


                }
            }
            return "";
        }
        protected string getSubStringLinqDropDownListRequerant(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + "=" + b.Text;
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + "=" + b.Text;
                    }

                }
            }
            return "";
        }
        protected string getSubStringLinqDropDownListSexeRequerant(DropDownList b, string field)
        {
            if (!(b.SelectedValue.Equals("0")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                return "pro." + field + "='" + b.SelectedItem + "'";
            }

            else
            {
                if (b.SelectedValue.Equals("0"))
                {
                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + "='" + b.SelectedItem + "'";
                    }

                }
            }
            return "";
        }
        protected string getDateBirthRequerant(TextBox a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;
                //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //return "reclam." + field + " >= '" + a.Text + "'";

                DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                return "pro." + field + " = '" + ff.ToString("MM/dd/yyyy") + "'";

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        //requete_controller.dateDu = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        //return " and " + "reclam." + field + " >=  '" + a.Text + "'";

                        DateTime ff = DateTime.ParseExact(a.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        return " and " + "pro." + field + " =  '" + ff.ToString("MM/dd/yyyy") + "'";
                    }


                }
            }
            return "";
        }
        protected string getSubStringLinqLabelWilayaRequerant(Label a, string field)
        {
            if (!(a.Text.Equals("")) && linqRequerant1_updated)
            {
                linqRequerant1_updated = false;

                return "pro." + field + " = " + wilaya_controller.getWilayaByName(a.Text).num;

            }
            else
            {
                if (a.Text.Equals(""))
                {

                    return "";
                }
                else
                {
                    if (!linqRequerant1_updated)
                    {
                        return " and pro." + field + " =" + wilaya_controller.getWilayaByName(a.Text).num;
                    }


                }
            }
            return "";
        }


        protected string getAgentWilaya()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);
            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));


            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return "";
                else return wilaya_claim.First().ClaimValue.ToString();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return "";
            }

        }
        protected Boolean isDGCell()
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindByName(Context.User.Identity.Name);

            var wilaya_claim = user.Claims.Where(cl => cl.ClaimType.Equals("wilaya"));
            try
            {
                if (wilaya_claim.First().ClaimValue.ToString().Equals("Cellule DG")) return true;
                else return false;
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Le système n'a pas pu trouvé la structure de cet agent');", true);
                return false;
            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        protected void DropDownList10_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid1.PageSize = Convert.ToInt32(DropDownList10.SelectedValue);
            filterRequerant();

        }



        protected bool IsGridEmpty(string num)
        {
            if (num.Equals(" ")) return false;
            else return true;
        }

        protected void grid1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            
            Label num_requerant = (Label)grid1.Rows[e.RowIndex].FindControl("Label30");
            TextBox nom_requerant = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox prenom_requerant = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox3");
            DropDownList wilaya = (DropDownList)grid1.Rows[e.RowIndex].FindControl("DropDownList1");
            DropDownList sexe = (DropDownList)grid1.Rows[e.RowIndex].FindControl("DropDownList2");
            TextBox date_naissance = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox15");
            TextBox Nom_CAnimateur = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox54");
            TextBox Prenom_CAnimateu = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox55");
            TextBox Address = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox4");
            TextBox Email = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox56");
            TextBox Tel = (TextBox)grid1.Rows[e.RowIndex].FindControl("TextBox57");

            requerant req = new requerant();
            req.num = num_requerant.Text;
            req.nom_requerant = nom_requerant.Text;
            req.prenom_requerant = prenom_requerant.Text;
            req.id_wilaya = Convert.ToInt32(wilaya.SelectedValue);
            req.SEXE = sexe.SelectedValue;
            req.Date_Naissance = DateTime.ParseExact(date_naissance.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            req.Nom_CAnimateur = Nom_CAnimateur.Text;
            req.Prenom_CAnimateur = Prenom_CAnimateu.Text;
            req.Adresse = Address.Text;
            req.Email = Email.Text;
            req.Tel = Tel.Text;

            requerant_controller.updateRequerant(req);
            grid1.EditIndex = -1;
            filterRequerant();
            GetFooterValues();

            
        }




        protected void GetFooterValues()
        {
            TextBox NomRequerant_footer = (TextBox)grid1.FooterRow.FindControl("TextBox30");
            TextBox PrenomRequerant_footer = (TextBox)grid1.FooterRow.FindControl("TextBox31");
            DropDownList wilaya_footer = (DropDownList)grid1.FooterRow.FindControl("DropDownList3");
            DropDownList sexe_footer = (DropDownList)grid1.FooterRow.FindControl("DropDownList4");
            TextBox DateBirthday_footer = (TextBox)grid1.FooterRow.FindControl("TextBox43");

            TextBox Nom_CAnimateur_footer = (TextBox)grid1.FooterRow.FindControl("TextBox52");
            TextBox Prenom_CAnimateur_footer = (TextBox)grid1.FooterRow.FindControl("TextBox53");
            Nom_CAnimateur_footer.Text = Nom_CAnimateur_str;
            Prenom_CAnimateur_footer.Text = Prenom_CAnimateur_str;

            NomRequerant_footer.Text = NomRequerant_str;
            PrenomRequerant_footer.Text = PrenomRequerant_str;
            wilaya_footer.SelectedValue = wilaya_str;
            sexe_footer.SelectedValue = sexe_str;
            DateBirthday_footer.Text = DateBirthday_str;
        }

        

        
        

        
    }

}