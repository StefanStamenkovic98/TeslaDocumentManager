using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TeslaDocumentManager
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*lblOperater.Text = UserLogIn.UserLoggedIn(this.Request).FullName;
            Admin a = new Admin();
            if(a.LoadAllUsers())
            {
                datagrid.DataSource = a.AllUsers;
                datagrid.DataBind();
            }*/
        }

        protected void lnkOdjava_Click(object sender, EventArgs e)
        {
            UserLogIn.LogOutUser(this.Response);
            Response.Redirect("~/LogIn.aspx");
        }


        protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Admin a = new Admin();
            a.Id = ((HiddenField)datagrid.Rows[e.RowIndex].FindControl("Id")).Value;
            if(a.DeleteUser())
            {
                datagrid.DataSource = null;
                UserLogIn user = new UserLogIn();
                if (user.LoadAllUsers())
                {
                    datagrid.DataSource = user.AllUsers;
                    datagrid.DataBind();
                }
            }
            else
            {
                error_message.Text = a.Message;
            }
        }

        protected void datagrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Admin a = new Admin();
            a.Id = ((HiddenField)datagrid.Rows[e.NewEditIndex].FindControl("Id")).Value;
            Session["UserID"] = a.Id;
            Response.Redirect("~/UpdateUser.aspx");
        }

        protected void btnDodajKorisnika_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SaveUser.aspx");
        }
    }
}