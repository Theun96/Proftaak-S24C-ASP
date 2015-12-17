using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI.WebControls;

namespace ICT4Rails.Classes
{
    public class Sector
    {
        System.Web.UI.WebControls.Label SectorLabel;

        public Rail Rail { get; private set; }
        public int Position { get; private set; }
        public string GridLocation { get; private set; }
        public string SectorInformation { get; set; }
        public bool Available { get; set; }
        public bool Reserved { get; set; }

        public Sector(Rail rail, int position, bool available, string tramID, bool reserved)
        {
            Rail = rail;
            Position = position;
            Available = available;
            Reserved = reserved;

            CheckSectorInformation(tramID);

            GridLocationMethod();
        }

        private void GridLocationMethod()
        {
            switch (Rail.ID)
            {
                case 38:
                    GridLocation = $"0 {(Position + 1).ToString()}";
                    break;
                case 37:
                    GridLocation = $"1 {(Position + 1).ToString()}";
                    break;
                case 36:
                    GridLocation = $"2 {(Position + 1).ToString()}";
                    break;
                case 35:
                    GridLocation = $"3 {(Position + 1).ToString()}";
                    break;
                case 34:
                    GridLocation = $"4 {(Position + 1).ToString()}";
                    break;
                case 33:
                    GridLocation = $"5 {(Position + 1).ToString()}";
                    break;
                case 32:
                    GridLocation = $"6 {(Position + 1).ToString()}";
                    break;
                case 31:
                    GridLocation = $"7 {(Position + 1).ToString()}";
                    break;
                case 30:
                    GridLocation = $"8 {(Position + 1).ToString()}";
                    break;
                case 40:
                    GridLocation = $"10 {(Position + 1).ToString()}";
                    break;
                case 41:
                    GridLocation = $"11 {(Position + 1).ToString()}";
                    break;
                case 42:
                    GridLocation = $"12 {(Position + 1).ToString()}";
                    break;
                case 43:
                    GridLocation = $"13 {(Position + 1).ToString()}";
                    break;
                case 44:
                    GridLocation = $"14 {(Position + 1).ToString()}";
                    break;
                case 45:
                    GridLocation = $"16 {(Position + 1).ToString()}";
                    break;
                case 58:
                    GridLocation = $"18 {(Position + 1).ToString()}";
                    break;
                case 57:
                    GridLocation = $"0 {(Position + 14).ToString()}";
                    break;
                case 56:
                    GridLocation = $"1 {(Position + 14).ToString()}";
                    break;
                case 55:
                    GridLocation = $"2 {(Position + 14).ToString()}";
                    break;
                case 54:
                    GridLocation = $"3 {(Position + 14).ToString()}";
                    break;
                case 53:
                    GridLocation = $"4 {(Position + 14).ToString()}";
                    break;
                case 52:
                    GridLocation = $"5 {(Position + 14).ToString()}";
                    break;
                case 51:
                    GridLocation = $"6 {(Position + 14).ToString()}";
                    break;
                case 64:
                    GridLocation = $"7 {(Position + 14).ToString()}";
                    break;
                case 63:
                    GridLocation = $"8 {(Position + 14).ToString()}";
                    break;
                case 62:
                    GridLocation = $"9 {(Position + 14).ToString()}";
                    break;
                case 61:
                    GridLocation = $"10 {(Position + 14).ToString()}";
                    break;
                case 74:
                    GridLocation = $"12 {(Position + 13).ToString()}";
                    break;
                case 75:
                    GridLocation = $"13 {(Position + 13).ToString()}";
                    break;
                case 76:
                    GridLocation = $"14 {(Position + 13).ToString()}";
                    break;
                case 77:
                    GridLocation = $"15 {(Position + 13).ToString()}";
                    break;
                case 12:
                    GridLocation = $"18 {(Position + 12).ToString()}";
                    break;
                case 13:
                    GridLocation = $"18 {(Position + 13).ToString()}";
                    break;
                case 14:
                    GridLocation = $"18 {(Position + 14).ToString()}";
                    break;
                case 15:
                    GridLocation = $"18 {(Position + 15).ToString()}";
                    break;
                case 16:
                    GridLocation = $"18 {(Position + 16).ToString()}";
                    break;
                case 17:
                    GridLocation = $"18 {(Position + 17).ToString()}";
                    break;
                case 18:
                    GridLocation = $"18 {(Position + 18).ToString()}";
                    break;
                case 19:
                    GridLocation = $"18 {(Position + 19).ToString()}";
                    break;
                case 20:
                    GridLocation = $"18 {(Position + 20).ToString()}";
                    break;
                case 21:
                    GridLocation = $"18 {(Position + 21).ToString()}";
                    break;
                default:
                    return;
            }
        }

        public int CompareTo(Sector s)
        {
            if (Position < s.Position)
            {
                return -1;
            }
            return Position == s.Position ? 0 : 1;
        }

        public System.Web.UI.WebControls.Label AddSectorLabel()
        {/*
            SectorLabel = new Label();
            SectorLabel.Dock = DockStyle.Fill;
            SectorLabel.Margin = new Padding(1);

            SectorLabel.Text = SectorInformation;

            SectorLabel.ForeColor = Color.Black;
            SectorLabel.TextAlign = ContentAlignment.MiddleCenter;
            SectorLabel.Tag = GridLocation;
            SectorLabel.BackColor = Color.LightGray;
            */
            //SectorLabel.Click += new EventHandler(Sector_Click);

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

            //DataTable DT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetTramStatus"], parameters1);
            
            string tramID = "";
            const int type = 3;
            if (type == 0)
            {
                SectorLabel.BackColor = Color.Yellow;
            }

            if (type == 1)
            {
                SectorLabel.BackColor = Color.Orange;
            }

            if (Reserved)
            {
                SectorLabel.ForeColor = Color.Green;
            }

            if (!Available)
            {
                SectorLabel.ForeColor = Color.White;
                SectorLabel.BackColor = Color.Black;
            }

            return SectorLabel;
        }
        /*
        private void Sector_Click(object sender, EventArgs e)
        {
            SectorPropertiesForm spf = new SectorPropertiesForm(Available, Position, Rail.ID, SectorInformation, Reserved);
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
        private void CheckSectorInformation(string tramId)
        {
            SectorInformation = !Available ? "X" : tramId;
        }
    }
}