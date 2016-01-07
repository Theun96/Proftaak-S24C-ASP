using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Classes;
using ICT4Rails.Data_Layer;

namespace ICT4Rails
{
    public partial class Techniek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllEngineers"], null);

            foreach (DataRow dr in dt.Rows)
            {
                DropDownUsers.Items.Add(dr["NAAM"].ToString());
            }
        }

        protected void ButtonRepaired_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonSaveEndDate_Click(object sender, EventArgs e)
        {

        }
    }
}