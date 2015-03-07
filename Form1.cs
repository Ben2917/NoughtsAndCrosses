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
        #region Variables and Objects
        bool turn = true; // Turn switches to true for X and false for O
        string title = "Noughts and Crosses";
        Random rnd = new Random();
        Button previousButton = new Button();
        int turnCount = 0;
        int AITurns = -1;
        static SimpleAI myAI = new SimpleAI();
        #endregion

        #region Form Initialiser
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Click Event
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
        #endregion

        #region Game Initialiser
        private void InitialiseGame()
        {
            // Could be refactored into its own class
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
        #endregion

        private void AITurn()
        {
            myAI.AIMain();
            #region AI 2 OLD
            // When going first the AI will place its nought in one of the corners
            /*
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
            else if (AITurns == 1 && b2.Enabled == true) // This occurs on the AI's next turn if the player has not placed their cross in the middle
            {
                //TODO: Fill in
            }
            else if (AITurns == 1 && b2.Enabled == false) // This occurs if the player does put their cross in the middle
            {
                // If the player puts their cross in an edge and not a corner this occurs
                if (a2.Text == "X" || c2.Text == "X" || b1.Text == "X" || b3.Text == "X")
                {
                    // This occurs if the AI chose the top left corner and the player chose the square below
                    if (previousButton == a1 && b1.Text == "X")
                    {
                        // in this case the plan is to choose an edge square
                        // that doesn't share a border with the previous AI
                        // choice.
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                b3.PerformClick(); // middle right
                                break;
                            case 1:
                                c2.PerformClick(); // or bottom middle
                                break;
                        }
                    }
                    else if (previousButton == a3)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                b1.PerformClick(); // middle left
                                break;
                            case 1:
                                c2.PerformClick(); // bottom middle
                                break;
                        }
                    }
                    else if (previousButton == c1)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                a2.PerformClick(); // top middle
                                break;
                            case 1:
                                b3.PerformClick(); // middle right
                                break;
                        }
                    }
                    else if (previousButton == c3)
                    {
                        switch (rnd.Next(0, 2))
                        {
                            case 0:
                                a2.PerformClick(); // top middle
                                break;
                            case 1:
                                b1.PerformClick(); // middle left
                                break;
                        }
                    }
                }
                else // The player has chosen a corner or the centre
                {
                    // The plan in this case is to take the opposite corner
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
            #endregion
            */
        }
        #endregion

        #region Winner check
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
                if (turnCount == 8)
                {
                    MessageBox.Show("It was a draw!", "Fail!");
                    this.Close();
                }
            }
        }
        #endregion

        #region Public Accessors
        public void ClickButtons(string buttonName)
        {
            // A public method that makes the
            // form buttons accessible to the
            // AI class.
            switch (buttonName)
            {
                case "a1":
                    a1.PerformClick();
                    break;
                case "a2":
                    a2.PerformClick();
                    break;
                case "a3":
                    a3.PerformClick();
                    break;
                case "b1":
                    b1.PerformClick();
                    break;
                case "b2":
                    b2.PerformClick();
                    break;
                case "b3":
                    b3.PerformClick();
                    break;
                case "c1":
                    c1.PerformClick();
                    break;
                case "c2":
                    c2.PerformClick();
                    break;
                case "c3":
                    c3.PerformClick();
                    break;
            }
        }


        // Public accessor to check if button is enabled.
        // Tested - Working
        public bool ButtonEnabled(string buttonName)
        {
            switch (buttonName)
            {
                case "a1":
                    return a1.Enabled;
                case "a2":
                    return a2.Enabled;
                case "a3":
                    return a3.Enabled;
                case "b1":
                    return b1.Enabled;
                case "b2":
                    return b2.Enabled;
                case "b3":
                    return b3.Enabled;
                case "c1":
                    return c1.Enabled;
                case "c2":
                    return c2.Enabled;
                case "c3":
                    return c3.Enabled;
                default:
                    return false;
                    
            }
        }

        // public accessor to get button text.
        // Needs testing.
        public string ButtonText(string buttonName)
        {
            switch (buttonName)
            {
                case "a1":
                    return a1.Text;
                case "a2":
                    return a2.Text;
                case "a3":
                    return a3.Text;
                case "b1":
                    return b1.Text;
                case "b2":
                    return b2.Text;
                case "b3":
                    return b3.Text;
                case "c1":
                    return c1.Text;
                case "c2":
                    return c2.Text;
                case "c3":
                    return c3.Text;
                default:
                    return null;

            }
        }

        #endregion

        #region Form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            InitialiseGame();
        }
        #endregion
    }
}
