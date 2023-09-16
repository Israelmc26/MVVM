using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicTacToe.Model;
using TicTacToe.ViewModel;

namespace TicTacToe.Views
{
    /// <summary>
    /// Logique d'interaction pour PlayTicTacToeGameView.xaml
    /// </summary>
    public partial class PlayTicTacToeGameView : UserControl
    {
        private PlayTicTacToeGameViewModel playTicTacToeGameViewModel;

       

        public PlayTicTacToeGameView()
        {
            
            TicTacToeGame game = new TicTacToeGame();
            playTicTacToeGameViewModel = new PlayTicTacToeGameViewModel(game);
            DataContext = playTicTacToeGameViewModel;
            InitializeComponent();
        }

        private void RadioButtonLevel_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;
            string selectedOption = selectedRadioButton.Content.ToString();
            //MessageBox.Show("Selected Option: " + selectedOption);
            playTicTacToeGameViewModel.PlayTicTacToeGameViewModelGameLevel = selectedOption;
        }

        private void RadioButtonPlayer_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;
            string selectedOption = selectedRadioButton.Content.ToString();
            //MessageBox.Show("Selected Option: " + selectedOption);

            if (selectedOption == "1 player")
            {
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelNbrOfPlayers = 1;
                Console.WriteLine(selectedOption + " is selected");
            }
            else if (selectedOption == "2 players")
            {
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelNbrOfPlayers = 2;
                Console.WriteLine(selectedOption + " is selected");
            }
            
        }

        private void ButtonStartGame_Click(object sender, RoutedEventArgs e)
        {
            

            if ((string) ButtonStartGame.Content == "New Game") 
            {

                ResetView();
                playTicTacToeGameViewModel.ResetPlayTicTacToeGameViewModel();
            }
            else
            {
                if ((bool)RadioButton1player.IsChecked)
                {
                    MessageBoxResult result = MessageBox.Show("Would you like to play against the computer (y/n)?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        playTicTacToeGameViewModel.StartSinglePlayerGame = true;
                        // User clicked Yes, perform the action
                        MessageBox.Show("You can start !!");
                    }
                    else
                    {
                        playTicTacToeGameViewModel.StartSinglePlayerGame = false;
                        // User clicked No, do nothing or handle accordingly
                        MessageBox.Show("Ok!");
                    }

                }
                else 
                {
                    MessageBox.Show("You can start !!!");
                }
                
                Button1.IsEnabled = true;
                Button2.IsEnabled = true;
                Button3.IsEnabled = true;
                Button4.IsEnabled = true;
                Button5.IsEnabled = true;
                Button6.IsEnabled = true;
                Button7.IsEnabled = true;
                Button8.IsEnabled = true;
                Button9.IsEnabled = true;


                ButtonStartGame.Content = "New Game";
            }

        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Help is pressed!!");
            int[] plays = playTicTacToeGameViewModel.GetbestPlay;
            string str = string.Join(", ", plays);
            MessageBox.Show("The best plays are: "+str);

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if ((playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1) )
            {
                // Change the content (text) of the button
                Button1.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                
            }
            else
            {
                // Change the content (text) of the button
                Button1.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 0;
            Button button = (Button)sender;
            button.IsEnabled = false;

        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button2.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button2.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 1;
            Button button = (Button)sender;
            button.IsEnabled = false;

        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button3.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button3.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 2;
            Button button = (Button)sender;
            button.IsEnabled = false;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button4.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
            }
            else
            {
                // Change the content (text) of the button
                Button4.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 3;
            Button button = (Button)sender;
            button.IsEnabled = false;

        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button5.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button5.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 4;
            Button button = (Button)sender;
            button.IsEnabled = false;

        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button6.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button6.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 5;
            Button button = (Button)sender;
            button.IsEnabled = false;
        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button7.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button7.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 6;
            Button button = (Button)sender;
            button.IsEnabled = false;
        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button8.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button8.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 7;
            Button button = (Button)sender;
            button.IsEnabled = false;
        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                Button9.Content = "X";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                Button9.Content = "O";
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            playTicTacToeGameViewModel.PlayerChoice = 8;
            Button button = (Button)sender;
            button.IsEnabled = false;

        }

        private void ResetView()
        {
            Button1.Content = "";
            Button1.IsEnabled=false;
            
            Button2.Content = "";
            Button2.IsEnabled = false;
            
            Button3.Content = "";
            Button3.IsEnabled = false;
            
            Button4.Content = "";
            Button4.IsEnabled = false;

            Button5.Content = "";
            Button5.IsEnabled = false;

            Button6.Content = "";
            Button6.IsEnabled = false;

            Button7.Content = "";
            Button7.IsEnabled = false;

            Button8.Content = "";
            Button8.IsEnabled = false;

            Button9.Content = "";
            Button9.IsEnabled = false;


            ButtonStartGame.Content = "Start Game";
            RadioButton1player.IsChecked = true;
            RadioButtonEasy.IsChecked = true;
            return;
        }

    }
}
