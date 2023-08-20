using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Model;

namespace TicTacToe
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            TicTacToeGame ticTacToeGame = new TicTacToeGame();
            base.OnStartup(e);
        }
      
    }
}
