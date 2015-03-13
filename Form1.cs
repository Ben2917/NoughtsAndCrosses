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
    /// <summary>
    /// This class holds all the methods assosciated
    /// with basic noughts and crosses gameplay.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Bug found - sometimes AI takes turn before the turn switches.
        /// Hard to replicate.
        /// </summary>
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

            turn = !turn;
            CheckForWinner();
            turnCount++;
            
            if (turn == false)
            {
                myAI.AIMain();
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
                myAI.AIMain();
            }
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
                if (turn)
                {
                    MessageBox.Show("Player wins!", title);
                    Exit();
                }
                else
                {
                    MessageBox.Show("AI Wins!", title);
                    Exit();
                }
            }
            else
            {
                if (turnCount == 8)
                {
                    MessageBox.Show("It was a draw!", "Fail!");
                    Exit();
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

        #region Menu buttons
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            this.Close();
            Application.Exit();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Refer to the read me for instructions on how to play.", title);
        }

        static void ResetGame()
        {
            // TODO: Make this method reset the game.
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        
        private void aboutThisAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A noughts and crosses game with AI.\nBy Mercenary96.", title);
        }
        #endregion
    }
}