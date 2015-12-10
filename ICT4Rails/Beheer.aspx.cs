﻿using ICT4Rails.Classes;
using ICT4Rails.Data_Layer;
using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            tblBeheer.Width = new Unit("100%");
            tblBeheer.Height = new Unit("400px");

            const int numrows = 19;
            const int numcells = 29;

            string widthPercent = (100 / numcells).ToString() + "%";
            string heightPercent = (100 / numrows).ToString() + "%";

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
                    //c.Controls.Add(new Label());
                    r.Cells.Add(c);
                }
                tblBeheer.Rows.Add(r);
            }

            //data uit database halen
            GetAllRails();
        }

        public void UpdateGrid()
        {
            foreach (Sector s in Sectors)
            {
                Label l = s.AddSectorLabel();

                string columnString = l.ID;
                string rowString = l.ID;

                int spaceIndex = columnString.IndexOf(" ");

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);
                
                //tlpGrid.Controls.Add(l, column, row);
                
            }

            foreach (Rail r in Rails)
            {
                /*
                Label l = r.AddRailLabel();

                string columnString = l.Tag.ToString();
                string rowString = l.Tag.ToString();

                int spaceIndex = columnString.IndexOf(" ");

                columnString = columnString.Substring(0, spaceIndex);
                rowString = rowString.Substring(spaceIndex);

                int column = Convert.ToInt32(columnString);
                int row = Convert.ToInt32(rowString);
                */
                //tlpGrid.Controls.Add(l, column, row);
            }
            
            //tlpGrid.Visible = true;
        }

        /// <summary>
        /// Get all the Rails from the database and place them in a list of Rails
        /// </summary>
        private void GetAllRails()
        {
            DataTable dt = DatabaseManager.ExecuteReadQuery(DatabaseQuerys.query["GetAllRails"], null);

            foreach (int nummer in from DataRow dr in dt.Rows select Convert.ToInt32(dr["NUMMER"]))
            {
                Rails.Add(new Rail(nummer));
            }
        }
    }
}