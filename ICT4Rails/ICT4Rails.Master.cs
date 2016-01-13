using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Rails
{
    public partial class Ict4Rails : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) return;
            LoggedInPH.Visible = true;
            AnonymousPH.Visible = false;
        }

        protected void btnLogout_OnClick(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("/");
        }
    }
}