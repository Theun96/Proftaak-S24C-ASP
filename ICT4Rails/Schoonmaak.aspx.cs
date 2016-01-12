using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Data_Layer;
using ICT4Rails.Plugins;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Rails
{
    public partial class Schoonmaak : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllCleaners"], null);

            foreach (DataRow dr in dt.Rows)
            {
                DropDownUsers.Items.Add(dr["NAAM"].ToString());
            }
            DataTable dt2 = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetClean"], null);
            string[] columns = new string[] { "nummer", "DatumTijdstip", "BeschikbaarDatum", "Naam", "nummer", "TypeOnderhoud" };

            foreach (DataRow dr in dt2.Rows)
            {
                if (dr["Naam"].ToString() == "")
                {
                    DropDownTrams.Items.Add(dr["nummer"].ToString());
                    DropDownTrams2.Items.Add(dr["nummer"].ToString());
                }

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
                        if (dr["Naam"].ToString() == "")
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

        protected void ButtonCleaned_Click(object sender, EventArgs e)
        {
            OracleParameter[] parameters =
            {
                new OracleParameter("naam", DropDownUsers.SelectedValue),
                new OracleParameter("id", DropDownTrams.SelectedValue)
            };
            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["SetClean"], parameters);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ButtonSaveEndDate_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(datepicker.Text) && DropDownTrams2.SelectedValue != null)
            {
                //DateTime dt = Convert.ToDateTime(datepicker.Text);
                OracleParameter[] parameters =
                {
                    new OracleParameter("datum", datepicker.Text),
                    new OracleParameter("nummer", DropDownTrams2.SelectedValue)
                };
                DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["SetCleanDate"], parameters);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                MessageBox.Show("Geen tram of datum geselecteerd.");
            }
        }
    }
}