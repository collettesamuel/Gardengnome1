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
                b.Text = "X";
                b.FontSize = 25;
            }
            else
            {
                b.Text = "O";
                b.FontSize = 25;
            }
            turn = !turn;
            b.IsEnabled = false;
            checkForWinner();
        }

        private void checkForWinner()
        {
            System.Diagnostics.Debug.WriteLine("CheckforWinner Working" + winner);
            //Horizontal checks
            if ((Button0_0.Text == Button1_0.Text) && (Button1_0.Text == Button2_0.Text) && (Button0_0.IsEnabled == false))
            { winner = true; }
            if ((Button0_1.Text == Button1_1.Text) && (Button1_1.Text == Button2_1.Text) && (Button0_1.IsEnabled == false))
            { winner = true; }
            if ((Button0_2.Text == Button1_2.Text) && (Button1_2.Text == Button2_2.Text) && (Button0_2.IsEnabled == false))
            { winner = true; }

            //Veritical Checks                                                                                 
            if ((Button0_0.Text == Button1_0.Text) && (Button1_0.Text == Button2_0.Text) && (Button0_0.IsEnabled == false))
            { winner = true; }
            if ((Button0_1.Text == Button1_1.Text) && (Button1_1.Text == Button2_1.Text) && (Button0_1.IsEnabled == false))
            { winner = true; }
            if ((Button0_2.Text == Button1_2.Text) && (Button1_2.Text == Button2_2.Text) && (Button0_2.IsEnabled == false))
            { winner = true; }

            //Diagonal Checks                                                                                   
            if ((Button0_0.Text == Button1_1.Text) && (Button1_1.Text == Button2_2.Text) && (Button0_0.IsEnabled == false))
            { winner = true; }
            if ((Button0_2.Text == Button1_1.Text) && (Button1_1.Text == Button2_0.Text) && (Button0_2.IsEnabled == false))
            { winner = true; }
            
            //Declaring winner
            if (winner == true)
            {
                string winnerName = "";
                if (turn)
                { winnerName = "2"; }
                else
                { winnerName = "1"; }

                DisplayAlert("Game Over","Player " + winnerName + " Wins!", "OK");
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

            turn = true;
            winner = false;
            System.Diagnostics.Debug.WriteLine("Check Variables turn: " + turn +" winner: " + winner);
        }
    }
}