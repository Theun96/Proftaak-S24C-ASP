using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Plugins;

namespace ICT4Rails
{
    public partial class RailInformation : System.Web.UI.Page
    {
        private int Id { get; set; }
        private int Nummer { get; set; }

        private bool Blokkade { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            string idstring = Request.QueryString["id"];
            int id;
            if (idstring == null) Response.Redirect("/");
            bool valid = int.TryParse(idstring, out id);
            if (!valid) Response.Redirect("/");
            Id = id;
            
            try
            {
                OracleParameter[] parameters =
                {
                    new OracleParameter("id", Id)
                };

                DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetSpecificSector"], parameters);

                foreach (DataRow dr in dt.Rows)
                {
                    Id = Convert.ToInt32(dr["ID"]);
                    Nummer = Convert.ToInt32(dr["Nummer"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            
            BlokkeerInformation();
            if (!IsPostBack)
            {
                //TramToevoegInformation();
            }
        }

        private void BlokkeerInformation()
        {
            btnRailBlokkeren.Text = Blokkade ? "Deblokkeren" : "Blokkeren";
            lblRailBlokkade.Text = !Blokkade ? "Blokkeer Spoor: " + Nummer : "Spoor: " + Nummer + " is Geblokkeerd!";

            if (Blokkade)
            {
                tbTramReserveren.Enabled = false;
                btnTramReserveren.Enabled = false;
            }
            else
            {
                tbTramReserveren.Enabled = true;
                btnTramReserveren.Enabled = true;
            }
        }

        protected void btnRailBlokkeren_Click(object sender, EventArgs e)
        {
            OracleParameter[] parameter =
            {
                new OracleParameter("spoorid", Id)
            };

            DataTable tramsOnRailDataTable =
                DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetRailTrams"], parameter);

            DataTable getAmountOfSectorDataTable =
                DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAmountOfSectors"], parameter);
            DataTable checkBlockedDataTable =
                DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["CheckRailBlocked"], parameter);

            if (tramsOnRailDataTable.Rows.Count != 0) return;

            foreach (DataRow dr in getAmountOfSectorDataTable.Rows)
            {
                if (Convert.ToInt32(dr[0]) == checkBlockedDataTable.Rows.Count)
                {
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["BlokkeerRail"], parameter);

                    //HttpContext.Current.Response.Redirect("/Beheer.aspx");
                    Blokkade = true;
                    BlokkeerInformation();
                }
                else
                {
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["DeBlokkeerRail"], parameter);

                    //HttpContext.Current.Response.Redirect("/Beheer.aspx");
                    Blokkade = false;
                    BlokkeerInformation();
                }
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("/Beheer.aspx");
        }

        protected void btnTramReserveren_Click(object sender, EventArgs e)
        {

        }
    }
}