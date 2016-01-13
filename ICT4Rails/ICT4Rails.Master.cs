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
            if (Session["User"] != null)
            {
                LoggedInPH.Visible = true;
                AnonymousPH.Visible = false;

                navBeheer.Visible = true;
                navInUitRij.Visible = true;
                navSchoonmaak.Visible = true;
                navTechniek.Visible = true;
            }
        }
    }
}