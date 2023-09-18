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
        private int _winner;
       

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
        private void CheckedRadioButtonLevel()
        {
            foreach (var control in RadioButtonGameLevelSelection.Children)
            {
                if (control is RadioButton radioButton && radioButton.IsChecked == true)
                {
                    // This control is a radio button and is checked
                    string content = radioButton.Content.ToString();
                    
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelGameLevel = content;
                }
            }
        }


        private void RadioButtonPlayer_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadioButton = (RadioButton)sender;
            string selectedOption = selectedRadioButton.Content.ToString();
            //MessageBox.Show("Selected Option: " + selectedOption);

            if (selectedOption == "1 player")
            {
                Console.WriteLine(selectedOption + " is selected");
            }
            else if (selectedOption == "2 players")
            {
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
                    MessageBoxResult result = MessageBox.Show("Would you like to start (y/n)?", "Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        playTicTacToeGameViewModel.StartSinglePlayerGame = true;
                        // User clicked Yes, perform the action
                        MessageBox.Show("You can start !");
                    }
                    else
                    {
                        playTicTacToeGameViewModel.StartSinglePlayerGame = false;
                        // User clicked No, do nothing or handle accordingly
                        MessageBox.Show("The computer will start!");

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
                RadioButtonNbrOfPlayerSelection.IsEnabled = false;
                RadioButtonGameLevelSelection.IsEnabled = false;
                CheckedRadioButtonLevel();
                ButtonStartGame.Content = "New Game";


                if (!playTicTacToeGameViewModel.StartSinglePlayerGame && (bool)RadioButton1player.IsChecked)
                {
                    playTicTacToeGameViewModel.ComputerPlay();
                    CheckWinner();

                    if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                        playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                    else
                        playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
                }
            }

        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Help is pressed!!");
            int[] plays = playTicTacToeGameViewModel.GetbestPlay;
            for (int i = 0; i < plays.Length; i++)
            {
                plays[i] += 1;
            }
            string str = string.Join(", ", plays);

            if(_winner!=-1)
                MessageBox.Show("The game is finished.");
            else
                MessageBox.Show("The best plays are: " + str);

        }


        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if ((playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1) )
            {
                // Change the content (text) of the button

                playTicTacToeGameViewModel.Button1Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                
            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button1Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
            Button1.IsEnabled = false;
            

            if ((bool)RadioButton1player.IsChecked && (_winner==-1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button2Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button2Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button2.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button3Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button3Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button3.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }


        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button4Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button4Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button4.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }


        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button5Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button5Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button5.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }


        }
        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button6Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button6Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button6.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();
                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }


        }
        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button7Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button7Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button7.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

        }
        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button8Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;

            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button8Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button8.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();

                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

        }
        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button9Content = playTicTacToeGameViewModel.strPlayer1;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                
            }
            else
            {
                // Change the content (text) of the button
                playTicTacToeGameViewModel.Button9Content = playTicTacToeGameViewModel.strPlayer2;
                CheckWinner();
                playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;
            }

            Button9.IsEnabled = false;

            if ((bool)RadioButton1player.IsChecked && (_winner == -1))
            {
                playTicTacToeGameViewModel.ComputerPlay();
                CheckWinner();
                if (playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer == 1)
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 2;
                else
                    playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer = 1;

            }

            


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
            RadioButtonNbrOfPlayerSelection.IsEnabled = true;
            RadioButtonGameLevelSelection.IsEnabled = true;
           
            //RadioButton1player.IsChecked = true;
            //RadioButtonEasy.IsChecked = true;
            return;
        }

        private void CheckWinner()
        {
            _winner = playTicTacToeGameViewModel.GetWinner();

            if (_winner == 0)
            {
                MessageBox.Show("The game is a draw !!\n You can start a new game by pressing -> New Game .");
            }
            else if (_winner!=-1)
            {

                if (!playTicTacToeGameViewModel.StartSinglePlayerGame && (bool)RadioButton1player.IsChecked && (_winner ==1) ||
                    playTicTacToeGameViewModel.StartSinglePlayerGame && (bool)RadioButton1player.IsChecked && (_winner == 2))
                {
                    MessageBox.Show("You Lost against the computer !!! \n You can start a new game by pressing -> New Game .");
                }
                else if (playTicTacToeGameViewModel.StartSinglePlayerGame && (bool)RadioButton1player.IsChecked && (_winner == 1)||
                        !playTicTacToeGameViewModel.StartSinglePlayerGame && (bool)RadioButton1player.IsChecked && (_winner == 2))
                {
                    MessageBox.Show("You Won against the computer !!! \n You can start a new game by pressing -> New Game .");
                }else
                {
                    MessageBox.Show($@"The Winner is Player {playTicTacToeGameViewModel.PlayTicTacToeGameViewModelCurrentPlayer} !!!You can start a new game by pressing -> New Game .");
                }

                //Disabling all buttons
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;

            }

           
        }

    }
}
