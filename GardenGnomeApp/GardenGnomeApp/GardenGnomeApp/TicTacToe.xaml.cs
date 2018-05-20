using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GardenGnomeApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicTacToe : ContentPage
    {
        public TicTacToe()
        {
            InitializeComponent();
            playerTwoLabel.Text = "Player 2: O";
            playerOneLabel.Text = "Player 1: X <<";
            playAgainstButton.Text = "Play Agaisnt Computer";
            easyButton.IsVisible = false;
            moderateButton.IsVisible = false;
            hardButton.IsVisible = false;
            playerOneScore.Text = string.Format("P1 Score: {0}",score1);
            playerTwoScore.Text = string.Format("P2 Score: {0}",score2);
            moderateButton.IsEnabled = false;
        }
        // Responsive Layout
        private double width = 0;
        private double height = 0;
     
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                //reconfigure layout
                if (width > height)
                {
                    outerStack.Orientation = StackOrientation.Horizontal;
                    mainGrid.HeightRequest = height;
                    mainGrid.WidthRequest = height;
                }
                else
                {
                    outerStack.Orientation = StackOrientation.Vertical;
                    mainGrid.HeightRequest = width;
                    mainGrid.WidthRequest = width;
                }
            }
        }

        //The Game
        bool turn = true;
        bool winner = false;
        private void buttonClicked(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                playerOneLabel.Text = "Player 1: X";
                playerTwoLabel.Text = "Player 2: O <<";
                b.Text = "X";
                b.FontSize = 25;
            }
            else
            {
                playerTwoLabel.Text = "Player 2: O";
                playerOneLabel.Text = "Player 1: X <<";
                b.Text = "O";
                b.FontSize = 25;
            }
            turn = !turn;
            b.IsEnabled = false;
            checkForWinner();

            if ((!turn) && (ai == true))
            {
                System.Diagnostics.Debug.WriteLine("computer is moving");
                if (difficulty == "Easy")
                    easyComputerMove();
                if (difficulty == "Moderate")
                    moderateComputerMove();
                if (difficulty == "Hard")
                    hardComputerMove();
            }
        }

        private void checkForWinner()
        {
            System.Diagnostics.Debug.WriteLine("CheckforWinner Working" + winner);
            //Horizontal checks
            if ((Button0_0.Text == Button1_0.Text) && (Button1_0.Text == Button2_0.Text) && (Button0_0.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("1");
            }
            if ((Button0_1.Text == Button1_1.Text) && (Button1_1.Text == Button2_1.Text) && (Button0_1.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("2");
            }
            if ((Button0_2.Text == Button1_2.Text) && (Button1_2.Text == Button2_2.Text) && (Button0_2.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("3");
            }

            //Veritical Checks                                                                                 
            if ((Button0_0.Text == Button0_1.Text) && (Button0_1.Text == Button0_2.Text) && (Button0_0.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("4");
            }
            if ((Button1_0.Text == Button1_1.Text) && (Button1_1.Text == Button1_2.Text) && (Button1_0.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("5");
            }
            if ((Button2_0.Text == Button2_1.Text) && (Button2_1.Text == Button2_2.Text) && (Button2_0.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("6");
            }

            //Diagonal Checks                                                                                   
            if ((Button0_0.Text == Button1_1.Text) && (Button1_1.Text == Button2_2.Text) && (Button0_0.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("7");
            }
            if ((Button0_2.Text == Button1_1.Text) && (Button1_1.Text == Button2_0.Text) && (Button0_2.IsEnabled == false))
            { winner = true;
                System.Diagnostics.Debug.WriteLine("8");
            }
            
            //Declaring winner
            if (winner == true)
            {
                string winnerName = "";
                if (turn)
                {
                    winnerName = "2";
                    score2 += 1;
                    playerTwoScore.Text = string.Format("P2 Score: {0}", score2);
                }
                else
                {
                    winnerName = "1";
                    score1 += 1;
                    playerOneScore.Text = string.Format("P1 Score: {0}", score1);
                }

                DisplayAlert("Game Over","Player " + winnerName + " Wins!", "OK");
                // stop the user from pressing more buttons after winning
                Button0_0.IsEnabled = false;
                Button1_0.IsEnabled = false;
                Button2_0.IsEnabled = false;
                Button0_1.IsEnabled = false;
                Button1_1.IsEnabled = false;
                Button2_1.IsEnabled = false;
                Button0_2.IsEnabled = false;
                Button1_2.IsEnabled = false;
                Button2_2.IsEnabled = false;
            }

            //Check for Draw
            if (
            (Button0_0.IsEnabled == false)&&
            (Button1_0.IsEnabled == false)&&
            (Button2_0.IsEnabled == false)&&
            (Button0_1.IsEnabled == false)&&
            (Button1_1.IsEnabled == false)&&
            (Button2_1.IsEnabled == false)&&
            (Button0_2.IsEnabled == false)&&
            (Button1_2.IsEnabled == false)&&
            (Button2_2.IsEnabled == false)&&
            (winner == false))// end condition
                {
                    DisplayAlert("Game Over", "Draw!", "OK");
                }
        }
        
        // restting the game with reset button
        private void resetClicked()
        {
            Button0_0.Text = "";
            Button1_0.Text = "";
            Button2_0.Text = "";
            Button0_1.Text = "";
            Button1_1.Text = "";
            Button2_1.Text = "";
            Button0_2.Text = "";
            Button1_2.Text = "";
            Button2_2.Text = "";
            Button0_0.IsEnabled = true;
            Button1_0.IsEnabled = true;
            Button2_0.IsEnabled = true;
            Button0_1.IsEnabled = true;
            Button1_1.IsEnabled = true;
            Button2_1.IsEnabled = true;
            Button0_2.IsEnabled = true;
            Button1_2.IsEnabled = true;
            Button2_2.IsEnabled = true;


            playerTwoLabel.Text = "Player 2: O";
            playerOneLabel.Text = "Player 1: X <<";
            turn = true;
            winner = false;
            System.Diagnostics.Debug.WriteLine("Check Variables turn: " + turn +" winner: " + winner);
        }

        // Play Agianst Computer
        bool ai = false; // not agianst computer by default
        string difficulty = "Moderate"; //morderate by default
        //Play Agianst Computer Button
        private void playAgainstClicked() {
            if (playAgainstButton.Text == "Play Agaisnt Computer")
            {
                playAgainstButton.Text = "Play Agiasnt Player 2";
                resetClicked();
                ai = true;
                easyButton.IsVisible = true;
                moderateButton.IsVisible = true;
                hardButton.IsVisible = true;
            }
            else
            {
                playAgainstButton.Text = "Play Agaisnt Computer";
                resetClicked();
                ai = false;
                easyButton.IsVisible = false;
                moderateButton.IsVisible = false;
                hardButton.IsVisible = false;
            }
            System.Diagnostics.Debug.WriteLine("Ai: " + ai);
        }

        //Changing Difficulty
        private void easyClicked()
        {
            difficulty = "Easy";
            easyButton.IsEnabled = false;
            moderateButton.IsEnabled = true;
            hardButton.IsEnabled = true;
            resetClicked();
        }

        private void moderateClicked()
        {
            difficulty = "Moderate";
            easyButton.IsEnabled = true;
            moderateButton.IsEnabled = false;
            hardButton.IsEnabled = true;
            resetClicked();
        }

        private void hardClicked()
        {
            difficulty = "Hard";
            easyButton.IsEnabled = true;
            moderateButton.IsEnabled = true;
            hardButton.IsEnabled = false;
            resetClicked();
        }

        // easy AI
        private void easyComputerMove()
        {
            Button move = null;
            
            if (
                (Button0_0.IsEnabled == false) &&
                (Button1_0.IsEnabled == false) &&
                (Button2_0.IsEnabled == false) &&
                (Button0_1.IsEnabled == false) &&
                (Button1_1.IsEnabled == false) &&
                (Button2_1.IsEnabled == false) &&
                (Button0_2.IsEnabled == false) &&
                (Button1_2.IsEnabled == false) &&
                (Button2_2.IsEnabled == false))// end condition
            {

            }
            else
            {
                while (move == null)
                {
                    move = randomMove();
                }
                move.SendClicked();
            }

            System.Diagnostics.Debug.WriteLine("computer clicked: " + move);
        }

        private Button randomMove()
        {
            
            Random rnd = new Random();
            int anyMove = rnd.Next(1, 10);
            System.Diagnostics.Debug.WriteLine("computer looking random move"+anyMove);
            if ((Button1_1.Text == "") && (anyMove == 1))
                return Button1_1;
            if ((Button1_0.Text == "") && (anyMove == 2))
                return Button1_0;
            if ((Button0_1.Text == "") && (anyMove == 3))
                return Button0_1;
            if ((Button2_1.Text == "") && (anyMove == 4))
                return Button2_1;
            if ((Button1_2.Text == "") && (anyMove == 5))
                return Button1_2;
            if ((Button0_0.Text == "") && (anyMove == 6))
                return Button0_0;
            if ((Button2_0.Text == "") && (anyMove == 7))
                return Button2_0;
            if ((Button0_2.Text == "") && (anyMove == 8))
                return Button0_2;
            if ((Button2_2.Text == "") && (anyMove == 9))
                return Button2_2;

            return null;
        }

        // morderate AI
        private void moderateComputerMove()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = lookForWinOrBlock("O"); //look for win
            if (move == null)
            {
                move = lookForWinOrBlock("X"); //look for block
                if (move == null)
                {
                    move = lookForCorner();
                    if (move == null)
                    {
                        move = lookForOpenSpace();
                    }
                }
            }
            if (
            (Button0_0.IsEnabled == false) &&
            (Button1_0.IsEnabled == false) &&
            (Button2_0.IsEnabled == false) &&
            (Button0_1.IsEnabled == false) &&
            (Button1_1.IsEnabled == false) &&
            (Button2_1.IsEnabled == false) &&
            (Button0_2.IsEnabled == false) &&
            (Button1_2.IsEnabled == false) &&
            (Button2_2.IsEnabled == false))// end condition
            {

            }
            else
            {
                move.SendClicked();
            }
            System.Diagnostics.Debug.WriteLine("computer clicked: " + move);
        }

        private Button lookForWinOrBlock(string mark)
        {
            System.Diagnostics.Debug.WriteLine("computer checking win or block");
            //HORIZONTAL TESTS
            if ((Button0_0.Text == mark) && (Button1_0.Text == mark) && (Button2_0.Text == ""))
                return Button2_0;
            if ((Button1_0.Text == mark) && (Button2_0.Text == mark) && (Button0_0.Text == ""))
                return Button0_0;
            if ((Button0_0.Text == mark) && (Button2_0.Text == mark) && (Button1_0.Text == ""))
                return Button1_0;

            if ((Button0_1.Text == mark) && (Button1_1.Text == mark) && (Button2_1.Text == ""))
                return Button2_1;
            if ((Button1_1.Text == mark) && (Button2_1.Text == mark) && (Button0_1.Text == ""))
                return Button0_1;
            if ((Button0_1.Text == mark) && (Button2_1.Text == mark) && (Button1_1.Text == ""))
                return Button1_1;

            if ((Button0_2.Text == mark) && (Button1_2.Text == mark) && (Button2_2.Text == ""))
                return Button2_2;
            if ((Button1_2.Text == mark) && (Button2_2.Text == mark) && (Button0_2.Text == ""))
                return Button0_2;
            if ((Button0_2.Text == mark) && (Button2_2.Text == mark) && (Button1_2.Text == ""))
                return Button1_2;

            //VERTICAL TESTS
            if ((Button0_0.Text == mark) && (Button0_1.Text == mark) && (Button0_2.Text == ""))
                return Button0_2;
            if ((Button0_1.Text == mark) && (Button0_2.Text == mark) && (Button0_0.Text == ""))
                return Button0_0;
            if ((Button0_0.Text == mark) && (Button0_2.Text == mark) && (Button0_1.Text == ""))
                return Button0_1;

            if ((Button1_0.Text == mark) && (Button1_1.Text == mark) && (Button1_2.Text == ""))
                return Button1_2;
            if ((Button1_1.Text == mark) && (Button1_2.Text == mark) && (Button1_0.Text == ""))
                return Button1_0;
            if ((Button1_0.Text == mark) && (Button1_2.Text == mark) && (Button1_1.Text == ""))
                return Button1_1;

            if ((Button2_0.Text == mark) && (Button2_1.Text == mark) && (Button2_2.Text == ""))
                return Button2_2;
            if ((Button2_1.Text == mark) && (Button2_2.Text == mark) && (Button2_0.Text == ""))
                return Button2_0;
            if ((Button2_0.Text == mark) && (Button2_2.Text == mark) && (Button2_1.Text == ""))
                return Button2_1;

            //DIAGONAL TESTS
            if ((Button0_0.Text == mark) && (Button1_1.Text == mark) && (Button2_2.Text == ""))
                return Button2_2;
            if ((Button1_1.Text == mark) && (Button2_2.Text == mark) && (Button0_0.Text == ""))
                return Button0_0;
            if ((Button0_0.Text == mark) && (Button2_2.Text == mark) && (Button1_1.Text == ""))
                return Button1_1;

            if ((Button2_0.Text == mark) && (Button1_1.Text == mark) && (Button0_2.Text == ""))
                return Button0_2;
            if ((Button1_1.Text == mark) && (Button0_2.Text == mark) && (Button2_0.Text == ""))
                return Button2_0;
            if ((Button2_0.Text == mark) && (Button0_2.Text == mark) && (Button1_1.Text == ""))
                return Button1_1;

            return null;
        }

        // can be harder
        private Button lookForCorner()
        {
            System.Diagnostics.Debug.WriteLine("computer looking for corner");
            if (Button0_0.Text == "")
                return Button0_0;
            if (Button2_0.Text == "")
                return Button2_0;
            if (Button0_2.Text == "")
                return Button0_2;
            if (Button2_2.Text == "")
                return Button2_2;

            return null;
        }


        private Button lookForOpenSpace()
        {
            System.Diagnostics.Debug.WriteLine("computer looking for empty space");
            if (Button1_1.Text == "")
                return Button1_1;
            if (Button1_0.Text == "")
                return Button1_0;
            if (Button0_1.Text == "")
                return Button0_1;
            if (Button2_1.Text == "")
                return Button2_1;
            if (Button1_2.Text == "")
                return Button1_2;

            return null;
        }

        // hard AI
        private void hardComputerMove()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = lookForWinOrBlock("O"); //look for win
            if (move == null)
            {
                move = lookForWinOrBlock("X"); //look for block
                if (move == null)
                {
                    move = lookForCornerHard(); // look for opposite corners / any empty corner
                    if (move == null)
                    {
                        if ( // randomise looking for open space move
                            (Button0_0.IsEnabled == false) &&
                            (Button1_0.IsEnabled == false) &&
                            (Button2_0.IsEnabled == false) &&
                            (Button0_1.IsEnabled == false) &&
                            (Button1_1.IsEnabled == false) &&
                            (Button2_1.IsEnabled == false) &&
                            (Button0_2.IsEnabled == false) &&
                            (Button1_2.IsEnabled == false) &&
                            (Button2_2.IsEnabled == false))// end condition
                        {

                        }
                        else
                        {
                            while (move == null)
                            {
                                move = randomMove();
                            }
                        }
                    }
                }
            }
            if (
            (Button0_0.IsEnabled == false) &&
            (Button1_0.IsEnabled == false) &&
            (Button2_0.IsEnabled == false) &&
            (Button0_1.IsEnabled == false) &&
            (Button1_1.IsEnabled == false) &&
            (Button2_1.IsEnabled == false) &&
            (Button0_2.IsEnabled == false) &&
            (Button1_2.IsEnabled == false) &&
            (Button2_2.IsEnabled == false))// end condition
            {

            }
            else
            {
                move.SendClicked();
            }
            System.Diagnostics.Debug.WriteLine("computer clicked: " + move);
        }

        private Button lookForCornerHard()
        {
            System.Diagnostics.Debug.WriteLine("computer looking for corner");
            if (Button0_0.Text == "O")
            {
                if (Button2_2.Text == "")
                    return Button2_2;
            }

            if (Button2_0.Text == "O")
            {
                if (Button0_2.Text == "")
                    return Button0_2;
            }

            if (Button2_2.Text == "O")
            {
                if (Button0_0.Text == "")
                    return Button0_0;
            }

            if (Button0_2.Text == "O")
            {
                if (Button2_0.Text == "")
                    return Button2_0;
            }


            if (Button0_0.Text == "")
                return Button0_0;
            if (Button2_0.Text == "")
                return Button2_0;
            if (Button0_2.Text == "")
                return Button0_2;
            if (Button2_2.Text == "")
                return Button2_2;

            return null;
        }

        //scoring system
        double score1 = 0;
        double score2 = 0;

        private void resetScore()
        {
            score1 = 0;
            score2 = 0;
            playerOneScore.Text = string.Format("P1 Score: {0}", score1);
            playerTwoScore.Text = string.Format("P2 Score: {0}", score2);
        }
    }
}

