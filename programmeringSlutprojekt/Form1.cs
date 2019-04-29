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
        int[] board = new int[9];
        private static readonly Random randPlayer = new Random();
        int currPlayer;
        Color Red = Color.FromName("Red");
        Color Green = Color.FromName("Green");
        int player1Wins;
        int player2Wins;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e) => initGame();

        private void resetBtn_Click(object sender, EventArgs e) => initGame();

        void initGame()
        {
            startBtn.Enabled = false;
            resetBtn.Enabled = true;
            Array.Clear(board, 0, board.Length);
            currPlayer = randPlayer.Next(1, 3);
            //gör alla knappar klickbara
            box0.Enabled = true;
            box1.Enabled = true;
            box2.Enabled = true;
            box3.Enabled = true;
            box4.Enabled = true;
            box5.Enabled = true;
            box6.Enabled = true;
            box7.Enabled = true;
            box8.Enabled = true;
            //återställ knapparnas färger
            box0.BackColor = default(Color);
            box1.BackColor = default(Color);
            box2.BackColor = default(Color);
            box3.BackColor = default(Color);
            box4.BackColor = default(Color);
            box5.BackColor = default(Color);
            box6.BackColor = default(Color);
            box7.BackColor = default(Color);
            box8.BackColor = default(Color);

        }
        private bool registerClick(Button btn, int player)
        {
            //hämta den fjärde karaktären i knappens namn, alltså platsen i fältet
            int btnNr = btn.Name[3] - 48;
            if (board[btnNr] == 0)
            {
                //ändra färg och notifiera eventhanteraren att en tillåten tryckning skett
                board[btnNr] = player;
                if (player == 2)
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
        private void btnClick(object sender, EventArgs e)
        {
            Button Button = (Button)sender;
            bool legalClick = registerClick(Button, currPlayer);
            //om knapptryckningen var tillåten, kolla om någon vunnit, annars fortsätt till nästa spelare
            if (legalClick == true)
            {
                int winState = checkWin();
                if (winState != 0)
                {
                    decWinner(winState);
                }
                else if (currPlayer == 2)
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
        
        int checkWin()
        {
            return 0;
        }

        void decWinner(int state)
        {
            //Inkrementera antalet gånger respektive spelare vunnit, återställer spelet.
            if (state == 1)
            {
                player1Wins++;
            }
            else if (state == 2)
            {
                player2Wins++;
            }
            else if (state == 3)
            {
                MessageBox.Show("Oavgjort! Startar om spelet.");
            }
            else
            {
                MessageBox.Show("Något är allvarligt fel, återställer spelet. Ifall detta fortsätter bör du starta om spelprogrammet.", "Trasigt spelstate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            initGame();
        }
    }
}
