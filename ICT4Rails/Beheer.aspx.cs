using ICT4Rails.Classes;
using ICT4Rails.Data_Layer;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Logic;

namespace ICT4Rails
{
    public partial class Beheer : Page
    {
        private List<Rail> Rails { get; set; }
        private List<Sector> Sectors { get; set; }
        private List<TableCell> TableCells { get; set; }

        private readonly TramLogic _tramLogic = new TramLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSimulation.Enabled = false;

            Rails = new List<Rail>();
            Sectors = new List<Sector>();
            TableCells = new List<TableCell>();

            tblBeheer.Width = new Unit("100%");
            tblBeheer.Height = new Unit("100%");
            
            const int numrows = 25;
            const int numcells = 19;

            string widthPercent = (100 / numcells) + "%";
            const string heightPercent = "30px";

            for (int j = 0; j < numrows; j++)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numcells; i++)
                {
                    TableCell c = new TableCell
                    {
                        Width = new Unit(widthPercent),
                        Height = new Unit(heightPercent),
                        ID = "c" + i + "_" + j
                    };
                    
                    TableCells.Add(c);

                    r.Cells.Add(c);
                }
                tblBeheer.Rows.Add(r);
            }
            
            //data uit database halen
            GetAllRails();

            GetLijnen();

            GetAllSectors();
            UpdateGrid();

            Debug.WriteLine(Environment.NewLine + "Aantalrails: " + Rails.Count + Environment.NewLine);
            Debug.WriteLine("Aantalsectors: " + Sectors.Count + Environment.NewLine);

            btnSimulation.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateGrid()
        {
            foreach (TableCell tc in TableCells)
            {
                tc.Controls.Clear();
            }

            foreach (Sector s in Sectors)
            {
                if(s.GridLocation == null) continue;
                LinkButton l = s.AddSectorLabel();

                foreach (var tc in TableCells.Where(tc => tc.ID.Substring(1) == s.GridLocation))
                {
                    tc.Controls.Add(l);
                }
            }
        
            foreach (Rail r in Rails)
            {
                if (r.GridLocation == null) continue;
                LinkButton l = r.AddRailLabel();
                
                foreach (var tc in TableCells.Where(tc => tc.ID.Substring(1) == r.GridLocation))
                {
                    tc.Controls.Add(l);
                }
            }

            foreach (Rail r in Rails)
            {
                if (r.GridLocation == null) continue;
                Label l = r.AddRailLijnLabel();

                foreach (var tc in TableCells.Where(tc => tc.ID.Substring(1) == r.GridLocationLijn))
                {
                    tc.Controls.Add(l);
                }
            }
        }

        /// <summary>
        /// Get all the Rails from the database and place them in a list of Rails
        /// </summary>
        private void GetAllRails()
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllRails"], null);

            foreach (var newRail in from DataRow dr in dt.Rows let id = Convert.ToInt32(dr["Id"]) let nummer = Convert.ToInt32(dr["Nummer"]) select new Rail(id, nummer))
            {
                Rails.Add(newRail);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetAllSectors()
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllSectors"], null);
            
            Sectors.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                var id = Convert.ToInt32(dr["Id"]);
                var spoorId = Convert.ToInt32(dr["Spoor_ID"]);

                var tramNummer = (dr["Tram_Nummer"]).ToString() != "" ? (dr["Tram_Nummer"]).ToString() : "";

                var nummer = Convert.ToInt32(dr["Nummer"]);
                var available = Convert.ToInt32(dr["Beschikbaar"]);
                var geblokkeerd = Convert.ToInt32(dr["Blokkade"]);

                var beschikbaar = available == 1;
                
                var blokkade = geblokkeerd == 1;

                var id1 = spoorId;
                foreach (Rail r in Rails.Where(r => r.Id == id1))
                {
                    Sectors.Add(new Sector(id, r, tramNummer, nummer, beschikbaar, blokkade));
                }
            }

            UpdateGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetLijnen()
        {
            foreach (Rail r in Rails)
            {
                //30 t/m 38
                if (r.Nummer == 38)
                {
                    r.Lijn = "2";
                }

                if (r.Nummer == 37)
                {
                    r.Lijn = "5";
                }

                if (r.Nummer == 36)
                {
                    r.Lijn = "1";
                }

                if (r.Nummer == 35)
                {
                    r.Lijn = "16/24";
                }

                if (r.Nummer == 34)
                {
                    r.Lijn = "2";
                }

                if (r.Nummer == 33)
                {
                    r.Lijn = "16/24";
                }

                if (r.Nummer == 32)
                {
                    r.Lijn = "10";
                }

                if (r.Nummer == 31)
                {
                    r.Lijn = "";
                }

                if (r.Nummer == 30)
                {
                    r.Lijn = "16/24";
                }

                //41 t/m 45
                if (r.Nummer == 41)
                {
                    r.Lijn = "10";
                }

                if (r.Nummer == 42)
                {
                    r.Lijn = "55";
                }

                if (r.Nummer == 43)
                {
                    r.Lijn = "1";
                }

                if (r.Nummer == 44)
                {
                    r.Lijn = "13";
                }

                if (r.Nummer == 45)
                {
                    r.Lijn = "17";
                }

                //51 t/m 57
                if (r.Nummer == 57)
                {
                    r.Lijn = "16/24";
                }

                if (r.Nummer == 56)
                {
                    r.Lijn = "5";
                }

                if (r.Nummer == 55)
                {
                    r.Lijn = "2";
                }

                if (r.Nummer == 54)
                {
                    r.Lijn = "5";
                }

                if (r.Nummer == 53)
                {
                    r.Lijn = "13";
                }

                if (r.Nummer == 52)
                {
                    r.Lijn = "17";
                }

                if (r.Nummer == 51)
                {
                    r.Lijn = "";
                }

                //61 t/m 64
                if (r.Nummer == 64)
                {
                    r.Lijn = "";
                }

                if (r.Nummer == 63)
                {
                    r.Lijn = "2";
                }

                if (r.Nummer == 62)
                {
                    r.Lijn = "";
                }

                if (r.Nummer == 61)
                {
                    r.Lijn = "";
                }
            }


        }

        protected void btnSimulation_Click(object sender, EventArgs e)
        {
            btnSimulation.Enabled = false;

            for (int i = 1; i <= 15; i++)
            {
                _tramLogic.Simulatie();
            }
            Response.Redirect(Request.RawUrl);

            btnSimulation.Enabled = true;
        }
    }
}