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
    public class Sector
    {
        LinkButton _sectorLabel = new LinkButton();

        public int ID { get; private set; }
        public Rail Rail { get; private set; }
        public string Tram_ID { get; private set; }
        public int Nummer { get; private set; }
        public bool Beschikbaar { get; private set; }
        public bool Blokkade { get; private set; }

        public string SectorInformation { get; private set; }
        public string GridLocation { get; private set; }

        public Sector(int id, Rail rail, string tram_id, int nummer, bool beschikbaar, bool blokkade)
        {
            ID = id;
            Rail = rail;
            Tram_ID = tram_id;
            Nummer = nummer;
            Beschikbaar = beschikbaar;
            Blokkade = blokkade;

            CheckSectorInformation(Tram_ID);

            GridLocationMethod();
        }

        private void GridLocationMethod()
        {
            switch (Rail.Nummer)
            {
                case 38:
                    GridLocation = $"0_{(Nummer + 1).ToString()}";
                    break;
                case 37:
                    GridLocation = $"1_{(Nummer + 1).ToString()}";
                    break;
                case 36:
                    GridLocation = $"2_{(Nummer + 1).ToString()}";
                    break;
                case 35:
                    GridLocation = $"3_{(Nummer + 1).ToString()}";
                    break;
                case 34:
                    GridLocation = $"4_{(Nummer + 1).ToString()}";
                    break;
                case 33:
                    GridLocation = $"5_{(Nummer + 1).ToString()}";
                    break;
                case 32:
                    GridLocation = $"6_{(Nummer + 1).ToString()}";
                    break;
                case 31:
                    GridLocation = $"7_{(Nummer + 1).ToString()}";
                    break;
                case 30:
                    GridLocation = $"8_{(Nummer + 1).ToString()}";
                    break;
                case 40:
                    GridLocation = $"10_{(Nummer + 1).ToString()}";
                    break;
                case 41:
                    GridLocation = $"11_{(Nummer + 1).ToString()}";
                    break;
                case 42:
                    GridLocation = $"12_{(Nummer + 1).ToString()}";
                    break;
                case 43:
                    GridLocation = $"13_{(Nummer + 1).ToString()}";
                    break;
                case 44:
                    GridLocation = $"14_{(Nummer + 1).ToString()}";
                    break;
                case 45:
                    GridLocation = $"16_{(Nummer + 1).ToString()}";
                    break;
                case 58:
                    GridLocation = $"18_{(Nummer + 1).ToString()}";
                    break;
                case 57:
                    GridLocation = $"0_{(Nummer + 14).ToString()}";
                    break;
                case 56:
                    GridLocation = $"1_{(Nummer + 14).ToString()}";
                    break;
                case 55:
                    GridLocation = $"2_{(Nummer + 14).ToString()}";
                    break;
                case 54:
                    GridLocation = $"3_{(Nummer + 14).ToString()}";
                    break;
                case 53:
                    GridLocation = $"4_{(Nummer + 14).ToString()}";
                    break;
                case 52:
                    GridLocation = $"5_{(Nummer + 14).ToString()}";
                    break;
                case 51:
                    GridLocation = $"6_{(Nummer + 14).ToString()}";
                    break;
                case 64:
                    GridLocation = $"7_{(Nummer + 14).ToString()}";
                    break;
                case 63:
                    GridLocation = $"8_{(Nummer + 14).ToString()}";
                    break;
                case 62:
                    GridLocation = $"9_{(Nummer + 14).ToString()}";
                    break;
                case 61:
                    GridLocation = $"10_{(Nummer + 14).ToString()}";
                    break;
                case 74:
                    GridLocation = $"12_{(Nummer + 13).ToString()}";
                    break;
                case 75:
                    GridLocation = $"13_{(Nummer + 13).ToString()}";
                    break;
                case 76:
                    GridLocation = $"14_{(Nummer + 13).ToString()}";
                    break;
                case 77:
                    GridLocation = $"15_{(Nummer + 13).ToString()}";
                    break;
                case 12:
                    GridLocation = $"18_{(Nummer + 12).ToString()}";
                    break;
                case 13:
                    GridLocation = $"18_{(Nummer + 13).ToString()}";
                    break;
                case 14:
                    GridLocation = $"18_{(Nummer + 14).ToString()}";
                    break;
                case 15:
                    GridLocation = $"18_{(Nummer + 15).ToString()}";
                    break;
                case 16:
                    GridLocation = $"18_{(Nummer + 16).ToString()}";
                    break;
                case 17:
                    GridLocation = $"18_{(Nummer + 17).ToString()}";
                    break;
                case 18:
                    GridLocation = $"18_{(Nummer + 18).ToString()}";
                    break;
                case 19:
                    GridLocation = $"18_{(Nummer + 19).ToString()}";
                    break;
                case 20:
                    GridLocation = $"18_{(Nummer + 20).ToString()}";
                    break;
                case 21:
                    GridLocation = $"18_{(Nummer + 21).ToString()}";
                    break;
                default:
                    return;
            }
        }

        public int CompareTo(Sector s)
        {
            if (Nummer < s.Nummer)
            {
                return -1;
            }
            return Nummer == s.Nummer ? 0 : 1;
        }

        public LinkButton AddSectorLabel()
        {
            _sectorLabel.Text = SectorInformation;
            _sectorLabel.ID = GridLocation;
            _sectorLabel.CssClass = "sectorDefault";

            _sectorLabel.Click += new EventHandler(Sector_Click);
            /*
            int parameterint = 3;

            if (SectorInformation == "" || SectorInformation == "X")
            {
                parameterint = 3;
            }
            else
            {
                parameterint = Convert.ToInt32(SectorInformation);
            }

            OracleParameter[] parameters1 = new OracleParameter[]
            {
                new OracleParameter("tramid", parameterint)
            };

            DataTable DT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTramStatus"], parameters1);
            
            string tramID = "";
            const int type = 3;
            if (type == 0)
            {
                _sectorLabel.BackColor = Color.Yellow;
            }

            if (type == 1)
            {
                _sectorLabel.BackColor = Color.Orange;
            }

            if (Reserved)
            {
                _sectorLabel.ForeColor = Color.Green;
            }

            if (!Beschikbaar)
            {
                _sectorLabel.ForeColor = Color.White;
                _sectorLabel.BackColor = Color.Black;
            }
            */
            return _sectorLabel;
        }
        /*
        private void Sector_Click(object sender, EventArgs e)
        {
            SectorPropertiesForm spf = new SectorPropertiesForm(Available, Position, Rail.Id, SectorInformation, Reserved);
            spf.ShowDialog();

            if (sender is Label)
            {
                Label label = (Label)sender;
                if (label.Parent.Parent is BeheerSysteemForm)
                {
                    BeheerSysteemForm form = (BeheerSysteemForm)label.Parent.Parent;
                    form.GetAllSectors();
                }
            }
        }
        */
        private void CheckSectorInformation(string tram_Id)
        {
            OracleParameter[] parameters1 =
            {
                new OracleParameter("id", tram_Id)
            };

            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTramNummer"], parameters1);
            
            foreach (DataRow dr in dt.Rows)
            {
                int nummer = Convert.ToInt32(dr["Nummer"]);

                if (nummer != 0)
                {
                    SectorInformation = !Beschikbaar ? "X" : nummer.ToString();
                }

            }
        }

        private static void Sector_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Response.Redirect("/");
        }
    }
}