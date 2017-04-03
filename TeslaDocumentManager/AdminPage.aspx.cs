using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeslaDocumentManager
{
    public partial class AdminPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}