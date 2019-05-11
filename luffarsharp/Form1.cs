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
    public partial class Luffarschack : Form
    {
        int[] board = new int[9];
        private static readonly Random randPlayer = new Random();
        int currPlayer;
        Color Red = Color.FromName("Red");
        Color Green = Color.FromName("Green");
        int player1Wins;
        int player2Wins;
        int moveCounter;
        public Luffarschack()
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
            moveCounter = 0;
            plr1Wins.Text = "Spelare 1 har vunnit: " + player1Wins.ToString() + " gånger";
            plr2Wins.Text = "Spelare 2 har vunnit: " + player2Wins.ToString() + " gånger";
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
            //hämta den fjärde karaktären i knappens namn, alltså platsen i fältet, konvertera den från en char till en double till en int.
            int btnNr = (int)char.GetNumericValue(btn.Name[3]);
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
            //registerClick returnerar true om platsen var tom, annars false
            bool legalClick = registerClick(Button, currPlayer);
            //om knapptryckningen var tillåten, kolla om någon vunnit, annars fortsätt till nästa spelare
            if (legalClick == true)
            {
                int winState = checkWin();
                //winState returnerar 0 för ingen vinnare, 1 för spelare 1, 2 för spelare 2 och 3 för oavgjort
                if (winState != 0)
                {
                    decWinner(winState);
                }
                else if (currPlayer == 2)
                {

                    currPlayer--;
                    moveCounter++;
                    //kör datorns omgång
                }
                else
                {
                    //ge kontroll till spelaren
                    currPlayer++;
                    moveCounter++;
                }
            }
        }

        int checkWin()
        {
            //kolla alla winstates
            if (board[0] != 0 && board[0] == board[3] && board[3] == board[6])
            {
                return board[0];
            }
            else if (board[0] != 0 && board[0] == board[1] && board[1] == board[2])
            {
                return board[0];
            }
            else if (board[0] != 0 && board[0] == board[4] && board[4] == board[8])
            {
                return board[0];
            }
            else if (board[3] != 0 && board[3] == board[4] && board[4] == board[5])
            {
                return board[3];
            }
            else if (board[6] != 0 && board[6] == board[4] && board[4] == board[2])
            {
                return board[6];
            }
            else if (board[6] != 0 && board[6] == board[7] && board[6] == board[8])
            {
                return board[6];
            }
            else if (board[1] != 0 && board[1] == board[4] && board[1] == board[7])
            {
                return board[1];
            }
            else if (board[2] != 0 && board[2] == board[5] && board[2] == board[8])
            {
                return board[2];
            }
            else if (moveCounter == 8)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        void decWinner(int state)
        {
            //state är 0 för ingen vinnare, 1 för spelare 1, 2 för spelare 2 och 3 för oavgjort
            //Inkrementera antalet gånger respektive spelare vunnit, återställer spelet.
            if (state == 1)
            {
                player1Wins++;
                MessageBox.Show("Spelare 1 vann!");
            }
            else if (state == 2)
            {
                player2Wins++;
                MessageBox.Show("Spelare 2 vann!");
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
