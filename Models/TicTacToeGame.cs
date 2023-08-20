using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    internal class TicTacToeGame
    {   //362880, 550000
        public TreeTicTacToe[] _tree;
        private int treeSize = 550000;

        int[] tab = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        int curNode = 1;
        int stage = 1;
        int[] tabState = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        enum strategy {Easy, Normal, Unbeatable };

        public TicTacToeGame()
        {
            _tree = new TreeTicTacToe[treeSize];
            for (int i = 0; i < _tree.Length; i++)
            {
                _tree[i] = new TreeTicTacToe();

            }//



            Console.WriteLine("The tree calculation...");
            _tree = TreeTicTacToe.getTree(tab, curNode, stage, tabState, _tree);
            Console.WriteLine("done !!!");


            curNode = 1;

            Console.WriteLine("\nBackwards induction calculation...");
            _tree = UnbeatStrategy.getUnbeatStrategy(_tree, curNode);
            Console.WriteLine("done !!!");



        }
        



		
    }
}
