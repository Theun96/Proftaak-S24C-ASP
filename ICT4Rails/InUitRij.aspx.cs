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
            if (tbTramNumber.Text == "Geef een tramnummer in.") { tbTramNumber.Text = ""; }
            //if (lblTramNumber.Text.Length > 5) return;

            tbTramNumber.Text += button.Text;
        }

        protected void TouchpadEnter_Click(object sender, EventArgs e)
        {
            //Checks
            if (tbTramNumber.Text == "Geef een tramnummer in." || tbTramNumber.Text.Length < 1) return;
            int tramnumber = Convert.ToInt32(Regex.Replace(tbTramNumber.Text, @"\s+", ""));
            int tramid = TramLogic.GetIdFromTram(tramnumber);
            if (tramid == 0)
            {
                MessageBox.Show("Tramnummer niet gevonden");
                tbTramNumber.Text = "";
                return;
            }

            bool alreadyExists = TramLogic.CheckIfExists(tramid);
            if (alreadyExists)
            {
                MessageBox.Show("Tram staat al op een sector");
                tbTramNumber.Text = "";
                return;
            }

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

            int spoor = TramLogic.CheckReserved(tramid);
            int[] position = _tramLogic.FindFreePlace(spoor, maintenance, tramid);
            if (position == null)
            {
                MessageBox.Show("Er is op dit moment geen plek beschikbaar");
                tbTramNumber.Text = "";
                return;
            }
            int railNumber = TramLogic.GetNumberFromRail(position[0]);
            TramLogic.AddTrainToSector(tramid, position[0], position[1]);
            TramLogic.AddTramToMaintenance(tramid, maintenance);
            MessageBox.Show($"Spoor: {railNumber}, Sector: {position[1]}");
            TouchpadClear_Click(null, null);
            if (maintenance != "")
            {
                Mailing mail = new Mailing();
                mail.mail("pts18werknemer1@gmail.com","er is een trein die een "+maintenance+" beurt nodig heeft.",maintenance);
            }
        }

        protected void TouchpadClear_Click(object sender, EventArgs e)
        {
            tbTramNumber.Text = "";
        }
    }
}