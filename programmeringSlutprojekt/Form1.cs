using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programmeringSlutprojekt
{
    public partial class Form1 : Form
    {
        int?[] board = new int?[9];
        int currPlayer = 1;
        Color Red = Color.FromName("Red");
        Color Green = Color.FromName("Green");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {

        }
        private bool registerClick(Button btn, int player)
        {
            //hämta den fjärde karaktären i knappens namn, alltså platsen i fältet
            int btnNr = btn.Name[3] - 48;
            if (board[btnNr] == null)
            {
                //ändra färg och notifiera eventhanteraren att en tillåten tryckning skett
                board[btnNr] = player;
                if (player == 1)
                {
                    btn.BackColor = Green;
                }
                else
                {
                    btn.BackColor = Red;
                }
                return true;
            }
            //returnera false, nuvarande spelares omgång fortsätter tills en tillåten tryckning skett
            else
            {
                return false;
            }
        }
        //händelselyssnare för gränssnittet
        //avslut på händelselyssnare för gränssnittet
        private void btnClick(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            bool legalClick = registerClick(Button, currPlayer);
            //om knapptryckningen var tillåten, fortsätt till nästa spelare
            if (legalClick == true)
            {
                if (currPlayer == 1)
                {

                    currPlayer--;
                    //kör datorns omgång
                }
                else
                {
                    //ge kontroll till spelaren
                    currPlayer++;
                }
            }
        }
    }
}
