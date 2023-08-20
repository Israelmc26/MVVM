using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Model
{
    public class UnbeatStrategy : TreeTicTacToe 
    {

        public UnbeatStrategy()
        {
        
        }



        public static TreeTicTacToe[] getUnbeatStrategy(TreeTicTacToe[] tree, int curNode)
        {

            //Console.WriteLine("\nIn the method getUnbeatStrategy----------------------------------");

            double[] tabOfVal = new double[tree[curNode].children.Length];


            for (int i = 0; i < tree[curNode].children.Length; i++)
            {
                if (!Double.IsNaN(tree[tree[curNode].children[i]].value))
                {
                    tabOfVal[i] = tree[tree[curNode].children[i]].value;
                }
                else
                {
                    tree = getUnbeatStrategy(tree, tree[curNode].children[i]);
                    tabOfVal[i] = tree[tree[curNode].children[i]].value;
                }

            }//Check that all children of curNode have a value 

            /**
            Console.WriteLine("The player "+tree[curNode].player+" can play------------------");
            for(int i =0; i<tree[curNode].children.Length;i++)
            {
                
                Console.WriteLine(tree[tree[curNode].children[i]].lastPlay+" ");
                
            }
            */



            tree[curNode].ne = new double[tabOfVal.Length];
            for (int i = 0; i < tree[curNode].ne.Length; i++)
            {
                tree[curNode].ne[i] = -1;
            }//Initializing values of ne


            double[] valIdx = new double[2];


            int idx = 0;
            if (tree[curNode].player == 1)
            {
                valIdx = getMaxValIdx(tabOfVal, tree, curNode);

                tree[curNode].value = valIdx[0];
                tree[curNode].ne[0] = tree[tree[curNode].children[(int)valIdx[1]]].lastPlay;

                //Console.WriteLine("The children values are ------------------");

                for (int i = 0; i < tabOfVal.Length; i++)
                {   //Console.WriteLine(tabOfVal[i]+" ");

                    if (tabOfVal[i] >= tree[curNode].value)
                    {
                        tree[curNode].value = tabOfVal[i];
                        tree[curNode].ne[idx] = tree[tree[curNode].children[i]].lastPlay;
                        idx++;
                    }//	

                }//end of for loop to find max values	
            }//set the ne and the values for player 1

            else if (tree[curNode].player == 2)
            {
                valIdx = getMinValIdx(tabOfVal, tree, curNode);

                tree[curNode].value = valIdx[0];
                tree[curNode].ne[0] = tree[tree[curNode].children[(int)valIdx[1]]].lastPlay;


                //Console.WriteLine("The children values are ------------------");



                for (int i = 0; i < tabOfVal.Length; i++)
                { //Console.WriteLine(tabOfVal[i]+" ");

                    if (tabOfVal[i] <= tree[curNode].value)
                    {//Console.WriteLine("The value "+tabOfVal[i]+" is smaller than "+tree[curNode].value +" ------------------");
                        tree[curNode].value = tabOfVal[i];
                        //Console.WriteLine("The ne value is "+tabOfVal[i]+" is smaller than"+tree[curNode].value +"------------------");
                        tree[curNode].ne[idx] = tree[tree[curNode].children[i]].lastPlay;
                        idx++;
                    }//	

                }//end of for loop to find min values	
            }//set the ne and the values for player 2


            /**
            Console.WriteLine("The best second play are------------------");
            for(int i =0; i<tree[curNode].ne.Length;i++)
            {
                if (tree[curNode].ne[i]!=-1)
                {
                Console.WriteLine(tree[curNode].ne[i]+" ");
                }
            }
            */





            return tree;
        }// end of method

        public static double[] getMinValIdx(double[] tab, TreeTicTacToe[] tree, int curNode)
        {
            double[] minValIdx = { 0, 0 };

            tree[curNode].value = tab[0];
            tree[curNode].ne[0] = tree[tree[curNode].children[0]].lastPlay;


            int idx = 0;

            for (int i = 0; i < tab.Length; i++)
            { //Console.WriteLine(tab[i]+" ");

                if (tab[i] < tree[curNode].value)
                {
                    tree[curNode].value = tab[i];
                    tree[curNode].ne[idx] = tree[tree[curNode].children[i]].lastPlay;
                    minValIdx[1] = i;
                    idx++;
                }//	

            }//end of for loop to find max values	

            minValIdx[0] = tree[curNode].value;


            return minValIdx;
        }// end of method getMinValIdx





        public static double[] getMaxValIdx(double[] tab, TreeTicTacToe[] tree, int curNode)
        {
            double[] maxValIdx = { 0, 0 };

            tree[curNode].value = tab[0];
            tree[curNode].ne[0] = tree[tree[curNode].children[0]].lastPlay;



            int idx = 0;

            for (int i = 0; i < tab.Length; i++)
            { //Console.WriteLine(tab[i]+" ");

                if (tab[i] > tree[curNode].value)
                {
                    tree[curNode].value = tab[i];
                    tree[curNode].ne[idx] = tree[tree[curNode].children[i]].lastPlay;
                    maxValIdx[1] = i;
                    idx++;
                }//	

            }//end of for loop to find max values	

            maxValIdx[0] = tree[curNode].value;


            return maxValIdx;
        }// end of method getMinValIdx




    }
}
