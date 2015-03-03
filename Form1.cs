using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoughtsAndCrossesWithAI
{
    public partial class Form1 : Form
    {
        bool turn = true; // Turn switches to true for X and false for O
        string title = "Noughts and Crosses";
        Random rnd = new Random();
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (turn == true)
            {
                button.Text = "X";
                button.Enabled = false;
            }
            else
            {
                button.Text = "O";
                button.Enabled = false;
            }

            CheckForWinner();
            turn = !turn;
            turnCount++;
            
            if (turn == false)
            {
                AITurn();
            }
        }

        private void InitialiseGame()
        {
            MessageBox.Show("Player to go first will now be selected.", title);
            if (rnd.Next(0, 2) == 0)
            {
                MessageBox.Show("Human player goes first.", title);
            }
            else
            {
                MessageBox.Show("AI player goes first.", title);
                turn = false;
                AITurn();
            }
        }

        private void AITurn()
        {
            Button buttonChosen = new Button();

            Func<Button, bool> ButtonEnabled = (button)
                =>
            {
                if (button.Enabled == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            while (true)
            {
                switch (rnd.Next(0, 9))
                {
                    case 0:
                        buttonChosen = a1;
                        break;
                    case 1:
                        buttonChosen = a2;
                        break;
                    case 2:
                        buttonChosen = a3;
                        break;
                    case 3:
                        buttonChosen = b1;
                        break;
                    case 4:
                        buttonChosen = b2;
                        break;
                    case 5:
                        buttonChosen = b3;
                        break;
                    case 6:
                        buttonChosen = c1;
                        break;
                    case 7:
                        buttonChosen = c2;
                        break;
                    case 8:
                        buttonChosen = c3;
                        break;
                }

                if (ButtonEnabled(buttonChosen) == true)
                {
                    buttonChosen.PerformClick();
                    break;
                }
                else
                {
                    continue;
                }
            }
            
        }

        private void CheckForWinner()
        {
            bool winner = false;

            //horizontal and vertical checks
            if (((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled)) || ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled)))
            {
                winner = true;
            }
            else if (((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled)) || ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled)))
            {
                winner = true;
            }
            else if (((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled)) || ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled)))
            {
                winner = true;
            }

            //Diagonals
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
            {
                winner = true;
            }
            else if ((c1.Text == b2.Text) && (b2.Text == a3.Text) && (!c1.Enabled))
            {
                winner = true;
            }


            if (winner)
            {
                if (turn == true)
                {
                    MessageBox.Show("Player wins!", title);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("AI Wins!", title);
                    this.Close();
                }
            }
            else
            {
                if (turnCount == 9)
                {
                    MessageBox.Show("It was a draw!", "Fail!");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialiseGame();
        }
    }
}
