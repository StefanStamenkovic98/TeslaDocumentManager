using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TeslaDocumentManager
{
    public partial class SaveUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*lblOperater.Text = UserLogIn.UserLoggedIn(this.Request).FullName;
            Admin a = new Admin();
            if (a.LoadUserGroupList())
            {
                ddlAccessLevel.DataSource = a.UserGroupsList;
                ddlAccessLevel.DataValueField = "Id";
                ddlAccessLevel.DataTextField = "Name";
                ddlAccessLevel.DataBind();
            }*/
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(tbxUsername.Text == string.Empty | tbxPassword.Text == string.Empty || tbxEmail.Text== string.Empty)
            {
                error_message.Text = "Niste popunili Username i/ili Email";
                error_message.ForeColor = System.Drawing.Color.Red;
                return;
            }
            error_message.Text = "";
            Admin a = new Admin();
            a.UserName = tbxUsername.Text;
            a.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(tbxPassword.Text, "SHA1");
            a.Email = tbxEmail.Text;
            a.FullName = tbxFullname.Text;
            a.UserGroupId = ddlAccessLevel.SelectedValue;
            a.Active = cbxActive.Checked;
            a.Phone = tbxPhone.Text;
            a.Note = tbxNote.Text;
            if (!a.CheckUserName(a.UserName))
            {
                error_message.Text = "Promeni username-";
            }
            else error_message.Text = "";
            if (!a.CheckUserName(a.Email))
            {
                error_message.Text += "Promeni email";
            }
            if (error_message.Text != string.Empty)
                error_message.ForeColor = System.Drawing.Color.Red;
            if (error_message.Text == string.Empty)
            {
                if (a.CreateUser())
                {
                    Response.Redirect("~/AdminPageKorisnici.aspx");
                }
                else
                {
                    error_message.Text = "User nije kreiran.";
                }
            }
            else return;
        }

        protected void btnKorisnici_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPageKorisnici.aspx");
        }
    }
}