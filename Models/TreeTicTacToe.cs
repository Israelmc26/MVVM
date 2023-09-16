using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class TreeTicTacToe
    {
        public int player;
        public int parent;
        public int[] children;
        public double[] ne;
        public double value;
        public int[] gameState;
        public int stageNode;
        public int lastPlay;
        static int lastNode = 1;
        static int[] idxWin = { 0, 0, 0 };


        public TreeTicTacToe()
        {
            player = 0;
            children = new int[0];
            ne = new double[1];
            value = 0;
            parent = 0;
            gameState = new int[0];
            lastPlay = 0;
            stageNode = 0;
            lastNode = 1;

        }//end of constructor without argument

        public static TreeTicTacToe[] getTree(int[] availPlay, int curNode, int stage, int[] tabState, TreeTicTacToe[] tree)
        {

            tree[curNode].ne[0] = Double.NaN;
            //Console.WriteLine("\nIn the method TreeTicTacToe----------------------------------");
            //Console.WriteLine("With node "+curNode+"--------------------------");

            tree[curNode].gameState = new int[tabState.Length];


            //Console.WriteLine("With the gameState "+curNode+"--------------------------");

            for (int j = 0; j < tabState.Length; j++)
            {
                tree[curNode].gameState[j] = tabState[j];
                //Console.WriteLine(tree[curNode].gameState[j]+ " ");   

            }//Fill the current state of the game 
             //Console.WriteLine("--------------------------");

            tree[curNode].stageNode = stage;
            //Console.WriteLine("At Stage "+tree[curNode].stageNode+"--------------------------");



            if (stage % 2 == 1)
            {
                tree[curNode].player = 1;
            }
            else
            {
                tree[curNode].player = 2;
            }// the player is recognized
             //Console.WriteLine("The current player is "+tree[curNode].player+"----------------------------------");


            //Check if the game is finished
            int gameVal = getWinner(tree[curNode].gameState, tree[tree[curNode].parent].player, stage - 1);
            
            if (gameVal == 0)
            { //Console.WriteLine("The game is DRAW---------------------------------");
                tree[curNode].value = 0;

            }
            else if (gameVal == 1)
            {//Console.WriteLine("The player 1 Won---------------------------------");
                tree[curNode].value = 10;

            }
            else if (gameVal == 2)
            {//Console.WriteLine("The player 2 Won---------------------------------");
                tree[curNode].value = -10;

            }
            else
            {
                tree[curNode].value = Double.NaN;


                //Console.WriteLine("The game is not finished---------------------------------");


                tree[curNode].children = new int[availPlay.Length];

                //Console.WriteLine("The Children are---------------------------------");

                for (int i = 0; i < availPlay.Length; i++)
                {
                    tree[curNode].children[i] = lastNode + i + 1;
                    tree[lastNode + i + 1].parent = curNode;
                    //Console.WriteLine("The child "+ tree[curNode].children[i]+ " has the parent "+tree[lastNode+i+1].parent+" -------------------");   

                }//fill the nodes of the children



                if (availPlay.Length != 0)
                {
                    lastNode = tree[curNode].children[availPlay.Length - 1]; // last node implemented
                                                                             //Console.WriteLine("The last node used is "+tree[curNode].children[availPlay.Length-1]+" ----------------------------------");


                    int[] tbChild = new int[availPlay.Length - 1];

                    //Console.WriteLine("The node "+ curNode+" can still play at the places:---------------");   
                    /**
                    for(int i : availPlay)
                    {
                        Console.WriteLine(i+ " ");//-----------------------------------------   
                    }
                    Console.WriteLine("--------------------------");
                    */

                    int[] tabStateNew = new int[tabState.Length];
                    int child = 0;
                    foreach (int i in availPlay)
                    {  //Console.WriteLine("When the node "+ curNode+" plays the place: "+ i+ " ---------------------");   

                        int idx = 0;

                        for (int k = 0; k < tabState.Length; k++)
                        {
                            tabStateNew[k] = tree[curNode].gameState[k]; // reset the state for each child

                        }

                        /**
                        Console.WriteLine("The table of state of node "+ curNode+" is :---------------------");
                        for(int k =0;k<tabState.Length;k++)
                         {
                            Console.WriteLine(tree[curNode].gameState[k]+" ");
                         }
                        Console.WriteLine("--------------------------");
                        
                        if(curNode!=1)
                        {
                            
                            Console.WriteLine("The table of state of node "+ tree[curNode].parent+" is :---------------------");
                            for(int k =0;k<tabState.Length;k++)
                             {
                                Console.WriteLine(tree[tree[curNode].parent].gameState[k]+" ");
                             }
                            Console.WriteLine("--------------------------");
                        
                            
                            
                        }// dont see for node 1
                            */

                        if (availPlay.Length == 1)
                        {   //Console.WriteLine("The last play is made! ---------------------");
                            tree[tree[curNode].children[child]].gameState = new int[tabState.Length];
                            tabState[availPlay[0]] = tree[curNode].player;
                            tree[tree[curNode].children[child]].lastPlay = availPlay[0];
                            //Console.WriteLine("The game state of child "+ tree[curNode].children[child] +" is :---------------------");

                            for (int k = 0; k < tabState.Length; k++)
                            {
                                tree[tree[curNode].children[child]].gameState[k] = tabState[k];
                                //Console.WriteLine(tree[tree[curNode].children[child]].gameState[k]+" ");

                            }//Fill the current state of the game  
                             //Console.WriteLine("--------------------------");

                        }// end of condition for one length child
                        else
                        {
                            for (int j = 0; j < availPlay.Length; j++)
                            {
                                if (i == availPlay[j])
                                {
                                    tree[tree[curNode].children[child]].lastPlay = availPlay[j];
                                }//setting the play made by the parent node

                                if (i != availPlay[j])
                                {
                                    tbChild[idx] = availPlay[j];
                                    tabStateNew[i] = tree[curNode].player;

                                    //Console.WriteLine("The child  "+ (tree[curNode].children[child])+ " can play "+availPlay[j]+" ----------------");
                                    tree[tree[curNode].children[child]].gameState = new int[tabState.Length];

                                    //Console.WriteLine("The game state of child "+ tree[curNode].children[child] +" is :---------------------");

                                    for (int k = 0; k < tabState.Length; k++)
                                    {
                                        tree[tree[curNode].children[child]].gameState[k] = tabStateNew[k];
                                        //Console.WriteLine(tree[tree[curNode].children[child]].gameState[k]+" ");

                                    }//Fill the current state of the next node  
                                     //Console.WriteLine("--------------------------");




                                    idx++;
                                }// end 



                            }// ensure that the children play in a different place

                        }//case where there is mode than one child



                        //Console.WriteLine("Call of the function getTree --------------------------");

                        //tree[tree[curNode].children[child]].gameState

                        tree = getTree(tbChild, tree[curNode].children[child], stage + 1, tree[tree[curNode].children[child]].gameState, tree);
                        child++;
                    }//get the tree for the children

                }//The game is finished

            }// end of else 




            //Console.WriteLine("Node "+ curNode+" is finished!!");



            return tree;


        }//end of method getTree


        private static int getWinner(int []tab, int player, int compt)
        {
            bool winGame = false;

            //Console.WriteLine("\nIn the method getWinner--------------");
            //Console.WriteLine("With the player "+player+" at stage"+compt+"--------------");

            if (compt >= 5)
            {
                /**
                Console.WriteLine("The gameState is--------------");

                for(int j =0;j<tab.length;j++)
                 {
                    Console.WriteLine(tab[j]+ " ");   

                 }//Show the current state of the game 
                Console.WriteLine("--------------");
                */



                if (tab[0] == player && tab[1] == player && tab[2] == player)
                {

                    winGame = true;
                    idxWin[0] = 0;
                    idxWin[1] = 1;
                    idxWin[2] = 2;
                }
                else if (tab[3] == player && tab[4] == player && tab[5] == player)
                {
                    winGame = true;
                    idxWin[0] = 3;
                    idxWin[1] = 4;
                    idxWin[2] = 5;
                }
                else if (tab[6] == player && tab[7] == player && tab[8] == player)
                {
                    winGame = true;
                    idxWin[0] = 6;
                    idxWin[1] = 7;
                    idxWin[2] = 8;

                }
                else if (tab[0] == player && tab[3] == player && tab[6] == player)
                {
                    winGame = true;
                    idxWin[0] = 0;
                    idxWin[1] = 3;
                    idxWin[2] = 6;
                }
                else if (tab[1] == player && tab[4] == player && tab[7] == player)
                {
                    winGame = true;
                    idxWin[0] = 1;
                    idxWin[1] = 4;
                    idxWin[2] = 7;
                }
                else if (tab[2] == player && tab[5] == player && tab[8] == player)
                {
                    winGame = true;
                    idxWin[0] = 2;
                    idxWin[1] = 5;
                    idxWin[2] = 8;
                }
                else if (tab[0] == player && tab[4] == player && tab[8] == player)
                {
                    winGame = true;
                    idxWin[0] = 0;
                    idxWin[1] = 4;
                    idxWin[2] = 8;
                }
                else if (tab[2] == player && tab[4] == player && tab[6] == player)
                {
                    winGame = true;
                    idxWin[0] = 2;
                    idxWin[1] = 4;
                    idxWin[2] = 6;
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

    }
}
