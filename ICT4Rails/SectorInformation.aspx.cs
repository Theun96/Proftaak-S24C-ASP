using ICT4Rails.Classes;
using ICT4Rails.Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Plugins;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Rails
{
    public partial class SectorInformation : System.Web.UI.Page
    {
        private int Id {get; set; }
        private string TramNummer { get; set; }
        private int Nummer { get; set; }
        private bool Beschikbaar { get; set; }

        private bool Blokkade
        {
            get { return (bool) ViewState["Blokkade"]; }
            set { ViewState["Blokkade"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string idstring = Request.QueryString["id"];
            int id;
            if(idstring == null) Response.Redirect("/");
            bool valid = int.TryParse(idstring, out id);
            if(!valid) Response.Redirect("/");
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
                    Id = Convert.ToInt32(dr["Spoor_ID"]);

                    TramNummer = (dr["Tram_Nummer"]).ToString() != "" ? (dr["Tram_Nummer"]).ToString() : "";

                    Nummer = Convert.ToInt32(dr["Nummer"]);
                    var available = Convert.ToInt32(dr["Beschikbaar"]);
                    var geblokkeerd = Convert.ToInt32(dr["Blokkade"]);

                    Beschikbaar = available == 1;

                    Blokkade = geblokkeerd == 1;
                }
            }
            catch (Exception)
            {
                throw;
            }

            BlokkeerInformation();
        }

        private void BlokkeerInformation()
        {
            btnBlokkeren.Text = Blokkade ? "Deblokkeren" : "Blokkeren";
            lblBlokkade.Text = !Blokkade ? "Blokkeer Sector: " + Nummer : "Sector: " + Nummer + " is Geblokkeerd!";
        }

        protected void btnBlokkeren_Click(object sender, EventArgs e)
        {
            Blokkade = !Blokkade;

            
            OracleParameter[] parameters =
                {
                    new OracleParameter("blokkade", Blokkade),
                    new OracleParameter("id", Id)
                };

            DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query[""], parameters);
            

            BlokkeerInformation();
        }
    }
}