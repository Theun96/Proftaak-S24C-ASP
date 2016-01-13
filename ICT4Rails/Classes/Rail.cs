using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4Rails.Classes
{
    public class Rail
    {
        private readonly LinkButton _railLabel = new LinkButton();
        private readonly Label _railLijnLabel = new Label();

        public int Id { get; private set; }
        public int Nummer { get; private set; }
        public string GridLocation { get; private set; }

        public string Lijn { private get; set; }
        public string GridLocationLijn { get; private set; }

        public Rail(int railId, int nummer)
        {
            Id = railId;
            Nummer = nummer;
            GridLocationMethod();
            GridLocationMethodLijn();
        }

        private void GridLocationMethod()
        {
            switch (Nummer)
            {
                case 38:
                    GridLocation = "0_0";
                    break;
                case 37:
                    GridLocation = "1_0";
                    break;
                case 36:
                    GridLocation = "2_0";
                    break;
                case 35:
                    GridLocation = "3_0";
                    break;
                case 34:
                    GridLocation = "4_0";
                    break;
                case 33:
                    GridLocation = "5_0";
                    break;
                case 32:
                    GridLocation = "6_0";
                    break;
                case 31:
                    GridLocation = "7_0";
                    break;
                case 30:
                    GridLocation = "8_0";
                    break;
                case 40:
                    GridLocation = "10_0";
                    break;
                case 41:
                    GridLocation = "11_0";
                    break;
                case 42:
                    GridLocation = "12_0";
                    break;
                case 43:
                    GridLocation = "13_0";
                    break;
                case 44:
                    GridLocation = "14_0";
                    break;
                case 45:
                    GridLocation = "16_0";
                    break;
                case 58:
                    GridLocation = "18_0";
                    break;
                case 57:
                    GridLocation = "0_13";
                    break;
                case 56:
                    GridLocation = "1_13";
                    break;
                case 55:
                    GridLocation = "2_13";
                    break;
                case 54:
                    GridLocation = "3_13";
                    break;
                case 53:
                    GridLocation = "4_13";
                    break;
                case 52:
                    GridLocation = "5_13";
                    break;
                case 51:
                    GridLocation = "6_13";
                    break;
                case 64:
                    GridLocation = "7_13";
                    break;
                case 63:
                    GridLocation = "8_13";
                    break;
                case 62:
                    GridLocation = "9_13";
                    break;
                case 61:
                    GridLocation = "10_13";
                    break;
                case 74:
                    GridLocation = "12_13";
                    break;
                case 75:
                    GridLocation = "13_13";
                    break;
                case 76:
                    GridLocation = "14_13";
                    break;
                case 77:
                    GridLocation = "15_13";
                    break;
                case 12:
                    GridLocation = "17_13";
                    break;
                case 13:
                    GridLocation = "17_14";
                    break;
                case 14:
                    GridLocation = "17_15";
                    break;
                case 15:
                    GridLocation = "17_16";
                    break;
                case 16:
                    GridLocation = "17_17";
                    break;
                case 17:
                    GridLocation = "17_18";
                    break;
                case 18:
                    GridLocation = "17_19";
                    break;
                case 19:
                    GridLocation = "17_20";
                    break;
                case 20:
                    GridLocation = "17_21";
                    break;
                case 21:
                    GridLocation = "17_22";
                    break;
                default:
                    break;
            }
        }

        private void GridLocationMethodLijn()
        {
            switch (Nummer)
            {
                case 38:
                    GridLocationLijn = "0_1";
                    break;
                case 37:
                    GridLocationLijn = "1_1";
                    break;
                case 36:
                    GridLocationLijn = "2_1";
                    break;
                case 35:
                    GridLocationLijn = "3_1";
                    break;
                case 34:
                    GridLocationLijn = "4_1";
                    break;
                case 33:
                    GridLocationLijn = "5_1";
                    break;
                case 32:
                    GridLocationLijn = "6_1";
                    break;
                case 31:
                    GridLocationLijn = "7_1";
                    break;
                case 30:
                    GridLocationLijn = "8_1";
                    break;
                case 40:
                    GridLocationLijn = "10_1";
                    break;
                case 41:
                    GridLocationLijn = "11_1";
                    break;
                case 42:
                    GridLocationLijn = "12_1";
                    break;
                case 43:
                    GridLocationLijn = "13_1";
                    break;
                case 44:
                    GridLocationLijn = "14_1";
                    break;
                case 45:
                    GridLocationLijn = "16_1";
                    break;
                case 58:
                    GridLocationLijn = "18_1";
                    break;
                case 57:
                    GridLocationLijn = "0_14";
                    break;
                case 56:
                    GridLocationLijn = "1_14";
                    break;
                case 55:
                    GridLocationLijn = "2_14";
                    break;
                case 54:
                    GridLocationLijn = "3_14";
                    break;
                case 53:
                    GridLocationLijn = "4_14";
                    break;
                case 52:
                    GridLocationLijn = "5_14";
                    break;
                case 51:
                    GridLocationLijn = "6_14";
                    break;
                case 64:
                    GridLocationLijn = "7_14";
                    break;
                case 63:
                    GridLocationLijn = "8_14";
                    break;
                case 62:
                    GridLocationLijn = "9_14";
                    break;
                case 61:
                    GridLocationLijn = "10_14";
                    break;
                default:
                    break;
            }
        }

        public LinkButton AddRailLabel()
        {
            _railLabel.Text = Nummer.ToString();
            _railLabel.ID = GridLocation;
            _railLabel.CssClass = "railDefault";

            _railLabel.Click += Rail_Click;

            return _railLabel;
        }

        public Label AddRailLijnLabel()
        {
            _railLijnLabel.Text = Lijn;
            _railLijnLabel.ID = GridLocationLijn;
            _railLijnLabel.CssClass = "lijnDefault";

            return _railLijnLabel;
        }

        private void Rail_Click(object sender, EventArgs e)
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

                    HttpContext.Current.Response.Redirect("/Beheer.aspx");
                }
                else
                {
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["DeBlokkeerRail"], parameter);

                    HttpContext.Current.Response.Redirect("/Beheer.aspx");
                }
            }
        }
    }
}