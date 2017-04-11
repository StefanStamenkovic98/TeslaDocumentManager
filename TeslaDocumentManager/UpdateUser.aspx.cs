using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace TeslaDocumentManager
{
    public partial class AdminPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            /*lblOperater.Text = UserLogIn.UserLoggedIn(this.Request).FullName;
            if (!this.IsPostBack)
            {
                if (Session["UserID"] == null)
                    Response.Redirect("~/AdminPageKorisnici.aspx");
                tbxUsername.Enabled = false;
                tbxEmail.Enabled = false;
                tbxPassword.Enabled = false;
                Admin a = new Admin();
                if (a.LoadUserGroupList())
                {
                    ddlAccessLevel.DataSource = a.UserGroupsList;
                    ddlAccessLevel.DataValueField = "Id";
                    ddlAccessLevel.DataTextField = "Name";
                    ddlAccessLevel.DataBind();
                }
                a.Id = Session["UserID"].ToString();
                UserLogIn user = a.UserPretraga();
                tbxUsername.Text = user.UserName;
                tbxFullname.Text = user.FullName;
                tbxEmail.Text = user.Email;
                cbxActive.Checked = user.Active;
                tbxPhone.Text = user.Phone;
                tbxNote.Text = user.Note;
                a.LoadUserGroupList();
                ddlAccessLevel.DataSource = a.UserGroupsList;
                ddlAccessLevel.DataValueField = "Id";
                ddlAccessLevel.DataTextField = "Name";
                int i = 0;
                foreach (ListItem x in ddlAccessLevel.Items)
                {
                    if (x.Value.ToString() == user.UserGroupId)
                    {
                        ddlAccessLevel.Items[i].Selected = true;
                        break;
                    }
                    i++;
                }
            }*/
        }

        protected void btnKorisnici_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPageKorisnici.aspx");
        }

        protected void lnkOdjava_Click(object sender, EventArgs e)
        {
            UserLogIn.LogOutUser(this.Response);
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            error_message.Text = "";
            Admin a = new Admin();
            a.Id = Session["UserID"].ToString();
            if (cbxPass.Checked == true)
                a.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(tbxPassword.Text, "SHA1");
            else a.Password = "";
            a.FullName = tbxFullname.Text;
            a.UserGroupId = ddlAccessLevel.SelectedValue;
            a.Active = cbxActive.Checked;
            a.Phone = tbxPhone.Text;
            a.Note = tbxNote.Text;            
            if (a.UpdateUser())
            {
                Response.Redirect("~/AdminPageKorisnici.aspx");
            }
            else
            {
                error_message.Text = "User nije kreiran.";
            }
        }
    }
}