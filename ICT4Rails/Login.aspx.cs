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
        private readonly ActiveDirectory _activedirectory = new ActiveDirectory();
        private bool Testing = false;

        protected void Page_Load(object sender, EventArgs e)
        {}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Testing)
            {
                Session["User"] = "admin";
            }
            else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                bool valid = _activedirectory.Authenticate(username, password);
                if (valid)
                {
                    Session["User"] = username;
                    Response.Redirect("/");
                }
                else
                {
                    lblWrong.Visible = true;
                }
            }
        }
    }
}