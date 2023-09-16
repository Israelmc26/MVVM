using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Model;
using static TicTacToe.ViewModel.PlayTicTacToeGameViewModel;

namespace TicTacToe.ViewModel
{
    internal class PlayTicTacToeGameViewModel : ViewModelBase
    {
        private TicTacToeGame _tictactoeGame;
        
        private bool _startSinglePlayerGame = true;
        //char labelChar;
       
        private int _maxCoupGame = 9;
        private int _compt = 0, _curPlay = 0, _curNode = 0;
        private int[] _curGame = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private String compPlay;
        private GameLevel _gameLevel = GameLevel.Easy;

        public enum GameLevel { Easy, Normal, Unbeatable };
        


        private int _valGame = -1;
        
        private int[] _idxWin = { 0, 0, 0 };


        public PlayTicTacToeGameViewModel(TicTacToeGame tictactoeGame)
        {
            _tictactoeGame = tictactoeGame;
        }

        public void ResetPlayTicTacToeGameViewModel()
        {
            
            _tictactoeGame = new TicTacToeGame();

        }

        public int PlayTicTacToeGameViewModelCurrentPlayer
        {
            get { return _tictactoeGame.CurrentPlayer; }
            set {
                if (_tictactoeGame.CurrentPlayer != value)
                {
                    _tictactoeGame.CurrentPlayer = value;
                    OnPropertyChanged("PlayTicTacToeGameViewModelCurrentPlayer");
                }
            }
        }

        public bool StartSinglePlayerGame
        {
            set { _startSinglePlayerGame = value; }
        }

        public string PlayTicTacToeGameViewModelGameLevel
        {   set 
            {
                switch (value)
                { 
                    case "Easy":
                        _gameLevel = GameLevel.Easy;
                        break;

                    case "Normal":
                        _gameLevel = GameLevel.Normal;
                        break;

                    case "Unbeatable":
                        _gameLevel = GameLevel.Unbeatable;
                        break;
                    
                    default:
                        break;


                } 
                 
            }
            
        }

        public int PlayTicTacToeGameViewModelNbrOfPlayers
        {
            set
            {
                _tictactoeGame.NbrOfPlayers = value;
            }
        }


        public GameLevel SetGameLevel
        {
            set
            {
                _gameLevel = value;
            }
        }

        public int GetWinner(int[] tab, int player, int compt)
        {
            bool winGame = false;

            //System.out.println("\nIn the method getWinner--------------");
            //System.out.println("With the player "+player+" at stage"+compt+"--------------");

            if (compt >= 5)
            {
                /**
                System.out.println("The gameState is--------------");

                for(int j =0;j<tab.length;j++)
                 {
                    System.out.print(tab[j]+ " ");   

                 }//Show the current state of the game 
                System.out.println("--------------");
                */



                if (tab[0] == player && tab[1] == player && tab[2] == player)
                {

                    winGame = true;
                    _idxWin[0] = 0;
                    _idxWin[1] = 1;
                    _idxWin[2] = 2;
                }
                else if (tab[3] == player && tab[4] == player && tab[5] == player)
                {
                    winGame = true;
                    _idxWin[0] = 3;
                    _idxWin[1] = 4;
                    _idxWin[2] = 5;
                }
                else if (tab[6] == player && tab[7] == player && tab[8] == player)
                {
                    winGame = true;
                    _idxWin[0] = 6;
                    _idxWin[1] = 7;
                    _idxWin[2] = 8;

                }
                else if (tab[0] == player && tab[3] == player && tab[6] == player)
                {
                    winGame = true;
                    _idxWin[0] = 0;
                    _idxWin[1] = 3;
                    _idxWin[2] = 6;
                }
                else if (tab[1] == player && tab[4] == player && tab[7] == player)
                {
                    winGame = true;
                    _idxWin[0] = 1;
                    _idxWin[1] = 4;
                    _idxWin[2] = 7;
                }
                else if (tab[2] == player && tab[5] == player && tab[8] == player)
                {
                    winGame = true;
                    _idxWin[0] = 2;
                    _idxWin[1] = 5;
                    _idxWin[2] = 8;
                }
                else if (tab[0] == player && tab[4] == player && tab[8] == player)
                {
                    winGame = true;
                    _idxWin[0] = 0;
                    _idxWin[1] = 4;
                    _idxWin[2] = 8;
                }
                else if (tab[2] == player && tab[4] == player && tab[6] == player)
                {
                    winGame = true;
                    _idxWin[0] = 2;
                    _idxWin[1] = 4;
                    _idxWin[2] = 6;
                }



            }//end of if check for winner
            if (compt == 9 && !winGame)
            {

                player = 0;
            }
            else if (winGame)
            {

            }
            else
            {
                player = -1;
            }

            return player;
        }//end of method getWinner

        public int[] GetbestPlay
        {
            get{ return _tictactoeGame.GetBestPlay(); }
            
        }
        public int PlayerChoice
        { set { _tictactoeGame.SetCurrentPlayChoice = value; }
          get { return _tictactoeGame.SetCurrentPlayChoice; }
        }

        


    }
}
