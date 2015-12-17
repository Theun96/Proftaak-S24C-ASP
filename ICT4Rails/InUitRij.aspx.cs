using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Rails
{
    public partial class InUitRij : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Touchpad_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            //Checks
            if (button == null || lblTramNumber.Text.Length > 5) return;
            if (lblTramNumber.Text == "Geef een tramnummer in.") { lblTramNumber.Text = ""; }

            lblTramNumber.Text += button.Text;
        }

        protected void TouchpadEnter_Click(object sender, EventArgs e)
        {
            //Checks
            if (lblTramNumber.Text == "Geef een tramnummer in." || lblTramNumber.Text.Length < 1) return;
            
        }

        protected void TouchpadClear_Click(object sender, EventArgs e)
        {
            lblTramNumber.Text = "Geef een tramnummer in.";
        }
    }
}