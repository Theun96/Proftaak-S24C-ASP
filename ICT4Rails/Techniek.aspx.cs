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


            DataTable dt2 = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTech"], null);
            string[] columns = new string[] {"nummer", "DatumTijdstip", "BeschikbaarDatum", "Naam", "nummer", "TypeOnderhoud"};

            foreach (DataRow dr in dt2.Rows)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < 6; i++)
                {
                    if (i != 4)
                    {
                        TableCell c = new TableCell
                        {
                            Text = dr[columns[i]].ToString()
                        };
                        r.Cells.Add(c);
                    }
                    else
                    {
                        string done = "Ja";
                        if (dr["Naam"] == null)
                        {
                            done = "Nee";
                        }
                        TableCell c = new TableCell
                        {
                            Text = done
                        };
                        r.Cells.Add(c);
                    }
                }
                table.Rows.Add(r);
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