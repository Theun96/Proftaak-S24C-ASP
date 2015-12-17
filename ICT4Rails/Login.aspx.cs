using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Data_Layer;
using System.DirectoryServices.AccountManagement;

namespace ICT4Rails
{
    public partial class Login : System.Web.UI.Page
    {
        private DatabaseManager _databaseManager = new DatabaseManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "pts18"))
            {
                // validate the credentials
                bool isValid = pc.ValidateCredentials("l.vankeulen", "test");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}