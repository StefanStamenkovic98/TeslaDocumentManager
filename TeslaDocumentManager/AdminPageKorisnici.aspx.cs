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
            lblOperater.Text = UserLogIn.UserLoggedIn(this.Request).FullName;
            Admin a = new Admin();
            if(a.LoadAllUsers())
            {
                datagrid.DataSource = a.AllUsers;
                datagrid.DataBind();
                /*if (a.LoadUserGroupList())
                {
                    ddlAccessLevel.DataSource = a.UserGroupsList;
                    ddlAccessLevel.DataValueField = "Id";
                    ddlAccessLevel.DataTextField = "Name";
                    ddlAccessLevel.DataBind();
                }*/
            }
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
                datagrid.DataSource = a.LoadAllUsers();
                datagrid.DataBind();
            }
            else
            {
                error_message.Text = a.Message;
            }
        }

    }
}