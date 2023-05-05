using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wedstrijd_app__IzzetGunturk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Draw();
        }
        private void Draw()
        {
            // Maak een list/array aan met teams
            List<string> teams = new List<string>()
            {"Real madrid", "FC Barcelona", "Bayern Munchen", "Inter", "Juventus", "Liverpool", "Manchester City", "PSG"};

            // nieuwe list aanmaken voor teams, zodat ze maar 1x voorkomen.
            List<string> draw = new List<string>();
            // zorgt voor shuffle list dus dat de teams niet dubbel komen.
            draw = teams.OrderBy(x => Guid.NewGuid()).ToList();
            labelTeam1.Text = draw[0];
            labelTeam2.Text = draw[1];
            labelTeam3.Text = draw[2];
            labelTeam4.Text = draw[3];
            labelTeam5.Text = draw[4];
            labelTeam6.Text = draw[5];
            labelTeam7.Text = draw[6];
            labelTeam8.Text = draw[7];
        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            ResultsGenerator();
        }

        private void ResultsGenerator()
        {
            // maak een random aan, zodat er willekeurige uitslagen komen.
            Random rnd = new Random();

            // maak een list/array aan voor de willekeurige uitslagen
            List<string> results = new List<string>();

            // maak een for-loop, zodat willekeurige resultaten komen
            for (int i = 0; i < 5; i++)
            {
                // score voor team 1 
                int goalsTeam1 = rnd.Next(0, 5);
                // score voor team 2
                int goalsTeam2 = rnd.Next(0, 5);
                // score van team1 - team2 samen, zodat er in de labels de resultaten worden weergegeven
                string result = Convert.ToString(goalsTeam1) + "-" + Convert.ToString(goalsTeam2);
                // voeg de scores toe aan de list results
                results.Add(result);
            }

            // koppel labels met de list results
            Label[] labelResults = { labelResult1, labelResult2, labelResult3, labelResult4 };
            for (int i = 0; i < 4; i++)  
            {
                labelResults[i].Text = results[i];
            }
        }

        private void buttonKopen_Click(object sender, EventArgs e)
        {
            MessageBox.Show(KopenKaartjes("You will be forwarded to the banking app and there you can pay!", "Sorry, to give everyone an equal chance to buy a ticket, the limit is 2 tickets per person. Thank you for your understanding!"));
        }

        private string KopenKaartjes(string message1, string message2)
        {
            int numberOfTickets = Convert.ToInt32(tBAantalKaartjes.Text);

            if (numberOfTickets <= 2)
            {
                return message1;
            }
            else
            {
                return message2;
            }
        }
    }
}
