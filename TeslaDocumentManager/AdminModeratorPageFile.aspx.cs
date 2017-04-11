using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeslaDocumentManager
{
    public partial class AdminModeratorPageFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void datagrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Admin a = new Admin();
            if (a.DeleteUser())
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

        protected void btnDodajDomen_Click(object sender, EventArgs e)
        {

        }

        protected void btnOdjava_Click(object sender, EventArgs e)
        {
            UserLogIn.LogOutUser(this.Response);
            Response.Redirect("~/LogIn.aspx");
        }
    }
}