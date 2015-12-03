using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Rails
{
    public partial class Beheer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tblBeheer.Width = new Unit("100%");
            tblBeheer.Height = new Unit("400px");

            int numrows = 19;
            int numcells = 29;

            string widthPercent = (100 / numcells).ToString() + "%";
            string heightPercent = (100 / numrows).ToString() + "%";

            for (int j = 0; j < numrows; j++)
            {
                TableRow r = new TableRow();
                for (int i = 0; i < numcells; i++)
                {
                    TableCell c = new TableCell();
                    c.Width = new Unit(widthPercent);
                    c.Height = new Unit(heightPercent);
                    //c.Controls.Add(new Label());
                    r.Cells.Add(c);
                }
                tblBeheer.Rows.Add(r);
            }
        }
    }
}