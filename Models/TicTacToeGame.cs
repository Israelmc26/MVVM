using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Threading;
using System.Windows.Controls;

namespace TicTacToe.Model
{
    internal class TicTacToeGame
    {   //362880, 550000
        private TreeTicTacToe[] _tree;
        private int treeSize = 550000;

        private int[] tab = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private int _curNode = 1;
        private int _stage = 1;
        private int [] _tabState = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        private int _currentPlayer = 1;
        
        private int _nbrOfPlayer= 1;
        private Random _rand = new Random();
        
        


        

        public int CurrentPlayer
        {
            get { return _currentPlayer; }
            set { _currentPlayer = value; }
        }
        public int NbrOfPlayers
        {
            set { _nbrOfPlayer = value; }
        }


        public TicTacToeGame()
        {
            _tree = new TreeTicTacToe[treeSize];
            for (int i = 0; i < _tree.Length; i++)
            {
                _tree[i] = new TreeTicTacToe();

            }//



            Console.WriteLine("The tree calculation...");
            _tree = TreeTicTacToe.getTree(tab, _curNode, _stage, _tabState, _tree);
            Console.WriteLine("done !!!");


            _curNode = 1;

            Console.WriteLine("\nBackwards induction calculation...");
            _tree = UnbeatStrategy.getUnbeatStrategy(_tree, _curNode);
            Console.WriteLine("done !!!");

           

        }

        public int[] GetBestPlay()
        {
 
            int neVal = 0;
            int[] curPlay = new int[9];
            Console.WriteLine("The first player can play------------------");
            for (int i = 0; i < _tree[_curNode].children.Length; i++)
            {

                Console.Write(_tree[_tree[_curNode].children[i]].lastPlay + " ");

            }
            Console.WriteLine("\nThe best first play are------------------");
            for (int i = 0; i < _tree[_curNode].ne.Length; i++)
            {
                if (_tree[_curNode].ne[i] != -1)
                {
                    
                    curPlay[neVal] = (int) _tree[_curNode].ne[i];
                    neVal++;
                    Console.Write(_tree[_curNode].ne[i] + " ");
                }
            }
            Console.WriteLine("\nThe expected value is " + _tree[_curNode].value + "------------------");

            


            return curPlay;
        }

        public int SetCurrentPlayChoice
        {
            set 
            {
                for (int i = 0; i < _tree[_curNode].children.Length; i++)
                {
                    if (_tree[_tree[_curNode].children[i]].lastPlay == value)
                    { _curNode = _tree[_curNode].children[i]; }
                }
            }
            get { return _curNode; }
        }

    }
}
