using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeslaDocumentManager
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUser.Text = UserLogIn.UserLoggedIn(this.Request).FullName;
        }

        protected void btnOdjava_Click(object sender, EventArgs e)
        {
            UserLogIn.LogOutUser(this.Response);
            Response.Redirect("~/LogIn.aspx");
        }

        protected void btnDodajFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EnterFile.aspx");
        }
    }
}