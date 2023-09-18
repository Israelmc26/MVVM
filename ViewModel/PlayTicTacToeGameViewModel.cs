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
        private int[] _curGame = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private GameLevel _gameLevel = GameLevel.Easy;
        private Random _random = new Random();
        public enum GameLevel { Easy, Normal, Unbeatable };
        public string strPlayer1 = "X";
        public string strPlayer2 = "O";

        
        private int[] _idxWin = { 0, 0, 0 };


        private string _button1Content;
        private string _button2Content;
        private string _button3Content;
        private string _button4Content;
        private string _button5Content;
        private string _button6Content;
        private string _button7Content;
        private string _button8Content;
        private string _button9Content;

        private bool _button1IsEnabled;
        private bool _button2IsEnabled;
        private bool _button3IsEnabled;
        private bool _button4IsEnabled;
        private bool _button5IsEnabled;
        private bool _button6IsEnabled;
        private bool _button7IsEnabled;
        private bool _button8IsEnabled;
        private bool _button9IsEnabled;


        private int[] _availablePlay
        {
            get
            {
                List<int> list = new List<int>();
                for (int i = 0; i < _maxCoupGame; i++)
                {
                    if (_curGame[i] == -1)
                    {
                        list.Add(i);
                    }
                }
                return list.ToArray();
            }
        }


        public PlayTicTacToeGameViewModel(TicTacToeGame tictactoeGame)
        {
            _tictactoeGame = tictactoeGame;
        }

        public void ResetPlayTicTacToeGameViewModel()
        {
            
            _tictactoeGame = new TicTacToeGame();
            _startSinglePlayerGame = true;
            _curGame = new int[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            _gameLevel = GameLevel.Easy;
            _idxWin = new int[3] { 0, 0, 0 };
            
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

        public string Button1Content
        {
            get { return _button1Content; }
            set
            {
                if (_button1Content != value)
                {
                    _button1Content = value;
                    OnPropertyChanged("Button1Content");
                }

                PlayerChoice = 0;
            }
        }
        public bool Button1IsEnabled
        {
            get { return _button1IsEnabled; }
            set
            {
                if (_button1IsEnabled != value)
                {
                    _button1IsEnabled = value;
                    OnPropertyChanged("Button1IsEnabled");
                }

            }
        }

        public string Button2Content
        {
            get { return _button2Content; }
            set
            {
                if (_button2Content != value)
                {
                    _button2Content = value;
                    OnPropertyChanged("Button2Content");
                }

                PlayerChoice = 1;
            }
        }

        public bool Button2IsEnabled
        {
            get { return _button2IsEnabled; }
            set
            {
                if (_button2IsEnabled != value)
                {
                    _button2IsEnabled = value;
                    OnPropertyChanged("Button2IsEnabled");
                }

            }
        }

        public string Button3Content
        {
            get { return _button3Content; }
            set
            {
                if (_button3Content != value)
                {
                    _button3Content = value;
                    OnPropertyChanged("Button3Content");
                }

                PlayerChoice = 2;
            }
        }
        public bool Button3IsEnabled
        {
            get { return _button3IsEnabled; }
            set
            {
                if (_button3IsEnabled != value)
                {
                    _button3IsEnabled = value;
                    OnPropertyChanged("Button3IsEnabled");
                }

            }
        }

        public string Button4Content
        {
            get { return _button4Content; }
            set
            {
                if (_button4Content != value)
                {
                    _button4Content = value;
                    OnPropertyChanged("Button4Content");
                }

                PlayerChoice = 3;
            }
        }

        public bool Button4IsEnabled
        {
            get { return _button4IsEnabled; }
            set
            {
                if (_button4IsEnabled != value)
                {
                    _button4IsEnabled = value;
                    OnPropertyChanged("Button4IsEnabled");
                }

            }
        }

        public string Button5Content
        {
            get { return _button5Content; }
            set
            {
                if (_button5Content != value)
                {
                    _button5Content = value;
                    OnPropertyChanged("Button5Content");
                }

                PlayerChoice = 4;
            }
        }

        public bool Button5IsEnabled
        {
            get { return _button5IsEnabled; }
            set
            {
                if (_button5IsEnabled != value)
                {
                    _button5IsEnabled = value;
                    OnPropertyChanged("Button5IsEnabled");
                }

            }
        }
        public string Button6Content
        {
            get { return _button6Content; }
            set
            {
                if (_button6Content != value)
                {
                    _button6Content = value;
                    OnPropertyChanged("Button6Content");
                }

                PlayerChoice = 5;
            }
        }
        public bool Button6IsEnabled
        {
            get { return _button6IsEnabled; }
            set
            {
                if (_button6IsEnabled != value)
                {
                    _button6IsEnabled = value;
                    OnPropertyChanged("Button6IsEnabled");
                }

            }
        }
        public string Button7Content
        {
            get { return _button7Content; }
            set
            {
                if (_button7Content != value)
                {
                    _button7Content = value;
                    OnPropertyChanged("Button7Content");
                }

                PlayerChoice = 6;
            }
        }

        public bool Button7IsEnabled
        {
            get { return _button7IsEnabled; }
            set
            {
                if (_button7IsEnabled != value)
                {
                    _button7IsEnabled = value;
                    OnPropertyChanged("Button7IsEnabled");
                }

            }
        }
        public string Button8Content
        {
            get { return _button8Content; }
            set
            {
                if (_button8Content != value)
                {
                    _button8Content = value;
                    OnPropertyChanged("Button8Content");
                }

                PlayerChoice = 7;
            }
        }
        public bool Button8IsEnabled
        {
            get { return _button8IsEnabled; }
            set
            {
                if (_button8IsEnabled != value)
                {
                    _button8IsEnabled = value;
                    OnPropertyChanged("Button8IsEnabled");
                }

            }
        }

        public string Button9Content
        {
            get { return _button9Content; }
            set
            {
                if (_button9Content != value)
                {
                    _button9Content = value;
                    OnPropertyChanged("Button9Content");
                }

                PlayerChoice = 8;
            }
        }

        public bool Button9IsEnabled
        {
            get { return _button9IsEnabled; }
            set
            {
                if (_button9IsEnabled != value)
                {
                    _button9IsEnabled = value;
                    OnPropertyChanged("Button9IsEnabled");
                }

            }
        }


        public bool StartSinglePlayerGame
        {
            set { _startSinglePlayerGame = value; }
            get { return _startSinglePlayerGame; }
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
                Console.WriteLine("GameLevel: " + value);
            }
            
        }


        public void ComputerPlay()
        {
            int[] bestPlay = GetbestPlay;
            int[] availablePlay = _availablePlay;
            int computerPlay = 0;
            switch (_gameLevel)
            {
                case GameLevel.Easy:
                    var randomIndex = _random.Next(0, availablePlay.Length);
                    computerPlay = availablePlay[randomIndex];
                    break;

                case GameLevel.Normal:
                    if (_random.Next(10) <= 5)
                    {
                        computerPlay = availablePlay[0];
                    }
                    else
                    {
                        computerPlay = bestPlay[0];
                    }

                    break;

                case GameLevel.Unbeatable:
                    randomIndex = _random.Next(0, bestPlay.Length);
                    computerPlay = bestPlay[randomIndex];
                    break;

                default:
                    break;

            }

            PlayerChoice = computerPlay;

            switch (computerPlay + 1)
            {
                case 1:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button1Content = strPlayer1;
                    else
                        Button1Content = strPlayer2;

                    Button1IsEnabled = false;

                    break;
                case 2:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button2Content = strPlayer1;
                    else
                        Button2Content = strPlayer2;

                    Button2IsEnabled = false;

                    break;
                case 3:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button3Content = strPlayer1;
                    else
                        Button3Content = strPlayer2;

                    Button3IsEnabled = false;

                    break;
                case 4:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button4Content = strPlayer1;
                    else
                        Button4Content = strPlayer2;

                    Button4IsEnabled = false;
                    break;
                case 5:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button5Content = strPlayer1;
                    else
                        Button5Content = strPlayer2;

                    Button5IsEnabled = false;
                    break;
                case 6:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button6Content = strPlayer1;
                    else
                        Button6Content = strPlayer2;

                    Button6IsEnabled = false;
                    break;
                case 7:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button7Content = strPlayer1;
                    else
                        Button7Content = strPlayer2;
                    Button7IsEnabled = false;

                    break;
                case 8:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button8Content = strPlayer1;
                    else
                        Button8Content = strPlayer2;
                    
                    Button8IsEnabled = false;

                    break;
                case 9:
                    if (_tictactoeGame.CurrentPlayer == 1)
                        Button9Content = strPlayer1;
                    else
                        Button9Content = strPlayer2;

                    Button9IsEnabled = false;
                    break;
                default : break;
                
            }

         


        }


        public int GetWinner()
        {
            bool winGame = false;
            int player = _tictactoeGame.CurrentPlayer;
            int compt = _maxCoupGame - _availablePlay.Length;
            

            if (_curGame[0] == player && _curGame[1] == player && _curGame[2] == player)
            {

                winGame = true;
                _idxWin[0] = 0;
                _idxWin[1] = 1;
                _idxWin[2] = 2;
            }
            else if (_curGame[3] == player && _curGame[4] == player && _curGame[5] == player)
            {
                winGame = true;
                _idxWin[0] = 3;
                _idxWin[1] = 4;
                _idxWin[2] = 5;
            }
            else if (_curGame[6] == player && _curGame[7] == player && _curGame[8] == player)
            {
                winGame = true;
                _idxWin[0] = 6;
                _idxWin[1] = 7;
                _idxWin[2] = 8;

            }
            else if (_curGame[0] == player && _curGame[3] == player && _curGame[6] == player)
            {
                winGame = true;
                _idxWin[0] = 0;
                _idxWin[1] = 3;
                _idxWin[2] = 6;
            }
            else if (_curGame[1] == player && _curGame[4] == player && _curGame[7] == player)
            {
                winGame = true;
                _idxWin[0] = 1;
                _idxWin[1] = 4;
                _idxWin[2] = 7;
            }
            else if (_curGame[2] == player && _curGame[5] == player && _curGame[8] == player)
            {
                winGame = true;
                _idxWin[0] = 2;
                _idxWin[1] = 5;
                _idxWin[2] = 8;
            }
            else if (_curGame[0] == player && _curGame[4] == player && _curGame[8] == player)
            {
                winGame = true;
                _idxWin[0] = 0;
                _idxWin[1] = 4;
                _idxWin[2] = 8;
            }
            else if (_curGame[2] == player && _curGame[4] == player && _curGame[6] == player)
            {
                winGame = true;
                _idxWin[0] = 2;
                _idxWin[1] = 4;
                _idxWin[2] = 6;
            }



            
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
            get
            {
                return _tictactoeGame.GetBestPlay();
            }
            
        }

        public int PlayerChoice
        { set 
            { 
                _tictactoeGame.SetCurrentPlayChoice = value;
                _curGame[value] = _tictactoeGame.CurrentPlayer;
            }
        }

        


    }
}
