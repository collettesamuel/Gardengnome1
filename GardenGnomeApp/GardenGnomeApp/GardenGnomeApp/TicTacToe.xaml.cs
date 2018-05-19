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
            System.Diagnostics.Debug.WriteLine("Finished Checking" + winner);
            System.Diagnostics.Debug.WriteLine(Button0_0.Text + Button1_0.Text + Button2_0.Text);
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
                { winnerName = "2"; }
                else
                { winnerName = "1"; }

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
    }
}

/*
 notes:
 click too fast wont update winner
 */