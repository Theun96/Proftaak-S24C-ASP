using ICT4Rails.Data_Layer;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4Rails.Classes
{
    public class Rail
    {
        Label RailLabel = new Label();

        public int ID { get; private set; }
        public string GridLocation { get; private set; }

        public Rail(int id)
        {
            ID = id;
            GridLocationMethod();
            //RailLabel.Click += new EventHandler(Rail_Click);
        }

        private void GridLocationMethod()
        {
            switch (ID)
            {
                case 38:
                    GridLocation = "0 0";
                    break;
                case 37:
                    GridLocation = "1 0";
                    break;
                case 36:
                    GridLocation = "2 0";
                    break;
                case 35:
                    GridLocation = "3 0";
                    break;
                case 34:
                    GridLocation = "4 0";
                    break;
                case 33:
                    GridLocation = "5 0";
                    break;
                case 32:
                    GridLocation = "6 0";
                    break;
                case 31:
                    GridLocation = "7 0";
                    break;
                case 30:
                    GridLocation = "8 0";
                    break;
                case 40:
                    GridLocation = "10 0";
                    break;
                case 41:
                    GridLocation = "11 0";
                    break;
                case 42:
                    GridLocation = "12 0";
                    break;
                case 43:
                    GridLocation = "13 0";
                    break;
                case 44:
                    GridLocation = "14 0";
                    break;
                case 45:
                    GridLocation = "16 0";
                    break;
                case 58:
                    GridLocation = "18 0";
                    break;
                case 57:
                    GridLocation = "0 13";
                    break;
                case 56:
                    GridLocation = "1 13";
                    break;
                case 55:
                    GridLocation = "2 13";
                    break;
                case 54:
                    GridLocation = "3 13";
                    break;
                case 53:
                    GridLocation = "4 13";
                    break;
                case 52:
                    GridLocation = "5 13";
                    break;
                case 51:
                    GridLocation = "6 13";
                    break;
                case 64:
                    GridLocation = "7 13";
                    break;
                case 63:
                    GridLocation = "8 13";
                    break;
                case 62:
                    GridLocation = "9 13";
                    break;
                case 61:
                    GridLocation = "10 13";
                    break;
                case 74:
                    GridLocation = "12 13";
                    break;
                case 75:
                    GridLocation = "13 13";
                    break;
                case 76:
                    GridLocation = "14 13";
                    break;
                case 77:
                    GridLocation = "15 13";
                    break;
                case 12:
                    GridLocation = "17 13";
                    break;
                case 13:
                    GridLocation = "17 14";
                    break;
                case 14:
                    GridLocation = "17 15";
                    break;
                case 15:
                    GridLocation = "17 16";
                    break;
                case 16:
                    GridLocation = "17 17";
                    break;
                case 17:
                    GridLocation = "17 18";
                    break;
                case 18:
                    GridLocation = "17 19";
                    break;
                case 19:
                    GridLocation = "17 20";
                    break;
                case 20:
                    GridLocation = "17 21";
                    break;
                case 21:
                    GridLocation = "17 22";
                    break;
            }
        }
        /*
        public Label AddRailLabel()
        {
            RailLabel.Dock = DockStyle.Fill;
            RailLabel.Margin = new Padding(1);

            RailLabel.Text = ID.ToString();

            RailLabel.ForeColor = Color.Black;
            RailLabel.TextAlign = ContentAlignment.MiddleCenter;
            RailLabel.Tag = GridLocation;
            RailLabel.BackColor = Color.Gray;

            return RailLabel;
        }


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
                if (s.Rail.ID.ToString() == ID.ToString() && !string.IsNullOrEmpty(s.SectorInformation))
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
                        new OracleParameter("railid", ID),
                        new OracleParameter("position", sectorsFromRail[i].Position)
                    };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.query["UpdateSectorInformation"], parameters1);
                }

                if (sectorsFromRail[i].Position == totalPostitions)
                {
                    sectorsFromRail[i].SectorInformation = "";

                    OracleParameter[] parameters1 = new OracleParameter[]
                    {
                        new OracleParameter("railid", ID),
                        new OracleParameter("position", sectorsFromRail[i].Position)
                    };
                    DatabaseManager.ExecuteInsertQuery(DatabaseQuerys.query["UpdateLastSectorInformation"], parameters1);
                }
            }

            form.GetAllSectors();
            /*
            //messagebox for sectorfromrail
            foreach (Sector s in sectorsFromRail)
            {
                MessageBox.Show(s.Rail.ID.ToString() + " - " + s.Position.ToString() + " - " + s.SectorInformation);
            }*/
    }
}
