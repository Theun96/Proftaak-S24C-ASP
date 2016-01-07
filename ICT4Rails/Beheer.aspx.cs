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
                        Height = new Unit(heightPercent)
                    };

                    c.ID = "c" + i.ToString() + "_" + j.ToString();

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

                int spaceIndex = columnString.IndexOf("_");

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex + 1);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);

                foreach (var tc in TableCells)
                {
                    if (tc.ID.Substring(1) == s.GridLocation)
                    {
                        tc.Controls.Add(l);
                    }
                }
            }
        
            foreach (Rail r in Rails)
            {
                if (r.GridLocation == null) continue;
                Label l = r.AddRailLabel();

                string columnString = l.ID;
                string rowString = l.ID;

                int spaceIndex = columnString.IndexOf("_");

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex + 1);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);
                
                foreach (var tc in TableCells)
                {
                    if (tc.ID.Substring(1) == r.GridLocation)
                    {
                        tc.Controls.Add(l);
                    }
                }
            }
        }

        /// <summary>
        /// Get all the Rails from the database and place them in a list of Rails
        /// </summary>
        private void GetAllRails()
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllRails"], null);

            int Id;
            int nummer;

            foreach (DataRow DR in dt.Rows)
            {
                Id = Convert.ToInt32(DR["Id"]);
                nummer = Convert.ToInt32(DR["Nummer"]);

                var newRail = new Rail(Id, nummer);
                Rails.Add(newRail);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetAllSectors()
        {
            DataTable DT = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.Query["GetAllSectors"], null);

            int Id;
            int Spoor_ID;
            string Tram_ID;
            int Nummer;
            int available;
            bool Beschikbaar;
            int geblokkeerd;
            bool Blokkade;

            Sectors.Clear();

            foreach (DataRow DR in DT.Rows)
            {
                Id = Convert.ToInt32(DR["Id"]);
                Spoor_ID = Convert.ToInt32(DR["Spoor_ID"]);

                Tram_ID = (DR["Tram_ID"]).ToString() != "" ? (DR["Tram_ID"]).ToString() : "";

                Nummer = Convert.ToInt32(DR["Nummer"]);
                available = Convert.ToInt32(DR["Beschikbaar"]);
                geblokkeerd = Convert.ToInt32(DR["Blokkade"]);

                Beschikbaar = available == 1;
                
                Blokkade = geblokkeerd == 1;

                foreach (Rail r in Rails.Where(r => r.Id == Spoor_ID))
                {
                    Sectors.Add(new Sector(Id, r, Tram_ID, Nummer, Beschikbaar, Blokkade));
                }
            }

            UpdateGrid();
        }
    }
}