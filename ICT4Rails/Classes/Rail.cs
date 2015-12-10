using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4Rails.Classes
{
    public class Rail
    {
        Label RailLabel = new Label();

        public int Nummer { get; private set; }
        public string GridLocation { get; private set; }

        public Rail(int nummer)
        {
            Nummer = nummer;
            GridLocationMethod();
            //RailLabel.Click += new EventHandler(Rail_Click);
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
            }
        }
        
        public Label AddRailLabel()
        {
            //RailLabel.Dock = DockStyle.Fill;
            //RailLabel.Margin = new Padding(1);

            RailLabel.Text = Nummer.ToString();
            RailLabel.ID = GridLocation;
            RailLabel.CssClass = "railDefault"; 

            return RailLabel;
        }
        
        /*
        private void Rail_Click(object sender, EventArgs e)
        {
            List<Sector> allSectors = new List<Sector>();
            List<Sector> sectorsFromRail = new List<Sector>();
            BeheerSysteemForm form = new BeheerSysteemForm();

            //list van alle sectoren
            if (sender is Label)
            {
                Label label = (Label)sender;
                if (label.Parent.Parent is BeheerSysteemForm)
                {
                    form = (BeheerSysteemForm)label.Parent.Parent;
                    allSectors = form.Sectors;
                }
            }

            //list van alle sectoren van huidige rail
            foreach (Sector s in allSectors)
            {
                if (s.Rail.Id.ToString() == Id.ToString() && !string.IsNullOrEmpty(s.SectorInformation))
                {
                    sectorsFromRail.Add(s);
                }
            }

            sectorsFromRail.Sort();

            //tellen hoeveel sectoren er zijn
            int totalPostitions = sectorsFromRail.Count;

            for (int i = 0; i < totalPostitions; i++)
            {
                if (!sectorsFromRail[i].Available)
                {
                    break;
                }

                if (sectorsFromRail[i].Position < totalPostitions)
                {
                    sectorsFromRail[i].SectorInformation = sectorsFromRail[i + 1].SectorInformation;

                    OracleParameter[] parameters1 = new OracleParameter[]
                    {
                        new OracleParameter("sectorinformation", sectorsFromRail[i + 1].SectorInformation),
                        new OracleParameter("railid", Id),
                        new OracleParameter("position", sectorsFromRail[i].Position)
                    };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateSectorInformation"], parameters1);
                }

                if (sectorsFromRail[i].Position == totalPostitions)
                {
                    sectorsFromRail[i].SectorInformation = "";

                    OracleParameter[] parameters1 = new OracleParameter[]
                    {
                        new OracleParameter("railid", Id),
                        new OracleParameter("position", sectorsFromRail[i].Position)
                    };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.Query["UpdateLastSectorInformation"], parameters1);
                }
            }

            form.GetAllSectors();
            /*
            //messagebox for sectorfromrail
            foreach (Sector s in sectorsFromRail)
            {
                MessageBox.Show(s.Rail.Id.ToString() + " - " + s.Position.ToString() + " - " + s.SectorInformation);
            }*/
    }
}
