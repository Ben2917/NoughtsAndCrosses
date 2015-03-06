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
        Button previousButton = new Button();
        int turnCount = 0;
        int AITurns = -1;

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
            #region AI 1
            /*
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
            */
            #endregion
            AITurns++;
            if (AITurns == 0)
            {
                switch (rnd.Next(0, 4))
                {
                    case 0:
                        a1.PerformClick();
                        previousButton = a1;
                        break;
                    case 1:
                        a3.PerformClick();
                        previousButton = a3;
                        break;
                    case 2:
                        c1.PerformClick();
                        previousButton = c1;
                        break;
                    case 3:
                        c3.PerformClick();
                        previousButton = c3;
                        break;
                }
            }
            else if (AITurns == 1 && b2.Enabled == true)
            {
                //TODO: Fill in
            }
            else if (AITurns == 1 && b2.Enabled == false)
            {
                //switch(rnd.Next(0, 2))
                if (a2.Text == "X" || c2.Text == "X" || b1.Text == "X" || b3.Text == "X")
                {
                    if (previousButton == a1 && b1.Text == "X")
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                b3.PerformClick();
                                break;
                            case 1:
                                c2.PerformClick();
                                break;
                        }
                    }
                    else if (previousButton == a3)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                b1.PerformClick();
                                break;
                            case 1:
                                c2.PerformClick();
                                break;
                        }
                    }
                    else if (previousButton == c1)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                a2.PerformClick();
                                break;
                            case 1:
                                b3.PerformClick();
                                break;
                        }
                    }
                    else if (previousButton == c3)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                a2.PerformClick();
                                break;
                            case 1:
                                b1.PerformClick();
                                break;
                        }
                    }
                }
                else
                {
                    if (previousButton == a1)
                    {
                        c3.PerformClick();
                    }
                    else if (previousButton == a3)
                    {
                        c1.PerformClick();
                    }
                    else if (previousButton == c1)
                    {
                        a3.PerformClick();
                    }
                    else if (previousButton == c3)
                    {
                        a1.PerformClick();
                    }
                }
            }
            else if(AITurns == 2 && (a1.Text == "X" || a3.Text == "X"
                || c1.Text == "X" || c3.Text == "X") && b2.Enabled == false)
            {
                if (a1.Enabled)
                {
                    a1.PerformClick();
                }
                else if (a3.Enabled)
                {
                    a3.PerformClick();
                }
                else if (c1.Enabled)
                {
                    c1.PerformClick();
                }
                else if (c3.Enabled)
                {
                    c3.PerformClick();
                }
            }
            else if (AITurns == 3)
            {
                if (a1.Text == "O" && a3.Text == "O" && a2.Enabled)
                {
                    a2.PerformClick();
                }
                else if (a3.Text == "O" && c3.Text == "O" && b3.Enabled)
                {
                    b3.PerformClick();
                }
                else if (c1.Text == "O" && c3.Text == "O" && c2.Enabled)
                {
                    c2.PerformClick();
                }
                else if (a1.Text == "O" && c1.Text == "O" && b1.Enabled)
                {
                    b1.PerformClick();
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
