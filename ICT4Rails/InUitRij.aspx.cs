using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Rails.Logic;
using ICT4Rails.Plugins;

namespace ICT4Rails
{
    public partial class InUitRij : System.Web.UI.Page
    {
        private readonly TramLogic _tramLogic = new TramLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Touchpad_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            //Checks
            if (button == null) return;
            if (lblTramNumber.Text == "Geef een tramnummer in.") { lblTramNumber.Text = ""; }
            if (lblTramNumber.Text.Length > 5) return;

            lblTramNumber.Text += button.Text;
        }

        protected void TouchpadEnter_Click(object sender, EventArgs e)
        {
            //Checks
            if (lblTramNumber.Text == "Geef een tramnummer in." || lblTramNumber.Text.Length < 1) return;
            int tramNumber = Convert.ToInt32(Regex.Replace(lblTramNumber.Text, @"\s+", ""));
            int[] info = _tramLogic.GetReservedSector(tramNumber);
            if (info[0] == 0 || info[1] == 0)
            {
                string maintenance = "";
                if (CheckDamaged.Checked && CheckDirty.Checked)
                {
                    maintenance = "Beide";
                }
                else if (CheckDirty.Checked)
                {
                    maintenance = "Schoonmaak";
                }
                else if (CheckDamaged.Checked)
                {
                    maintenance = "Techniek";
                }

                //_tramLogic.AddIncoming(tramNumber.ToString(), maintenance);
                _tramLogic.FindFreePlace();
                MessageBox.Show("Er is nog geen reservering voor uw tram. Er is een bericht naar de trambeheerder gestuurd.");
            }
            else
            {
                //trammanager.CheckInTrain(txtTramNumber.Text);
                MessageBox.Show($"Rail: {info[0]}, Sector: {info[1]}");
            }
        }

        protected void TouchpadClear_Click(object sender, EventArgs e)
        {
            lblTramNumber.Text = "Geef een tramnummer in.";
        }
    }
}