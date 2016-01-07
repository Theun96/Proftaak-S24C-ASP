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

namespace ICT4Rails
{
    public partial class Beheer : System.Web.UI.Page
    {
        public List<Rail> Rails { get; private set; }
        public List<Sector> Sectors { get; private set; }

        public List<TableCell> TableCells { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Rails = new List<Rail>();
            Sectors = new List<Sector>();
            TableCells = new List<TableCell>();

            tblBeheer.Width = new Unit("100%");
            tblBeheer.Height = new Unit("100%");
            
            const int numrows = 29;
            const int numcells = 19;

            string widthPercent = (100 / numcells).ToString() + "%";
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
                        ID = "c" + i.ToString() + "_" + j.ToString()
                    };


                    TableCells.Add(c);

                    r.Cells.Add(c);
                    
                }
                tblBeheer.Rows.Add(r);
            }

            //data uit database halen
            GetAllRails();

            GetAllSectors();
            UpdateGrid();

            Debug.WriteLine(Environment.NewLine + "Aantalrails: " + Rails.Count.ToString() + Environment.NewLine);
            Debug.WriteLine("Aantalsectors: " + Sectors.Count.ToString() + Environment.NewLine);
        }

        public void UpdateGrid()
        {
            foreach (TableCell tc in TableCells)
            {
                tc.Controls.Clear();
            }

            foreach (Sector s in Sectors)
            {
                if(s.GridLocation == null) continue;
                LinkButton l = s.AddSectorLabel();

                string columnString = l.ID;
                string rowString = l.ID;

                int spaceIndex = columnString.IndexOf("_", StringComparison.Ordinal);

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex + 1);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);

                foreach (var tc in TableCells.Where(tc => tc.ID.Substring(1) == s.GridLocation))
                {
                    tc.Controls.Add(l);
                }
            }
        
            foreach (Rail r in Rails)
            {
                if (r.GridLocation == null) continue;
                Label l = r.AddRailLabel();

                string columnString = l.ID;
                string rowString = l.ID;

                int spaceIndex = columnString.IndexOf("_", StringComparison.Ordinal);

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex + 1);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);
                
                foreach (var tc in TableCells.Where(tc => tc.ID.Substring(1) == r.GridLocation))
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
        public void GetAllSectors()
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
    }
}